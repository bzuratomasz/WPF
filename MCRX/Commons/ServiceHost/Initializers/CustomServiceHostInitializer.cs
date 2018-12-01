using Autofac;
using Autofac.Integration.Wcf;
using ServiceHosts.Initializers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHosts.Initializers
{
    public abstract class CustomServiceHostInitializer<TImplementation, TContract> : IServiceHostInitializer
    {
        readonly ILifetimeScope _lifetimeScope;
        ServiceHost _serviceHost;

        protected CustomServiceHostInitializer(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public ServiceHost Initialize()
        {
            _serviceHost = CreateServiceHost();
            _serviceHost.AddDependencyInjectionBehavior<TContract>(_lifetimeScope);
            _serviceHost.Open();
            return _serviceHost;
        }

        protected virtual ServiceHost CreateServiceHost()
        {
            return new ServiceHost(typeof(TImplementation));
        }

        public void Dispose()
        {
            if (_serviceHost == null) return;

            if (_serviceHost.State != CommunicationState.Faulted)
                _serviceHost.Close();
            else
                _serviceHost.Abort();
        }
    }
}
