using Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using DataModel.Models;

namespace DataAccessService.Services
{
    public class CollectionAnalyzerService : ICollectionAnalyzerService
    {
        public PersonsList UpdatePersonLogic(PersonEntity item, PersonsList deserialized)
        {
            var tmpObject = new PersonsList();
            tmpObject.PersonList = new List<PersonEntity>();

            tmpObject.PersonList.AddRange(deserialized.PersonList);

            if (item.Id > 0)
            {
                var objToDelete = tmpObject.PersonList.FirstOrDefault(s => s.Id == item.Id);
                if (objToDelete != null)
                {
                    tmpObject.PersonList.Remove(objToDelete);
                    tmpObject.PersonList.Add(item);
                }
            }
            else
            {
                throw new Exception("Id can't be equal 0!");
            }

            return tmpObject;
        }
    }
}
