using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CiudadRepository : GenericRepository<Ciudad>, ICiudad
{
    private readonly VeterinariaContext _context;

    public CiudadRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Ciudad>> GetAllAsync()
    {
        return await _context.Ciudades
            .Include(p => p.Clientes)

            .ToListAsync();
    }

    public async Task<List<Cliente>> GetclientesByPaisIdAsync(int paisId)
    {
        return await _context.Clientes.Where(d => d.IdCiudad == paisId).ToListAsync();
    }
    public async Task<Ciudad> GetByIdAsync(int id)
    {
        return await _context.Ciudades
            .Include(p => p.Clientes)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
