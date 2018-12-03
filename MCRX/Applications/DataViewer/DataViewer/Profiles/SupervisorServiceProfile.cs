using AutoMapper;
using DataContract.DataContracts;
using DataModel.Models;
using DataViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewer.Profiles
{
    public class SupervisorServiceProfile : Profile
    {
        public SupervisorServiceProfile()
        {
            Mapper.CreateMap<PersonEntityDTO, PersonEntity>();
            Mapper.CreateMap<PersonEntity, PersonEntityDTO>();

            Mapper.CreateMap<PersonEntityBase, PersonEntity>();
            Mapper.CreateMap<PersonEntity, PersonEntityBase>();
        }
    }
}
