using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Collections;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class Emergency_DashboardRepo : IEmergency_Dashboard
    {
        private readonly IConfiguration configuration;

        public Emergency_DashboardRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<M_Return_Message> AddAsync(Emergency_Param entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(Emergency_Param entity)
        {
            throw new NotImplementedException();
        }

        public async Task<EMR_Dashboard> Emergency_Dashboard(Emergency_Param entity)
        {
            try
            {
                string procedure1 = "sp_Dash_EMR_Drill_Counts";
                string procedure2 = "sp_Dash_EMR_Drill_Improvement_Counts";
                string procedure3 = "sp_Dash_EMR_Mitigation_Counts";
                string procedure4 = "sp_Dash_EMR_Escalation_Counts";
                string procedure5 = "sp_Dash_EMR_ERT_Counts";
                string procedure6 = "sp_Dash_EMR_Completed_ZoneWsie";
                var parameters = new
                {
                    //Year = entity.Year,
                    //CreatedBy = entity.CreatedBy,
                    //Category_Name = entity.Category_Name,
                    //Zone_Id = entity.Zone_Id,
                    //Community_Id = entity.Community_Id,
                    //Building_Id = entity.Building_Id,
                    //From_Date = entity.From_Date,
                    //To_Date = entity.To_date
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    IReadOnlyList<Emergency_Dashboard> Total_Emer_List = new List<Emergency_Dashboard>();
                    IReadOnlyList<Emergency_Drill_Improvement> Total_Emer_Drill_Improve_List = new List<Emergency_Drill_Improvement>();
                    IReadOnlyList<Emergency_Counts> Total_Emer_Mitigation_List = new List<Emergency_Counts>();
                    IReadOnlyList<Emergency_Escalations_Counts> Total_Emer_Escalation_List = new List<Emergency_Escalations_Counts>();
                    IReadOnlyList<Emergency_ERT> Total_ERT_List = new List<Emergency_ERT>();
                    IReadOnlyList<Emergency_ZoneWiseData> Total_Zone_Comp_Count = new List<Emergency_ZoneWiseData>();

                    Total_Emer_List = (await connection.QueryAsync<Emergency_Dashboard>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Emer_Drill_Improve_List = (await connection.QueryAsync<Emergency_Drill_Improvement>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Emer_Mitigation_List = (await connection.QueryAsync<Emergency_Counts>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Emer_Escalation_List = (await connection.QueryAsync<Emergency_Escalations_Counts>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_ERT_List = (await connection.QueryAsync<Emergency_ERT>(procedure5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Total_Zone_Comp_Count = (await connection.QueryAsync<Emergency_ZoneWiseData>(procedure6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    EMR_Dashboard Dashboard = new EMR_Dashboard()
                    {
                        Total_Emer_List = Total_Emer_List,
                        Total_Emer_Drill_Improve_List = Total_Emer_Drill_Improve_List,
                        Total_Emer_Mitigation_List = Total_Emer_Mitigation_List,
                        Total_Emer_Escalation_List = Total_Emer_Escalation_List,
                        Total_ERT_List = Total_ERT_List,
                        Total_Zone_Comp_Count= Total_Zone_Comp_Count,
                    };
                    return Dashboard;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<IReadOnlyList<Emergency_Param>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Emergency_Param> GetByIdAsync(Emergency_Param entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(Emergency_Param entity)
        {
            throw new NotImplementedException();
        }
    }
}
