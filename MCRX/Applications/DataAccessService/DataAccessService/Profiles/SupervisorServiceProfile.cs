using AutoMapper;
using DataContract.DataContracts;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Profiles
{
    public class SupervisorServiceProfile : Profile
    {
        public SupervisorServiceProfile()
        {
            Mapper.CreateMap<PersonEntityDTO, PersonEntity>();
            Mapper.CreateMap<PersonEntity, PersonEntityDTO>();
        }
    }
}
