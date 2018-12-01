using Autofac;
using AutoMapper;
using DataAccessService.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Modules
{
    public class ProfilesRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<SupervisorServiceProfile>();
            });

        }
    }
}
