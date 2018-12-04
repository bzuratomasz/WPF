using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Models;
using System.Collections.ObjectModel;
using Infrastructure.Interfaces.DataViewer.Services;
using AutoMapper;
using DataViewer.Repositories.Interfaces;
using DataViewer.Models;

namespace DataViewer.Repositories
{
    public class PersonEntityBaseRepository : IPersonEntityBaseRepository
    {
        private readonly IServiceModel _serviceModel;
        private ObservableCollection<PersonEntityBase> _personGrid = new ObservableCollection<PersonEntityBase>();


        public PersonEntityBaseRepository(IServiceModel serviceModel)
        {
            _serviceModel = serviceModel;

            _serviceModel.GetAllPersons().ForEach(item =>
            {
                _personGrid.Add(Mapper.Map<PersonEntityBase>(item));
            });
        }

        public ObservableCollection<PersonEntityBase> GetActualCollection()
        {
            return _personGrid;
        }

        public ObservableCollection<PersonEntityBase> GetDatabaseCollection()
        {
            var buffer = new ObservableCollection<PersonEntityBase>();

            _serviceModel.GetAllPersons().ForEach(item =>
            {
                buffer.Add(Mapper.Map<PersonEntityBase>(item));
            });

            return buffer;
        }
    }
}
