using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

/* primero se general el paisrepositorio(context) */
public class PaisRepository : GenericRepository<Pais>, IPais
{
    private readonly VeterinariaContext _context;

    public PaisRepository(VeterinariaContext context)
        : base(context)
    {
        /*  Luego se le da click derecho en "veterinariaContext" y se le eda en create and asing field context  */
        _context = context;
    }

    public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises
            .Include(p => p.Departamentos)
            .ThenInclude(c => c.Ciudades)
            .ToListAsync();
    }

    public async Task<List<Departamento>> GetDepartamentosByPaisIdAsync(int paisId)
    {
        return await _context.Departamentos.Where(d => d.IdPais == paisId).ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(
        int pageIndex,
        int pageSize,
        string search
    )
    {
        var query = _context.Paises as IQueryable<Pais>;
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombrePais.ToLower().Contains(search));
        }
        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query
            .Include(u => u.Departamentos)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<Pais> GetByIdAsync(int id)
    {
        return await _context.Paises
            .Include(p => p.Departamentos)
            .ThenInclude(d => d.Ciudades)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
