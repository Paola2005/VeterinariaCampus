using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IPais : IGenericRepository<Pais>
    {
        Task<List<Departamento>> GetDepartamentosByPaisIdAsync(int paisId);
    }
}
