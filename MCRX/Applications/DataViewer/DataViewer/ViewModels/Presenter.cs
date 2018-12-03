using AutoMapper;
using DataModel.Models;
using DataViewer.Bootstrappers;
using DataViewer.Models;
using DataViewer.Profiles;
using DataViewer.Services;
using Infrastructure.Interfaces.DataViewer.Services;
using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataViewer.ViewModels
{
    public class Presenter
    {
        private ObservableCollection<PersonEntityBase> _personGrid = new ObservableCollection<PersonEntityBase>();
        private IServiceModel _service = new ServiceModel();

        public Presenter()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SupervisorServiceProfile>();
            });

            FillGrid();
        }

        public ObservableCollection<PersonEntityBase> PersonGrid
        {
            get
            {
                return _personGrid;
            }
            set
            {
                if (_personGrid != value)
                {
                    _personGrid = value;
                }
            }
        }

        public ICommand SaveCommand
        {
            get { return new DelegateCommand(SaveList); }
        }

        public ICommand CancelCommand
        {
            get { return new DelegateCommand(CancelSaving); }
        }

        private void CancelSaving()
        {
            _personGrid.Clear();
            FillGrid();
        }

        private void SaveList()
        {
            var dbState = _service.GetAllPersons();
            var grid = PersonGrid.ToList();

            //Add
            grid.ForEach(item =>
            {
                if (item.Id == 0)
                {
                    _service.AddPerson(Mapper.Map<PersonEntity>(item));
                }
            });

            //Delete
            dbState.ForEach(item =>
            {
                if (grid.Count(s => s.Id == item.Id) == 0)
                {
                    _service.DeletePerson(item.Id);
                }
            });

            //Update
            var compareLogic = new CompareLogic();
            dbState.ToList().ForEach(item =>
            {
                var result = grid.SingleOrDefault(s => s.Id == item.Id);
                if (result != null)
                {
                    if (!compareLogic.Compare(item,result).AreEqual)
                    {
                        _service.UpdatePerson(Mapper.Map<PersonEntity>(result));
                    }
                }
            });
        }

        private void FillGrid()
        {
            _service.GetAllPersons().ForEach(item =>
            {
                _personGrid.Add(Mapper.Map<PersonEntityBase>(item));
            });
        }
    }
}
