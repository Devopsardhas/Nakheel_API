using Microsoft.AspNetCore.Http;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IHandOverInspectionRepo : IGenericRepo<M_Insp_HandOver>
    {
        #region[HandOver Inspection]
        public Task<IReadOnlyList<M_Insp_HandOver>> HandOver_Building_GetAllAsync(DataTableAjaxPostModel entity);
        //public Task<M_Insp_HandOver> Insp_HandOver_Building_Qn_GetAll(M_Insp_HandOver entity);
        public Task<IReadOnlyList<M_Insp_HandOver_Questionnaires>> Insp_HandOver_Building_Qn_GetAll(M_Insp_HandOver entity);
        public Task<M_Return_Message> Update_HndOver_Building_Pending(M_Insp_HandOver entity);
        public Task<M_Return_Message> Update_HndOver_Bldg_Qns_Approval(M_Insp_HandOver entity);
        public Task<M_Return_Message> HndOver_Insp_Reject(M_Insp_HndOver_Assign_Action entity);
        public Task<M_Insp_HandOver> Get_HndOver_Bldg_Qns_View(M_Insp_HandOver entity);
        public Task<M_Return_Message> HndOver_Building_Assign_Action(M_Insp_HndOver_Assign_Action entity);
        public Task<M_Return_Message> Add_HndOver_Bldg_Closure_Action(M_Insp_HndOver_Assign_Action entity);
        //public Task<IReadOnlyList<M_Insp_HandOver>> HandOver_Infrastructure_GetAllAsync(DataTableAjaxPostModel entity);
        public Task<IReadOnlyList<M_Insp_HndOver_Assign_Action>> HandOver_Action_Closure_GetAll(M_Insp_HndOver_Assign_Action entity);
        public Task<M_Insp_HandOver> HandOver_Closure_GetById(M_Insp_HndOver_Assign_Action entity);
        public Task<M_Return_Message> HandOver_Closure_Action_Approval(M_Insp_HndOver_Assign_Action entity);
        public Task<M_Return_Message> HandOver_Closure_Action_Reject(M_Insp_HndOver_Assign_Action entity);
        #endregion
        #region[Health & Safety Inspection]
        public Task<M_Return_Message> AddAsync_HealthSafety(M_Insp_HealthSafety_Master entity);
        public Task<IReadOnlyList<M_Insp_HealthSafety_Master>> HealthSafety_GetAllAsync(DataTableAjaxPostModel entity);
        public Task<M_Insp_HealthSafety_Master> GetByIdAsync_HealthSafety(M_Insp_HealthSafety_Master entity);
        public Task<M_Return_Message> Update_HealthSafety_Building_Pending(M_Insp_HealthSafety_Master entity);
        public Task<IReadOnlyList<M_Insp_HealthSafety_Questionnaires>> Insp_HealthSafety_CheckList_Qn_GetAll(M_Insp_HealthSafety_Master entity);
        public Task<M_Insp_HealthSafety_Master> Insp_HealthSafety_Qns_GetAll(M_Insp_HealthSafety_Questionnaires entity);
        public Task<M_Return_Message> AddAsync_Qns_HealthSafety(M_Insp_HealthSafety_Master entity);
        public Task<M_Insp_HealthSafety_Master> Get_HealthSafety_Bldg_Qns_View(M_Insp_HealthSafety_Master entity);
        public Task<M_Return_Message> Update_HealthSafety_Bldg_Qns_Approval(M_Insp_HealthSafety_Master entity);
        public Task<M_Return_Message> HealthSafety_Insp_Reject(M_Insp_HealthSafety_Assign_Team entity);
        public Task<M_Return_Message> Add_HealthSafety_Assign_Team(M_Insp_HealthSafety_Assign_Team entity);
        public Task<M_Return_Message> HealthSafety_Closure_Action_Add(M_Insp_HealthSafety_Assign_Team entity);
        public Task<IReadOnlyList<M_Insp_HealthSafety_Assign_Team>> HealthSafety_Action_Closure_GetAll(M_Insp_HealthSafety_Assign_Team entity);
        public Task<M_Insp_HealthSafety_Master> HealthSafety_Closure_GetById(M_Insp_HealthSafety_Assign_Team entity);
        public Task<M_Return_Message> HealthSafety_Closure_Action_Approval(M_Insp_HealthSafety_Assign_Team entity);
        public Task<M_Return_Message> HealthSafety_Closure_Action_Reject(M_Insp_HealthSafety_Assign_Team entity);
        #endregion
        #region[Service Provider Inspection]
        public Task<M_Return_Message> AddAsync_ServiceProvider(M_Insp_ServiceProvider_Master entity);
        public Task<IReadOnlyList<M_Insp_ServiceProvider_Master>> ServiceProvider_GetAllAsync(DataTableAjaxPostModel entity);
        public Task<M_Insp_ServiceProvider_Master> GetByIdAsync_ServiceProvider(M_Insp_ServiceProvider_Master entity);
        public Task<M_Return_Message> Update_ServiceProvider_Schedule(M_Insp_ServiceProvider_Master entity);
        public Task<M_Insp_ServiceProvider_Master> Insp_ServiceProvider_Qn_GetAll(M_Insp_ServiceProvider_Master entity);
        public Task<M_Return_Message> AddAsync_Qns_ServiceProvider(M_Insp_ServiceProvider_Master entity);
        public Task<M_Return_Message> Insp_ServiceProvider_Qn_HSSETeam(M_Insp_ServiceProvider_Master entity);
        public Task<M_Insp_ServiceProvider_Master> Get_ServiceProvider_Qns_View(M_Insp_ServiceProvider_Master entity);
        public Task<M_Return_Message> Update_ServiceProvider_Qns_Approval(M_Insp_Safety_Violation entity);
        public Task<M_Return_Message> ServiceProvider_Insp_Qns_Reject(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<M_Return_Message> Add_ServiceProvider_Assign_Team(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<M_Return_Message> ServiceProvider_Closure_Action_Add(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<IReadOnlyList<M_Insp_ServiceProvider_Assign_Team>> ServiceProvider_Action_Closure_GetAll(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<M_Insp_ServiceProvider_Master> ServiceProvider_Closure_GetById(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<M_Return_Message> ServiceProvider_Closure_Action_Approval(M_Insp_ServiceProvider_Assign_Team entity);
        public Task<M_Return_Message> ServiceProvider_Closure_Action_Reject(M_Insp_ServiceProvider_Assign_Team entity);
        #endregion
        #region[Fire & Life Safety Inspection]
        public Task<IReadOnlyList<M_Insp_FireLifeSafety_Questionnaires>> Insp_FireLifeSafety_Qns_GetAll(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Return_Message> AddAsync_FireLifeSafety(M_Insp_FireLifeSafety_Master entity);
        public Task<IReadOnlyList<M_Insp_FireLifeSafety_Master>> FireLifeSafety_GetAllAsync(DataTableAjaxPostModel entity);
        public Task<M_Insp_FireLifeSafety_Master> Insp_FireLifeSafety_GetByID(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Return_Message> Update_FireLifeSafety_Schedule(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Insp_FireLifeSafety_Master> Insp_FireLifeSafetyCS_Qns_GetAll(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Return_Message> AddAsync_Qns_FireLifeSafety(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Insp_FireLifeSafety_Master> Get_FireLifeSafety_Qns_View(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Return_Message> Update_FireLifeSafety_Qns_Approval(M_Insp_FireLifeSafety_Master entity);
        public Task<M_Return_Message> Add_FireLifeSafety_Assign_Team(M_Insp_FireLifeSafety_Assign_Action entity);
        public Task<M_Return_Message> FireLifeSafety_Closure_Action_Add(M_Insp_FireLifeSafety_Assign_Action entity);
        public Task<IReadOnlyList<M_Insp_FireLifeSafety_Master>> FireLifeSafety_Action_Closure_GetAll(M_Insp_FireLifeSafety_Assign_Action entity);
        public Task<M_Insp_FireLifeSafety_Master> FireLifeSafety_Closure_GetById(M_Insp_FireLifeSafety_Assign_Action entity);
        public Task<M_Return_Message> FireLifeSafety_Closure_Action_Approval(M_Insp_FireLifeSafety_Assign_Action entity);
        public Task<M_Return_Message> FireLifeSafety_Closure_Action_Reject(M_Insp_FireLifeSafety_Assign_Action entity);
        #endregion
        public List<string> UploadImage(List<IFormFile> file);
        public List<string> Upload_Picture(List<IFormFile> file);
    }
}
