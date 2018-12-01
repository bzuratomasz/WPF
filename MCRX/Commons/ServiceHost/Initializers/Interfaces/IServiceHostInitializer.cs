using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServiceHosts.Initializers.Interfaces
{
    public interface IServiceHostInitializer
    {
        ServiceHost Initialize();
    }
}
