using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ClienteDireccionRepository : GenericRepository<ClienteDireccion>, IClienteDireccion
{
    private readonly VeterinariaContext _context;

    public ClienteDireccionRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
}
