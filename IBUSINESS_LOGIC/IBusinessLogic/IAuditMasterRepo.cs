using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAuditMasterRepo : IGenericRepo<M_Audit_Category>
    {
        #region [Audit Topics] 
        public Task<IReadOnlyList<M_Audit_Topics>> GetAll_AM_Topics();
        public Task<IReadOnlyList<M_Audit_Topics>> GetById_AM_Topics(M_Audit_Topics entity);
        public Task<M_Return_Message> Add_AM_Topics(List<M_Audit_Topics> entity);
        public Task<M_Return_Message> Delete_AM_Topics(M_Audit_Topics entity);
        #endregion

        #region [Audit Sub Topics] 
        public Task<IReadOnlyList<M_Audit_Sub_Topics>> GetAll_AM_Sub_Topics();
        public Task<IReadOnlyList<M_Audit_Sub_Topics>> GetById_AM_Sub_Topics(M_Audit_Sub_Topics entity);
        public Task<M_Return_Message> Add_AM_Sub_Topics(List<M_Audit_Sub_Topics> entity);
        public Task<M_Return_Message> Delete_AM_Sub_Topics(M_Audit_Sub_Topics entity);
        #endregion

        #region [Audit Questionnaires] 
        public Task<IReadOnlyList<M_Audit_Questionnaires>> GetAll_AM_Questionnaires();
        public Task<IReadOnlyList<M_Audit_Questionnaires>> GetById_AM_Questionnaires(M_Audit_Questionnaires entity);
        public Task<M_Return_Message> Add_AM_Questionnaires(List<M_Audit_Questionnaires> entity);
        public Task<M_Return_Message> Delete_AM_Questionnaires(M_Audit_Questionnaires entity);
        public Task<IReadOnlyList<M_Audit_Questionnaires>> Get_Env_Sp_Questionaire(M_Audit_Questionnaires entity);

        #endregion

        #region [Audit Findings]
        public Task<IReadOnlyList<M_AuditFindings>> GetAll_Am_AuditFindings();
        public Task<IReadOnlyList<M_AuditFindings>> GetByID_AuditFindings(M_AuditFindings entity);
        public Task<M_Return_Message> Add_Am_Audit_Findings(List<M_AuditFindings> entity);
        public Task<M_Return_Message> Delete_AM_Audit_Findings(M_AuditFindings entity);
        public Task<M_Return_Message> Update_Am_Audit_Findings(M_AuditFindings entity);
        #endregion
        public Task<IReadOnlyList<M_Audit_QuestionnaireDetails>> Get_All_Questionnaire_Chk(M_Audit_QuestionnaireDetails entity);

        #region [Audit_Schedule] 
        public Task<M_Return_Message> Add_Audit_Schedule(Audit_Schedule_Model entity);
        public Task<IReadOnlyList<Audit_Schedule_Model>> Get_All_Audit_Schedule(DataTableAjaxPostModel entity);
        public Task<IReadOnlyList<M_Audit_Type>> Get_All_Audit_Type();
        public Task<IReadOnlyList<Audit_Schedule_Model>> GetById_AM_AuditSchedule(Audit_Schedule_Model entity);
        public Task<M_Return_Message> Add_Audit_Findings_Chk(Audit_Schedule_Model entity);
        public Task<IReadOnlyList<Audit_Schedule_Model>> GetbyIdAudit_CheckList(Audit_Schedule_Model entity);
        #endregion

        #region [Audit Schedule - Internal Audit]
        public Task<M_Return_Message> Add_Internal_Audit(Aud_Internal_Audit entity);
        public Task<IReadOnlyList<Aud_Internal_Audit>> Get_All_Internal_Audit(DataTableAjaxPostModel model);
        public Task<Aud_Internal_Audit> GetByIdInternalAudit(Aud_Internal_Audit entity);
        public Task<Aud_Internal_Audit> GetByIdInternalAuditSed(Aud_Internal_Audit entity);
        public Task<M_Return_Message> Add_Internal_Aud_CheckList(List<Internal_Aud_CheckList> entity);
        public Task<IReadOnlyList<Internal_Aud_CheckList>> Get_Internal_Aud_CheckList(Aud_Internal_Audit entity);
        public Task<M_Return_Message> Add_NCR_Report_Form(Aud_Internal_NCR_Form entity);
        public Task<M_Return_Message> Update_NCR_Report_Form(Aud_Internal_NCR_Form entity);
        public Task<M_Return_Message> Get_Internal_Audit_Audit_Team(Aud_Internal_Audit entity);
        public Task<M_Return_Message> Complete_NCR_Report_Form(Aud_Internal_Audit entity);
        public Task<Aud_Internal_NCR_Form> Get_NCR_Report_Form_Details(Aud_Internal_NCR_Form entity);
        #endregion
    }
}
