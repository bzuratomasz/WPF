using AutoMapper;
using DataModel.Models;
using DataViewer.Bootstrappers;
using DataViewer.Interfaces;
using DataViewer.Profiles;
using DataViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataViewer.ViewModels
{
    public class Presenter : ObservableObject
    {

        public Presenter()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SupervisorServiceProfile>();
            });

            FillGrid();
        }

        private void FillGrid()
        {
            _service.GetAllPersons().ForEach(item =>
            {
                _personGrid.Add(item);
            });
        }

        private ObservableCollection<PersonEntity> _personGrid = new ObservableCollection<PersonEntity>();
        private IServiceModel _service = new ServiceModel();

        public ObservableCollection<PersonEntity> PersonGrid
        {
            get
            {
                return _personGrid;
            }
            set
            {
                _personGrid = value;
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
            var grid = _personGrid.ToList();

            //Add
            grid.ForEach(item =>
            {
                if (item.Id == 0)
                {
                    _service.AddPerson(item);
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

            //Update - To Analyze!
            dbState.ToList().ForEach(item =>
            {
                var result = grid.SingleOrDefault(s => s.Id == item.Id);
                if (result != null)
                {
                    if (item != result)
                    {
                        _service.UpdatePerson(result);
                    }
                }
            });
        }
    }
}
