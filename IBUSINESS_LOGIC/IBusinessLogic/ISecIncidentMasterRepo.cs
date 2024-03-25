using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface ISecIncidentMasterRepo:IGenericRepo<M_Sec_Inc_Category_Master>
    {
        #region [Injury Type Master]
        public Task<IReadOnlyList<M_Sec_Inc_Type_Master>> Sec_Inc_Type_GetAllAsync();
        public Task<M_Return_Message> Sec_Inc_Type_AddAsync(M_Sec_Inc_Type_Master entity);
        public Task<M_Return_Message> Sec_Inc_Type_UpdateAsync(M_Sec_Inc_Type_Master entity);
        public Task<M_Sec_Inc_Type_Master> Sec_Inc_Type_GetByIdAsync(M_Sec_Inc_Type_Master entity);
        public Task<M_Return_Message> Sec_Inc_Type_DeleteAsync(M_Sec_Inc_Type_Master entity);
        #endregion
        #region [Category Master]
        public Task<IReadOnlyList<M_Sub_Security_Incident_Master>> Sub_Security_GetAllAsync();
        public Task<IReadOnlyList<M_Sec_Incident_Report>> Sub_SecurityCategory_GetId(M_Sub_Security_Incident_Master entity);
        public Task<IReadOnlyList<M_Sec_Incident_Report>> Sub_SecDeptSection_GetId(M_Sec_Incident_Report entity);
        public Task<IReadOnlyList<M_Sec_Incident_Report>> Sec_Get_Location(M_Sec_Incident_Report entity);
        public Task<M_Return_Message> Sub_Security_AddAsync(M_Sub_Security_Incident_Master entity);
        public Task<M_Return_Message> Sub_Security_UpdateAsync(M_Sub_Security_Incident_Master entity);
        public Task<M_Sub_Security_Incident_Master> Sub_Security_GetByIdAsync(M_Sub_Security_Incident_Master entity);
        public Task<M_Return_Message> Sub_Security_DeleteAsync(M_Sub_Security_Incident_Master entity);
        public Task<IReadOnlyList<M_Sub_Security_Incident_Master>> Sub_Security_GetAllbyCatid(M_Sub_Security_Incident_Master entity);
        #endregion
        #region[Security Incident]
        public Task<IReadOnlyList<M_Sec_Incident_Report>> Get_All_Security_Inc_req(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Security_Inc_Report(M_Sec_Incident_Report entity);
        public Task<M_Return_Message> Sec_Inc_Report_Update(M_Sec_Incident_Report entity);
        public Task<M_Sec_Incident_Report> View_Security_Incident(M_Sec_Incident_Report entity);
        public Task<M_Return_Message> Add_Invest_Finding_Details(M_Sec_Investigation_Find_List entity);
        public Task<M_Return_Message> Security_Inc_ActionTaken_AddNew(M_Sec_Incident_ActionTaken entity);
        public Task<M_Return_Message> SecurityIncActionStatus(M_Sec_Incident_Report entity);
        public Task<M_Return_Message> Security_Inc_FollowUpAction_Add(M_Sec_Incident_FollowUpAction entity);
        public Task<IReadOnlyList<M_Sec_Incident_Report>> Get_Filter_Sec_Inc_List(M_Sec_Incident_Report entity);
        #endregion
    }

}
