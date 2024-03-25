using BUSINESS_LOGIC.BusinessLogic;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LOGIC
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeMasterRepo, EmployeeMasterRepo>();
            services.AddTransient<IIncidentMasterRepo, IncidentMasterRepo>();
            services.AddTransient<ISecIncidentMasterRepo, SecIncidentMasterRepo>();
            services.AddTransient<IBusinessUnitMasterRepo, BusinessUnitMasterRepo>();
            services.AddTransient<IZoneMasterRepo, ZoneMasterRepo>();
            services.AddTransient<ICommunityMasterRepo, CommunityMasterRepo>();
            services.AddTransient<IIncident_Report_Repo, Incident_Report_Repo>();
            services.AddTransient<ICommonMediaUploadRepo, CommonMediaUploadRepo>();
            services.AddTransient<IIncidentSubMasterRepo, IncidentSubMasterRepo>();
            services.AddTransient<IBuildingMasterRepo, BuildingMasterRepo>();
            services.AddTransient<IMasterCommunityRepo, MasterCommunityRepo>();
            services.AddTransient<IInc_Observation_Report_Repo, Inc_Observation_Report_Repo>();
            services.AddTransient<IInvestigationReportRepo, InvestigationReportRepo>();
            services.AddTransient<IRoleMasterRepo, RoleMasterRepo>();
            services.AddTransient<IDesignationMasterRepo, DesignationMasterRepo>();
            services.AddTransient<IAccountsRepo, AccountsRepo>();
            services.AddTransient<IDepartmentMasterRepo, DepartmentMasterRepo>();
            services.AddTransient<IDashboardRepo, DashboardRepo>();
            services.AddTransient<IAuditMasterRepo, AuditMasterRepo>();
            services.AddTransient<IInspectionMasterRepo, InspectionMasterRepo>();
            services.AddTransient<IInspectionFormRepo, InspectionFormRepo>();
            services.AddTransient<IHandOverInspectionRepo, HandOverInspectionRepo>();
            services.AddTransient<IControlofWork_MasterRepo, ControlofWork_MasterRepo>();
            services.AddTransient<IServiceMonthlyStatistics, Service_Monthly_Statistics>();
            services.AddTransient<IDrillCalendar, DrillCalendar>();
            services.AddTransient<IDrillSchedule, DrillSchedule>();
            services.AddTransient<IInspectionDashboardRepo, InspectionDashboardRepo>();
            services.AddTransient<IEmergencyRepo, EmergencyRepo>();
            services.AddTransient<IERT, ERT>();
            services.AddTransient<IEmergencyAlert, EmergencyAlert>();
            services.AddTransient<ILocationMasterRepo, LocationMasterRepo>();
            services.AddTransient<IAlertTrigger, AlertTrigger>();
            services.AddTransient<IMitigationReport, MitigationReport>();
            services.AddTransient<IServiceProviderSignup_DashboardRepo, ServiceProviderSignup_DashboardRepo>();
            services.AddTransient<IHSE_BulletinRepo, HSE_BulletinRepo>();
            services.AddTransient<IAuditSpRepo, AuditSpRepo>();
            services.AddTransient<IAuditNCMFormRepo, AuditNCMFormRepo>();
            services.AddTransient<IAuditEnvRepo, AuditEnvRepo>();
            services.AddTransient<IAuditWelfareRepo, AuditWelfareRepo>();
            services.AddTransient<IAuditInternalRepo, AuditInternalRepo>();
            services.AddTransient<IEmergency_Dashboard, Emergency_DashboardRepo>();
        }
    }
}
