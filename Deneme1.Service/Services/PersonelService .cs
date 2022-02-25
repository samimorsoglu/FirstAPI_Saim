using AutoMapper;
using Deneme1.Core.Model;
using Deneme1.Data.IRepositories;
using Deneme1.Data.IUnitOfWorks;
using Deneme1.Service.IServices;
using Deneme1.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme1.Service.Services
{
    public class PersonelService : Service<Personel>, IPersonelService
    {
        private readonly IMapper _mapper;
        public PersonelService(IUnitOfWork unitOfWork, IRepository<Personel> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }
    }
}
