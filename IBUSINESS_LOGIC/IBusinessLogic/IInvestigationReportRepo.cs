using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IInvestigationReportRepo : IGenericRepo<M_Investigation_Report>
    {
        public Task<IReadOnlyList<M_Incident_Report>> IncNotificationGetAll(DataTableAjaxPostModel entity);
    }
}
