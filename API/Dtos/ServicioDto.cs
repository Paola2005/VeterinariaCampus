using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ServicioDto
    {
        public int Id{get; set;}
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public List <CitaDto>Citas{get; set;}
    }
}