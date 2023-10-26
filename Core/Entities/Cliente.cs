using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities;

public class Cliente : BaseEntity
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Apellido { get; set; }
    [Required]
    public string Email { get; set; }

    public int IdCiudad { get; set; }
    public Ciudad Ciudades { get; set; }


    public ClienteDireccion ClienteDirecciones{get; set;}
    
    public ICollection<Cita> Citas { get; set; }
    public ICollection<ClienteTelefono> ClientesTelefonos { get; set; }
    public ICollection<Mascota> Mascotas { get; set; }

    
    
}
