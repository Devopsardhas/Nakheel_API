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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class ZoneMasterRepo : IZoneMasterRepo
    {
        private readonly IConfiguration configuration;

        public ZoneMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<IReadOnlyList<M_Zone_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Zone_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
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

        public async Task<M_Return_Message> AddAsync(M_Zone_Master entity)
        {
            try
            {
                string procedure = "sp_Zone_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Zone_Id = entity.Zone_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Name = entity.Zone_Name,
                        Description = entity.Description,
                        Is_Community = entity.Is_Community,
                        Is_Master_Community = entity.Is_Master_Community,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Zone AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Zone_Master entity)
        {
            try
            {
                string procedure = "sp_Zone_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Zone_Id = entity.Zone_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Name = entity.Zone_Name,
                        Description = entity.Description,
                        Is_Community = entity.Is_Community,
                        Is_Master_Community = entity.Is_Master_Community,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Zone UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Zone_Master> GetByIdAsync(M_Zone_Master entity)
        {
            try
            {
                string procedure = "sp_Zone_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Zone_Id = entity.Zone_Id
                    };
                    return (await connection.QueryAsync<M_Zone_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Zone GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_Zone_Master entity)
        {
            try
            {
                string procedure = "sp_Zone_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Zone_Id = entity.Zone_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Zone DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Zone_Master>> GetALL_Zone_by_Is_Community()
        {
            try
            {
                string procedure = "sp_GetZone_by_Community";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
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

        public async Task<IReadOnlyList<M_Zone_Master>> GetALL_Zone_by_Is_MasterCommunity()
        {
            try
            {
                string procedure = "sp_GetZone_by_MasterCommunity";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
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
#pragma warning restore CS8603 // Possible null reference return.
    }
}
