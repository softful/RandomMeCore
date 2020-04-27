using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RandomMeCore.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomMeCore.Core.Services;
using System.Linq;
using System;
using RandomMeCore.Core.Models;

namespace RandomMeCore.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : ApiControllerBase
    {       
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {            
            this.userService = userService;
        }

        [HttpGet("all/{limit}")]
        [ProducesResponseType(typeof(IEnumerable<GeneratedUser>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(int limit,
            CancellationToken cancellationToken = default)
        {
            if (limit < 1 || limit > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            var result = await userService.GenerateRandomUsers(limit, cancellationToken);
            
            var femaleUrl = this.Url.Action("GetRandomPhoto", "Users", new { gender = Gender.F }, this.Request.Scheme);
            var maleUrl = this.Url.Action("GetRandomPhoto", "Users", new { gender = Gender.M }, this.Request.Scheme);

            foreach (var user in result)
            {
                user.PhotoUrl = user.Gender == Gender.F ? femaleUrl : maleUrl;
            }

            return Ok(result);
        }

        [HttpGet("photo/{gender}")]        
        public async Task<IActionResult> GetRandomPhoto(Gender gender,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
            //return File(new byte[1], "img/png");
        }

        [HttpGet("single")]
        [ProducesResponseType(typeof(IEnumerable<GeneratedUser>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSingle(
            CancellationToken cancellationToken = default)
        {
            var result = await userService.GenerateRandomUsers(1, cancellationToken);
            return Ok(result.First());
        }

    }
}
