using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class MAuditNCMForm : M_AuditNCM_Common
    {
        public string? Am_Sp_NCR_Id { get; set; }
        public string? Audit_Sp_Sch_Id { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Audit_Date { get; set; }
        public string? Audit_Type_Name { get; set; }
        public string? Audit_Unique_Id { get; set; }
        public string? Service_Provider_Id { get; set; }
        public string? CreatedBy_Name { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Name { get; set; }
        public string? Non_Conformity_Desc { get; set; }
        public string? AS_Procedure_Require { get; set; }
        public string? Target_Date { get; set; }
        public string? Service_Provider_Name { get; set; }
        public string? Role_Id { get; set; }
        public string? Login_Id { get; set; }
        public string? Root_Cause_Analysis { get; set; }
        public string? Description_Root_Cause { get; set; }
        public string? RecordsFiltered { get; set; }
        public string? RecordsTotal { get; set; }
        public string? Access_Schedule { get; set; }
        public string? Walk_In_Insp_Name { get; set; }
        public List<Dropdown_Values>? Business_Master_List { get; set; }
        public List<Dropdown_Values>? Zone_Master_List { get; set; }
        public List<M_AuditNCM_CA>? Audit_NCM_CA_List { get; set; }
        public List<M_AuditNCM_CA_Rej>? Audit_NCM_CA_Rej_List { get; set; }
        public List<M_AuditNCM_CA_Rej>? Audit_NCM_Form_Rej_List { get; set; }
        public List<Am_Sp_NCR_History_Approval>? Am_Sp_NCR_History_Approval_List { get; set; }
    }

    public class Am_Sp_NCR_History_Approval
    {
        public string? History_Id { get; set; }
        public string? Am_Sp_NCR_Id { get; set; }
        public string? Audit_Sp_Sch_Id { get; set; }
        public string? Emp_Name { get; set; }
        public string? Role_Name { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Last_DateTime { get; set; }
        public string? CreatedDate { get; set; }
        public string? Next_Action { get; set; }
    }


    public class M_AuditNCM_CA_Rej
    {
        public string? Am_Sp_NCR_CA_Rej_Id { get; set; }
        public string? Am_Sp_NCR_Form_Rej_Id { get; set; }
        public string? Am_Sp_NCR_Id { get; set; }
        public string? Reject_Reason { get; set; }
        public string? Unique_Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedBy_Name { get; set; }
    }

    public class M_AuditNCM_CA
    {
        public string? NCR_Form_CA_Id { get; set; }
        public string? Closure_Description { get; set; }
        public string? File_Path { get; set; }
        public string? CreatedBy { get; set; }
        public string? Closure_Date { get; set; }
        public string? Closure_Name { get; set; }
    }

    public class M_AuditNCM_Common
    {
        public string? Unique_Id { get; set; }
        public string? Status { get; set; }
        public string? Status_Name { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }

    }
}
