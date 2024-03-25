using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IIncident_Report_Repo : IGenericRepo<M_Incident_Report>
    {
        public Task<IReadOnlyList<M_Incident_Report>> IncidentNotificationGetAll(DataTableAjaxPostModel entity);

        public Task<M_Return_Message> IncidentStatusUpdate(M_Incident_Report entity);

        public Task<M_Return_Message> Inc_Investigation_Team(M_Inc_Investigation_Team entity);

        public Task<M_Return_Message> Inc_Add_Knowledge_Share(Inc_Knowledge_Share entity);

        public Task<M_Return_Message> Inc_Add_Knowledge_Share_No(Inc_Knowledge_Share entity);

        public Task<M_Return_Message> Inc_AddCorrective_Assign_Action(M_Corrective_Assign_Action entity);

        public Task<IReadOnlyList<Corrective_Assign_Action>> Inc_Action_Closure_Get_All(Corrective_Assign_Action entity);

        public Task<M_Return_Message> Inc_Add_Corrective_Action(Add_Corrective_Action entity);

        public Task<IReadOnlyList<Evidence_Upload_Photos>> Incident_Closure_Evidence(Corrective_Assign_Action entity);

        public Task<M_Return_Message> Update_Corrective_Assign_Action(Corrective_Assign_Action entity);

        public Task<IReadOnlyList<Incident_Update_History>> Incident_Status_History(M_Incident_Report entity);

        public Task<M_Return_Message> IncidentStatusUpdate_IsReq(M_Incident_Report entity);

        public Task<M_Return_Message> Inc_AddReject_Reason_Action(M_Incident_Notification_Reject entity);

        public Task<M_Return_Message> Update_Corrective_Assign_Status(Evidence_Upload_Photos entity);

        public Task<M_Return_Message> Re_Assign_Corrective_Assign_Action(Corrective_Assign_Action entity);

        public Task<IReadOnlyList<Corrective_Assign_Action>> Action_Closure_Get_All_Approval(Corrective_Assign_Action entity);

        public Task<Notification_Dashboard_Count> Get_Dashboard(M_Incident_Report entity);

        public Task<M_Return_Message> IncidentNotificationAdd(M_Investigation_Report_Add entity);

        public Task<IReadOnlyList<M_Incident_Report>> IncidentNotificationCardView(M_Incident_Report entity);
    }
}
