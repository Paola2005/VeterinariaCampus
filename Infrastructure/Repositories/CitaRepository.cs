using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CitaRepository : GenericRepository<Cita>, ICita
{
    private readonly VeterinariaContext _context;

    public CitaRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
}
