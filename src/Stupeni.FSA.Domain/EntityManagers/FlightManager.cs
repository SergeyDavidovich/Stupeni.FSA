using Stupeni.FSA.Entities;
using Stupeni.FSA.EntityManagers.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Stupeni.FSA.EntityManagers
{
    #region Business rules definition
    // №1. Добавление рейсов. Рейс не может быть добавлен, если разница между добавляемой датой STD и текущей датой меньше трех часов
    #endregion
    public class FlightManager : DomainService, IFlightRepository
    {
        private readonly IRepository<Flight, int> _repository;

        public FlightManager(IRepository<Flight, int> repository)
        {
            _repository = repository;
        }

        public async Task<Flight> GetAllAsync(Flight flight, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Flight> GetByIdAsync(Flight flight, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Flight> CreateAsync(Flight flight, CancellationToken token)
        {
            CheckSTD(flight.STD);
            return flight;
        }

        public async Task<Flight> UpdateAsync(Flight flight, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Flight> DeleteAsync(Flight flight, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        #region Business rules implementations
        /// <summary>
        /// Реализация бизнес правила №1
        /// </summary>
        /// <param name="std">Запланированное время отправления</param>
        /// <exception cref="Exception">Генерируется, когда разница между добавленной датой STD и текущей датой составляет менее часа</exception>
        private void CheckSTD(DateTime std)
        {
            var timeDifference = DateTime.Now - std;
            if (timeDifference.TotalHours < 1)
                throw new Exception("STD cannot be set if the difference between the added STD date and the current date is less than an hour.");
        }
        #endregion
    }
}