using System;

namespace Qlik.Sense.ServiceClusterManager.Model.Services
{
	public enum ServiceStateEnum
	{
		Initializing,
		CertificatesNotInstalled,
		Running,
		NoCommunication,
		Disabled,
		Unknown,
	}

	public class InnerServiceStatus : PersistentModel
	{
		protected InnerServiceStatus() { }
		protected InnerServiceStatus(InnerServiceStatus item) : base(item)
		{
			if (item != null)
			{
				HostName = item.HostName;
				ServiceType = item.ServiceType;
				ServiceId = item.ServiceId;
				State = item.State;
			}
		}

		internal InnerServiceStatus(ServiceStatus item) : base(item)
		{
			if (item != null)
			{
				HostName = item.HostName;
				ServiceType = item.ServiceType;
				ServiceId = item.ServiceId;
				State = item.State;
			}
		}

		public string HostName { get; set; }
		public ServiceTypeEnum ServiceType { get; set; }
		public Guid ServiceId { get; set; }
		public ServiceStateEnum State { get; set; }
	}

	public class ServiceStatus : InnerServiceStatus
	{
		public ServiceStatus() { }
		protected ServiceStatus(InnerServiceStatus innerItem) : base(innerItem) { }

		public static ServiceStatus FromInner(InnerServiceStatus innerItem)
		{
			return innerItem == null ? null : new ServiceStatus(innerItem);
		}

		public static InnerServiceStatus ToInner(ServiceStatus item)
		{
			return item == null ? null : new InnerServiceStatus(item);
		}

		// virtual properties, fetched by base properties
		public ServerNode ServerNode { get; set; }
	}
}
