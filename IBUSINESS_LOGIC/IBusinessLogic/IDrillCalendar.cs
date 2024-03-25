using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IDrillCalendar :IGenericRepo<Drill_Calendar>
    {
        Task<Get_Drill_Calendar> GetAllAsync(Drill_Calendar_Param _Param);
    }
}
