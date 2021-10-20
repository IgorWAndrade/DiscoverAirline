using DiscoverAirline.Core;
using DiscoverAirline.Security.Domain.Entities;
using DiscoverAirline.Security.Domain.Interfaces.Repositories;
using DiscoverAirline.Security.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoverAirline.Security.Rule.Services
{
    public class CtrService : ICtrService
    {
        private readonly IBaseRepository<Controller> _repository;

        public CtrService(IBaseRepository<Controller> repository)
        {
            _repository = repository;
        }

        public Task<Notification> AddAsync(object model)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Notification> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Notification> UpdateAsync(object model)
        {
            throw new NotImplementedException();
        }
    }
}
