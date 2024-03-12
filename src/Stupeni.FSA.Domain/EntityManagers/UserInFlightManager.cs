using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    public class UserInFlightManager : DomainService, IUserInFlightRepository
    {
        private readonly IRepository<UserInFlight> repository;

        public UserInFlightManager()
        {
                
        }

        public Task<UserInFlight> GetAllAsync(UserInFlight userInFlight, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserInFlight> GetByIdAsync(UserInFlight userInFlight, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserInFlight> CreateAsync(UserInFlight userInFlight, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserInFlight> UpdateAsync(UserInFlight userInFlight, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<UserInFlight> DeleteAsync(UserInFlight userInFlight, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}