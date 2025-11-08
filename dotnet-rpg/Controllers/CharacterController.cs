using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{id = 1 , name = "Sam"}
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> GetAll()
        {

            return Ok(characters);
        }
        
        [HttpGet("{id}")]
        public ActionResult<Character> GetAll(int id)
        {
            
            return Ok(characters.FirstOrDefault(C=>C.id == id));
        }
        
    }
}