using Deneme1.Data.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext _appDbContext)
        {
            _context = _appDbContext;
        }

        public void Commit() //savechange
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync() //savechangeasync
        {
            await _context.SaveChangesAsync();
        }
    }
}
