using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace API.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int IdCiudad { get; set; }
        public List<ClienteTelefonoDto> ClienteTelefonos { get; set; }
        public List<MascotaDto> Mascotas { get; set; }
        public List<CitaDto> Citas { get; set; }
    }
}
