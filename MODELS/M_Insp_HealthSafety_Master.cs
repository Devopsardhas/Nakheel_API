using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    #region [Health & Safety Inspection]
    public class M_Insp_HealthSafety_Master : M_Common_Fields
    {
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Company_Name { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Id { get; set; }
        public string? Building_Name { get; set; }
        public string? Business_Unit_Type_Name { get; set; }
        public string? Date_of_Inspection { get; set; }
        public string? Schedule_Type { get; set; }
        public string? Health_Safety_Type { get; set; }
        public string? Zone_Supervisor { get; set; }
        public string? Zone_Manager { get; set; }
        public string? Inspected_By_Id { get; set; }
        public string? Inspected_By_Name { get; set; }
        public string? Safety_Violation { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
        public List<M_Insp_HealthSafety_Questionnaires>? L_Insp_HealthSafety_Questionnaires { get; set; }
        public List<M_Insp_HealthSafety_Questionnaires>? L_Insp_HealthSafety_Observation { get; set; }
        public List<M_Insp_HealthSafety_Assign_Action>? L_Insp_HealthSafety_CA { get; set; }
        public List<Insp_HealthSafety_History>? L_Insp_HealthSafety_History { get; set; }
        public List<M_Insp_HealthSafety_Master>? L_M_Upcoming_Activity { get; set; }
        public Notification_Dashboard_Count? L_M_Notification_Dashboard_Count { get; set; }
    }
    public class Insp_HealthSafety_History
    {
        public string? History_Id { get; set; }
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Emp_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? History_DateTime { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? CreatedDate { get; set; }
        public string? Next_Action { get; set; }
    }
    public class M_Insp_HealthSafety_Questionnaires : M_Common_Fields
    {
        public string? Insp_Hs_Qns_Id { get; set; }
        public string? Insp_HsObs_Id { get; set; }
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Insp_Topic_Id { get; set; }
        public string? Insp_Topic_Name { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Insp_Questionnaires_Name { get; set; }
        public string? Qns_Action { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? Hazard_Risk { get; set; }
        public string? Requirements { get; set; }
        public string? Description_Action { get; set; }
        public string? Category { get; set; }
        public string? Sub_Category { get; set; }
        public string? Risk_Level { get; set; }
    }
    public class M_Insp_HealthSafety_Assign_Action
    {
        public string? Assign_Action_Id { get; set; }
        public string? Insp_HsObs_Id { get; set; }
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Responsible_Name { get; set; }
        public string? Target_Date { get; set; }
        public string? Action_Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? Role_Id { get; set; }
        public string? Status { get; set; }
        public string? Action_Taken { get; set; }
        public string? Photo_File_Path { get; set; }
    }
    public class M_Insp_HealthSafety_Assign_Team
    {
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Assign_Action_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? Role_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Responsible_Name { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Action_Taken { get; set; }
        public string? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? Reject_Stage { get; set; }
        public string? Reject_Reason_Description { get; set; }
        public List<M_Insp_HealthSafety_Assign_Action>? L_M_Insp_HealthSafety_Team { get; set; }
        public List<M_Insp_HealthSafety_Photos>? L_M_Insp_HealthSafety_Photos { get; set; }
    }
    public class M_Insp_HealthSafety_Photos
    {
        public string? Hs_Photo_Id { get; set; }
        public string? Insp_HealthSafety_Id { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Photo_File_Path { get; set; }
    }
    #endregion
    #region [Service Provider Inspection]
    public class M_Insp_ServiceProvider_Master : M_Common_Fields
    {
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Company_Name { get; set; }
        public string? Inspected_By_Id { get; set; }
        public string? Inspected_By_Name { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Id { get; set; }
        public string? Building_Name { get; set; }
        public string? Business_Unit_Type_Name { get; set; }
        public string? Inspection_Date { get; set; }
        public string? Schedule_Type { get; set; }
        public string? Access_Schedule { get; set; }
        public string? Service_Provider_Type { get; set; }
        public string? Safety_Violation { get; set; }
        public string? Zone_In_Charge_Id { get; set; }
        public string? Service_Provider_Id { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
        public List<M_Insp_ServiceProvider_Questionnaires>? L_Insp_ServiceProvider_Qns { get; set; }
        public List<M_Insp_ServiceProvider_Questionnaires>? L_Insp_ServiceProvider_Observation { get; set; }
        public List<M_Insp_ServiceProvider_Assign_Action>? L_Insp_ServiceProvider_CA { get; set; }
        public List<Insp_Service_Provider_History>? L_Insp_ServiceProvider_History { get; set; }
    }
    public class Insp_Service_Provider_History
    {
        public string? History_Id { get; set; }
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Emp_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? History_DateTime { get; set; }
        public string? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? Next_Action { get; set; }
    }
    public class M_Insp_ServiceProvider_Questionnaires : M_Common_Fields
    {
        public string? Insp_Sp_Qns_Id { get; set; }
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Insp_SpObs_Id { get; set; }
        public string? Insp_Topic_Id { get; set; }
        public string? Insp_Topic_Name { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Insp_Questionnaires_Name { get; set; }
        public string? Qns_Action { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? Hazard_Risk { get; set; }
        public string? Requirements { get; set; }
        public string? Description_Action { get; set; }
        public string? Category { get; set; }
        public string? Sub_Category { get; set; }
        public string? Risk_Level { get; set; }
    }
    public class M_Insp_ServiceProvider_Assign_Action
    {
        public string? Corrective_Action_Id { get; set; }
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Insp_SpObs_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Assignee_Type { get; set; }
        public string? Target_Date { get; set; }
        public string? Action_Description { get; set; }
        public string? Action_Taken { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
    }
    public class M_Insp_ServiceProvider_Assign_Team
    {
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? CreatedBy { get; set; }
        public string? Role_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Responsible_Name { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Action_Taken { get; set; }
        public string? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? Reject_Stage { get; set; }
        public string? Reject_Reason { get; set; }
        public List<M_Insp_ServiceProvider_Assign_Action>? L_M_Insp_ServiceProvider_Team { get; set; }
        public List<M_Insp_ServiceProvider_Photos>? L_M_Insp_ServiceProvider_Photos { get; set; }
    }
    public class M_Insp_ServiceProvider_Photos
    {
        public string? Sp_Photo_Id { get; set; }
        public string? Insp_ServiceProvider_Id { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Photo_File_Path { get; set; }
    }
    #endregion
    #region [Fire & Life Safety Inspection]
    public class M_Insp_FireLifeSafety_Master : M_Common_Fields
    {
        public string? Insp_Request_Id { get; set; }
        public string? Company_Name { get; set; }
        public string? Inspected_By_Id { get; set; }
        public string? Inspected_By_Name { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Id { get; set; }
        public string? Building_Name { get; set; }
        public string? Business_Unit_Type_Name { get; set; }
        public string? Inspection_Date { get; set; }
        public string? Schedule_Type { get; set; }
        public string? Fire_Life_Type { get; set; }
        public string? Safety_Violation { get; set; }
        public string? Zone_Rep_Attended { get; set; }
        public string? Service_Provider_Attended { get; set; }
        public string? Zone_Rep_Id { get; set; }
        public string? Service_Provider_Id { get; set; }
        public string? Access_Schedule { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
        public List<M_Insp_FireLifeSafety_Questionnaires>? L_Insp_FireLifeSafety_Qns { get; set; }
        public List<M_Insp_HealthSafety_Questionnaires>? L_Insp_FireLifeSafety_Observation { get; set; }
        public List<M_Insp_FireLifeSafety_Assign_Action>? L_Insp_FireLifeSafety_CA { get; set; }
        public List<Insp_FireLifeSafety_History>? L_Insp_FireLifeSafety_History { get; set; }
    }
    public class Insp_FireLifeSafety_History
    {
        public string? History_Id { get; set; }
        public string? Insp_Request_Id { get; set; }
        public string? Emp_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? History_DateTime { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? CreatedDate { get; set; }
        public string? Next_Action { get; set; }
    }
    public class M_Insp_FireLifeSafety_Questionnaires : M_Common_Fields
    {
        public string? Insp_Question_Id { get; set; }
        public string? Insp_Request_Id { get; set; }
        public string? Insp_Topic_Id { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Insp_Questionnaires_Name { get; set; }
        public string? Qns_Action { get; set; }
        public string? Details_of_Evidence { get; set; }
        public string? Risk_Description { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? Risk_Level { get; set; }
        public string? Description_Action { get; set; }
        public string? Category { get; set; }
        public string? Sub_Category { get; set; }
    }
    public class M_Insp_FireLifeSafety_Assign_Action
    {
        public string? Insp_Request_Id { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Responsible_Name { get; set; }
        public string? Assignee_Type { get; set; }
        public string? Target_Date { get; set; }
        public string? Description_Action { get; set; }
        public string? Action_Taken { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Status { get; set; }
        public string? Reject_Stage { get; set; }
        public string? Reject_Reason { get; set; }
        public List<M_Insp_FireLifeSafety_Assign_Team>? L_M_Insp_FireLifeSafety_Team { get; set; }
        public List<M_Insp_FireLifeSafety_Photos>? L_M_Insp_FireLifeSafety_Photos { get; set; }
    }
    public class M_Insp_FireLifeSafety_Assign_Team
    {
        public string? Corrective_Action_Id { get; set; }
        public string? Insp_Request_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Assignee_Type { get; set; }
        public string? Target_Date { get; set; }
        public string? Description_Action { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
    }
    public class M_Insp_FireLifeSafety_Photos
    {
        public string? Photo_Id { get; set; }
        public string? Insp_Request_Id { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Photo_File_Path { get; set; }
    }
    #endregion
}
