using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditWelfareRepo : IGenericRepo<M_AuditWelfare>
    {
        public Task<IReadOnlyList<M_AuditWelfare>> Audit_Welfare_GetAll(DataTableAjaxPostModel entity);
        public Task<M_AuditWelfare> Audit_Welfare_GetById(M_AuditWelfare entity);
        public Task<IReadOnlyList<AM_Welfare_Dropdown_Values>> Am_Welfare_Audit_Team_GetBy_Id(M_AuditWelfare entity);
        public Task<IReadOnlyList<AM_Welfare_Dropdown_Values>> Am_Welfare_Representative_GetBy_Id(M_AuditWelfare entity);
        public Task<M_Return_Message> Audit_Welfare_Add(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_Find_Questionnaire_Add(Am_Welfare_Add_Finding_Questionnaires_List entity);
        public Task<M_Return_Message> Am_Welfare_Find_Ques_LM_ApprovalReject(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_Find_Ques_Director_ApprovalReject(M_AuditWelfare entity);
        public Task<IReadOnlyList<AM_Welfare_Dropdown_Values>> Am_Welfare_CA_Service_Provider_Zone_GetBy(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_Corrective_Action_Add(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_NCR_Action_Add(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_Find_Ques_HSE_ApprovalReject(M_AuditWelfare entity);
        public Task<M_Return_Message> Am_Welfare_Find_Ques_Lead_Au_ApprovalReject(M_AuditWelfare entity);
    }
}
