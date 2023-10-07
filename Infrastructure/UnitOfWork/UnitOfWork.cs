using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinariaContext _context;
    private PaisRepository _paises;

    public UnitOfWork(VeterinariaContext context)
    {
        _context = context;
    }
    public IPais Paises{
        get{
            if (_paises==null){
                _paises=new PaisRepository(_context);
            }
            return _paises;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
