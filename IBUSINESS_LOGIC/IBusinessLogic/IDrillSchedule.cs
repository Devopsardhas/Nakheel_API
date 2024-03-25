using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IDrillSchedule : IGenericRepo<Drill_Schedule>
    {
        public Task<IReadOnlyList<Drill_Schedule>> Drill_Schedule_GetAll(DataTableAjaxPostModel entity);
        public Task<IReadOnlyList<Drill_Schedule>> Drill_Action_GetAll(DataTableAjaxPostModel entity);
        public Task<Drill_Sch_Assignee> Drill_Sch_Get_Assignee(Drill_Schedule_Param entity);
        public Task<M_Return_Message> Drill_Sch_Update_Status(Drill_Schedule_Param entity);
        public Task<M_Return_Message> Drill_Sch_Update_Action(Drill_Action_Param entity);
        public Task<M_Return_Message> Drill_Sch_Update_IMP_Act(Drill_Action_Param entity);
        public Task<Get_All_DrillSCH> Drill_Sch_Get_Details(Drill_Schedule_Param entity);
        public Task<Get_All_DrillSCH> Drill_Sch_Get_Actions(Drill_Schedule_Param entity);
        public Task<M_Return_Message> Drill_Sch_Add_Fire(Drill_Fire entity);
        public Task<M_Return_Message> Drill_Sch_Add_Closure(Improvement_Act entity);
        public Task<M_Return_Message> Drill_Sch_Add_Fire_Obsr(Drill_Fire_Obsr entity);
        public Task<M_Return_Message> Drill_Sch_Add_Cm_Drill(Drill_CommonFRM entity);
        public Task<M_Return_Message> Update_Reject_Status(Drill_REJ entity);
        public Task<M_Return_Message> Update_Photo_Status(Drill_Schedule_Param entity);
        public Task<M_Return_Message> Update_Video_Status(Drill_Schedule_Param entity);
        public Task<M_Return_Message> Reassign_Status(Improvement_Act entity);
    }
}
