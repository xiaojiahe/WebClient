using System.Collections.Generic;
using System.Dynamic;
using Qlik.Sense.ServiceClusterManager.Model.Services;

namespace Qlik.Sense.ServiceClusterManager.Model
{
    public class ServiceRegistrationRequest
    {
	    public ServiceCluster ServiceCluster { get; set; }
		public string HostName { get; set; }
		public List<ServiceTypeEnum> TypesToRegisterAsDefault { get; set; }
		public List<IService> ServicesToRegister { get; set; }
    }
}
