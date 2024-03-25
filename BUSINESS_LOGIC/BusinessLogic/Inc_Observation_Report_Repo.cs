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
using static Dapper.SqlMapper;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class Inc_Observation_Report_Repo : IInc_Observation_Report_Repo
    {
        private readonly IConfiguration configuration;

        public Inc_Observation_Report_Repo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        public async Task<M_Return_Message> AddAsync(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Inc_Observation_Report_Add";
                string procedure_2 = "sp_Inc_Healthy_Safety_Type_Add";
                string procedure_3 = "sp_Inc_Obser_Environment_Add";
                string procedure_4 = "sp_Inc_Observation_Photos_Add";
                string procedure_5 = "sp_Inc_Observation_Videos_Add";
                string procedure_6 = "sp_Email_Incident_Observation_Create";
                string procedure_7 = "sp_Observation_Update_Status_History_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                        Obser_Date = entity.Obser_Date,
                        Obser_Time = entity.Obser_Time,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Building = entity.Building_Id,
                        Community = entity.Community_Id,
                        Master_Community_Id = entity.Master_Community_Id,
                        Category = entity.Category,
                        Observation_Type = entity.Observation_Type,
                        Loc_Latitude = entity.Loc_Latitude,
                        Loc_Longitude = entity.Loc_Longitude,
                        Obser_Details = entity.Obser_Details,
                        Description_Observation = entity.Description_Observation,
                        Imm_Corrective_Actions = entity.Imm_Corrective_Actions,
                        Company_Name = entity.Company_Name,
                        Contact_Name = entity.Contact_Name,
                        Mobile_Number = entity.Mobile_Number,
                        CreatedBy = entity.CreatedBy,
                        Priority = entity.Priority,
                        Business_Unit_Type_Name = entity.Business_Unit_Type_Name,
                        Master_Community_Name = entity.Master_Community_Name //Exact Location
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Observation_Report>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Inc_Health_Observation_Type != null && entity.L_Inc_Health_Observation_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Health_Observation_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Obser_Health_Id = item.Inc_Obser_Health_Id,
                                    Inc_Obser_Report_Id = Obj.Inc_Obser_Report_Id,
                                    Health_Safety_Id = item.Health_Safety_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Environment_Observation_Type != null && entity.L_Inc_Environment_Observation_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Environment_Observation_Type)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Envir_ObserType_Id = item.Inc_Envir_ObserType_Id,
                                    Inc_Obser_Report_Id = Obj.Inc_Obser_Report_Id,
                                    Environment_Id = item.Environment_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Observation_Photos != null && entity.L_Inc_Observation_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Observation_Photos)
                            {
                                var parameters_4 = new
                                {
                                    Obs_Photo_Id = item.Obs_Photo_Id,
                                    Inc_Obser_Report_Id = Obj.Inc_Obser_Report_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Observation_Videos != null && entity.L_Inc_Observation_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Observation_Videos)
                            {
                                var parameters_5 = new
                                {
                                    Obs_Video_Id = item.Obs_Video_Id,
                                    Inc_Obser_Report_Id = Obj.Inc_Obser_Report_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters_6 = new
                        {
                            Inc_Observation_Id = Obj.Inc_Obser_Report_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_7 = new
                        {
                            Inc_Observation_Id = Obj.Inc_Obser_Report_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_7, parameters_7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

        public Task<M_Return_Message> DeleteAsync(M_Incident_Observation_Report entity)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<M_Incident_Observation_Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<M_Incident_Observation_Report>> ObservationReportGetAllAsync(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Zone_Value = "";
                var Category_Value = "";
                var Observation_Type = "";
                var Status_Value = "";
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
                                Zone_Value = item.Search!.Value;
                                break;
                            case 2:
                                Category_Value = item.Search!.Value;
                                break;
                            case 3:
                                Observation_Type = item.Search!.Value;
                                break;
                            case 4:
                                Status_Value = item.Search!.Value;
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
                    Zone_Id = entity.Zone_Id,
                    Card_Id = entity.Card_Id
                };
                string procedure = "sp_Get_Incident_Observation_Report_Test";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Incident_Observation_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ObservationReportGetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_Observation_Team(M_Inc_Observation_Team entity)
        {
            try
            {
                string procedure = "sp_Inc_Observation_Assign_Team";
                string procedure_2 = "sp_Send_Email_and_Notification_Observation_Assign_Team";
                string procedure_3 = "sp_Update_Observation_History_Assign";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_M_Inc_Observation_Emp, commandType: CommandType.StoredProcedure);

                    foreach (var item in entity.L_M_Inc_Observation_Emp!)
                    {
                        var parameters_2 = new
                        {
                            Inc_Observation_Id = item.Inc_Obser_Report_Id,
                            Person_Responsible_Id = item.Responsible_Id
                        };
                        var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_3 = new
                    {
                        Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Observation_Corrective_Action>> Obs_Action_Closure_Get_All(Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Observation_Action_Closure";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.Responsible_Id,
                        Role_Id = entity.Role_Id,
                        Zone_Id = entity.Zone_Id
                    };
                    return (await connection.QueryAsync<M_Observation_Corrective_Action>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Obs_Action_Closure_Get_All";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Observation_Corrective_Action(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Add_Observation_Corrective_Action";
                //string procedure_3 = "sp_Inc_Obs_Action_Closure_Delete";
                string procedure_4 = "sp_Incident_Observation_Status_Update";
                string procedure_5 = "sp_Send_Email_and_Noti_Obs_CA_Supervior_Team";
                string procedure_6 = "sp_Update_Observation_History_SP_Closure";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var ClosureDelete = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Observation_Id,
                    };
                    //connection.Execute(procedure_3, ClosureDelete, commandType: CommandType.StoredProcedure);
                    connection.Execute(procedure, entity.L_Observation_Corrective_Action, commandType: CommandType.StoredProcedure);
                    if (entity.Role_Id == "5")
                    {
                        var UpdateStatus = new
                        {
                            Inc_Observation_Report_Id = entity.Inc_Observation_Id,
                            Status = "6",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var UpdateStatus = new
                        {
                            Inc_Observation_Report_Id = entity.Inc_Observation_Id,
                            Status = "3",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    var parameters_5 = new
                    {
                        Inc_Observation_Id = entity.Inc_Observation_Id,
                        Corrective_Action_Id = entity.Obs_Corrective_Action_Id,
                        //Report_By = entity.CreatedBy
                    };
                    var ObjSpMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_6 = new
                    {
                        Inc_Observation_Id = entity.Inc_Observation_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                    };
                    var ObjSpHis = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Observation Status Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Incident_Observation_Report> GetByIdAsync(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure1 = "sp_Get_Inc_Observation_Report_GetById";
                string procedure2 = "sp_Get_Inc_Obser_Health_Safety_GetById";
                string procedure3 = "sp_Get_Inc_Obser_Environment_Type_GetById";
                string procedure4 = "sp_Get_Inc_Obser_Photos_GetById";
                string procedure5 = "sp_Get_Inc_Obser_Videos_GetById";
                string procedure6 = "sp_Observation_History_By_Obs_Id";
                string procedure7 = "sp_Observation_Reject_By_Obs_Id";
                string procedure8 = "sp_Inc_Obs_GetById_CA_HSEList";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Observation_Report>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjHealth = (await connection.QueryAsync<M_Inc_Health_Observation_Type>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Health_Observation_Type = ObjHealth;
                    }
                    if (Obj != null)
                    {
                        var ObjEnvironment = (await connection.QueryAsync<M_Inc_Environment_Observation_Type>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Environment_Observation_Type = ObjEnvironment;
                    }
                    if (Obj != null)
                    {
                        var ObjPhotos = (await connection.QueryAsync<M_Inc_Observation_Photos>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Observation_Photos = ObjPhotos;
                    }
                    if (Obj != null)
                    {
                        var ObjVideos = (await connection.QueryAsync<M_Inc_Observation_Videos>(procedure5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Observation_Videos = ObjVideos;
                    }
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Observation_Status_History>(procedure6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Observation_Status_History = ObjUpdate_History;
                    }
                    if (Obj != null)
                    {
                        var ObjReject_History = (await connection.QueryAsync<M_Observation_Corrective_Action>(procedure7, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Observation_Report_Reject = ObjReject_History;
                    }
                    if (Obj != null)
                    {
                        var ObjCA = (await connection.QueryAsync<M_Observation_Corrective_Action>(procedure8, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Observation_Report_CA = ObjCA;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Observation Report GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Observation_Corrective_Action> Inc_Observation_Supervisor_GetByID(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure_1 = "sp_Get_Supervisor_Corrective_Action_List";
                string procedure_2 = "sp_Inc_Obs_GetById_CA_Photos";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                        Role_Id = entity.Role_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Observation_Corrective_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var parameters_1 = new
                        {
                            Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id
                        };
                        var ObjPhotos = (await connection.QueryAsync<Observation_Corrective_Action>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Observation_Corrective_Action = ObjPhotos;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Observation Supervisor GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_Observation_Corrective_Action(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Update_Observation_Corrective_Action";
                string procedure_2 = "sp_GetId_Obs_Corrective_ActionTeamList_Compare";
                string procedure_3 = "sp_Incident_Observation_Supervisor_Update";
                string procedure_4 = "sp_Send_Email_and_Noti_Observation_HSE_Manager_Team";
                string procedure_5 = "sp_Update_Observation_Supervisor_History";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Obs_Corrective_Action_Id = entity.Obs_Corrective_Action_Id,
                        Status = "4",
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parametersver = new
                    {
                        Inc_Observation_Id = entity.Inc_Observation_Id,
                        Status = "2",
                    };
                    var objver = (await connection.QueryAsync<Corrective_Assign_Action>(procedure_2, parametersver, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (objver == null)
                    {
                        var UpdateStatus = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            Status = "4",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_3, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var UpdateStatusMail = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatusMail, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var UpdateStatusHis = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_5, UpdateStatusHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Update_Corrective_Assign_Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Re_Assign_Corrective_Assign_Action(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Observation_Report_Re_Assign_Corrective_Assign_Action";
                string procedure_2 = "sp_Send_Email_and_Notification_Observation_Assign_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Obs_Corrective_Action_Id = entity.Obs_Corrective_Action_Id,
                        Responsible_Id = entity.Responsible_Id,
                        Remarks = entity.Remarks
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();

                    var parameters_2 = new
                    {
                        Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        Person_Responsible_Id = entity.Responsible_Id
                    };
                    var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Re_Assign_Corrective_Assign_Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_Observation_Corrective_Action_HSE(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Update_Observation_Corrective_Action";
                string procedure_1 = "sp_Update_Observation_Priority";
                string procedure_2 = "sp_Update_Observation_History_Completed";
                string procedure_3 = "sp_Send_Email_and_Noti_Obs_Priority_High";
                string procedure_4 = "sp_Incident_Observation_Supervisor_Update";
                string procedure_5 = "sp_Send_Email_and_Notifi_Observation_Directors";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Obs_Corrective_Action_Id = entity.Obs_Corrective_Action_Id,
                        Status = "3",
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity.Priority == "High")
                    {
                        var parameters_1 = new
                        {
                            Inc_Obser_Report_Id = entity.Inc_Observation_Id,
                            Priority = entity.Priority,
                        };
                        var objPriority = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_2 = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            Report_By = entity.CreatedBy
                        };
                        var objMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_1 = new
                        {
                            Inc_Obser_Report_Id = entity.Inc_Observation_Id,
                            Priority = entity.Priority,
                        };
                        var objPriority = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    if (obj != null)
                    {
                        var UpdateStatus = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            Status = "5",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var UpdateStatusMail = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, UpdateStatusMail, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var UpdateStatusHis = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, UpdateStatusHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Update_Corrective_Assign_Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_Observation_Corrective_Action_HSE_Reject(M_Observation_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Update_Observation_Corrective_Action";
                string procedure_1 = "sp_Inc_Observation_Reject_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Observation_Reject";
                string procedure_3 = "sp_Incident_Observation_HSE_Reject";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Obs_Corrective_Action_Id = entity.Obs_Corrective_Action_Id,
                        Status = "5",
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var AddReject_History = new
                    {
                        Obs_Reject_Id = entity.Obs_Reject_Id,
                        Reject_Reason_Stage = entity.Reject_Reason_Stage,
                        Reject_Reason_Description = entity.Reject_Reason_Description,
                        RejectedBy = entity.RejectedBy,
                        Inc_Obser_Report_Id = entity.Inc_Observation_Id,
                        Status = "7",
                        Role_Id = entity.Role_Id
                    };
                    var ObsRej = (await connection.QueryAsync<M_Return_Message>(procedure_1, AddReject_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var Reject_Mail = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Observation_Id,
                        Obs_Reject_Id = ObsRej!.Status_Code,
                    };
                    var ObsRejMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, Reject_Mail, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var UpdateStatus = new
                        {
                            Inc_Observation_Id = entity.Inc_Observation_Id,
                            Status = "7",
                        };
                        var ObjUpdate = (await connection.QueryAsync<M_Return_Message>(procedure_3, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Update_Corrective_Assign_Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateObservationPriority(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure = "sp_Update_Observation_Priority";
                string procedure_1 = "sp_Send_Email_and_Noti_Obs_Priority_High";
                string procedure_2 = "sp_Obs_Status_History_Priority";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Priority == "High")
                    {
                        var parameters = new
                        {
                            Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                            Priority = entity.Priority,
                        };
                        var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_1 = new
                        {
                            Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                            Report_By = entity.CreatedBy
                        };
                        var objMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                            Priority = entity.Priority,
                        };
                        var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_2 = new
                    {
                        Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "UpdateObservationPriority";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_Obs_Category_Positive(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure = "sp_Update_Obs_Category_Positive";
                string procedure_1 = "sp_Send_Email_and_Noti_Obs_Category_Positive";
                string procedure_2 = "sp_Obs_Status_History_Category_Positive";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                        Description_Observation = entity.Description_Observation,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_1 = new
                    {
                        Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        Report_By = entity.CreatedBy
                    };
                    var objMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Update_Obs_Category_Positive";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Observation_Status_History>> Observation_Status_History(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure = "sp_Observation_History_By_Obs_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                    };
                    return (await connection.QueryAsync<Observation_Status_History>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Observation_Status_History";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Inc_Observation_Report_Update";
                string procedure_12 = "sp_Inc_Observation_Report_Delete";
                string procedure_2 = "sp_Inc_Healthy_Safety_Type_Add";
                string procedure_3 = "sp_Inc_Obser_Environment_Add";
                string procedure_4 = "sp_Inc_Observation_Photos_Add";
                string procedure_5 = "sp_Inc_Observation_Videos_Add";
                string procedure_6 = "sp_Email_Incident_Observation_Create";
                string procedure_7 = "sp_Observation_Update_Status_History_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                        Obser_Date = entity.Obser_Date,
                        Obser_Time = entity.Obser_Time,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Building = entity.Building_Id,
                        Community = entity.Community_Id,
                        Master_Community_Id = entity.Master_Community_Id,
                        Category = entity.Category,
                        Observation_Type = entity.Observation_Type,
                        Loc_Latitude = entity.Loc_Latitude,
                        Loc_Longitude = entity.Loc_Longitude,
                        Obser_Details = entity.Obser_Details,
                        Description_Observation = entity.Description_Observation,
                        Imm_Corrective_Actions = entity.Imm_Corrective_Actions,
                        Company_Name = entity.Company_Name,
                        Contact_Name = entity.Contact_Name,
                        CreatedBy = entity.CreatedBy,
                        Business_Unit_Type_Name = entity.Business_Unit_Type_Name
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Observation_Report>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    var parameters_12 = new
                    {
                        Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                    };
                    var ObjDelete = (await connection.QueryAsync<M_Incident_Observation_Report>(procedure_12, parameters_12, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Inc_Health_Observation_Type != null && entity.L_Inc_Health_Observation_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Health_Observation_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Obser_Health_Id = item.Inc_Obser_Health_Id,
                                    Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                                    Health_Safety_Id = item.Health_Safety_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Environment_Observation_Type != null && entity.L_Inc_Environment_Observation_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Environment_Observation_Type)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Envir_ObserType_Id = item.Inc_Envir_ObserType_Id,
                                    Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                                    Environment_Id = item.Environment_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Observation_Photos != null && entity.L_Inc_Observation_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Observation_Photos)
                            {
                                var parameters_4 = new
                                {
                                    Obs_Photo_Id = item.Obs_Photo_Id,
                                    Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Observation_Videos != null && entity.L_Inc_Observation_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Observation_Videos)
                            {
                                var parameters_5 = new
                                {
                                    Obs_Video_Id = item.Obs_Video_Id,
                                    Inc_Obser_Report_Id = entity.Inc_Obser_Report_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters_6 = new
                        {
                            Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_7 = new
                        {
                            Inc_Observation_Id = entity.Inc_Obser_Report_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_7, parameters_7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

        public async Task<IReadOnlyList<M_Incident_Observation_Report>> ObservationNotificationCardView(M_Incident_Observation_Report entity)
        {
            try
            {
                string procedure = "sp_Inc_Observation_Dashboard_PopupDetails";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Zone_Id = entity.Zone_Id,
                        Cid = entity.Action,
                    };
                    return (await connection.QueryAsync<M_Incident_Observation_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ObservationNotificationCardView";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}
