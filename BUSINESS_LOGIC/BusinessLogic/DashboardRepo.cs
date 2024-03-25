using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
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
using System.Collections;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class DashboardRepo : IDashboardRepo
    {
        private readonly IConfiguration configuration;

        public DashboardRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #region [Basic Interface]
        public Task<M_Return_Message> AddAsync(DashboardGraphModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(DashboardGraphModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DashboardGraphModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<DashboardGraphModel> GetByIdAsync(DashboardGraphModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(DashboardGraphModel entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Incident Dashboard] 
        public async Task<Incident_Dashboard_New> Incident_Dashboard_New(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Inc_Zone";
                //string procedure2 = "sp_Dash_Inc_Injury_NonInjury";
                //string procedure3 = "sp_Dash_Inc_Category_Count";
                string procedure4 = "sp_Dash_Classification";
                //string procedure5 = "sp_Dash_Inc_Record_Non_Record";
                string procedure6 = "sp_Dash_Inc_Relation_NCM";
                //string procedure7 = "sp_Dash_Inc_Incident_Statistics";
                string procedure8 = "sp_Dash_Inc_Type_Counts";
                //string procedure9 = "sp_Dash_Inc_Counts_New";
                string procedure10 = "sp_Dash_Inc_Building_Counts";
                string procedure11 = "sp_Dash_Inc_Management_Count";
                string procedure12 = "sp_Dash_Inc_Trends_Statistics";
                string procedure13 = "sp_Dash_Inc_Trends_Statistics_Yearwise";
                string procedure14 = "sp_Dash_Inc_Zone_Dropdown";
                string procedure15 = "sp_Dash_Inc_Community_Dropdown";
                string procedure16 = "sp_Dash_Inc_Building_Dropdown";
                string procedure17 = "sp_Dash_CommunityWise_Data";
                string procedure18 = "sp_Dash_Incident_Yearwise";
                string procedure19 = "sp_Dash_Inc_Incident_Severity_Rate";
                string procedure20 = "sp_Dash_Inc_Incident_Sever_MonthWise";
                var parameter = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_Date = entity.To_date
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    IReadOnlyList<Incident_Management_Count>? Total_Inc_Manage_Count = new List<Incident_Management_Count>();
                    //IReadOnlyList<DashboardGraphModel>? Injury_NonInjury_List = new List<DashboardGraphModel>();
                    IReadOnlyList<Inc_TotalCount_YearWise>? Classification_List = new List<Inc_TotalCount_YearWise>();
                    //IReadOnlyList<DashboardGraphModel>? Recordable_NonRecord_List = new List<DashboardGraphModel>();
                    IReadOnlyList<Inc_Zone_Count>? Zone_Count_List = new List<Inc_Zone_Count>();
                    //IReadOnlyList<Inc_Category_Count>? Categroy_Count_List = new List<Inc_Category_Count>();
                    IReadOnlyList<Inc_RelationTo_NCM>? Related_NCM_List  = new List<Inc_RelationTo_NCM>();
                    //IReadOnlyList<DashboardGraphModel>? Incident_Statistics_List = new List<DashboardGraphModel>();
                    IReadOnlyList<Incident_Dashboard_Count> Incident_Type_List = new List<Incident_Dashboard_Count>();
                    //IReadOnlyList<Incident_Dashboard_Count> Total_Count_List = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> Total_Incident_Count_List = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> Total_Inc_Closed_Count_List = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> Total_Inc_Opened_Count_List = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> Total_Inc_Approve_Pending_List = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count>? Zone_List_Dropdown = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count>? Commnuity_List_Dropdown = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count>? Buidling_List_Dropdown = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<DashboardGraphModel>? Incident_Trend_Statistics_List = new List<DashboardGraphModel>();
                    IReadOnlyList<Inc_TotalCount_YearWise>? Total_Inc_count_YearList = new List<Inc_TotalCount_YearWise>();
                    IReadOnlyList<DashboardGraphModel>? Community_List = new List<DashboardGraphModel>();
                    IReadOnlyList<Inc_TotalCount_YearWise>? Incident_TotalCount = new List<Inc_TotalCount_YearWise>();
                    IReadOnlyList<Inc_Serverit_Count>? Total_INC_Ser_Count = new List<Inc_Serverit_Count>();
                    IReadOnlyList<DashboardGraphModel>? Inc_Sev_Month_List = new List<DashboardGraphModel>();

                    //Injury_NonInjury_List = (await connection.QueryAsync<DashboardGraphModel>(procedure2, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Classification_List = (await connection.QueryAsync<Inc_TotalCount_YearWise>(procedure4, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Recordable_NonRecord_List = (await connection.QueryAsync<DashboardGraphModel>(procedure5, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Zone_Count_List = (await connection.QueryAsync<Inc_Zone_Count>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Categroy_Count_List = (await connection.QueryAsync<Inc_Category_Count>(procedure3, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Related_NCM_List = (await connection.QueryAsync<Inc_RelationTo_NCM>(procedure6, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Incident_Statistics_List = (await connection.QueryAsync<DashboardGraphModel>(procedure7, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Incident_Type_List= (await connection.QueryAsync<Incident_Dashboard_Count>(procedure8, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Total_Count_List = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure9, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Incident_Count_List = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure10, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Zone_List_Dropdown = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure14, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Commnuity_List_Dropdown = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure15, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Buidling_List_Dropdown = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure16, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Inc_Manage_Count = (await connection.QueryAsync<Incident_Management_Count>(procedure11, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Incident_Trend_Statistics_List = (await connection.QueryAsync<DashboardGraphModel>(procedure12, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Inc_count_YearList = (await connection.QueryAsync<Inc_TotalCount_YearWise>(procedure13, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Community_List = (await connection.QueryAsync<DashboardGraphModel>(procedure17, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Incident_TotalCount = (await connection.QueryAsync<Inc_TotalCount_YearWise>(procedure18, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_INC_Ser_Count = (await connection.QueryAsync<Inc_Serverit_Count>(procedure19, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Inc_Sev_Month_List = ((await connection.QueryAsync<DashboardGraphModel>(procedure20, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList());

                    Incident_Dashboard_New _Dashboard1 = new Incident_Dashboard_New()
                    {
                        Zone_Count_List = Zone_Count_List,
                        //Injury_NonInjury_List = Injury_NonInjury_List,
                        Classification_List = Classification_List,
                        //Recordable_NonRecord_List = Recordable_NonRecord_List,
                        //Categroy_Count_List = Categroy_Count_List,
                        Related_NCM_List = Related_NCM_List,
                        //Incident_Statistics_List = Incident_Statistics_List,
                        Incident_Type_List = Incident_Type_List,
                        //Total_Count_List = Total_Count_List,
                        Total_Incident_Count_List = Total_Incident_Count_List,
                        Zone_List_Dropdown = Zone_List_Dropdown,
                        Commnuity_List_Dropdown = Commnuity_List_Dropdown,
                        Buidling_List_Dropdown = Buidling_List_Dropdown,
                        Total_Inc_Manage_Count = Total_Inc_Manage_Count,
                        Incident_Trend_Statistics_List= Incident_Trend_Statistics_List,
                        Total_Inc_count_YearList  = Total_Inc_count_YearList,
                        Community_List = Community_List,
                        Incident_TotalCount= Incident_TotalCount,
                        Total_INC_Ser_Count= Total_INC_Ser_Count,
                        Inc_Sev_Month_List= Inc_Sev_Month_List,
                    };
                    return _Dashboard1;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<Incident_Dashboard> Incident_Dashboard(DashboardParam entity)
        {
            try
            {
                string procedure_1 = "[sp_Dash_Inc_Category_Graph]";
                string procedure_2 = "[sp_Dash_Inc_Type_Graph]";
                string procedure_3 = "[sp_Dash_Inc_Nature_Injury_Graph]";
                string procedure_4 = "[sp_Dash_Inc_Zone_Graph]";
                string procedure_5 = "[sp_Dash_Inc_NCM_Injured_Person_Graph]";
                string procedure_6 = "[sp_Dash_Inc_Location_Graph]";
                string procedure_7 = "[sp_Dash_Inc_Building_Counts]";
                string procedure_8 = "[sp_Dash_Inc_Type_Counts]";
                string procedure_9 = "[sp_Dash_Inc_Nature_Injury_Counts]";
                string procedure_10 = "[sp_Dash_Inc_Counts]";
                string procedure_11 = "[sp_Dash_Inc_Company_Graph]";
                var param_1 = new
                {
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                };
                var param_2 = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Zone_ID = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_ID = entity.Building_ID,
                    Category_Name = entity.Category_Name,
                    From_Date = entity.From_Date,
                    To_date = entity.To_date,
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    IReadOnlyList<DashboardGraphModel> Graph_Inc_Category = new List<DashboardGraphModel>();
                    IReadOnlyList<DashboardGraphModel> Graph_Inc_Type = new List<DashboardGraphModel>();
                    IReadOnlyList<DashboardGraphModel> Graph_Nature_Injury = new List<DashboardGraphModel>();
                    IReadOnlyList<DashboardGraphModel> Graph_Zone = new List<DashboardGraphModel>();
                    IReadOnlyList<DashboardGraphModel> Graph_NCM_Injured = new List<DashboardGraphModel>();
                    IReadOnlyList<Incident_Dashboard_Count> G_List_Locations = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> G_List_Building = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> G_List_Inc_Type = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> G_List_Inc_Nature_Injury = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<Incident_Dashboard_Count> G_Cards_Inc_Counts = new List<Incident_Dashboard_Count>();
                    IReadOnlyList<DashboardGraphModel> Graph_Inc_Company = new List<DashboardGraphModel>();

                    Graph_Inc_Category = (await connection.QueryAsync<DashboardGraphModel>(procedure_1, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Graph_Inc_Type = (await connection.QueryAsync<DashboardGraphModel>(procedure_2, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Graph_Nature_Injury = (await connection.QueryAsync<DashboardGraphModel>(procedure_3, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Graph_Zone = (await connection.QueryAsync<DashboardGraphModel>(procedure_4, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Graph_NCM_Injured = (await connection.QueryAsync<DashboardGraphModel>(procedure_5, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_List_Locations = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure_6, param_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_List_Building = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure_7, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_List_Inc_Type = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure_8, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_List_Inc_Nature_Injury = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure_9, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_Cards_Inc_Counts = (await connection.QueryAsync<Incident_Dashboard_Count>(procedure_10, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Graph_Inc_Company = (await connection.QueryAsync<DashboardGraphModel>(procedure_11, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    Incident_Dashboard _Dashboard = new Incident_Dashboard()
                    {
                        Graph_Inc_Category = Graph_Inc_Category,
                        Graph_Inc_Type = Graph_Inc_Type,
                        Graph_Nature_Injury = Graph_Nature_Injury,
                        Graph_Zone = Graph_Zone,
                        Graph_NCM_Injured = Graph_NCM_Injured,
                        G_List_Location = G_List_Locations,
                        G_List_Building = G_List_Building,
                        G_List_Inc_Type = G_List_Inc_Type,
                        G_List_Inc_Nature_Injury = G_List_Inc_Nature_Injury,
                        G_Cards_Inc_Counts = G_Cards_Inc_Counts,
                        Graph_Inc_Company = Graph_Inc_Company,
                    };
                    return _Dashboard;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident_Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Incident_Report>> Incident_Dashboard_Card_View(Dashboard_Table_View_Param entity)
        {
            try
            {
                string procedure_1 = "[sp_Dash_Inc_Cards_View_Datas]";
                var param_1 = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Card_View_Id = entity.Card_View_Id,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_date = entity.To_date
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Incident_Report>(procedure_1, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident_Dashboard_Card_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<DashboardGraphModel>> Inc_Dash_Card_View(Dashboard_Table_View_Param entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Inc_MonthWise_Analytics";
                var parameter = new
                {
                    Year = entity.Year,
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Card_View_Id = entity.Card_View_Id,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_date = entity.To_date
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<DashboardGraphModel>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {

                string Repo = "Inc_Dash_Card_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Observation Dashboard] 

        public async Task<Observation_Dashboard> Get_Observation_Dashboard(DashboardParam entity)
        {
            try
            {
                //string procedure_1 = "[sp_Dash_Inc_Category_Graph]";
                //string procedure_4 = "[sp_Dash_Inc_Zone_Graph]";
                //string procedure_5 = "[sp_Dash_Inc_NCM_Injured_Person_Graph]";
                //string procedure_6 = "[sp_Dash_Inc_Location_Graph]";
                //string procedure_7 = "[sp_Dash_Inc_Building_Counts]";
                //string procedure_8 = "[sp_Dash_Inc_Type_Counts]";
                //string procedure_9 = "[sp_Dash_Inc_Nature_Injury_Counts]";
                //string procedure_11 = "[sp_Dash_Inc_Company_Graph]";
                string procedure_1 = "sp_Dashboard_Obs_Zone_Data";
                //string procedure_2 = "sp_Dashboard_Observation_Type_Graph";
                //string procedure_3 = "sp_Dashboard_Observation_Category_Graph";
                string procedure_4 = "sp_Dashboard_Obs_Community_Wise_Data";
                string procedure_5 = "sp_Dashboard_Obs_RaisedBy_Ser_Prov";
                string procedure_6 = "sp_Dashboard_Obs_Raised_Against_By_Ser_Prov";
                string procedure_7 = "sp_Dashboard_Obs_Zone_Empl_Details";
                string procedure_10 = "sp_Dashboard_Observation_Counts";
                var param_1 = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_ID = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date, 
                    To_date = entity.To_date,
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    //IReadOnlyList<Dashboard_Observation_Model> Graph_Obs_Category = new List<Dashboard_Observation_Model>();
                    //IReadOnlyList<Dashboard_Observation_Model> Graph_Zone = new List<Dashboard_Observation_Model>();
                    //IReadOnlyList<Dashboard_Observation_Model> Graph_NCM_Injured = new List<DashboardGraphModel>();
                    //IReadOnlyList<Observation_Dashboard_Count> G_List_Locations = new List<Observation_Dashboard_Count>();
                    //IReadOnlyList<Observation_Dashboard_Count> G_List_Building = new List<Observation_Dashboard_Count>();
                    //IReadOnlyList<Observation_Dashboard_Count> G_List_Obs_Type = new List<Observation_Dashboard_Count>();
                    //IReadOnlyList<Observation_Dashboard_Count> G_List_Inc_Nature_Injury = new List<Observation_Dashboard_Count>();
                    //IReadOnlyList<Dashboard_Observation_Model> Graph_Obs_Company = new List<Dashboard_Observation_Model>();
                    IReadOnlyList<Dashboard_Observation_Model> Graph_Obs_Type = new List<Dashboard_Observation_Model>();
                    IReadOnlyList<Dashboard_Observation_Model> Graph_Obs_Category = new List<Dashboard_Observation_Model>();
                    IReadOnlyList<Observation_Dashboard_Count> G_Cards_Obs_Counts = new List<Observation_Dashboard_Count>();
                    IReadOnlyList<Obs_Dashboard_Count>? Zone_Count_List = new List<Obs_Dashboard_Count>();
                    IReadOnlyList<Dashboard_Observation_Model> Community_Count_List = new List<Dashboard_Observation_Model>();
                    IReadOnlyList<Obs_Dashboard_Count>? Raised_By_Ser_Prov_List = new List<Obs_Dashboard_Count>();
                    IReadOnlyList<Obs_Dashboard_Count>? Raised_By_Against_Ser_Prov_List = new List<Obs_Dashboard_Count>();
                    IReadOnlyList<Obs_Dashboard_Count>? Zone_Base_Emp_Details = new List<Obs_Dashboard_Count>();
                    //Graph_Obs_Category = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_1, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Graph_Zone = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_4, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Graph_NCM_Injured = (await connection.QueryAsync<DashboardGraphModel>(procedure_5, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //G_List_Locations = (await connection.QueryAsync<Observation_Dashboard_Count>(procedure_6, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //G_List_Building = (await connection.QueryAsync<Observation_Dashboard_Count>(procedure_7, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //G_List_Obs_Type = (await connection.QueryAsync<Observation_Dashboard_Count>(procedure_8, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //G_List_Nature_Injury = (await connection.QueryAsync<Observation_Dashboard_Count>(procedure_9, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Graph_Obs_Company = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_11, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    G_Cards_Obs_Counts = (await connection.QueryAsync<Observation_Dashboard_Count>(procedure_10, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Graph_Obs_Type = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_2, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //Graph_Obs_Category = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_3, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Zone_Count_List = (await connection.QueryAsync<Obs_Dashboard_Count>(procedure_1, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Community_Count_List = (await connection.QueryAsync<Dashboard_Observation_Model>(procedure_4, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Raised_By_Ser_Prov_List = (await connection.QueryAsync<Obs_Dashboard_Count>(procedure_5, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Raised_By_Against_Ser_Prov_List = (await connection.QueryAsync<Obs_Dashboard_Count>(procedure_6, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Zone_Base_Emp_Details = (await connection.QueryAsync<Obs_Dashboard_Count>(procedure_7, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    Observation_Dashboard _Dashboard = new Observation_Dashboard()
                    {
                        //Graph_Zone = Graph_Zone,
                        //Graph_NCM_Injured = Graph_NCM_Injured,
                        //G_List_Location = G_List_Locations,
                        //G_List_Building = G_List_Building,
                        //G_List_Obs_Type = G_List_Obs_Type,
                        //G_List_Inc_Nature_Injury = G_List_Inc_Nature_Injury,
                        //Graph_Obs_Company = Graph_Obs_Company,
                        //Graph_Obs_Type = Graph_Obs_Type,
                        //Graph_Obs_Category = Graph_Obs_Category,
                        G_Cards_Obs_Counts = G_Cards_Obs_Counts,
                        Zone_Count_List = Zone_Count_List,
                        Community_Count_List = Community_Count_List,
                        Raised_By_Ser_Prov_List = Raised_By_Ser_Prov_List,
                        Raised_By_Against_Ser_Prov_List = Raised_By_Against_Ser_Prov_List,
                        Zone_Base_Emp_Details = Zone_Base_Emp_Details,
                    };
                    return _Dashboard;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Observation_Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Incident_Observation_Report>> Observation_Dashboard_Card_View(Dashboard_Table_View_Param entity)
        {
            try
            {
                string procedure_1 = "sp_Dashboard_Obs_Cards_View_Data";
                var param_1 = new
                {
                    CreatedBy = entity.CreatedBy,
                    Year = entity.Year,
                    Category_Name = entity.Category_Name,
                    Zone_ID = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_date = entity.To_date,
                    Card_View_Id = entity.Card_View_Id,
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Incident_Observation_Report>(procedure_1, param_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Observation_Dashboard_Card_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

       #endregion
    }
}
