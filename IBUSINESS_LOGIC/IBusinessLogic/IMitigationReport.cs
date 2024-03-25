using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IMitigationReport:IGenericRepo<Mitigation_Report>
    {
        public Task<Mitigation_Report> GetByIdAsync(Trigger_Param entity);
        public Task<IReadOnlyList<Mitigation_Report>> GetAllAsync(Mitigation_Param entity);
        public Task<List<Dropdown_Values>> Get_All_REF_ID();
    }
}
