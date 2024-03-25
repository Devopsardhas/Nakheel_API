using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditEnvRepo:IGenericRepo<M_Audit_Env>
    {
        public Task<IReadOnlyList<M_Audit_Env>> GetAll_Env_Audit(DataTableAjaxPostModel entity);
        public Task<M_Audit_Env> Edit_Env_Audit(M_Audit_Env entity);
        public Task<M_Return_Message> Add_Env_Audit(M_Audit_Env entity);
        public Task<M_Return_Message> Am_Env_Audit_Questionnaire_Add(Am_Env_Audit_Add_Questionnaires_List entity);
        public Task<M_Return_Message> Am_Env_Audit_ApprovalReject(M_Audit_Env entity);
        public Task<M_Return_Message> Am_Env_Audit_Add_Sp_Target(M_Audit_Env entity);
        public Task<M_Return_Message> Am_Env_Audit_Add_NCR_Action(M_Audit_Env entity);
        public Task<M_Return_Message> Am_Env_Audit_HSE_Approve(Env_Audit_Approval entity);
        public Task<M_Return_Message> Am_Env_Audit_Reject(Env_Audit_Reject entity);
    }
}
