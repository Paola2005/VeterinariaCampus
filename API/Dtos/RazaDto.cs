using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class RazaDto
    {
        public int Id{get; set;}
        public string NombreRaza { get; set; }
            public List<MascotaDto> Mascotas { get; set; }
    }
}