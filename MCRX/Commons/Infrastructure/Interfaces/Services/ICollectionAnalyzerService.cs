using DataModel;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Services
{
    public interface ICollectionAnalyzerService
    {
        PersonsList UpdatePersonLogic(PersonEntity item, PersonsList deserialized);
    }
}
