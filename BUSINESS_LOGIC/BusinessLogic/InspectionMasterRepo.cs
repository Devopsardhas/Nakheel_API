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
    public class InspectionMasterRepo : IInspectionMasterRepo
    {
        private readonly IConfiguration configuration;

        public InspectionMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Inspection Category]
        public async Task<IReadOnlyList<M_Insp_Category>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_Insp_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Insp_Category_Id = entity.Insp_Category_Id,
                        Insp_Category_Name = entity.Insp_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Insp_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Insp_Category_Id = entity.Insp_Category_Id,
                        Insp_Category_Name = entity.Insp_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Category> GetByIdAsync(M_Insp_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Category_Id = entity.Insp_Category_Id
                    };
                    return (await connection.QueryAsync<M_Insp_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> DeleteAsync(M_Insp_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Category_Id = entity.Insp_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Inspection Sub Category]
        public async Task<IReadOnlyList<M_Insp_Sub_Category>> Insp_Sub_Cat_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Sub_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Sub_Category>> Insp_Sub_Cat_GetById(M_Insp_Sub_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Category_Id = entity.Insp_Category_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_Sub_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Sub_Cat_Add(List<M_Insp_Sub_Category> entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Insp_Sub_Category_Id = item.Insp_Sub_Category_Id,
                            Insp_Category_Id = item.Insp_Category_Id,
                            Insp_Sub_Category_Name = item.Insp_Sub_Category_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Sub_Cat_Delete(M_Insp_Sub_Category entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Sub_Category_Id = entity.Insp_Sub_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inspection Type Master]
        public async Task<IReadOnlyList<M_Insp_Type>> Insp_Type_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Type>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Type_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Type_Add(M_Insp_Type entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Insp_Type_Name = entity.Insp_Type_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Type_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Type_Update(M_Insp_Type entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Insp_Type_Name = entity.Insp_Type_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Type_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Type> Insp_Type_GetById(M_Insp_Type entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Type_Id = entity.Insp_Type_Id
                    };
                    return (await connection.QueryAsync<M_Insp_Type>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Type_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Type_Delete(M_Insp_Type entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Type_Id = entity.Insp_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Type_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Inspection Observation Master]
        public async Task<IReadOnlyList<M_Insp_Observation>> Insp_Observation_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Observation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Observation>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Observation_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Observation_Add(M_Insp_Observation entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Observation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Insp_Observation_Id = entity.Insp_Observation_Id,
                        Insp_Observation_Name = entity.Insp_Observation_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Observation_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Observation_Update(M_Insp_Observation entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Observation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Insp_Observation_Id = entity.Insp_Observation_Id,
                        Insp_Observation_Name = entity.Insp_Observation_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Observation_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Observation> Insp_Observation_GetById(M_Insp_Observation entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Observation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Observation_Id = entity.Insp_Observation_Id
                    };
                    return (await connection.QueryAsync<M_Insp_Observation>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Observation_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Observation_Delete(M_Insp_Observation entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Observation_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Observation_Id = entity.Insp_Observation_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Observation_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Inspection Topic]
        public async Task<IReadOnlyList<M_Insp_Topic>> Insp_Topic_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Topic_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Topic>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Topic_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Topic>> Insp_Topic_GetById(M_Insp_Topic entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Topic_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Type_Id = entity.Insp_Type_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_Topic>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Topic_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Topic_Add(List<M_Insp_Topic> entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Topic_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Insp_Topic_Id = item.Insp_Topic_Id,
                            Insp_Type_Id = item.Insp_Type_Id,
                            Insp_Topic_Name = item.Insp_Topic_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Topic_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Topic_Delete(M_Insp_Topic entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Topic_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Topic_Id = entity.Insp_Topic_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Topic_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inspection Questionnaires]
        public async Task<IReadOnlyList<M_Insp_Questionnaires>> Insp_Questionnaires_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Questionnaires>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Questionnaires_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Questionnaires>> Insp_Questionnaires_GetById(M_Insp_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Insp_Topic_Id = entity.Insp_Topic_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_Questionnaires>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Questionnaires_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Questionnaires_Add(List<M_Insp_Questionnaires> entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                            Insp_Topic_Id = item.Insp_Topic_Id,
                            Insp_Type_Id = item.Insp_Type_Id,
                            Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Questionnaires_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Questionnaires_Delete(M_Insp_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Questionnaires_Id = entity.Insp_Questionnaires_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Questionnaires_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inspection Landscaping Master]
        public async Task<IReadOnlyList<M_Insp_Landscap_Master>> Insp_Landscap_Mas_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscap_Mas_Add(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                        Insp_Landscap_Mas_Name = entity.Insp_Landscap_Mas_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscap_Mas_Update(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                        Insp_Landscap_Mas_Name = entity.Insp_Landscap_Mas_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Landscap_Master> Insp_Landscap_Mas_GetById(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscap_Mas_Delete(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Category_Master : DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Inspection Landscaping Sub Master]
        public async Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_Landscap_Sub_Cat_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Sub_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_Landscap_Sub_Cat_GetById(M_Insp_Landscap_Sub_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Sub_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscap_Sub_Cat_Add(List<M_Insp_Landscap_Sub_Master> entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Insp_Landscap_Sub_Mas_Id = item.Insp_Landscap_Sub_Mas_Id,
                            Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                            Insp_Landscap_Sub_Mas_Name = item.Insp_Landscap_Sub_Mas_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscap_Sub_Cat_Delete(M_Insp_Landscap_Sub_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_landscap_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Landscap_Sub_Mas_Id = entity.Insp_Landscap_Sub_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Inspection SoftService Master]
        public async Task<IReadOnlyList<M_Insp_Landscap_Master>> Insp_SoftService_Mas_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Mas_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Mas_Add(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                        Insp_Landscap_Mas_Name = entity.Insp_Landscap_Mas_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Mas_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Mas_Update(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                        Insp_Landscap_Mas_Name = entity.Insp_Landscap_Mas_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Mas_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Landscap_Master> Insp_SoftService_Mas_GetById(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Mas_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Mas_Delete(M_Insp_Landscap_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Mas_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Inspection SoftService Sub Master]
        public async Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_SoftService_Sub_Cat_GetAll()
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Sub_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Sub_Cat_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_SoftService_Sub_Cat_GetById(M_Insp_Landscap_Sub_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Insp_Landscap_Mas_Id = entity.Insp_Landscap_Mas_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_Landscap_Sub_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Sub_Cat_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Sub_Cat_Add(List<M_Insp_Landscap_Sub_Master> entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Insp_Landscap_Sub_Mas_Id = item.Insp_Landscap_Sub_Mas_Id,
                            Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                            Insp_Landscap_Sub_Mas_Name = item.Insp_Landscap_Sub_Mas_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Sub_Cat_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Sub_Cat_Delete(M_Insp_Landscap_Sub_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_SoftService_Check_Sub_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Insp_Landscap_Sub_Mas_Id = entity.Insp_Landscap_Sub_Mas_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_Sub_Cat_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion


#pragma warning restore CS8603 // Possible null reference return.

    }
}
