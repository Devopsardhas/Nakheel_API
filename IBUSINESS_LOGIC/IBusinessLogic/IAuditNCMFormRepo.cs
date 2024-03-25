using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditNCMFormRepo : IGenericRepo<MAuditNCMForm>
    {
        public Task<IReadOnlyList<MAuditNCMForm>> Audit_NCM_Form_GetAll(DataTableAjaxPostModel entity);
        public Task<MAuditNCMForm> Am_Sp_NCR_Form_GetbyId(MAuditNCMForm entity);
        public Task<MAuditNCMForm> Audit_NCM_Form_Create_GetById(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_Form_Add(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_CA_Action_Add(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_CA_Action_HSE_ApprovalReject(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_Report_Form_Add(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_Form_HSE_ApprovalReject(MAuditNCMForm entity);
        public Task<M_Return_Message> Audit_NCM_Form_Dir_ApprovalReject(MAuditNCMForm entity);
        public Task<M_Return_Message> NCM_CA_Action_Lead_Auditor_ApprovalReject(MAuditNCMForm entity);
    }
}
