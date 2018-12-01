using Autofac;
using DataAccessService.Modules;
using log4net;
using ServiceHosts.Initializers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService.Bootstrappers
{
    public class ServiceBootstrapper : IDisposable
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Autofac.IContainer _container;

        public ServiceBootstrapper()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DataServiceModule());
            builder.RegisterModule(new ProfilesRegistrationModule());

            _container = builder.Build();
        }

        public void Start()
        {
            if (_container != null)
            {
                var _host = _container.Resolve<IServiceHostInitializer>();
                _host.Initialize();
            }
        }

        public void Dispose()
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}
