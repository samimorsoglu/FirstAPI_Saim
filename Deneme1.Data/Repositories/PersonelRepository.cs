using Deneme1.Core.Model;
using Deneme1.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Data.Repositories
{
    public class PersonelRepository : Repository<Personel>, IPersonelRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public PersonelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
