﻿using IdentityServer.API.Dtos;
using IdentityServer.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.API.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserManager<ApplicationUser> userManager)
        {
                _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto signupDto)
        {

            var user = new ApplicationUser
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
                City = signupDto.City,
            };

            var result = await _userManager.CreateAsync(user,signupDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            return NoContent();
        }
    }
}
