using DataViewer.Repositories.Interfaces;
using Infrastructure.Interfaces.DataViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataModel.Models;
using KellermanSoftware.CompareNetObjects;
using DataViewer.Models;

namespace DataViewer.Services
{
    public class DbUpdaterService : IDbUpdaterService
    {
        private readonly IServiceModel _service;
        private readonly IPersonEntityBaseRepository _repository;

        public DbUpdaterService(IServiceModel serviceModel, IPersonEntityBaseRepository repository)
        {
            _service = serviceModel;
            _repository = repository;
        }

        public void DbUpdate(List<PersonEntity> changes)
        {
            var dbState = _repository.GetDatabaseCollection().ToList();
            var grid = changes;

            grid.ForEach(item =>
            {
                if (item.Id == 0)
                {
                    _service.AddPerson(Mapper.Map<PersonEntity>(item));
                }
            });

            dbState.ForEach(item =>
            {
                if (grid.Count(s => s.Id == item.Id) == 0)
                {
                    _service.DeletePerson(item.Id);
                }
            });

            var compareLogic = new CompareLogic();
            dbState.ToList().ForEach(item =>
            {
                var result = grid.SingleOrDefault(s => s.Id == item.Id);
                if (result != null)
                {
                    if (!compareLogic.Compare(item, result).AreEqual)
                    {
                        _service.UpdatePerson(Mapper.Map<PersonEntity>(result));
                    }
                }
            });
        }

        public List<PersonEntity> GetDbValues()
        {
            var result = new List<PersonEntity>();

            _repository.GetDatabaseCollection().ToList().ForEach(item => 
            {
                result.Add(Mapper.Map<PersonEntity>(item));
            });

            return result;
        }
    }
}
