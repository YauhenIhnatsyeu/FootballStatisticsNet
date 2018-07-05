using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace FS.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FunClubsController : Controller
    {
        private readonly IFunClubsRepository funClubsRepository;
        private readonly IMapper mapper;
        private readonly ITeamsRepository teamsRepository;
        private readonly IUsersFunClubsRepository usersFunClubsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FunClubsController(
            IFunClubsRepository funClubsRepository,
            IMapper mapper,
            ITeamsRepository teamsRepository,
            IUsersFunClubsRepository usersFunClubsRepository,
            IUsersRepository<User> usersRepository)
        {
            this.funClubsRepository = funClubsRepository;
            this.mapper = mapper;
            this.teamsRepository = teamsRepository;
            this.usersFunClubsRepository = usersFunClubsRepository;
            this.usersRepository = usersRepository;
        }

        /// <summary>
        /// Gets all funclubs with users that are accepted into them
        /// </summary>
        [AllowAnonymous]
        [Route("/api/funclubs/get")]
        public IActionResult Get()
        {
            IEnumerable<FunClub> funClubs = funClubsRepository.Get()
                .Select(funClub => funClub.FilterUsersFunClub(
                    ufc => ufc.MemberStatus == MemberStatus.In));

            return Ok(
                mapper.Map<IEnumerable<FunClub>, IEnumerable<FunClubToClientDTO>>(funClubs)
            );
        }

        /// <summary>
        /// Gets all funclubs, which current user created, with users that want to join them
        /// </summary>
        [Route("/api/funclubs/get-unaccepted")]
        public IActionResult GetUnaccepted()
        {
            User loggedInUser = usersRepository.GetLoggedInUser();

            IEnumerable<FunClub> funClubs = funClubsRepository.Get()
                .Where(funClub => funClub.UsersFunClub.Any(
                    ufc => ufc.User == loggedInUser && ufc.UserIsCreator == true))
                .Select(funClub => funClub.FilterUsersFunClub(
                    ufc => ufc.MemberStatus == MemberStatus.Requested));

            return Ok(
                mapper.Map<IEnumerable<FunClub>, IEnumerable<FunClubToClientDTO>>(funClubs)
            );
        }

        [HttpPost]
        [Route("/api/funclubs/create")]
        public IActionResult Create([FromBody] FunClubToServerDTO funClubDto)
        {
            if (funClubDto == null)
            {
                return BadRequest();
            }

            var teamToSave = new Team {Code = funClubDto.TeamId};
            teamsRepository.Add(teamToSave);

            var funClub = new FunClub
            {
                Name = funClubDto.Name,
                Description = funClubDto.Description,
                AvatarUrl = funClubDto.AvatarUrl,
                Team = teamsRepository.GetByTeam(teamToSave)
            };

            // User-creator
            usersFunClubsRepository.Add(new UserFunClub
            {
                FunClub = funClub,
                User = usersRepository.GetLoggedInUser(),
                UserIsCreator = true,
                MemberStatus = MemberStatus.In
            });

            // Other users
            foreach (string userId in funClubDto.UsersIds)
            {
                usersFunClubsRepository.Add(new UserFunClub
                {
                    FunClub = funClub,
                    User = usersRepository.FindById(userId),
                    UserIsCreator = false,
                    MemberStatus = MemberStatus.In
                });
            }

            return Ok();
        }

        [HttpPost]
        [Route("/api/funclubs/send-join-request")]
        public IActionResult AddJoiningAwaitingUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            UserFunClub userFunClub = usersFunClubsRepository.GetByUserFunClub(
                mapper.Map<UserFunClubToServerDTO, UserFunClub>(userFunClubDto)
            );

            if (userFunClub != null)
            {
                if (userFunClub.MemberStatus == MemberStatus.Banned)
                {
                    return BadRequest();
                }

                return Ok();
            }

            usersFunClubsRepository.Add(new UserFunClub
            {
                User = usersRepository.GetLoggedInUser(),
                FunClub = funClubsRepository.FindById(userFunClubDto.FunClubId),
                MemberStatus = MemberStatus.Requested,
                UserIsCreator = false
        });

            return Ok();
        }

        [HttpPost]
        [Route("/api/funclubs/accept-join-request")]
        public IActionResult AcceptJoinRequest([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            UserFunClub userFunClub = usersFunClubsRepository.GetByUserFunClub(
                mapper.Map<UserFunClubToServerDTO, UserFunClub>(userFunClubDto)
            );

            if (userFunClub?.MemberStatus == MemberStatus.Banned)
            {
                return BadRequest();
            }

            return TryChangeUserFunClubStatus(userFunClub, MemberStatus.In)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/api/funclubs/ban-user")]
        public IActionResult BanUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            UserFunClub userFunClub = usersFunClubsRepository.GetByUserFunClub(
                mapper.Map<UserFunClubToServerDTO, UserFunClub>(userFunClubDto)
            );

            if (userFunClub?.MemberStatus == MemberStatus.Banned)
            {
                return Ok();
            }

            return TryChangeUserFunClubStatus(userFunClub, MemberStatus.Banned)
                ? (IActionResult)Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("/api/funclubs/expel-user")]
        [Route("/api/funclubs/unban-user")]
        public IActionResult ExpelOrUnbanUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            UserFunClub userFunClub = usersFunClubsRepository.GetByUserFunClub(
                mapper.Map<UserFunClubToServerDTO, UserFunClub>(userFunClubDto)
            );

            return TryChangeUserFunClubStatus(userFunClub, MemberStatus.Out)
                ? (IActionResult)Ok()
                : BadRequest();
        }

        private bool TryChangeUserFunClubStatus(UserFunClub userFunClub, MemberStatus memberStatus)
        {
            if (userFunClub == null)
            {
                return false;
            }

            FunClub funClub = funClubsRepository.FindById(userFunClub.FunClubId);
            User loggedInUser = usersRepository.GetLoggedInUser();

            if (!funClub.IsCreatedBy(loggedInUser))
            {
                return false;
            }

            if (userFunClub.UserId == loggedInUser.Id)
            {
                return false;
            }

            userFunClub.MemberStatus = memberStatus;
            usersFunClubsRepository.Update(userFunClub);

            return true;
        }
    }
}