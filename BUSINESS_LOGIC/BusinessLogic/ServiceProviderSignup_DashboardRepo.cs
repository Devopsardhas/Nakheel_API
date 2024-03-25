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
    public class ServiceProviderSignup_DashboardRepo : IServiceProviderSignup_DashboardRepo
    {
        private readonly IConfiguration configuration;

        public ServiceProviderSignup_DashboardRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public Task<M_Return_Message> AddAsync(Dashboard_Serv_Provi_Model entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(Dashboard_Serv_Provi_Model entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Dashboard_Serv_Provi_Model>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dashboard_Serv_Provi_Model> GetByIdAsync(Dashboard_Serv_Provi_Model entity)
        {
            throw new NotImplementedException();
        }

        
        public Task<M_Return_Message> UpdateAsync(Dashboard_Serv_Provi_Model entity)
        {
            throw new NotImplementedException();
        }
        #region [Dashboard]
        public async Task<ServiceProvider_Model> ServiceProvider_Dashboard(ServiceProviderSignup_Dashboard entity)
        {
            try
            {
                string procedure1 = "sp_Dash_ServiceProvider_Counts";
                string procedure2 = "sp_Dash_ServicePro_PemitType_Counts";
                string procedure3 = "sp_Dash_ServicePro_Zone_Counts";
                string procedure4 = "sp_Dash_ServicePro_Community_Counts";
                string procedure5 = "sp_Dash_ServicePro_ScopeOfWork_Counts";
                string procedure6 = "sp_Dash_ServicePro_ZoneWiseData_Counts";
                string procedure7 = "sp_Dash_ServicePro_Long_shortTerm_Counts";
                string procedure8 = "sp_Dash_ServPro_Tot_PermitTypes_Count";
                string procedure9 = "sp_Dash_ServicePro_Monthly_statis";
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
                var parameter1 = new
                {
                    Month = entity.Month,
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
                    IReadOnlyList<ServiceProvider_Dashborad_Count> Total_Count_List = new List<ServiceProvider_Dashborad_Count>();
                    IReadOnlyList<ServiceProv_PermitType_Counts> PermitType_Count_List = new List<ServiceProv_PermitType_Counts>();
                    IReadOnlyList<ServiceProv_Count> ZoneCount_List = new List<ServiceProv_Count>();
                    IReadOnlyList<Dashboard_Serv_Provi_Model> CommunityCount_List = new List<Dashboard_Serv_Provi_Model>();
                    IReadOnlyList<ServiceProv_Count> ScopeOfWork_Count_List = new List<ServiceProv_Count>();
                    IReadOnlyList<ServiceProv_Count>? ServiceProv_ZoneWise_List = new List<ServiceProv_Count>();
                    IReadOnlyList<ServiceProv_LongShortTerm>? LongShort_Term_List = new List<ServiceProv_LongShortTerm>();
                    IReadOnlyList<ServiceProv_Count>? TotalPermit_Count = new List<ServiceProv_Count>();
                    IReadOnlyList<MonthlyStatistics_Model>? Monthly_Statistic_List = new List<MonthlyStatistics_Model>();

                    Total_Count_List = (await connection.QueryAsync<ServiceProvider_Dashborad_Count>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    PermitType_Count_List = (await connection.QueryAsync<ServiceProv_PermitType_Counts>(procedure2, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    ZoneCount_List = (await connection.QueryAsync<ServiceProv_Count>(procedure3, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    CommunityCount_List = (await connection.QueryAsync<Dashboard_Serv_Provi_Model>(procedure4, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    ScopeOfWork_Count_List = (await connection.QueryAsync<ServiceProv_Count>(procedure5, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    ServiceProv_ZoneWise_List = (await connection.QueryAsync<ServiceProv_Count>(procedure6, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    LongShort_Term_List = (await connection.QueryAsync<ServiceProv_LongShortTerm>(procedure7, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    TotalPermit_Count = (await connection.QueryAsync<ServiceProv_Count>(procedure8, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Monthly_Statistic_List = (await connection.QueryAsync<MonthlyStatistics_Model>(procedure9, parameter1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    ServiceProvider_Model Dashboard = new ServiceProvider_Model()
                    {
                        Total_Count_List = Total_Count_List,
                        PermitType_Count_List = PermitType_Count_List,
                        ZoneCount_List = ZoneCount_List,
                        CommunityCount_List = CommunityCount_List,
                        ScopeOfWork_Count_List = ScopeOfWork_Count_List,
                        ServiceProv_ZoneWise_List = ServiceProv_ZoneWise_List,
                        LongShort_Term_List = LongShort_Term_List,
                        TotalPermit_Count = TotalPermit_Count,
                        Monthly_Statistic_List = Monthly_Statistic_List,
                    };
                    return Dashboard;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<ServiceProvider_Model>> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity)
        {
            try
            {
                string Procedure_01 = "sp_Dash_ServiceProv_CardView_Data";
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
                using(var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<ServiceProvider_Model>(Procedure_01, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Permit Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion
#pragma warning restore CS8603 // Possible null reference return.

    }
}
