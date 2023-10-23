using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IPais Paises { get; }
        ICiudad Ciudades { get; }
        ICita Citas { get; }
        ICliente Clientes { get; }
        IClienteDireccion ClienteDirecciones { get; }
        IClienteTelefono ClienteTelefonos { get; } /* Etas se colocan UnitOfWord */
        IDepartamento Departamentos { get; }
        IMascota Mascotas { get; }
        IRaza Razas { get; }
        IServicio Servicios { get; }
        Task<int> SaveAsync();
    }
}
