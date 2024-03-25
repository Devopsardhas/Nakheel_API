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
    public class IncidentSubMasterRepo : IIncidentSubMasterRepo
    {
        private readonly IConfiguration configuration;

        public IncidentSubMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Mechanism Injury Master]
        public async Task<IReadOnlyList<M_Inc_Mechanism_Injury_Master>> Mechanism_Injury_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Mechanism_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Mechanism_Injury_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Mechanism Injury Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Mechanism_Injury_AddAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Mechanism_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Inc_Mechanism_Injury_Id = entity.Inc_Mechanism_Injury_Id,
                        Inc_Mechanism_Injury_Name = entity.Inc_Mechanism_Injury_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Mechanism Injury Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Mechanism_Injury_UpdateAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Mechanism_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Inc_Mechanism_Injury_Id = entity.Inc_Mechanism_Injury_Id,
                        Inc_Mechanism_Injury_Name = entity.Inc_Mechanism_Injury_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Mechanism Injury Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Mechanism_Injury_Master> Mechanism_Injury_GetByIdAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Mechanism_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Inc_Mechanism_Injury_Id = entity.Inc_Mechanism_Injury_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Mechanism_Injury_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Mechanism Injury Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Mechanism_Injury_DeleteAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Mechanism_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Inc_Mechanism_Injury_Id = entity.Inc_Mechanism_Injury_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Mechanism Injury Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Agency Injury Master]
        public async Task<IReadOnlyList<M_Inc_Agency_Injury_Master>> Agency_Injury_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Agency_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Agency_Injury_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Agency Injury Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Agency_Injury_AddAsync(M_Inc_Agency_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Agency_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Inc_Agency_Injury_Id = entity.Inc_Agency_Injury_Id,
                        Inc_Agency_Injury_Name = entity.Inc_Agency_Injury_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Agency Injury Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Agency_Injury_UpdateAsync(M_Inc_Agency_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Agency_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Inc_Agency_Injury_Id = entity.Inc_Agency_Injury_Id,
                        Inc_Agency_Injury_Name = entity.Inc_Agency_Injury_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Agency Injury Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Agency_Injury_Master> Agency_Injury_GetByIdAsync(M_Inc_Agency_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Agency_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Inc_Agency_Injury_Id = entity.Inc_Agency_Injury_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Agency_Injury_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Agency Injury Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Agency_Injury_DeleteAsync(M_Inc_Agency_Injury_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Agency_Injury_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Inc_Agency_Injury_Id = entity.Inc_Agency_Injury_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Agency Injury Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Health_Safety_Type_Master]
        public async Task<IReadOnlyList<M_Inc_Health_Safety_Master>> Health_Safety_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Health_Safety_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Health_Safety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Health Safety Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Health_Safety_AddAsync(M_Inc_Health_Safety_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Health_Safety_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Health_Safety_Type_Id = entity.Health_Safety_Type_Id,
                        Health_Safety_Type_Name = entity.Health_Safety_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Health Safety Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Health_Safety_UpdateAsync(M_Inc_Health_Safety_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Health_Safety_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Health_Safety_Type_Id = entity.Health_Safety_Type_Id,
                        Health_Safety_Type_Name = entity.Health_Safety_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Health Safety Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Health_Safety_Master> Health_Safety_GetByIdAsync(M_Inc_Health_Safety_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Health_Safety_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Health_Safety_Type_Id = entity.Health_Safety_Type_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Health_Safety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Health Safety Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Health_Safety_DeleteAsync(M_Inc_Health_Safety_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Health_Safety_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Health_Safety_Type_Id = entity.Health_Safety_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Health Safety Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Environment Type Master]
        public async Task<IReadOnlyList<M_Inc_Environment_Type_Master>> Environment_Type_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Environment_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Environment_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Environment Type Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Environment_Type_AddAsync(M_Inc_Environment_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Environment_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Environment_Type_Id = entity.Environment_Type_Id,
                        Environment_Type_Name = entity.Environment_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Environment Type Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Environment_Type_UpdateAsync(M_Inc_Environment_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Environment_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Environment_Type_Id = entity.Environment_Type_Id,
                        Environment_Type_Name = entity.Environment_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Environment Type Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Environment_Type_Master> Environment_Type_GetByIdAsync(M_Inc_Environment_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Environment_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Environment_Type_Id = entity.Environment_Type_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Environment_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Environment Type Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Environment_Type_DeleteAsync(M_Inc_Environment_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Environment_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Environment_Type_Id = entity.Environment_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Illness Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Type Environmental Factor Master]
        public async Task<IReadOnlyList<M_Type_Environmental_Factor_Master>> Type_Environmental_Factor_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Type_Environmental_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Type_Environmental_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Environmental Factor Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Environmental_Factor_AddAsync(M_Type_Environmental_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Environmental_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Type_Eml_Factor_Id = entity.Type_Eml_Factor_Id,
                        Type_Eml_Factor_Name = entity.Type_Eml_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Environmental Factor Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Environmental_Factor_UpdateAsync(M_Type_Environmental_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Environmental_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Type_Eml_Factor_Id = entity.Type_Eml_Factor_Id,
                        Type_Eml_Factor_Name = entity.Type_Eml_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Environmental Factor Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Type_Environmental_Factor_Master> Type_Environmental_Factor_GetByIdAsync(M_Type_Environmental_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Environmental_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Type_Eml_Factor_Id = entity.Type_Eml_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Type_Environmental_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Environmental Factor Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Environmental_Factor_DeleteAsync(M_Type_Environmental_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Environmental_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Type_Eml_Factor_Id = entity.Type_Eml_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Environmental Factor Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Classification Master]
        public async Task<IReadOnlyList<M_Inc_Classification_Master>> Classification_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Classification_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Classification_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Classification_AddAsync(M_Inc_Classification_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Classification_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Classification_Id = entity.Classification_Id,
                        Classification_Name = entity.Classification_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Classification_UpdateAsync(M_Inc_Classification_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Classification_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Classification_Id = entity.Classification_Id,
                        Classification_Name = entity.Classification_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Classification_Master> Classification_GetByIdAsync(M_Inc_Classification_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Classification_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Classification_Id = entity.Classification_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Classification_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Classification_DeleteAsync(M_Inc_Classification_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Classification_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Classification_Id = entity.Classification_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Type Security Master]
        public async Task<IReadOnlyList<M_Type_Security_Incident_Master>> Type_Security_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Type_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Security_AddAsync(M_Type_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Inc_Type_Security_Id = entity.Inc_Type_Security_Id,
                        Classification_Id = entity.Classification_Id,
                        Inc_Type_Security_Name = entity.Inc_Type_Security_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Security_UpdateAsync(M_Type_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Inc_Type_Security_Id = entity.Inc_Type_Security_Id,
                        Classification_Id = entity.Classification_Id,
                        Inc_Type_Security_Name = entity.Inc_Type_Security_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Type_Security_Incident_Master> Type_Security_GetByIdAsync(M_Type_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Inc_Type_Security_Id = entity.Inc_Type_Security_Id
                    };
                    return (await connection.QueryAsync<M_Type_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_Security_DeleteAsync(M_Type_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Inc_Type_Security_Id = entity.Inc_Type_Security_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Type_Security_Incident_Master>> Type_Security_GetAllbyClassid(M_Type_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Security_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                        Classification_Id=entity.Classification_Id
                    };
                    return (await connection.QueryAsync<M_Type_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Type Security Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Inc_Mechanism_Injury_Master> GetByIdAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<M_Inc_Mechanism_Injury_Master>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> AddAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Vehicle Accident Type Master]
        public async Task<IReadOnlyList<M_Vehicle_Accident_Type_Master>> Vehicle_Accident_Type_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Vehicle_Accident_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Vehicle_Accident_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Vehicle_Accident_Type_AddAsync(M_Vehicle_Accident_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Vehicle_Accident_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Vehicle_Accident_Type_Id = entity.Vehicle_Accident_Type_Id,
                        Vehicle_Accident_Type_Name = entity.Vehicle_Accident_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Vehicle Accident Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Vehicle_Accident_Type_UpdateAsync(M_Vehicle_Accident_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Vehicle_Accident_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Vehicle_Accident_Type_Id = entity.Vehicle_Accident_Type_Id,
                        Vehicle_Accident_Type_Name = entity.Vehicle_Accident_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Vehicle Accident Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Vehicle_Accident_Type_Master> Vehicle_Accident_Type_GetByIdAsync(M_Vehicle_Accident_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Vehicle_Accident_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Vehicle_Accident_Type_Id = entity.Vehicle_Accident_Type_Id
                    };
                    return (await connection.QueryAsync<M_Vehicle_Accident_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Vehicle Accident Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Vehicle_Accident_Type_DeleteAsync(M_Vehicle_Accident_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Vehicle_Accident_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Vehicle_Accident_Type_Id = entity.Vehicle_Accident_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Vehicle Accident Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Incident Related Master]

        public async Task<IReadOnlyList<M_Incident_Related_Master>> Incident_Related_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Incident_Related_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Incident_Related_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Classification Master Incident_Related_GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        Task<M_Return_Message> IIncidentSubMasterRepo.Incident_Related_AddAsync(M_Incident_Related_Master entity)
        {
            throw new NotImplementedException();
        }

        Task<M_Return_Message> IIncidentSubMasterRepo.Incident_Related_UpdateAsync(M_Incident_Related_Master entity)
        {
            throw new NotImplementedException();
        }

        Task<M_Incident_Related_Master> IIncidentSubMasterRepo.Incident_Related_GetByIdAsync(M_Incident_Related_Master entity)
        {
            throw new NotImplementedException();
        }

        Task<M_Return_Message> IIncidentSubMasterRepo.Incident_Related_DeleteAsync(M_Incident_Related_Master entity)
        {
            throw new NotImplementedException();
        }

        #endregion


#pragma warning restore CS8603 // Possible null reference return.
    }

}
