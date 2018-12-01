using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Services
{
    public interface IFileManager
    {
        bool CreateXmlFileIfNotExists();
        bool StoreData(PersonEntity item);
        bool DeleteRow(int id);
        List<PersonEntity> GetAllPersons();
        bool UpdatePerson(PersonEntity item);
    }
}
