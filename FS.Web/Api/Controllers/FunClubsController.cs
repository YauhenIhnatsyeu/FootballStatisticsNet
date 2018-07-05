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

        //private User currentUser 

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
            User currentUser = usersRepository.GetLoggedInUser();

            IEnumerable<FunClub> funClubs = funClubsRepository.Get()
                .Where(funClub => funClub.UsersFunClub.Any(
                    ufc => ufc.User == currentUser && ufc.UserIsCreator == true))
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
                MemberStatus = MemberStatus.Requested
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

            FunClub funClub = funClubsRepository.FindById(userFunClubDto.FunClubId);

            if (!funClub.IsCreatedBy(usersRepository.GetLoggedInUser()))
            {
                return BadRequest();
            }

            UserFunClub userFunClub = usersFunClubsRepository.GetByUserFunClub(
                mapper.Map<UserFunClubToServerDTO, UserFunClub>(userFunClubDto)
            );

            if (userFunClub == null)
            {
                return BadRequest();
            }

            if (userFunClub.MemberStatus == MemberStatus.Banned)
            {
                return BadRequest();
            }

            userFunClub.MemberStatus = MemberStatus.In;
            userFunClub.UserIsCreator = false;
            usersFunClubsRepository.Update(userFunClub);

            return Ok();
        }

        [HttpPost]
        [Route("/api/funclubs/remove-user")]
        public IActionResult RemoveUser([FromBody] UserFunClubToServerDTO userFunClubDto)
        {
            if (userFunClubDto == null)
            {
                return BadRequest();
            }

            usersFunClubsRepository.Remove(new UserFunClub
            {
                User = usersRepository.FindById(userFunClubDto.UserId),
                FunClub = funClubsRepository.FindById(userFunClubDto.FunClubId)
            });

            return Ok();
        }
    }
}