using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditSpRepo : IGenericRepo<M_AuditSp> 
    {
        public Task<IReadOnlyList<M_AuditSp>> Audit_Sp_GetAll(DataTableAjaxPostModel entity);
        public Task<M_AuditSp> Audit_Sp_GetById(M_AuditSp entity);
        public Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_Audit_Team_GetBy_Id(M_AuditSp entity);
        public Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_Representative_GetBy_Id(M_AuditSp entity);
        public Task<M_Return_Message> Audit_Sp_Add(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_Find_Questionnaire_Add(Am_Sp_Add_Finding_Questionnaires_List entity);
        public Task<M_Return_Message> Am_Sp_Find_Ques_LM_ApprovalReject(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_Find_Ques_Director_ApprovalReject(M_AuditSp entity);
        public Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_CA_Service_Provider_Zone_GetBy(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_Corrective_Action_Add(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_NCR_Action_Add(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_Find_Ques_HSE_ApprovalReject(M_AuditSp entity);
        public Task<M_Return_Message> Am_Sp_Find_Ques_Lead_Au_ApprovalReject(M_AuditSp entity);
        public Task<Am_Sp_Qus_Evidence> Am_Sp_Ques_Photo_Delete(Am_Sp_Qus_Evidence entity);
    }
}
