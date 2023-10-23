using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class CiudadDto
    {
        public int Id{get; set;}
        public string NombreCiudad{get; set;}
        public int IdDepartamento{get; set;}
        public List<ClienteDto>Clientes{get; set;}
    }
}