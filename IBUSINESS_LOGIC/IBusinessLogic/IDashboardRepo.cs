using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IDashboardRepo : IGenericRepo<DashboardGraphModel>
    {
        public Task<Incident_Dashboard> Incident_Dashboard(DashboardParam entity);
        public Task<Incident_Dashboard_New> Incident_Dashboard_New(DashboardParam entity);
        public Task<IReadOnlyList<M_Incident_Report>> Incident_Dashboard_Card_View(Dashboard_Table_View_Param entity);
        public Task<IReadOnlyList<DashboardGraphModel>> Inc_Dash_Card_View(Dashboard_Table_View_Param entity);
        public Task<Observation_Dashboard> Get_Observation_Dashboard(DashboardParam entity);
        public Task<IReadOnlyList<M_Incident_Observation_Report>> Observation_Dashboard_Card_View(Dashboard_Table_View_Param entity);
    }
}
