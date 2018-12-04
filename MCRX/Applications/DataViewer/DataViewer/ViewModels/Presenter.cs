using AutoMapper;
using DataModel.Models;
using DataViewer.Bootstrappers;
using DataViewer.Models;
using DataViewer.Modules;
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

        public Presenter()
        {

        }

        public ObservableCollection<PersonEntityBase> PersonGrid
        {
            get
            {
                return MainModule.PersonEntityBaseRepository.GetActualCollection();
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
            var result = MainModule.DbUpdaterService.GetDbValues();
            PersonGrid.Clear();

            result.ForEach(item => 
            {
                PersonGrid.Add(Mapper.Map<PersonEntityBase>(item));
            });
        }

        private void SaveList()
        {
            var changes = new List<PersonEntity>();

            PersonGrid.ToList().ForEach(item => 
            {
                changes.Add(Mapper.Map<PersonEntity>(item));
            });

            MainModule.DbUpdaterService.DbUpdate(changes);
        }
    }
}
