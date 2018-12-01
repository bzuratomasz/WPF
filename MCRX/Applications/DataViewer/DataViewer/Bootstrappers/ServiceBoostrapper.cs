using Autofac;
using AutoMapper;
using DataViewer.Profiles;
using DataViewer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewer.Bootstrappers
{
    public class ServiceBootstrapper : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceModel>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
