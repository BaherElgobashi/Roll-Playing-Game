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
        public async Task< ActionResult<List<Character>>> GetAll()
        {

            return Ok( await _characterService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<Character>> GetCharacterById(int id)
        {

            return Ok( await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Character>> AddCharacter(Character newCharacter)
        {
             await _characterService.AddCharacter(newCharacter);
            return Ok(_characterService);
        }
        
    }
}