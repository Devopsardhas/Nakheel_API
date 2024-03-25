using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmergencyAlert :IGenericRepo<EMR_Alert>
    {
        public Task<IReadOnlyList<EMR_Alert>> Alert_GetAll(DataTableAjaxPostModel entity);
        public Task<EMR_Alert> Alert_GetById(Drill_Alert_Param entity);
        public Task<M_Return_Message> Alert_Spot_Delete(Drill_Alert_Param entity);
        public Task<List<Alert_Spot>> Alert_Spot_GetBy_Mitig_ID(Drill_Alert_Param entity);
        public Task<M_Return_Message> Alert_Spot_Reject_Add(EMR_Reject entity);
        public Task<M_Return_Message> Alert_Spot_Approve_Add(EMR_Reject entity);

        #region Emergency Checklist 
        public Task<IReadOnlyList<EMR_Alert_CHK>> Alert_CHK_GetAll();
        public Task<M_Return_Message> Alert_CHK_Add(List<EMR_Alert_CHK> entity);
        public Task<List<EMR_Alert_CHK>> Alert_CHK_GetByID(EMR_Alert_CHK entity);
        public Task<M_Return_Message> Alert_CHK_Delete(EMR_Alert_CHK entity);
        #endregion
    }
}
