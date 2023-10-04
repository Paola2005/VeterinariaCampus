using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly VeterinariaContext _context;
        public UnitOfWork(VeterinariaContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
    }
