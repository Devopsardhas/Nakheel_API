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
    public class RoleMasterRepo : IRoleMasterRepo
    {
        private readonly IConfiguration configuration;

        public RoleMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<IReadOnlyList<M_Role_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Role_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Role_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> AddAsync(M_Role_Master entity)
        {
            try
            {
                string procedure = "sp_Role_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Role_Id = entity.Role_Id,
                        Role_Name = entity.Role_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Role AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Role_Master entity)
        {
            try
            {
                string procedure = "sp_Role_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Role_Id = entity.Role_Id,
                        Role_Name = entity.Role_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Role UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Role_Master> GetByIdAsync(M_Role_Master entity)
        {
            try
            {
                string procedure = "sp_Role_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Role_Id = entity.Role_Id
                    };
                    return (await connection.QueryAsync<M_Role_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Role GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_Role_Master entity)
        {
            try
            {
                string procedure = "sp_Role_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Role_Id = entity.Role_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Role DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
#pragma warning restore CS8603 // Possible null reference return.
    }
}
