using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IInc_Observation_Report_Repo: IGenericRepo<M_Incident_Observation_Report>
    {
        public Task<IReadOnlyList<M_Incident_Observation_Report>> ObservationReportGetAllAsync(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Inc_Observation_Team(M_Inc_Observation_Team entity);
        public Task<IReadOnlyList<M_Observation_Corrective_Action>> Obs_Action_Closure_Get_All(Observation_Corrective_Action entity);
        public Task<M_Return_Message> Add_Observation_Corrective_Action(M_Observation_Corrective_Action entity);
        public Task<M_Return_Message> UpdateObservationPriority(M_Incident_Observation_Report entity);
        public Task<M_Return_Message> Update_Obs_Category_Positive(M_Incident_Observation_Report entity);
        public Task<M_Observation_Corrective_Action> Inc_Observation_Supervisor_GetByID(M_Observation_Corrective_Action entity);
        public Task<M_Return_Message> Update_Observation_Corrective_Action(M_Observation_Corrective_Action entity);
        public Task<M_Return_Message> Re_Assign_Corrective_Assign_Action(M_Observation_Corrective_Action entity);
        public Task<M_Return_Message> Update_Observation_Corrective_Action_HSE(M_Observation_Corrective_Action entity);
        public Task<M_Return_Message> Update_Observation_Corrective_Action_HSE_Reject(M_Observation_Corrective_Action entity);
        public Task<IReadOnlyList<Observation_Status_History>> Observation_Status_History(M_Incident_Observation_Report entity);
        public Task<IReadOnlyList<M_Incident_Observation_Report>> ObservationNotificationCardView(M_Incident_Observation_Report entity);
    }
}
