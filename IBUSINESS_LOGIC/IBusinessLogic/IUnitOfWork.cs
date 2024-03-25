using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IUnitOfWork
    {
        IEmployeeMasterRepo EmployeeMaster { get; }
        IIncidentMasterRepo MIncidentMaster { get; }
        ISecIncidentMasterRepo MsecIncidentMasterRepo { get; }
        IBusinessUnitMasterRepo MBusinessUnitMaster { get; }
        IZoneMasterRepo ZoneMasterRepo { get; }
        ICommunityMasterRepo MCommunityMasterRepo { get; }
        IIncident_Report_Repo Incident_Report_Repo { get; }
        IIncidentSubMasterRepo MIncidentSubMaster { get; }
        ICommonMediaUploadRepo CommonMediaUploadRepo { get; }
        IBuildingMasterRepo MBuildingMasterRepo { get; }
        IMasterCommunityRepo MMasterCommunityMasterRepo { get; }
        IInc_Observation_Report_Repo MInc_Observation_Report_Repo { get; }
        IInvestigationReportRepo MInvestigationReportRepo { get; }
        IRoleMasterRepo MRoleMasterRepo { get; }
        IDesignationMasterRepo MDesignationMasterRepo { get; }
        IAccountsRepo MAccountsRepo { get; }
        IDepartmentMasterRepo MDepartmentMasterRepo { get; }
        IDashboardRepo MDashboardRepo { get; }
        IAuditMasterRepo MAuditMasterRepo { get; }
        IInspectionMasterRepo MInspectionMasterRepo { get; }
        IInspectionFormRepo MInspectionFormRepo { get; }
        IHandOverInspectionRepo MHandOverInspectionRepo { get; }
        IControlofWork_MasterRepo MControlofWorkMasterRepo { get; }
        IServiceMonthlyStatistics MServiceMonthlyStatistics { get; }
        IDrillCalendar  DrillCalendar { get; }
        IDrillSchedule DrillSchedule { get; }
        IEmergencyRepo MEmergencyRepo { get; }
        IInspectionDashboardRepo MInspectionDashboardRepo { get; }
        ISecIncidentMasterRepo MsecIncidentSecurityRepo { get; }
        IERT ERTRepo { get; }
        IEmergencyAlert AlertRepo { get; }
        ILocationMasterRepo MLocationMasterRepo { get; }
        IAlertTrigger TriggerRepo { get; }
        IMitigationReport MitigationRepo { get; }
        IServiceProviderSignup_DashboardRepo MServiceProviderSignupDashboardRepo { get; }
        IHSE_BulletinRepo MBulletinRepo { get; }
        IAuditSpRepo MAuditSpRepo { get; }
        IAuditNCMFormRepo MAuditNCMFormRepo { get; }
        IAuditEnvRepo MAuditEnvRepo { get; }
        IAuditWelfareRepo MAuditWelfareRepo { get; }
        IAuditInternalRepo MAuditInternalRepo { get; }
        IEmergency_Dashboard MEmergencyDashboard { get; }
    }
}
