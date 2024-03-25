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
    public class EmergencyRepo : IEmergencyRepo
    {
#pragma warning disable CS8603 // Possible null reference return.
        private readonly IConfiguration configuration;
        public EmergencyRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<M_Return_Message> AddAsync(M_Emer_Mitigation_Add entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> DeleteAsync(M_Emer_Mitigation_Add entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<M_Emer_Mitigation_Add>> GetAll_Emer_Miti(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Zone_Name = "";
                var Community_Name = "";
                var BuildingName = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
                var Status = "";
                var Emer_Title = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 2:
                                Community_Name = item.Search!.Value;
                                break;
                            case 3:
                                BuildingName = item.Search!.Value;
                                break;
                            case 4:
                                Emer_Title = item.Search!.Value;
                                break;
                            case 5:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 6:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 7:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Emerg_Mitigation_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Emer_Mitigation_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Emer_Miti(M_Emer_Mitigation_Add entity)
        {
            try
            {
                string procedure_1 = "Sp_Emer_Mitigation_Add";
                string procedure_2 = "Sp_Emer_Miti_Photo_Add";
                string procedure_3 = "Sp_Emergency_Mitigation_Update_History_Add";
                string procedure_4 = "sp_Send_Email_Emr_Escation_Brozen_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Level_Id = "";

                    var his_Remarks = "";
                    var M_Status = "";

                    if (entity.Emer_level == "3")
                    {
                        Level_Id = "3,4";
                        his_Remarks = "Escalate To Bronze Team";
                        M_Status = "1";
                    }

                    else if (entity.Emer_level == "2")
                    {
                        Level_Id = "2";
                        his_Remarks = "Escalate To Silver Team";
                        M_Status = "2";
                    }

                    else if ((entity.Emer_level == "2,3") || (entity.Emer_level == "3,2"))
                    {
                        Level_Id = "3,2,4";
                        his_Remarks = "Escalate To Bronze / Silver Team";
                        M_Status = "5";
                    }

                    var parameter_1 = new
                    {
                        Emer_Miti_Id = entity.Emer_Miti_Id,
                        Emer_Company = entity.Emer_Company,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Business_Unit_Name = entity.Business_Unit_Name,
                        Zone_Id = entity.Zone_Id,
                        Zone_Name = entity.Zone_Name,
                        Community_Id = entity.Community_Id,
                        Community_name = entity.Community_name,
                        Building_Id = entity.Building_Id,
                        Building_Name = entity.Building_Name,
                        Emer_Description = entity.Emer_Description,
                        Emer_Risk = entity.Emer_Risk,
                        Emer_Situation = entity.Emer_Situation,
                        Emer_Evidence = entity.Emer_Evidence,
                        Emer_level = Level_Id,
                        CreatedBy = entity.CreatedBy,
                        Emer_Title = entity.Emer_Title,
                        Remarks = his_Remarks,
                        Status = M_Status,
                    };
                    var Obj = (await connection.QueryAsync<M_Emer_Mitigation_Add>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Emer_Miti_Photos != null && entity.L_Emer_Miti_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Emer_Miti_Photos)
                            {
                                var parameters_2 = new
                                {
                                    Emer_Miti_Photo_Id = item.Emer_Miti_Photo_Id,
                                    Emer_Miti_Id = Obj.Emer_Miti_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_3 = new
                        {
                            Em_Mit_Id = Obj.Emer_Miti_Id,
                            Emp_Id = entity.CreatedBy,
                            CreatedBy = entity.CreatedBy,
                            Remarks = his_Remarks,
                            Remarks1 = entity.Remarks1,
                            Role_Id = entity.Role_Id,
                            Status = "1",
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_4 = new
                        {
                            Emer_Miti_Id = Obj.Emer_Miti_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Emer_Mitigation_Add> Emer_Miti_GetById(M_Emer_Mitigation_Add entity)
        {
            try
            {
                string procedure = "Sp_Emer_miti_GetById";
                string procedure1 = "sp_Emer_Miti_Photos_GetbyId";
                string procedure_2 = "sp_EM_Crisis_Sub_Emp_Master_ByLevel";
                string procedure_3 = "sp_EM_Crisis_Get_Update_History";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Emer_Miti_Id = entity.Emer_Miti_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Emer_Mitigation_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var parameters_2 = new
                        {
                            LevelM_Id = Obj.Emer_level,
                            Zone_Id = Obj.Zone_Id,
                            Community_Id = Obj.Community_Id,
                        };
                        var ObjPhotos = (await connection.QueryAsync<M_Emer_Miti_Photos>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Emer_Miti_Photos = ObjPhotos;

                        var ObjCrisis_Sub_Emp = (await connection.QueryAsync<Crisis_SubEmp_Master>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Crisis_SubEmp_Master_Details = ObjCrisis_Sub_Emp;

                        var Objhis = (await connection.QueryAsync<Emergency_Mitigation_Update_History>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Crisis_SubEmp_Update_History = Objhis;
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emer_Miti_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public Task<IReadOnlyList<M_Emer_Mitigation_Add>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<M_Emer_Mitigation_Add> GetByIdAsync(M_Emer_Mitigation_Add entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> UpdateAsync(M_Emer_Mitigation_Add entity)
        {
            throw new NotImplementedException();
        }
        public async Task<M_Return_Message> UpdateEmergency_MitigationStatus(Emergency_Mitigation_Update_History entity)
        {
            try
            {
                string procedure_1 = "Sp_Emergency_Mitigation_Update_History_Add";
                string procedure_2 = "Sp_Emergency_Mitigation_UpdateStatus";
                string procedure_3 = "sp_Send_Email_Emr_Escation_Silver_Team";
                string procedure_4 = "sp_Send_Email_Emr_Escation_Gold_Team";

                string procedure_5 = "sp_Send_Email_Emr_Escation_Reviewed";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Remarks2 == "1")
                    {
                        var parameter_1 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Emp_Id = entity.Emp_Id,
                            Role_Id = entity.Role_Id,
                            Status = entity.Status,
                            Remarks = entity.Remarks,
                            Remarks1 = entity.Remarks1,
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();


                        var parameter_2 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Status = "4",
                        };
                        var UpObj = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_2, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameters_71 = new
                        {
                            Emer_Miti_Id = entity.Em_Mit_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_71, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    else if (entity.Remarks2 == "2")
                    {
                        var parameter_1 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Emp_Id = entity.Emp_Id,
                            Role_Id = entity.Role_Id,
                            Status = entity.Status,
                            Remarks = entity.Remarks,
                            Remarks1 = entity.Remarks1,
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameter_2 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Status = "2",
                            Emer_level = "2",
                        };
                        var UpObj = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_2, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameters_74 = new
                        {
                            Emer_Miti_Id = entity.Em_Mit_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_74, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Remarks2 == "3")
                    {
                        var parameter_1 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Emp_Id = entity.Emp_Id,
                            Role_Id = entity.Role_Id,
                            Status = entity.Status,
                            Remarks = entity.Remarks,
                            Remarks1 = entity.Remarks1,
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();


                        var parameter_2 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Status = "4",
                        };
                        var UpObj = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_2, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameters_72 = new
                        {
                            Emer_Miti_Id = entity.Em_Mit_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_72, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    else if (entity.Remarks2 == "4")
                    {
                        var parameter_1 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Emp_Id = entity.Emp_Id,
                            Role_Id = entity.Role_Id,
                            Status = entity.Status,
                            Remarks = entity.Remarks,
                            Remarks1 = entity.Remarks1,
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameter_2 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Status = "3",
                            Emer_level = "1",
                        };
                        var UpObj = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_2, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameters_75 = new
                        {
                            Emer_Miti_Id = entity.Em_Mit_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_75, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Remarks2 == "5")
                    {
                        var parameter_1 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Emp_Id = entity.Emp_Id,
                            Role_Id = entity.Role_Id,
                            Status = entity.Status,
                            Remarks = entity.Remarks,
                            Remarks1 = entity.Remarks1,
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameter_2 = new
                        {
                            Em_Mit_Id = entity.Em_Mit_Id,
                            Status = "4",
                            Emer_level = "1",
                        };
                        var UpObj = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_2, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        var parameters_73 = new
                        {
                            Emer_Miti_Id = entity.Em_Mit_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_73, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }


        public async Task<IReadOnlyList<Emergency_Alert_Master>> GetAll_Emer_Alert()
        {
            try
            {
                string procedure = "sp_Get_EM_Emergency_Alert_Master";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<Emergency_Alert_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Emergency_Category";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Emer_Alert(Emergency_Alert_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Emergency_Alert_Master_Add";
                string procedure_2 = "sp_EM_Emergency_Alert_SubZone_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Emergency_Alert_Id = entity.Emergency_Alert_Id,
                        Emergency_Category_Id = entity.Emergency_Category_Id,
                        Description = entity.Description,
                        Emergency_Date = entity.Emergency_Date,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Emergency_SubZone_Alert_Master != null && entity.L_Emergency_SubZone_Alert_Master.Count > 0)
                        {
                            foreach (var item in entity.L_Emergency_SubZone_Alert_Master)
                            {
                                var parameters_2 = new
                                {
                                    Emergency_SubZoneAlert_Id = item.Emergency_SubZoneAlert_Id,
                                    Emergency_Alert_Id = Obj.Status_Code,
                                    Zone_Id = item.Zone_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
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
                string Repo = "Emergency_Category_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Emergency_Alert_Master> Emer_Alert_GetById(Emergency_Alert_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Emergency_Alert_View";
                string procedure_2 = "sp_EM_Sub_Zone_Emergency_Alert_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Emergency_Alert_Id = entity.Emergency_Alert_Id,
                    };
                    var Obj = (await connection.QueryAsync<Emergency_Alert_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjSubEmp_Master_Details = (await connection.QueryAsync<Emergency_SubZone_Alert_Master>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Emergency_SubZone_Alert_Master = ObjSubEmp_Master_Details;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emer_Alert_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Return_Message> UpdateEmer_Alert(Emergency_Alert_Master entity)
        {
            throw new NotImplementedException();
        }

#pragma warning restore CS8603 // Possible null reference return.

    }
}
