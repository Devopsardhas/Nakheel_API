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
    public class LocationMasterRepo:ILocationMasterRepo
    {
        private readonly IConfiguration configuration;

        public LocationMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<M_Return_Message> AddAsync(M_Location_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Location_Master_Add";
                string procedure_2 = "sp_Sub_Location_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id=entity.Building_Id,
                        Location_Name =entity.Location_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Location != null && entity.L_M_Location.Count > 0)
                        {
                            foreach (var item in entity.L_M_Location)
                            {
                                var parameters_2 = new
                                {
                                    Location_Id = Obj.Status_Code,
                                    Sub_Location_Name = item.Sub_Location_Name,
                                    Description = item.Description,
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
                string Repo = "Location Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        public Task<M_Return_Message> DeleteAsync(M_Location_Master entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<M_Location_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Location_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<M_Location_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Location GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Location_Master> GetByIdAsync(M_Location_Master entity)
        {
            try
            {
                string procedure = "sp_Location_Master_GetByID";
                string procedureBList = "sp_Location_Master_SubList";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 4,
                        Location_Id = entity.Location_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Location_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjBuilding = (await connection.QueryAsync<M_Location_List>(procedureBList, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Location = ObjBuilding;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Location GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Location_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Inc_Location_Master_Update";
                string procedure_2 = "sp_Sub_Location_Master_Add_New";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        //Action = 1,
                        Location_Id = entity.Location_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Location_Name=entity.Location_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Location != null && entity.L_M_Location.Count > 0)
                        {
                            foreach (var item in entity.L_M_Location)
                            {
                                if (string.IsNullOrEmpty(item.Location_Id))
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_Location_Id = 0,
                                        Location_Id = Obj.Status_Code,
                                        Sub_Location_Name = item.Sub_Location_Name,
                                        Description = item.Description,
                                        CreatedBy = item.CreatedBy,
                                    };
                                    await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                                }
                                else
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_Location_Id = item.Sub_Location_Id,
                                        Location_Id = item.Location_Id,
                                        Sub_Location_Name = item.Sub_Location_Name,
                                        Description = item.Description,
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
                string Repo = "Location Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.



    }
}
