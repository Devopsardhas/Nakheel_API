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
    public class DesignationMasterRepo : IDesignationMasterRepo
    {
        private readonly IConfiguration configuration;

        public DesignationMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<IReadOnlyList<M_Designation_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Designation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Designation_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> AddAsync(M_Designation_Master entity)
        {
            try
            {
                string procedure = "sp_Designation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Designation_Id = entity.Designation_Id,
                        Designation_Name = entity.Designation_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Designation AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Designation_Master entity)
        {
            try
            {
                string procedure = "sp_Designation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Designation_Id = entity.Designation_Id,
                        Designation_Name = entity.Designation_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Designation UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Designation_Master> GetByIdAsync(M_Designation_Master entity)
        {
            try
            {
                string procedure = "sp_Designation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Designation_Id = entity.Designation_Id
                    };
                    return (await connection.QueryAsync<M_Designation_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Designation GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_Designation_Master entity)
        {
            try
            {
                string procedure = "sp_Designation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Designation_Id = entity.Designation_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Designation DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
#pragma warning restore CS8603 // Possible null reference return.
    }
}
