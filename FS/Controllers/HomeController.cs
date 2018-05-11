using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using FS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using FS.Dtos;

namespace FS.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{*url}")]
        public IActionResult Index() {
            return View();
        }
    }
}