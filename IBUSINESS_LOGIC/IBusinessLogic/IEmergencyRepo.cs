using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmergencyRepo : IGenericRepo<M_Emer_Mitigation_Add> 
    {
        public Task<IReadOnlyList<M_Emer_Mitigation_Add>> GetAll_Emer_Miti(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Emer_Miti(M_Emer_Mitigation_Add entity);
        public Task<M_Emer_Mitigation_Add> Emer_Miti_GetById(M_Emer_Mitigation_Add entity);
        public Task<M_Return_Message> UpdateEmergency_MitigationStatus(Emergency_Mitigation_Update_History entity);


        public Task<IReadOnlyList<Emergency_Alert_Master>> GetAll_Emer_Alert();
        public Task<M_Return_Message> Add_Emer_Alert(Emergency_Alert_Master entity);
        public Task<Emergency_Alert_Master> Emer_Alert_GetById(Emergency_Alert_Master entity);
        public Task<M_Return_Message> UpdateEmer_Alert(Emergency_Alert_Master entity);
    }
}
