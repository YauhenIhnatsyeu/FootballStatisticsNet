using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FS.Core.Enums;
using FS.Core.Interfaces.Repositories;
using FS.Core.Models;
using FS.Web.Api.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FS.Web.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/fanclubs")]
    public class FanClubsController : Controller
    {
        private readonly IAvatarsRepository avatarsRepository;
        private readonly IFanClubsRepository fanClubsRepository;
        private readonly IMapper mapper;
        private readonly ITeamsRepository teamsRepository;
        private readonly IUsersFanClubsRepository usersFanClubsRepository;
        private readonly IUsersRepository<User> usersRepository;

        public FanClubsController(
            IAvatarsRepository avatarsRepository,
            IFanClubsRepository fanClubsRepository,
            IMapper mapper,
            ITeamsRepository teamsRepository,
            IUsersFanClubsRepository usersFanClubsRepository,
            IUsersRepository<User> usersRepository)
        {
            this.avatarsRepository = avatarsRepository;
            this.fanClubsRepository = fanClubsRepository;
            this.mapper = mapper;
            this.teamsRepository = teamsRepository;
            this.usersFanClubsRepository = usersFanClubsRepository;
            this.usersRepository = usersRepository;
        }

        /// <summary>
        ///     Gets all fanClubs with users that are accepted into them
        /// </summary>
        [AllowAnonymous]
        [Route("get")]
        public IActionResult Get()
        {
            IEnumerable<FanClub> fanClubs = fanClubsRepository.Get()
                .Select(fanClub => fanClub.FilterUsersFanClub(
                    ufc => ufc.MemberStatus == MemberStatus.In));

            return Ok(
                mapper.Map<IEnumerable<FanClub>, IEnumerable<FanClubToClientDTO>>(fanClubs)
            );
        }

        /// <summary>
        ///     Gets all fanClubs, which current user created, with users that want to join them
        /// </summary>
        [Route("get-unaccepted")]
        public IActionResult GetUnaccepted()
        {
            User loggedInUser = usersRepository.GetLoggedInUser();

            IEnumerable<FanClub> fanClubs = fanClubsRepository.Get()
                .Where(fanClub => fanClub.UsersFanClub.Any(
                    ufc => ufc.User == loggedInUser && ufc.UserIsCreator == true))
                .Select(fanClub => fanClub.FilterUsersFanClub(
                    ufc => ufc.MemberStatus == MemberStatus.Requested));

            return Ok(
                mapper.Map<IEnumerable<FanClub>, IEnumerable<FanClubToClientDTO>>(fanClubs)
            );
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] FanClubToServerDTO fanClubDto)
        {
            if (fanClubDto == null)
            {
                return BadRequest();
            }

            var fanClub = mapper.Map<FanClubToServerDTO, FanClub>(fanClubDto);
            fanClub.Team = teamsRepository.GetByCode(fanClubDto.TeamId);

            if (fanClubDto.AvatarId != null)
            {
                string avatarUrl = avatarsRepository.GetUrlById(fanClubDto.AvatarId);

                if (avatarUrl == null)
                {
                    return BadRequest();
                }

                fanClub.AvatarUrl = avatarUrl;
            }

            usersFanClubsRepository.Add(new UserFanClub
            {
                FanClub = fanClub,
                User = usersRepository.GetLoggedInUser(),
                UserIsCreator = true,
                MemberStatus = MemberStatus.In
            });

            return Ok();
        }

        [HttpPost]
        [Route("send-join-request")]
        public IActionResult AddJoiningAwaitingUser([FromBody] UserFanClubToServerDTO userFanClubDto)
        {
            if (userFanClubDto == null)
            {
                return BadRequest();
            }

            UserFanClub userFanClub = usersFanClubsRepository.GetByUserFanClub(
                mapper.Map<UserFanClubToServerDTO, UserFanClub>(userFanClubDto)
            );

            if (userFanClub != null)
            {
                if (userFanClub.MemberStatus == MemberStatus.Banned)
                {
                    return BadRequest();
                }

                return Ok();
            }

            usersFanClubsRepository.Add(new UserFanClub
            {
                User = usersRepository.FindById(userFanClubDto.UserId),
                FanClub = fanClubsRepository.FindById(userFanClubDto.FanClubId),
                MemberStatus = MemberStatus.Requested,
                UserIsCreator = false
            });

            return Ok();
        }

        [HttpPost]
        [Route("accept-join-request")]
        public IActionResult AcceptJoinRequest([FromBody] UserFanClubToServerDTO userFanClubDto)
        {
            if (userFanClubDto == null)
            {
                return BadRequest();
            }

            UserFanClub userFanClub = usersFanClubsRepository.GetByUserFanClub(
                mapper.Map<UserFanClubToServerDTO, UserFanClub>(userFanClubDto)
            );

            if (userFanClub?.MemberStatus == MemberStatus.Banned)
            {
                return BadRequest();
            }

            return TryChangeUserFanClubStatus(userFanClub, MemberStatus.In)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("ban-user")]
        public IActionResult BanUser([FromBody] UserFanClubToServerDTO userFanClubDto)
        {
            if (userFanClubDto == null)
            {
                return BadRequest();
            }

            UserFanClub userFanClub = usersFanClubsRepository.GetByUserFanClub(
                mapper.Map<UserFanClubToServerDTO, UserFanClub>(userFanClubDto)
            );

            if (userFanClub?.MemberStatus == MemberStatus.Banned)
            {
                return Ok();
            }

            return TryChangeUserFanClubStatus(userFanClub, MemberStatus.Banned)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        [HttpPost]
        [Route("expel-user")]
        [Route("unban-user")]
        public IActionResult ExpelOrUnbanUser([FromBody] UserFanClubToServerDTO userFanClubDto)
        {
            if (userFanClubDto == null)
            {
                return BadRequest();
            }

            UserFanClub userFanClub = usersFanClubsRepository.GetByUserFanClub(
                mapper.Map<UserFanClubToServerDTO, UserFanClub>(userFanClubDto)
            );

            return TryChangeUserFanClubStatus(userFanClub, MemberStatus.Out)
                ? (IActionResult) Ok()
                : BadRequest();
        }

        private bool TryChangeUserFanClubStatus(UserFanClub userFanClub, MemberStatus memberStatus)
        {
            if (userFanClub == null)
            {
                return false;
            }

            FanClub fanClub = fanClubsRepository.FindById(userFanClub.FanClubId);
            User loggedInUser = usersRepository.GetLoggedInUser();

            if (!fanClub.IsCreatedBy(loggedInUser))
            {
                return false;
            }

            if (userFanClub.UserId == loggedInUser.Id)
            {
                return false;
            }

            userFanClub.MemberStatus = memberStatus;
            usersFanClubsRepository.Update(userFanClub);

            return true;
        }
    }
}