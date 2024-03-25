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
    public class BuildingMasterRepo : IBuildingMasterRepo
    {
        private readonly IConfiguration configuration;

        public BuildingMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<M_Return_Message> AddAsync(M_Building_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Building_Master_Add";
                string procedure_2 = "sp_Sub_Building_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Building != null && entity.L_M_Building.Count > 0)
                        {
                            foreach (var item in entity.L_M_Building)
                            {
                                var parameters_2 = new
                                {
                                    Building_Id = Obj.Status_Code,
                                    Building_Name = item.Building_Name,
                                    Building_Description = item.Building_Description,
                                    CreatedBy = item.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = Obj.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_Building_Master entity)
        {
            try
            {
                string procedure = "sp_Building_Master_ID_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,
                        Building_Id = entity.Building_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> SubDeleteAsync(M_Building_List entity)
        {
            try
            {
                string procedure = "sp_Sub_Building_Master_ID_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,
                        Sub_Building_Id = entity.Sub_Building_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Building Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        public async Task<IReadOnlyList<M_Building_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Building_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<M_Building_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Building_Master> GetByIdAsync(M_Building_Master entity)
        {
            try
            {
                string procedure = "sp_Building_Master_GetByID";
                string procedureBList = "sp_Building_Master_SubList";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 4,
                        Building_Id = entity.Building_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Building_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjBuilding = (await connection.QueryAsync<M_Building_List>(procedureBList, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Building = ObjBuilding;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Building_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Inc_Building_Master_Update";
                string procedure_2 = "sp_Sub_Building_Master_Add_New";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        //Action = 1,
                        Building_Id = entity.Building_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Building != null && entity.L_M_Building.Count > 0)
                        {
                            foreach (var item in entity.L_M_Building)
                            {
                                if (item.Building_Id == null)
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_Building_Id = 0,
                                        Building_Id = Obj.Status_Code,
                                        Building_Name = item.Building_Name,
                                        Building_Description = item.Building_Description,
                                        CreatedBy = item.CreatedBy,
                                    };
                                    await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                                }
                                else
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_Building_Id = item.Sub_Building_Id,
                                        Building_Id = item.Building_Id,
                                        Building_Name = item.Building_Name,
                                        Building_Description = item.Building_Description,
                                        CreatedBy = item.CreatedBy,
                                    };
                                    await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                                }

                            }
                        }
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
                string Repo = "Building Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Building_List>> Get_All_Building_byZone(M_Building_Master entity)
        {
            try
            {
                string procedure = "sp_Get_All_Building_byZone";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id
                    };
                    return (await connection.QueryAsync<M_Building_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Get_All_Building_byZone";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> CheckBuilding_Name(M_Building_List entity)
        {
            try
            {
                string procedure = "sp_Building_Name_Duplicate";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,

                        Building_Name = entity.Building_Name
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
#pragma warning restore CS8603 // Possible null reference return.
    }
}
