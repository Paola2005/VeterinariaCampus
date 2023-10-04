using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class DeapartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly VeterinariaContext _context;

    public DeapartamentoRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
}
