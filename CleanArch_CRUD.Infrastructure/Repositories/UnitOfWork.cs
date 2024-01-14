using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Category> Categories {get; set;}

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
