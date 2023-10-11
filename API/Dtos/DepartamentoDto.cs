using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class DepartamentoDto
    {
        public int IdPais {get; set;}
        public string NombreDep { get; set; }
        public List<CiudadDto> Ciudades {get; set;}
    }
}