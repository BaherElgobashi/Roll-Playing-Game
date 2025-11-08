using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.DTOs.Character
{
    public class GetCharacterDto
    {
        public int id { get; set; }
        public string name { get; set; } = "Frodo";
        public int hitPoints { get; set; } = 100;
        public int strength { get; set; } = 100;
        public int defense { get; set; } = 100;
        public int intelligence { get; set; } = 100;
        public RpgClass Class { get; set; } = RpgClass.knight;
    }
}