using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QLVatLieuXayDung.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QLVatLieuXayDung22.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<User> _users = new List<User>();
        public UserController()
        {
            _users = new List<User>();
            for (int i = 0; i<= 9; i++)
            {
                _users.Add(new User()
                {
                    UserId = i,
                    UserName = "User" + i,
                    Dob = "",

                });   
            }    
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _users;
        }
    }
}
