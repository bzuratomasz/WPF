using DataViewer.Repositories;
using DataViewer.Repositories.Interfaces;
using DataViewer.Services;
using Infrastructure.Interfaces.DataViewer.Services;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataViewer.Modules
{
    public class MainModule : IModule
    {
        public static IPersonEntityBaseRepository PersonEntityBaseRepository;
        public static IServiceModel ServiceModel;
        public static IDbUpdaterService DbUpdaterService;

        private readonly IRegionManager regionManager;
        public MainModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Views.StartupWindow));

            var container = new UnityContainer()
                .RegisterType<IPersonEntityBaseRepository, PersonEntityBaseRepository>(new TransientLifetimeManager())
                .RegisterType<IDbUpdaterService, DbUpdaterService>(new TransientLifetimeManager())
                .RegisterType<IServiceModel, ServiceModel>(new TransientLifetimeManager());

            PersonEntityBaseRepository = container.Resolve<PersonEntityBaseRepository>();
            ServiceModel = container.Resolve<ServiceModel>();
            DbUpdaterService = container.Resolve<DbUpdaterService>();
        }

    }
}
