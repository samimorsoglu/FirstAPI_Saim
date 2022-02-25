using Deneme1.Data.IRepositories;
using Deneme1.Data.IUnitOfWorks;
using Deneme1.Data.Repositories;
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
        private StudentRepository _studentRepository;
        private PersonelRepository _personelRepository;

        public UnitOfWork(AppDbContext _appDbContext)
        {
            _context = _appDbContext;
        }

        public IStudentRepository Students => _studentRepository = _studentRepository ?? new StudentRepository(_context);

        public IPersonelRepository Personels => _personelRepository = _personelRepository ?? new PersonelRepository(_context);


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
