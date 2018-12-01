using Autofac;
using DataAccessService.Configurations;
using DataAccessService.Contracts;
using DataAccessService.Hosters;
using DataAccessService.Services;
using DataContract.ServiceContracts;
using Infrastructure.Interfaces.Configuration;
using Infrastructure.Interfaces.Services;
using log4net;
using ServiceHosts.Initializers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Modules
{
    public class DataServiceModule : Autofac.Module
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected override void Load(ContainerBuilder builder)
        {
            Logger.Debug("DataServiceModule initialization...");

            builder
                .RegisterType<Configuration>()
                .As<IConfiguration>()
                .SingleInstance();

            builder
                .RegisterType<WorkflowServiceHostInitializer>()
                .As<IServiceHostInitializer>()
                .AutoActivate()
                .SingleInstance();

            builder
                .RegisterType<SupervisorService>()
                .As<IDataManager>()
                .SingleInstance()
                .AutoActivate();

            builder
                .RegisterType<FileManagerService>()
                .As<IFileManager>()
                .SingleInstance();
        }
    }
}
