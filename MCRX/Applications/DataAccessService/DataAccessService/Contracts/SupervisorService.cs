using DataContract.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract.DataContracts;
using Infrastructure.Interfaces.Services;
using DataModel.Models;
using AutoMapper;

namespace DataAccessService.Contracts
{
    public class SupervisorService : IDataManager
    {
        private readonly IFileManager _fileManager;

        public SupervisorService(IFileManager fileManager)
        {
            _fileManager = fileManager;
            _fileManager.CreateXmlFileIfNotExists();
        }
        public bool AddPerson(PersonEntityDTO person)
        {
            return _fileManager.StoreData(Mapper.Map<PersonEntity>(person));
        }

        public bool DeletePerson(int id)
        {
            return _fileManager.DeleteRow(id);
        }

        public List<PersonEntityDTO> GetAllPersons()
        {
            return Mapper.Map<List<PersonEntityDTO>>(_fileManager.GetAllPersons());
        }

        public bool UpdatePerson(PersonEntityDTO person)
        {
            return _fileManager.UpdatePerson(Mapper.Map<PersonEntity>(person));
        }
    }
}
