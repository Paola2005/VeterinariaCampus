using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ClienteTelefonoRepository : GenericRepository<ClienteTelefono>, IClienteTelefono
{
    private readonly VeterinariaContext _context;

    public ClienteTelefonoRepository(VeterinariaContext context) : base(context)
    {
        _context = context;
    }
}
