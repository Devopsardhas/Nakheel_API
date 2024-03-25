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
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class IncidentMasterRepo : IIncidentMasterRepo
    {
        private readonly IConfiguration configuration;

        public IncidentMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Inc_Category_Master]
        public async Task<IReadOnlyList<M_Inc_Category_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Category Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Inc_Category_Id = entity.Inc_Category_Id,
                        Inc_Category_Name = entity.Inc_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Category Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Inc_Category_Id = entity.Inc_Category_Id,
                        Inc_Category_Name = entity.Inc_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Category Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Category_Master> GetByIdAsync(M_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Inc_Category_Id = entity.Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Category Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> DeleteAsync(M_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Inc_Category_Id = entity.Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Category Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inc_Type_Master]
        public async Task<IReadOnlyList<M_Inc_Type_Master>> Type_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_AddAsync(M_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Inc_Type_Id = entity.Inc_Type_Id,
                        Inc_Cat_Id = entity.Inc_Cat_Id,
                        Inc_Type_Name = entity.Inc_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_UpdateAsync(M_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Inc_Type_Id = entity.Inc_Type_Id,
                        Inc_Cat_Id = entity.Inc_Cat_Id,
                        Inc_Type_Name = entity.Inc_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Type_Master> Type_GetByIdAsync(M_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Inc_Type_Id = entity.Inc_Type_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Type_DeleteAsync(M_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Inc_Type_Id = entity.Inc_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Inc_Type_Master>> Type_GetByCatIdAsync(M_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                        Inc_Cat_Id=entity.Inc_Cat_Id

                    };
                    return (await connection.QueryAsync<M_Inc_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Inc Type Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inc_Injury_Type_Master]
        public async Task<IReadOnlyList<M_Inc_Injury_Type_Master>> Injury_Type_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Injury_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Injury_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Type Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Injury_Type_AddAsync(M_Inc_Injury_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Injury_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Injury_Type_Id = entity.Injury_Type_Id,
                        Injury_Type_Name = entity.Injury_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Type Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Injury_Type_UpdateAsync(M_Inc_Injury_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Injury_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Injury_Type_Id = entity.Injury_Type_Id,
                        Injury_Type_Name = entity.Injury_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Type Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Injury_Type_Master> Injury_Type_GetByIdAsync(M_Inc_Injury_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Injury_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Injury_Type_Id = entity.Injury_Type_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Injury_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Type Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Injury_Type_DeleteAsync(M_Inc_Injury_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Injury_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Injury_Type_Id = entity.Injury_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Type Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Nature Injury Illness Master]
        public async Task<IReadOnlyList<M_Nature_Injury_Illness_Master>> Nature_Injury_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Nature_Injury_Illness_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Nature_Injury_Illness_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Illness Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Nature_Injury_AddAsync(M_Nature_Injury_Illness_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Nature_Injury_Illness_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Injury_Illness_Id = entity.Injury_Illness_Id,
                        Injury_Illness_Name = entity.Injury_Illness_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Illness Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Nature_Injury_UpdateAsync(M_Nature_Injury_Illness_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Nature_Injury_Illness_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Injury_Illness_Id = entity.Injury_Illness_Id,
                        Injury_Illness_Name = entity.Injury_Illness_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Illness Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Nature_Injury_Illness_Master> Nature_Injury_GetByIdAsync(M_Nature_Injury_Illness_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Nature_Injury_Illness_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Injury_Illness_Id = entity.Injury_Illness_Id
                    };
                    return (await connection.QueryAsync<M_Nature_Injury_Illness_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Injury Illness Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Nature_Injury_DeleteAsync(M_Nature_Injury_Illness_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Nature_Injury_Illness_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Injury_Illness_Id = entity.Injury_Illness_Id
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

        #region [Unsafe Act Master]
        public async Task<IReadOnlyList<M_Inc_Unsafe_Act_Master>> Unsafe_Act_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Act_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Unsafe_Act_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Act Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Act_AddAsync(M_Inc_Unsafe_Act_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Act_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Unsafe_Act_Id = entity.Unsafe_Act_Id,
                        Unsafe_Act_Name = entity.Unsafe_Act_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Act Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Act_UpdateAsync(M_Inc_Unsafe_Act_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Act_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Unsafe_Act_Id = entity.Unsafe_Act_Id,
                        Unsafe_Act_Name = entity.Unsafe_Act_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Act Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Unsafe_Act_Master> Unsafe_Act_GetByIdAsync(M_Inc_Unsafe_Act_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Act_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Unsafe_Act_Id = entity.Unsafe_Act_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Unsafe_Act_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Act Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Act_DeleteAsync(M_Inc_Unsafe_Act_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Act_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Unsafe_Act_Id = entity.Unsafe_Act_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Act Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Unsafe Condition Master]
        public async Task<IReadOnlyList<M_Inc_Unsafe_Condition_Master>> Unsafe_Condition_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Condition_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Unsafe_Condition_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Condition Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Condition_AddAsync(M_Inc_Unsafe_Condition_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Condition_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Unsafe_Condition_Id = entity.Unsafe_Condition_Id,
                        Unsafe_Condition_Name = entity.Unsafe_Condition_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Condition Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Condition_UpdateAsync(M_Inc_Unsafe_Condition_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Condition_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Unsafe_Condition_Id = entity.Unsafe_Condition_Id,
                        Unsafe_Condition_Name = entity.Unsafe_Condition_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Condition Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Unsafe_Condition_Master> Unsafe_Condition_GetByIdAsync(M_Inc_Unsafe_Condition_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Condition_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Unsafe_Condition_Id = entity.Unsafe_Condition_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Unsafe_Condition_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Condition Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Unsafe_Condition_DeleteAsync(M_Inc_Unsafe_Condition_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Unsafe_Condition_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Unsafe_Condition_Id = entity.Unsafe_Condition_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Unsafe Condition Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Personal Factor Master]
        public async Task<IReadOnlyList<M_Inc_Personal_Factor_Master>> Personal_Factor_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_Personal_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_Personal_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Personal Factor Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Personal_Factor_AddAsync(M_Inc_Personal_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Personal_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Personal_Factor_Id = entity.Personal_Factor_Id,
                        Personal_Factor_Name = entity.Personal_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Personal Factor Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Personal_Factor_UpdateAsync(M_Inc_Personal_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Personal_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Personal_Factor_Id = entity.Personal_Factor_Id,
                        Personal_Factor_Name = entity.Personal_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Personal Factor Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_Personal_Factor_Master> Personal_Factor_GetByIdAsync(M_Inc_Personal_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Personal_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Personal_Factor_Id = entity.Personal_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Inc_Personal_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Personal Factor Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Personal_Factor_DeleteAsync(M_Inc_Personal_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_Personal_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Personal_Factor_Id = entity.Personal_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Personal Factor Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [System Factor Master]
        public async Task<IReadOnlyList<M_Inc_System_Factor_Master>> System_Factor_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Inc_System_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Inc_System_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "System Factor Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> System_Factor_AddAsync(M_Inc_System_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_System_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        System_Factor_Id = entity.System_Factor_Id,
                        System_Factor_Name = entity.System_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "System Factor Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> System_Factor_UpdateAsync(M_Inc_System_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_System_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        System_Factor_Id = entity.System_Factor_Id,
                        System_Factor_Name = entity.System_Factor_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "System Factor Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Inc_System_Factor_Master> System_Factor_GetByIdAsync(M_Inc_System_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_System_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        System_Factor_Id = entity.System_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Inc_System_Factor_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "System Factor Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> System_Factor_DeleteAsync(M_Inc_System_Factor_Master entity)
        {
            try
            {
                string procedure = "sp_Inc_System_Factor_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        System_Factor_Id = entity.System_Factor_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "System Factor Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        
        #endregion

#pragma warning restore CS8603 // Possible null reference return.

    }
}
