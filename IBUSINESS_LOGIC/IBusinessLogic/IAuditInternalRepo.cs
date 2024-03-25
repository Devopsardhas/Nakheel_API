using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditInternalRepo : IGenericRepo<M_Audit_Internal_Master>
    {
        public Task<IReadOnlyList<M_Audit_Internal_Master>> Audit_Internal_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Audit_Internal_Master> Audit_Internal_GetById(M_Audit_Internal_Master entity);
        public Task<IReadOnlyList<AM_Internal_Dropdown_Values>> AM_Internal_Audit_Team_GetBy_Id(M_AuditSp entity);
        public Task<IReadOnlyList<AM_SP_Dropdown_Values>> AM_Int_Representative_GetById(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> Audit_Internal_Add(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_Find_Questionnaire_Add(AM_Internal_Add_Finding_Qns_List entity);
        public Task<M_Return_Message> AM_Int_Find_Ques_LM_ApprovalReject(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_Find_Ques_Director_ApprovalReject(M_Audit_Internal_Master entity);
        public Task<IReadOnlyList<AM_Internal_Dropdown_Values>> AM_Int_CA_Service_Provider_Zone_GetBy(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_Corrective_Action_Add(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_NCR_Action_Add(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_Find_Ques_HSE_ApprovalReject(M_Audit_Internal_Master entity);
        public Task<M_Return_Message> AM_Int_Find_Ques_Lead_Au_ApprovalReject(M_Audit_Internal_Master entity);
    }
}
