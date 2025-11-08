using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;
using dotnet_rpg.Services.CharacterServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_rpg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> GetAll()
        {

            return Ok(_characterService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetCharacterById(int id)
        {

            return Ok(_characterService.GetCharacterById(id));
        }

        [HttpPost]
        public ActionResult<Character> AddCharacter(Character newCharacter)
        {
            _characterService.AddCharacter(newCharacter);
            return Ok(_characterService);
        }
        
    }
}