﻿using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.DataViewer.Services
{
    public interface IServiceModel
    {
        List<PersonEntity> GetAllPersons();
        bool AddPerson(PersonEntity person);
        bool UpdatePerson(PersonEntity person);
        bool DeletePerson(int id);
    }
}
