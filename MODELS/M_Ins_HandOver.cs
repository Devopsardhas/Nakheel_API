﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Insp_HandOver: M_Common_Fields
    {
        public string? Insp_HndOver_Building_Id { get; set; }
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
        public string? Date_of_Audit { get; set; }
        public string? Zone_Representative { get; set; }
        public string? SP_Attended { get; set; }
        public string? Others_SP { get; set; }
        public string? Service_Provider { get; set; }
        public string? Inspected_By_Id { get; set; }
        public string? Inspected_By_Name { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? HandOver_Type { get; set; }
        public string? HandOver_Type_List { get; set; }
        public string? Consultant_Name { get; set; }
        public string? Consultant_MNo { get; set; }
        public string? Contractor_Name { get; set; }
        public string? Contractor_MNo { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
        public List<M_Insp_HandOver_Questionnaires>? L_Insp_HandOver_Questionnaires { get; set; }
        //public List<M_Insp_HandOver_Questionnaires>? L_Insp_HandOver_Infra_Qns { get; set; }
        public List<M_Insp_HealthSafety_Questionnaires>? L_Insp_HandOver_Observation { get; set; }
        public List<M_Insp_HndOver_Assign_Action>? L_Insp_HandOver_CA { get; set; }
        public List<Insp_HandOver_Building_History>? L_HandOver_Building_History { get; set; }
    }
    public class M_Insp_HandOver_Questionnaires : M_Common_Fields
    {
        public string? Insp_Qns_Building_Id { get; set; }
        public string? Insp_HndOver_Building_Id { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Insp_Questionnaires_Name { get; set; }
        public string? Qns_Action { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? Risk_Level { get; set; }
        public string? Risk_Description { get; set; }
        public string? Description_Action { get; set; }
        public string? Category { get; set; }
    }
    public class HandOver_Bldg_Corrective_Action: M_Common_Fields
    {
        public string? Corrective_Action_Id { get; set; }
        public string? Insp_HndOver_Building_Id { get; set; }
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Assignee_Type { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Description_Action { get; set; }
    }
    public class Insp_HandOver_Building_History
    {
        public string? Building_History_Id { get; set; }
        public string? Insp_HndOver_Building_Id { get; set; }
        public string? Action_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? Updated_DateTime { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? CreatedDate { get; set; }
        public string? Next_Action { get; set; }
    }
    public class M_Insp_HndOver_Assign_Action
    {
        public string? Bldg_Action_Id { get; set; }
        public string? Corrective_Action_Id { get; set; }
        public string? Insp_HndOver_Building_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Responsible_Id { get; set; }
        public string? Responsible_Name { get; set; }
        public string? Role_Id { get; set; }
        public string? Assignee_Type { get; set; }
        public string? HandOver_Type { get; set; }
        public string? Target_Date { get; set; }
        public string? Description { get; set; }
        public string? Description_Action { get; set; }
        public string? Photo_File_Path { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Status { get; set; }
        public string? Reject_Stage { get; set; }
        public string? Reject_Reason { get; set; }
        public List<M_Insp_HandOver_Photos>? L_Insp_HndOver_Photos { get; set; }
    }
    public class M_Insp_HandOver_Photos
    {
        public string? Bldg_Photo_Id { get; set; }
        public string? Insp_HndOver_Building_Id { get; set; }
        public string? Photo_File_Path { get; set; }
    }
}
