using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataViewer.Services
{
    public interface IDbUpdaterService
    {
        void DbUpdate(List<PersonEntity> changes);

        List<PersonEntity> GetDbValues();
    }
}
