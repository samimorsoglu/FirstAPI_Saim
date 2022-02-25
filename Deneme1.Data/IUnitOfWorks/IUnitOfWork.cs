using Deneme1.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Data.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        IPersonelRepository Personels { get; }
        Task CommitAsync();
        void Commit();
    }
}
