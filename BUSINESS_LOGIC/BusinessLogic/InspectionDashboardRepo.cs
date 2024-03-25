using BUSINESS_LOGIC.ErrorLogs;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IBUSINESS_LOGIC.IBusinessLogic;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class InspectionDashboardRepo : IInspectionDashboardRepo
    {
        private readonly IConfiguration configuration;
        public InspectionDashboardRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<M_Return_Message> AddAsync(M_InspectionDashboard entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> DeleteAsync(M_InspectionDashboard entity)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<M_InspectionDashboard>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<M_InspectionDashboard> GetByIdAsync(M_InspectionDashboard entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> UpdateAsync(M_InspectionDashboard entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<M_Zone_Master>> Insp_Dash_Zone_GetAll(Insp_Dash_ZoneWise Login)
        {
            try
            {
                string procedure = "sp_Insp_Dash_Dropdown_Zone_Master_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Login_Id = Login.Value,
                    };
                    return (await connection.QueryAsync<M_Zone_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Zone GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Community_Master>> Insp_Dash_CommunityByZone(M_Community_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_Dash_Dropdown_Community_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Login_Id = entity.Business_Unit_Id,
                    };
                    return (await connection.QueryAsync<M_Community_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Dash_CommunityByZone";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Building_List>> Insp_Dash_Building_byZone(M_Building_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_Dash_Dropdown_Building_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Login_Id = entity.Unique_Id,
                    };
                    return (await connection.QueryAsync<M_Building_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Dash_Building_byZone";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        //Discussion Date : 14-12-2023
        // Both : 
        //Leadership Tour -- Sch Yes -- Walkin Yes
        //Health & Safety -- Sch Yes -- Walkin Yes
        //Fire & Life Safety  -- Sch Yes -- Walkin Yes

        //Sechdule :
        //Joint Inspection -- Sch Yes -- Walkin NO
        //Service Provider -- Sch Yes -- Walkin No

        //Walkin :
        //Spot Inspection   -- Sch NO -- Walkin Yes
        //Handover Inspection -- Sch NO -- Walkin Yes
        public async Task<M_InspectionDashboard> Insp_Dashboard(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Management_Count_GetbyId";
                string procedure2 = "sp_Dash_Insp_Inspection_Type_Count_GetbyId";
                string procedure3 = "sp_Dash_Insp_ZoneWise_Graph";
                string procedure4 = "sp_Dash_Insp_CommunityWise_Graph";
                string procedure5 = "sp_Dash_Insp_CategoryWise_Graph";
                string procedure6 = "sp_Dash_Insp_SubCategoryWise_Graph";
                string procedure7 = "sp_Dash_Insp_ServiceProvider_Count_GetbyId";
                string procedure8 = "sp_Dash_Insp_Management_Graph_GetbyId";
                string procedure9 = "sp_Dash_Insp_Management_Graph_Yearly_GetbyId";
                string procedure10 = "sp_Dash_Insp_Management_Schedule_Count_GetbyId";
                string procedure11 = "sp_Dash_Insp_Management_WalkIn_Count_GetbyId";
                string procedure12 = "sp_Dash_Insp_HSE_Officer_Wise_Graph";
                var parameter = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    Insp_Dash_Management? Management_Count = new Insp_Dash_Management();
                    Insp_Dash_Types_Insp? Type_Of_Insp_Count = new Insp_Dash_Types_Insp();
                    List<Insp_Dash_ZoneWise_Graph>? ZoneWise_Count = new List<Insp_Dash_ZoneWise_Graph>();
                    List<Insp_Dash_ZoneWise_Graph>? HSE_Officer_Count = new List<Insp_Dash_ZoneWise_Graph>();
                    List<Insp_Dash_ZoneWise>? CommunityWise_Count = new List<Insp_Dash_ZoneWise>();
                    List<Insp_Dash_ZoneWise>? CategoryWise_Count = new List<Insp_Dash_ZoneWise>();
                    List<Insp_Dash_ZoneWise>? SubCategoryWise_Count = new List<Insp_Dash_ZoneWise>();
                    Insp_Dash_Management? ServiceProvider_Count = new Insp_Dash_Management();
                    List<Insp_Dash_Management_Graph>? Management_Graph = new List<Insp_Dash_Management_Graph>();
                    List<Insp_Dash_Management_Year_Graph>? Management_Year_Graph = new List<Insp_Dash_Management_Year_Graph>();
                    Insp_Dash_Management? Mgmt_Schedule = new Insp_Dash_Management();
                    Insp_Dash_Management? Mgmt_WalkIn = new Insp_Dash_Management();
                    Management_Count = (await connection.QueryAsync<Insp_Dash_Management>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    Type_Of_Insp_Count = (await connection.QueryAsync<Insp_Dash_Types_Insp>(procedure2, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    ZoneWise_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise_Graph>(procedure3, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    CommunityWise_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise>(procedure4, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    CategoryWise_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise>(procedure5, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    SubCategoryWise_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise>(procedure6, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    ServiceProvider_Count = (await connection.QueryAsync<Insp_Dash_Management>(procedure7, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    Management_Graph = (await connection.QueryAsync<Insp_Dash_Management_Graph>(procedure8, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Management_Year_Graph = (await connection.QueryAsync<Insp_Dash_Management_Year_Graph>(procedure9, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Mgmt_Schedule = (await connection.QueryAsync<Insp_Dash_Management>(procedure10, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    Mgmt_WalkIn = (await connection.QueryAsync<Insp_Dash_Management>(procedure11, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    HSE_Officer_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise_Graph>(procedure12, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    M_InspectionDashboard Dashboard = new M_InspectionDashboard()
                    {
                        Insp_Dash_Management_Count = Management_Count,
                        Insp_Dash_Types_Insp_Count = Type_Of_Insp_Count,
                        Insp_Dash_ZoneWise_Count = ZoneWise_Count,
                        Insp_Dash_CommunityWise_Count = CommunityWise_Count,
                        Insp_Dash_CategoryWise_Count = CategoryWise_Count,
                        Insp_Dash_SubCategoryWise_Count = SubCategoryWise_Count,
                        Insp_Dash_ServiceProvider_Count = ServiceProvider_Count,
                        Insp_Dash_Management_Graph = Management_Graph,
                        Insp_Dash_Management_Year_Graph = Management_Year_Graph,
                        Insp_Dash_Mgmt_Schedule_Count = Mgmt_Schedule,
                        Insp_Dash_Mgmt_WalkIn_Count = Mgmt_WalkIn,
                        Insp_Dash_HSE_Officer_Count = HSE_Officer_Count,
                    };
                    return Dashboard;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_InspectionDashboard> Insp_Dash_Cat_Onchange(DashboardParam entity)
        {
            try
            {
                string procedure6 = "sp_Dash_Insp_SubCategoryWise_Onchange_Graph";
                var parameter = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    List<Insp_Dash_ZoneWise>? SubCategoryWise_Count = new List<Insp_Dash_ZoneWise>();
                    SubCategoryWise_Count = (await connection.QueryAsync<Insp_Dash_ZoneWise>(procedure6, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    M_InspectionDashboard Dashboard = new M_InspectionDashboard()
                    {
                        Insp_Dash_SubCategoryWise_Count = SubCategoryWise_Count,
                    };
                    return Dashboard;
                }

            }
            catch (Exception ex)
            {

                string Repo = "Insp_Dash_Cat_Onchange";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Mgmt_Card_View_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    Card_Access = entity.Card_Access,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Insp_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Sch_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Mgmt_Card_View_Sch_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    Card_Access = entity.Card_Access,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Insp_Sch_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Walk_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Mgmt_Card_View_Walk_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    Card_Access = entity.Card_Access,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Insp_Walk_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Type_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Mgmt_Card_View_Type_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    Card_Access = entity.Card_Access,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Insp_Type_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Get_Insp_Service_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Insp_Mgmt_Card_View_Service_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date,
                    Remarks = entity.Remarks,
                    Card_Access = entity.Card_Access,
                    If_HSE_Team = entity.If_HSE_Team,
                    HSE_Team_Id = entity.HSE_Team_Id,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Insp_Service_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_ZoneWise>> Insp_Dash_Filter_HSETeam_GetAll()
        {
            try
            {
                string procedure = "sp_Insp_Dash_Filter_HSETeam_Dropdown_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_ZoneWise>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Dash_Filter_HSETeam_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Dash_Card_View_Data>> Insp_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Main_Insp_Mgmt_Card_View_Sch_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Card_Access = entity.Card_Access,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Insp_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Main_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

    }
}
