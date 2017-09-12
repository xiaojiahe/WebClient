using System.Collections.Generic;

namespace Qlik.Sense.ServiceClusterManager.Model.Services
{
	public enum ServiceLogVerbosityEnum
	{
		Off, Fatal, Error, Warning, Basic, Extended, Info, Debug
	}
	public enum ServiceLogFacilityEnum
	{
		AuditActivity,
		AuditSecurity,
		Service,
		Application,
		Audit,
		License,
		ManagementConsole,
		Performance,
		Security,
		Synchronization,
		System,
		UserManagement,
		RuleAudit,
		TaskExecution
	}

	public class ServiceLogVerbosities : Dictionary<ServiceLogFacilityEnum, ServiceLogVerbosityEnum> { }
}
