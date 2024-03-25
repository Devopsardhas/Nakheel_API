using IBUSINESS_LOGIC.IBusinessLogic;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IEmployeeMasterRepo employeeMasterRepo
            , IIncidentMasterRepo mIncidentMaster
            , ISecIncidentMasterRepo msecIncidentMaster
            , IBusinessUnitMasterRepo mBusinessUnitMaster
            , IZoneMasterRepo zoneMasterRepo
            , ICommunityMasterRepo mCommunityMasterRepo
            , IIncident_Report_Repo incident_Report_Repo
            , IIncidentSubMasterRepo mIncidentSubMaster
            , ICommonMediaUploadRepo commonMediaUploadRepo
            , IBuildingMasterRepo buildingMasterRepo
            , IMasterCommunityRepo masterCommunityRepo
            , IInc_Observation_Report_Repo mInc_Observation_Report_Repo
            , IInvestigationReportRepo mInvestigationReportRepo
            , IRoleMasterRepo mRoleMasterRepo
            , IDesignationMasterRepo mDesignationMasterRepo
            , IAccountsRepo mAccountsRepo
            , IDepartmentMasterRepo mDepartmentMasterRepo
            , IDashboardRepo mDashboardRepo
            , IAuditMasterRepo mAuditMasterRepo
            , IInspectionMasterRepo mInspectionMasterRepo
            , IInspectionFormRepo mInspectionFormRepo
            , IHandOverInspectionRepo mHandOverInspectionRepo
            , IControlofWork_MasterRepo mControlofWorkMasterRepo
            , IServiceMonthlyStatistics mServiceMonthlyStatistics
            , IDrillCalendar drillCalendar
            , IDrillSchedule drillSchedule
            , IEmergencyRepo emergencyRepo
            , IInspectionDashboardRepo mInspectionDashboardRepo
            , ISecIncidentMasterRepo msecIncidentMasterRepo
            , IERT eRT
            , IEmergencyAlert alertRepo
            , ILocationMasterRepo mlocationMasterRepo
            , IAlertTrigger alertTriggerRepo
            , IMitigationReport mitigationRepo
            ,IServiceProviderSignup_DashboardRepo mServiceProviderSignup_DashboardRepo
            ,IHSE_BulletinRepo mHSE_BulletinRepo
            ,IAuditSpRepo mAuditSpRepo
            ,IAuditNCMFormRepo mauditNCMFormRepo
            , IAuditEnvRepo mAuditEnvRepo
            , IAuditWelfareRepo mAuditWelfareRepo
            ,IAuditInternalRepo mAuditInternalRepo
            ,IEmergency_Dashboard mEmergencyDashboard
            )
        {
            EmployeeMaster = employeeMasterRepo;
            MIncidentMaster = mIncidentMaster;
            MsecIncidentMasterRepo = msecIncidentMaster;
            MBusinessUnitMaster = mBusinessUnitMaster;
            ZoneMasterRepo = zoneMasterRepo;
            MCommunityMasterRepo = mCommunityMasterRepo;
            Incident_Report_Repo = incident_Report_Repo;
            MIncidentSubMaster = mIncidentSubMaster;
            CommonMediaUploadRepo = commonMediaUploadRepo;
            MBuildingMasterRepo = buildingMasterRepo;
            MMasterCommunityMasterRepo = masterCommunityRepo;
            MInc_Observation_Report_Repo = mInc_Observation_Report_Repo;
            MInvestigationReportRepo = mInvestigationReportRepo;
            MRoleMasterRepo = mRoleMasterRepo;
            MDesignationMasterRepo = mDesignationMasterRepo;
            MAccountsRepo = mAccountsRepo;
            MDepartmentMasterRepo = mDepartmentMasterRepo;
            MDashboardRepo = mDashboardRepo;
            MAuditMasterRepo = mAuditMasterRepo;
            MInspectionMasterRepo = mInspectionMasterRepo;
            MInspectionFormRepo = mInspectionFormRepo;
            MHandOverInspectionRepo = mHandOverInspectionRepo;
            MControlofWorkMasterRepo = mControlofWorkMasterRepo;
            MServiceMonthlyStatistics = mServiceMonthlyStatistics;
            DrillCalendar = drillCalendar;
            DrillSchedule = drillSchedule;
            MEmergencyRepo = emergencyRepo;
            MInspectionDashboardRepo = mInspectionDashboardRepo;
            MsecIncidentSecurityRepo = msecIncidentMasterRepo;
            ERTRepo = eRT;
            AlertRepo = alertRepo;
            MLocationMasterRepo = mlocationMasterRepo;
            TriggerRepo = alertTriggerRepo;
            MitigationRepo = mitigationRepo;
            MServiceProviderSignupDashboardRepo = mServiceProviderSignup_DashboardRepo;
            MBulletinRepo = mHSE_BulletinRepo;
            MAuditSpRepo = mAuditSpRepo;
            MAuditNCMFormRepo = mauditNCMFormRepo;
            MAuditEnvRepo = mAuditEnvRepo;
            MAuditWelfareRepo = mAuditWelfareRepo;
            MAuditInternalRepo = mAuditInternalRepo;
            MEmergencyDashboard = mEmergencyDashboard;


        }
        public IEmployeeMasterRepo EmployeeMaster { get; }
        public IIncidentMasterRepo MIncidentMaster { get; }
        public ISecIncidentMasterRepo MsecIncidentMasterRepo { get; }
        public IBusinessUnitMasterRepo MBusinessUnitMaster { get; }
        public IZoneMasterRepo ZoneMasterRepo { get; }
        public ICommunityMasterRepo MCommunityMasterRepo { get; }
        public IIncident_Report_Repo Incident_Report_Repo { get; }
        public IIncidentSubMasterRepo MIncidentSubMaster { get; }
        public ICommonMediaUploadRepo CommonMediaUploadRepo { get; }
        public IBuildingMasterRepo MBuildingMasterRepo { get; }
        public IMasterCommunityRepo MMasterCommunityMasterRepo { get; }
        public IInc_Observation_Report_Repo MInc_Observation_Report_Repo { get; }
        public IInvestigationReportRepo MInvestigationReportRepo { get; }
        public IRoleMasterRepo MRoleMasterRepo { get; }
        public IDesignationMasterRepo MDesignationMasterRepo { get; }
        public IAccountsRepo MAccountsRepo { get; }
        public IDepartmentMasterRepo MDepartmentMasterRepo { get; }
        public IDashboardRepo MDashboardRepo { get; }
        public IAuditMasterRepo MAuditMasterRepo { get; }
        public IInspectionMasterRepo MInspectionMasterRepo { get; }
        public IInspectionFormRepo MInspectionFormRepo { get; }
        public IHandOverInspectionRepo MHandOverInspectionRepo { get; }
        public IControlofWork_MasterRepo MControlofWorkMasterRepo { get; }
        public IServiceMonthlyStatistics MServiceMonthlyStatistics { get; }
        public IDrillCalendar DrillCalendar { get; }
        public IDrillSchedule DrillSchedule { get; }
        public IEmergencyRepo MEmergencyRepo { get; }
        public IInspectionDashboardRepo MInspectionDashboardRepo { get; }
        public ISecIncidentMasterRepo MsecIncidentSecurityRepo { get; }
        public IERT ERTRepo { get; }
        public IEmergencyAlert AlertRepo { get; }
        public ILocationMasterRepo MLocationMasterRepo { get; }
        public IAlertTrigger TriggerRepo { get; }
        public IMitigationReport MitigationRepo { get; }
        public IServiceProviderSignup_DashboardRepo MServiceProviderSignupDashboardRepo { get; }
        public IHSE_BulletinRepo MBulletinRepo { get; }
        public IAuditSpRepo MAuditSpRepo { get; }
        public IAuditNCMFormRepo MAuditNCMFormRepo { get; }
        public IAuditEnvRepo MAuditEnvRepo { get; }
        public IAuditWelfareRepo MAuditWelfareRepo { get; }
        public IAuditInternalRepo MAuditInternalRepo { get; }
        public IEmergency_Dashboard MEmergencyDashboard { get; }
    }
}
