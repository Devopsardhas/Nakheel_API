using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IMasterCommunityRepo:IGenericRepo<M_MasterCommunity_Master>
    {
        public Task<M_Return_Message> SubDeleteAsync(M_MasterCommunity_List entity);
        public Task<M_Return_Message> CheckMasterCommunity_Name(M_MasterCommunity_List entity);
        public Task<IReadOnlyList<M_MasterCommunity_List>> Get_All_MasterCommunity_byZone(M_MasterCommunity_Master entity);

        public Task<IReadOnlyList<Level_Master>> Get_All_LevelM();
        public Task<M_Return_Message> LevelM_Delete(Level_Master entity);
        public Task<M_Return_Message> LevelM_Add(Level_Master entity);
        public Task<Level_Master> Get_ById_LevelM(Level_Master entity);
        public Task<M_Return_Message> LevelM_Update(Level_Master entity);

        public Task<IReadOnlyList<Crisis_Team_Master>> Get_All_Crisis();
        public Task<M_Return_Message> Crisis_Delete(Crisis_Master entity);
        public Task<M_Return_Message> Crisis_Add(Crisis_Team_Master entity);
        public Task<Crisis_Master> Get_ById_Crisis(Crisis_Master entity);
        public Task<M_Return_Message> Crisis_Update(Crisis_Master entity);
        public Task<Crisis_Team_Master> Crisis_View(Crisis_Team_Master entity);
        public Task<IReadOnlyList<Crisis_Team_Master>> Crisis_Viewby_Emp(Crisis_Team_Master entity);
        public Task<IReadOnlyList<Crisis_SubEmp_Master>> Crisis_Get_Emp_Level(Crisis_Master entity);

        public Task<IReadOnlyList<Emergency_Category_Master>> Get_All_Emergency_Category();
        public Task<M_Return_Message> Emergency_Category_Delete(Emergency_Category_Master entity);
        public Task<M_Return_Message> Emergency_Category_Add(Emergency_Category_Master entity);
        public Task<Emergency_Category_Master> Get_ById_Emergency_Category(Emergency_Category_Master entity);
        public Task<M_Return_Message> Emergency_Category_Update(Emergency_Category_Master entity);

        public Task<IReadOnlyList<Service_Provider_Scope_of_Work>> Get_All_Scope_of_Work();
        public Task<M_Return_Message> Scope_of_Work_Delete(Service_Provider_Scope_of_Work entity);
        public Task<M_Return_Message> Scope_of_Work_Add(Service_Provider_Scope_of_Work entity);
        public Task<Service_Provider_Scope_of_Work> Get_ById_Scope_of_Work(Service_Provider_Scope_of_Work entity);
        public Task<M_Return_Message> Scope_of_Work_Update(Service_Provider_Scope_of_Work entity);

        public Task<IReadOnlyList<ERT_Team_Details>> Get_All_ERT_Team_Details();
        public Task<M_Return_Message> ERT_Team_Details_Delete(ERT_Team_Details entity);
        public Task<M_Return_Message> ERT_Team_Details_Add(ERT_Team_Details entity);
        public Task<ERT_Team_Details> Get_ById_ERT_Team_Details(ERT_Team_Details entity);
        public Task<M_Return_Message> ERT_Team_Details_Update(ERT_Team_Details entity);
        public Task<IReadOnlyList<ERT_Team_Details>> Get_All_ERT_Team_Details_Filter(ERT_Team_Details entity);

        public Task<IReadOnlyList<SafetyPer_Dash_Card_View_Data>> SafetyPer_Main_Dash_Card_View_Data(DashboardParam entity);
        public Task<IReadOnlyList<Audit_Dash_Card_View_Data>> Audit_Main_Dash_Card_View_Data(DashboardParam entity);
        

        #region [ERT TEAM DETAILS MASTERS ONLY --GET ALL]
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Department();
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Building_No();
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_FloorNo();
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Role();
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Training_Status();
        public Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Type();
        #endregion

    }
}
