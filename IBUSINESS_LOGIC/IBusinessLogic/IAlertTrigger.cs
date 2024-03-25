using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAlertTrigger :IGenericRepo<Trigger>
    {
        public Task<IReadOnlyList<Trigger>> AlertTRG_GetAll(DataTableAjaxPostModel entity);
        public Task<IReadOnlyList<TRIG_Assignee>> Alert_Assignee_GetAll(DataTableAjaxPostModel entity);
        public Task<Trigger> GetByIdAsync(Trigger_Param entity);
        public Task<Drill_Sch_Assignee> Get_Mitigation_Assignee(Trigger_Param entity);
        public Task<M_Return_Message> Add_Assignee(TRIG_Assignee entity);
        public Task<Trigger> Alert_Act_GetById(Trigger_Param entity);
        public Task<M_Return_Message> Add_Assignee_Checklist(ChecklistMap entity);
        public Task<M_Return_Message> Update_Assignee_Checklist(ChecklistMap entity);
        public Task<List<ChecklistMap>> Checklist_GetBy_SpotId(Trigger_Param entity);
        public Task<List<Dropdown_Values>> Get_All_Emergency_Type();
        public Task<M_Return_Message> Update_Checklist_Status(Trigger_Param entity);
        public Task<M_Return_Message> AddAsync(List<Trigger> entity);
        public Task<M_Return_Message> Alert_Trig_Reject(TRIG_Reject entity);
        public Task<M_Return_Message> Alert_Trig_Rej_Update(TRIG_Reject entity);
    }
}
