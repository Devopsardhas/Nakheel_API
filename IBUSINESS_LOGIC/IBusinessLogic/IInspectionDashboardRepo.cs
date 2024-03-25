using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IInspectionDashboardRepo : IGenericRepo<M_InspectionDashboard>
    {
        public Task<IReadOnlyList<M_Zone_Master>> Insp_Dash_Zone_GetAll(Insp_Dash_ZoneWise Login);
        public Task<IReadOnlyList<M_Community_Master>> Insp_Dash_CommunityByZone(M_Community_Master entity);
        public Task<IReadOnlyList<M_Building_List>> Insp_Dash_Building_byZone(M_Building_Master entity);
        public Task<IReadOnlyList<Insp_Dash_ZoneWise>> Insp_Dash_Filter_HSETeam_GetAll();
        public Task<M_InspectionDashboard> Insp_Dashboard(DashboardParam entity);
        public Task<M_InspectionDashboard> Insp_Dash_Cat_Onchange(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Sch_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Walk_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Type_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Service_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Insp_Main_Dash_Card_View_Data(DashboardParam entity);
    }
}
