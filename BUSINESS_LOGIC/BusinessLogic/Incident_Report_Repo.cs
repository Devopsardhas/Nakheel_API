using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using MODELS;
using System.Data.SqlClient;
using System.Data;
using BUSINESS_LOGIC.ErrorLogs;
using Dapper;
namespace BUSINESS_LOGIC.BusinessLogic
{
    public class Incident_Report_Repo : IIncident_Report_Repo
    {
        private readonly IConfiguration configuration;

        public Incident_Report_Repo(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
#pragma warning disable CS8603 // Possible null reference return.

        public async Task<M_Return_Message> AddAsync(M_Incident_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Incident_Notification_Add";
                string procedure_2 = "sp_Inc_Inve_Injury_Type_Add";
                string procedure_3 = "sp_Inc_Inve_Nature_Injury_Add";
                string procedure_4 = "sp_Inc_Notification_Photos_Add";
                string procedure_5 = "sp_Inc_Inve_InjuredPerson_Add";
                string procedure_6 = "sp_Inc_Inve_Vehicle_Accident_Add";
                string procedure_7 = "sp_Inc_Notification_Videos_Add";
                string procedure_8 = "sp_Email_Incident_Notification_Create";
                string procedure_9 = "sp_Inc_Update_Status_History_Add";
                //string procedure_10 = "sp_Upcoming_Activity_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Inc_Category_Id = entity.Inc_Category_Id,
                        Inc_Type_Id = entity.Inc_Type_Id,
                        Inc_Date = entity.Inc_Date,
                        Inc_Time = entity.Inc_Time,
                        Zone = entity.Zone,
                        Building = entity.Building,
                        Business_Unit = entity.Business_Unit,
                        Loc_Latitude = entity.Loc_Latitude,
                        Loc_Longitude = entity.Loc_Longitude,
                        Inc_Description = entity.Inc_Description,
                        Is_Injury_Illness = entity.Is_Injury_Illness,
                        Injured_Person = entity.Injured_Person,
                        Company_Name = entity.Company_Name,
                        Contact_Name = entity.Contact_Name,
                        Mobile_Number = entity.Mobile_Number,
                        CreatedBy = entity.CreatedBy,
                        Community_Id = entity.Community_Id,
                        Master_Community_Id = entity.Master_Community_Id,
                        Is_Investigation_Req = entity.Is_Investigation_Req,
                        Is_PropertyDamaged = entity.Is_PropertyDamaged,
                        Is_InsuranceClaim = entity.Is_InsuranceClaim,
                        Inc_Business_Unit_Type = entity.Inc_Business_Unit_Type,
                        Inc_Fire_Location = entity.Inc_Fire_Location,
                        Immediate_Action = entity.Immediate_Action,
                        Is_Follow_required = entity.Is_Follow_required,
                        Actions_Taken_Description = entity.Actions_Taken_Description,
                        Add_Description_3 = entity.Add_Description_3, //Would you like to provide more Information SAVE//
                        Master_Community_Name = entity.Master_Community_Name,
                        Exact_Loaction = entity.Exact_Loaction,
                        Is_Vehicle_Accident_Per = entity.Is_Vehicle_Accident_Per,
                        Incident_Party = entity.Incident_Party,
                        Description_of_Incident_Party = entity.Description_of_Incident_Party,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Inc_Remarks_1 = entity.Inc_Remarks_1,
                        Inc_Remarks_2 = entity.Inc_Remarks_2,
                        Inc_Remarks_3 = entity.Inc_Remarks_3,
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Report>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Inc_Inve_Injury_Type != null && entity.L_Inc_Inve_Injury_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Injury_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Injury_Type_Id = item.Inc_Injury_Type_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Injury_Type_Id = item.Injury_Type_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Inve_Nature_Injury != null && entity.L_Inc_Inve_Nature_Injury.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Nature_Injury)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Nature_Injury_Id = item.Inc_Nature_Injury_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Nature_Injury_Id = item.Nature_Injury_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Notification_Photos != null && entity.L_Inc_Notification_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Notification_Photos)
                            {
                                var parameters_4 = new
                                {
                                    Photo_Id = item.Photo_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Inc_Persons_Injured != null && entity.L_M_Inc_Persons_Injured.Count > 0)
                        {
                            foreach (var item in entity.L_M_Inc_Persons_Injured)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Persons_Injured_Id = item.Inc_Persons_Injured_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Persons_Name = item.Persons_Name,
                                    Persons_ContactNo = item.Persons_ContactNo,
                                    Injured_Type = item.Injured_Type,
                                    BodyParts_List = item.BodyParts_List,
                                    Persons_Id = item.Persons_Id,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Inc_Vehicle_Accident != null && entity.L_M_Inc_Vehicle_Accident.Count > 0)
                        {
                            foreach (var item in entity.L_M_Inc_Vehicle_Accident)
                            {
                                var parameters_2 = new
                                {
                                    Inc_VehicleAccident_Id = item.Inc_VehicleAccident_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Vehicle_Accident_Id = item.Vehicle_Accident_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Notification_Videos != null && entity.L_Inc_Notification_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Notification_Videos)
                            {
                                var parameters_5 = new
                                {
                                    Video_Id = item.Video_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_8 = new
                        {
                            Inc_Notification_Id = Obj.Inc_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_9 = new
                        {
                            Inc_Id = Obj.Inc_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(procedure_9, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                        //var parameters_10 = new
                        //{
                        //    Schedule_Type_Id = Obj.Inc_Id,
                        //    Zone_Id = entity.Zone,
                        //    Community_Id = entity.Community_Id,
                        //    Building_Id = entity.Building,
                        //    Module_Name = "Incident Report",
                        //    Hyper_Link = "/Incident/IncidentReporting",
                        //    CreatedBy = entity.CreatedBy
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure_10, parameters_10, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

        public Task<M_Return_Message> DeleteAsync(M_Incident_Report entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<M_Incident_Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<M_Incident_Report> GetByIdAsync(M_Incident_Report entity)
        {
            try
            {
                string procedure1 = "sp_Get_Incident_Notification_byId";
                string procedure2 = "sp_Get_Incident_Notification_Photos_byId";
                string procedure3 = "sp_Get_Incident_Notification_Inve_Injury_Type";
                string procedure4 = "sp_Get_Incident_Notification_Nature_Injury";
                string procedure5 = "sp_Get_Incident_Notification_InjuredPerson_List";
                string procedure6 = "sp_Get_Incident_Notification_Vehicle_Accident";
                string procedure7 = "sp_Get_Incident_Notification_Videos_by_Id";
                string procedure8 = "sp_Incident_History_by_inc_Id";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Report>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjPhotos = (await connection.QueryAsync<M_Inc_Notification_Photos>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Notification_Photos = ObjPhotos;
                    }
                    if (Obj != null)
                    {
                        var ObjInjuryType = (await connection.QueryAsync<M_Inc_Inve_Injury_Type>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Inve_Injury_Type = ObjInjuryType;
                    }
                    if (Obj != null)
                    {
                        var ObjNatureType = (await connection.QueryAsync<M_Inc_Inve_Nature_Injury>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Inve_Nature_Injury = ObjNatureType;
                    }
                    if (Obj != null)
                    {
                        var ObjPersonsInjury = (await connection.QueryAsync<M_Inc_Persons_Injured>(procedure5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Inc_Persons_Injured = ObjPersonsInjury;
                    }

                    if (Obj != null)
                    {
                        var ObjVehicleAccident = (await connection.QueryAsync<M_Inc_Vehicle_Accident>(procedure6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Inc_Vehicle_Accident = ObjVehicleAccident;
                    }
                    if (Obj != null)
                    {
                        var ObjVideos = (await connection.QueryAsync<M_Inc_Notification_Videos>(procedure7, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inc_Notification_Videos = ObjVideos;
                    }

                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Incident_Update_History>(procedure8, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Incident_Update_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Report GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Incident_Report>> IncidentNotificationGetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Inc_Category_Id_Value = "";
                var Inc_Type_Id_Value = "";
                var Zone_Value = "";
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
                                Inc_Category_Id_Value = item.Search!.Value;
                                break;
                            case 2:
                                Inc_Type_Id_Value = item.Search!.Value;
                                break;
                            case 3:
                                Zone_Value = item.Search!.Value;
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
                string procedure = "sp_Get_Incident_Notification_Test";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "IncidentNotificationGetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> IncidentStatusUpdate_IsReq(M_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Incident_Status_Update_isRequerd";
                string procedure_2 = "sp_Send_Email_and_Notification_HSE_Team";
                string procedure_3 = "sp_Send_Email_and_Notification_Lead_Inv_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Status = entity.Status,
                        Is_Investigation_Req = entity.Is_Investigation_Req,
                        Is_Investigation_Reportable = entity.Is_Investigation_Reportable,
                        Incident_Related_Id = entity.Incident_Related_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Remarks = entity.Remarks,
                        Lead_Investigator_Id = entity.Lead_Investigator_Id,
                        Add_Description_1 = entity.Add_Description_1,
                        Add_Description_2 = entity.Add_Description_2,
                    };

                    var Objre = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity.Lead_Investigator_Id == null)
                    {
                        var parameters_2 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                            MailPDF = entity.Mail_Remarks
                        };
                        var Objre1 = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_3 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> IncidentStatusUpdate(M_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Incident_Status_Update";
                string procedure_2 = "sp_Send_Email_and_Noti_Lead_Investigator_Team";
                string procedure_3 = "sp_Send_Email_and_Noti_HSE_Director_Team";
                string procedure_4 = "sp_Send_Email_and_Noti_Zone_Director_Team";
                string procedure_5 = "sp_Send_Email_and_Noti_Supervisor_Team";
                string procedure_6 = "sp_Send_Email_and_Noti_Incident_Close_Team";
                string procedure_7 = "sp_Incident_Circulate_Knowledge";
                string procedure_8 = "sp_Send_Email_and_Noti_Zone_Employess";
                string procedure_9 = "sp_Email_Incident_Notification_Insurance_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Remarks = entity.Remarks,
                    };
                    var Status = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity.Status == "13")
                    {
                        var parameters_2 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre1 = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Status == "7")
                    {
                        var parameters_3 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Status == "8")
                    {
                        var parameters_4 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_41 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                            Mail_Pdf_Bytes = entity.Mail_Remarks,
                        };
                        var ObjZone = (await connection.QueryAsync<M_Return_Message>(procedure_8, parameters_41, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        if (entity.Is_InsuranceClaim == "Yes")
                        {
                            var parameters_9 = new
                            {
                                Inc_Notification_Id = entity.Inc_Id,
                            };
                            var Objins = (await connection.QueryAsync<M_Return_Message>(procedure_9, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }

                    else if (entity.Status == "9")
                    {
                        var parameters_5 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Status == "12")
                    {
                        var parameters_5 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    if (entity.L_Circulate_Knowledge_Details != null)
                    {
                        connection.Execute(procedure_7, entity.L_Circulate_Knowledge_Details, commandType: CommandType.StoredProcedure);
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Corrective_Assign_Action>> Inc_Action_Closure_Get_All(Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Inc_Action_Closure";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Created_By = entity.Person_Responsible_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<Corrective_Assign_Action>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master Inc_Action_Closure_Get_All";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_AddCorrective_Assign_Action(M_Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Add_Corrective_Assign_Action";
                string procedure_4 = "sp_Incident_Notification_Status_Update";
                string procedure_44 = "sp_Incident_Status_Update_Actionpart";
                string procedure_444 = "sp_Send_Email_and_Noti_Corrective_Action_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_Corrective_Assign_Action, commandType: CommandType.StoredProcedure);

                    var UpdateStatus = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Status = "10",
                    };
                    var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var UpdateStatusHis = new
                    {
                        Inc_Id = entity.Inc_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Status = "10",
                    };
                    var ond = (await connection.QueryAsync<M_Return_Message>(procedure_44, UpdateStatusHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    foreach (var item in entity.L_Corrective_Assign_Action!)
                    {
                        var parameters_5 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                            Person_Responsible_Id = item.Person_Responsible_Id
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_444, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_Add_Corrective_Action(Add_Corrective_Action entity)
        {
            try
            {
                string Procedure_Delete = "sp_Add_Corrective_Evidence_Upload_Delete";
                string procedure = "sp_Add_Corrective_Evidence_Upload";
                string procedure_1 = "sp_Send_Email_and_Noti_Corre_Action_Supervior_Team";
                string procedure_11 = "sp_Send_Email_and_Noti_Corre_Action_Lead_inv_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Parameters_Delete = new
                    {

                        Corrective_Action_Id = entity.Corrective_Action_Id
                    };
                    var delete_Obj = (await connection.QueryAsync<M_Return_Message>(Procedure_Delete, Parameters_Delete, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    connection.Execute(procedure, entity.L_List_Add_Corrective_Action, commandType: CommandType.StoredProcedure);

                    if (entity.Role_Id == "5")
                    {
                        var parameters_5 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Report_By = entity.Created_By
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_11, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_5 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Report_By = entity.Created_By
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_Add_Knowledge_Share(Inc_Knowledge_Share entity)
        {
            try
            {
                string procedure_1 = "sp_Add_Knowledge_Share";
                string procedure_2 = "sp_Add_Key_Points";
                string procedure_3 = "sp_Add_Recommendations";
                string procedure_4 = "sp_Incident_Notification_Status_Update";
                string procedure_5 = "sp_Incident_Status_Update_KeyPoints";
                string procedure_6 = "sp_Send_Email_and_Noti_HSE_Manager_Team";
                string procedure_7 = "sp_Knowledge_Share_Delete";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                        File_Path = entity.File_Path,
                        Knowledge_Description = entity.Knowledge_Description,
                        KnowledgeInc_Category = entity.KnowledgeInc_Category,
                        KnowledgeInc_Type = entity.KnowledgeInc_Type,
                    };

                    connection.Execute(procedure_7, parameters, commandType: CommandType.StoredProcedure);
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    connection.Execute(procedure_2, entity.L_Inc_Knowledge_Share_Key_Points, commandType: CommandType.StoredProcedure);
                    connection.Execute(procedure_3, entity.L_Inc_Knowledge_Share_Recommendations, commandType: CommandType.StoredProcedure);

                    if (entity.Is_Preview == "No")
                    {
                        var UpdateStatus = new
                        {
                            Inc_Id = entity.Inc_Id,
                            Status = "14",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_5 = new
                        {
                            Inc_Id = entity.Inc_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };

                        var objd = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_6 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Inc_Add_Knowledge_Share";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_Add_Knowledge_Share_No(Inc_Knowledge_Share entity)
        {
            try
            {
                string procedure_1 = "sp_Update_Knowledge_Share_Details";
                //string procedure_2 = "sp_Add_Key_Points";
                //string procedure_3 = "sp_Add_Recommendations";
                string procedure_4 = "sp_Incident_Notification_Status_Update";
                string procedure_5 = "sp_Incident_Status_Update_KeyPoints_No";
                string procedure_6 = "sp_Send_Email_and_Noti_HSE_Manager_Team";
                //string procedure_7 = "sp_Knowledge_Share_Delete";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Is_Preview = entity.Is_Preview
                    };

                    //connection.Execute(procedure_7, parameters, commandType: CommandType.StoredProcedure);
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //connection.Execute(procedure_2, entity.L_Inc_Knowledge_Share_Key_Points, commandType: CommandType.StoredProcedure);
                    //connection.Execute(procedure_3, entity.L_Inc_Knowledge_Share_Recommendations, commandType: CommandType.StoredProcedure);

                    if (entity.Is_Preview == "No")
                    {
                        var UpdateStatus = new
                        {
                            Inc_Id = entity.Inc_Id,
                            Status = "14",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_5 = new
                        {
                            Inc_Id = entity.Inc_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };

                        var objd = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_6 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Inc_Add_Knowledge_Share";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_Investigation_Team(M_Inc_Investigation_Team entity)
        {
            try
            {
                string procedure = "sp_Inc_Investigation_Team";
                string procedure_1 = "sp_Update_Incident_History";
                string procedure_2 = "sp_Send_Email_and_Noti_Investigation_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_M_Inc_Invs_Emp, commandType: CommandType.StoredProcedure);

                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                    };

                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        Inc_Notification_Id = entity.Inc_Id,
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
                string Repo = "IncidentStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Return_Message> UpdateAsync(M_Incident_Report entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Evidence_Upload_Photos>> Incident_Closure_Evidence(Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Incident_Closure_Evidence";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                    };
                    return (await connection.QueryAsync<Evidence_Upload_Photos>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master Incident_Closure_Evidence";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Corrective_Assign_Action(Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Update_Corrective_Assign_Action";
                string procedure_2 = "sp_Get_Corrective_ActionTeamList";
                string procedure_4 = "sp_Incident_Notification_Status_Update";
                string procedure_5 = "sp_Update_Incident_History_Assign_Action";
                string procedure_6 = "sp_Send_Email_and_Noti_Corre_Action_Verfied_Team";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Rejected_Reason = entity.Reject_Reason,
                        Status = entity.Status,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parametersver = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Status = "4",
                    };
                    var objver = (await connection.QueryAsync<Corrective_Assign_Action>(procedure_2, parametersver, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                    if (objver!.Count == 0)
                    {
                        var UpdateStatus = new
                        {
                            Inc_Id = entity.Inc_Id,
                            Status = "11",
                        };
                        var on = (await connection.QueryAsync<M_Return_Message>(procedure_4, UpdateStatus, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_2 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    var parameterhis = new
                    {
                        Inc_Id = entity.Inc_Id,
                        CreatedBy = entity.Created_By,
                        Role_Id = entity.Role_Id,
                    };
                    var objhis = (await connection.QueryAsync<Corrective_Assign_Action>(procedure_5, parameterhis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


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

        public async Task<M_Return_Message> Update_Corrective_Assign_Status(Evidence_Upload_Photos entity)
        {
            try
            {
                string procedure = "sp_Inc_Incident_Closure_Evidence_Update_Final";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Inc_Id = entity.Inc_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master Incident_Closure_Evidence";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Incident_Update_History>> Incident_Status_History(M_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Incident_History_by_inc_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id,
                    };
                    return (await connection.QueryAsync<Incident_Update_History>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident_Status_History";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Inc_AddReject_Reason_Action(M_Incident_Notification_Reject entity)
        {
            try
            {
                string procedure = "sp_Add_Reject_Reason_Action";
                string procedure_1 = "sp_Send_Email_and_Noti_Inc_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Reject_Reason_Stage = entity.Reject_Reason_Stage,
                        Reject_Reason_Description = entity.Reject_Reason_Description,
                        Rejected_By = entity.Rejected_By,
                        Reject_Inc_Id = entity.Reject_Inc_Id,
                        Status = entity.Status,
                        Role_Id = entity.Role_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        Inc_Notification_Id = entity.Reject_Inc_Id,
                        Reject_Id = Obj!.Status_Code
                    };
                    var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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

        public async Task<M_Return_Message> Re_Assign_Corrective_Assign_Action(Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Re_Assign_Corrective_Assign_Action";
                string procedure_444 = "sp_Send_Email_and_Noti_Corrective_Action_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Person_Responsible_Id = entity.Person_Responsible_Id
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();

                    var parameters_5 = new
                    {
                        Inc_Notification_Id = entity.Inc_Id,
                        Person_Responsible_Id = entity.Person_Responsible_Id
                    };
                    var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_444, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "sp_Re_Assign_Corrective_Assign_Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Corrective_Assign_Action>> Action_Closure_Get_All_Approval(Corrective_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Inc_Action_Closure_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Created_By = entity.Person_Responsible_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<Corrective_Assign_Action>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master Inc_Action_Closure_Get_All";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Notification_Dashboard_Count> Get_Dashboard(M_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Inc_Notification_Dashboard_Count";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Zone_Id = entity.Zone,
                    };
                    return (await connection.QueryAsync<Notification_Dashboard_Count>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master Get_Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> IncidentNotificationAdd(M_Investigation_Report_Add entity)
        {
            try
            {
                string procedure_1 = "sp_Incident_Notification_Add";
                string procedure_2 = "sp_Inc_Inve_Injury_Type_Add";
                string procedure_3 = "sp_Inc_Inve_Nature_Injury_Add";
                string procedure_4 = "sp_Inc_Notification_Photos_Add";
                string procedure_5 = "sp_Inc_Inve_InjuredPerson_Add";
                string procedure_6 = "sp_Inc_Inve_Vehicle_Accident_Add";
                string procedure_7 = "sp_Inc_Notification_Videos_Add";
                string procedure_8 = "sp_Email_Incident_Notification_Create";
                string procedure_9 = "sp_Inc_Update_Status_History_Add";
                //string procedure_10 = "sp_Upcoming_Activity_Add";

                string Inv_procedure_1 = "sp_Inves_Investigation_Details_Add";
                string Inv_procedure_2 = "sp_Inves_Other_Parties_Involved_Add";
                string Inv_procedure_3 = "sp_Inves_Immediate_Cause_Unsafe_Act_Add";
                string Inv_procedure_4 = "sp_Inves_Immediate_Cause_Unsafe_Cond_Add";
                string Inv_procedure_5 = "sp_Inves_Root_Cause_PF_Add";
                string Inv_procedure_6 = "sp_Inves_Root_Cause_SF_Add";
                string Inv_procedure_7 = "sp_Inves_Mechanism_InjuryIllness_Add";
                string Inv_procedure_8 = "sp_Inves_AgencySource_InjuryIllness_Add";
                string Inv_procedure_9 = "sp_Inves_Environmental_Impact_Details_Add";
                string Inv_procedure_10 = "sp_Inves_Security_Impact_Details_Add";
                string Inv_procedure_11 = "sp_Inves_Actions_Taken_Immediately_Add";
                string Inv_procedure_12 = "sp_Inves_Incident_Root_Cause_Add";
                string Inv_procedure_13 = "sp_Inves_Corrective_Actions_Add";
                string Inv_procedure_14 = "sp_Inves_Declarations_Approvals_Add";
                string Inv_procedure_15 = "sp_Inves_Attachements_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Inc_Id = entity.Inc_Id,
                        Inc_Category_Id = entity.Inc_Category_Id,
                        Inc_Type_Id = entity.Inc_Type_Id,
                        Inc_Date = entity.Inc_Date,
                        Inc_Time = entity.Inc_Time,
                        Zone = entity.Zone,
                        Building = entity.Building,
                        Business_Unit = entity.Business_Unit,
                        Loc_Latitude = entity.Loc_Latitude,
                        Loc_Longitude = entity.Loc_Longitude,
                        Inc_Description = entity.Inc_Description,
                        Is_Injury_Illness = entity.Is_Injury_Illness,
                        Injured_Person = entity.Injured_Person,
                        Company_Name = entity.Company_Name,
                        Contact_Name = entity.Contact_Name,
                        Mobile_Number = entity.Mobile_Number,
                        CreatedBy = entity.CreatedBy,
                        Community_Id = entity.Community_Id,
                        Is_PropertyDamaged = entity.Is_PropertyDamaged,
                        Is_InsuranceClaim = entity.Is_InsuranceClaim,
                        Inc_Business_Unit_Type = entity.Inc_Business_Unit_Type,
                        Inc_Fire_Location = entity.Inc_Fire_Location,
                        Immediate_Action = entity.Immediate_Action,
                        Is_Follow_required = entity.Is_Follow_required,
                        Actions_Taken_Description = entity.Actions_Taken_Description,
                        Add_Description_3 = entity.Add_Description_3, //Would you like to provide more Information SAVE//
                        Exact_Loaction = entity.Exact_Loaction,
                        Is_Vehicle_Accident_Per = entity.Is_Vehicle_Accident_Per,
                        Incident_Party = entity.Incident_Party,
                        Description_of_Incident_Party = entity.Description_of_Incident_Party,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Inc_Remarks_1 = entity.Inc_Remarks_1,
                        Inc_Remarks_2 = entity.Inc_Remarks_2,
                        Inc_Remarks_3 = entity.Inc_Remarks_3,
                    };
                    var Obj = (await connection.QueryAsync<M_Incident_Report>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Inc_Inve_Injury_Type != null && entity.L_Inc_Inve_Injury_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Injury_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Injury_Type_Id = item.Inc_Injury_Type_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Injury_Type_Id = item.Injury_Type_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Inve_Nature_Injury != null && entity.L_Inc_Inve_Nature_Injury.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Nature_Injury)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Nature_Injury_Id = item.Inc_Nature_Injury_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Nature_Injury_Id = item.Nature_Injury_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Notification_Photos != null && entity.L_Inc_Notification_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Notification_Photos)
                            {
                                var parameters_4 = new
                                {
                                    Photo_Id = item.Photo_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Inc_Persons_Injured != null && entity.L_M_Inc_Persons_Injured.Count > 0)
                        {
                            foreach (var item in entity.L_M_Inc_Persons_Injured)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Persons_Injured_Id = item.Inc_Persons_Injured_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Persons_Name = item.Persons_Name,
                                    Persons_ContactNo = item.Persons_ContactNo,
                                    Injured_Type = item.Injured_Type,
                                    BodyParts_List = item.BodyParts_List,
                                    Persons_Id = item.Persons_Id,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Inc_Vehicle_Accident != null && entity.L_M_Inc_Vehicle_Accident.Count > 0)
                        {
                            foreach (var item in entity.L_M_Inc_Vehicle_Accident)
                            {
                                var parameters_2 = new
                                {
                                    Inc_VehicleAccident_Id = item.Inc_VehicleAccident_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Vehicle_Accident_Id = item.Vehicle_Accident_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Inc_Notification_Videos != null && entity.L_Inc_Notification_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Notification_Videos)
                            {
                                var parameters_5 = new
                                {
                                    Video_Id = item.Video_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var Inv_parameters_1 = new
                        {
                            Inc_Id = Obj.Inc_Id,
                            Description_circumstances = entity.Description_circumstances,
                            Additional_Information = entity.Additional_Information,
                            Risk_Assessment_Environmental_Impact = entity.Risk_Assessment_Environmental_Impact,
                            Is_Ref = entity.Is_Ref,
                            CreatedBy = entity.CreatedBy,
                            Invs_File_Path = entity.Invs_File_Path,
                        };
                        var Inv_Obj = (await connection.QueryAsync<M_Return_Message>(Inv_procedure_1, Inv_parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                        if (entity.L_Inves_Other_Parties_Involved != null && entity.L_Inves_Other_Parties_Involved.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Other_Parties_Involved)
                            {
                                var Inv_parameters_2 = new
                                {
                                    Inves_Other_Parties_Id = item.Inves_Other_Parties_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Role_Position = item.Role_Position,
                                    Other_Name = item.Other_Name,
                                    Other_Contact_no = item.Other_Contact_no,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_2, Inv_parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Act != null && entity.L_Inves_Immediate_Cause_Unsafe_Act.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Act)
                            {
                                var Inv_parameters_3 = new
                                {
                                    Inves_Unsafe_Act_Id = item.Inves_Unsafe_Act_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_Unsafe_Act_Id = item.M_Unsafe_Act_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_3, Inv_parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Cond != null && entity.L_Inves_Immediate_Cause_Unsafe_Cond.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Cond)
                            {
                                var Inv_parameters_4 = new
                                {
                                    Inves_Unsafe_Cond_Id = item.Inves_Unsafe_Cond_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_Unsafe_Cond_Id = item.M_Unsafe_Cond_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_4, Inv_parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_PF != null && entity.L_Inves_Root_Cause_PF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_PF)
                            {
                                var Inv_parameters_5 = new
                                {
                                    Inves_RootCause_PF_Id = item.Inves_RootCause_PF_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_RootCause_PF_Id = item.M_RootCause_PF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_5, Inv_parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_SF != null && entity.L_Inves_Root_Cause_SF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_SF)
                            {
                                var Inv_parameters_6 = new
                                {
                                    Inves_RootCause_SF_Id = item.Inves_RootCause_SF_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_RootCause_SF_Id = item.M_RootCause_SF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_6, Inv_parameters_6, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Mechanism_InjuryIllness != null && entity.L_Inves_Mechanism_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Mechanism_InjuryIllness)
                            {
                                var Inv_parameters_7 = new
                                {
                                    Inves_Mechanism_Injury_Id = item.Inves_Mechanism_Injury_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_Mechanism_InjuryIllness_Id = item.M_Mechanism_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_7, Inv_parameters_7, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_AgencySource_InjuryIllness != null && entity.L_Inves_AgencySource_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_AgencySource_InjuryIllness)
                            {
                                var Inv_parameters_8 = new
                                {
                                    Inves_AgencySource_Injury_Id = item.Inves_AgencySource_Injury_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    M_AgencySource_InjuryIllness_Id = item.M_AgencySource_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(Inv_procedure_8, Inv_parameters_8, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Environmental_Impact_Details != null && entity.L_Inves_Environmental_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Environmental_Impact_Details)
                            {
                                var Inv_parameters_9 = new
                                {
                                    Inves_Environmental_Id = item.Inves_Environmental_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Environmental_Incident = item.Environmental_Incident,
                                    Cause_Of_Release = item.Cause_Of_Release,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_9, Inv_parameters_9, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Security_Impact_Details != null && entity.L_Inves_Security_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Security_Impact_Details)
                            {
                                var Inv_parameters_10 = new
                                {
                                    Inves_Security_Id = item.Inves_Security_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Classification_Id = item.Classification_Id,
                                    Type_of_Security_Incident_Id = item.Type_of_Security_Incident_Id,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_10, Inv_parameters_10, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Actions_Taken_Immediately != null && entity.L_Inves_Actions_Taken_Immediately.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Actions_Taken_Immediately)
                            {
                                var Inv_parameters_11 = new
                                {
                                    Inves_Action_Taken_Id = item.Inves_Action_Taken_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Description_of_Actions = item.Description_of_Actions,
                                    Action_Taken_By = item.Action_Taken_By,
                                    Date_Completed = item.Date_Completed,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_11, Inv_parameters_11, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Incident_Root_Cause != null && entity.L_Inves_Incident_Root_Cause.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Incident_Root_Cause)
                            {
                                var Inv_parameters_12 = new
                                {
                                    Inves_Root_Cause_Id = item.Inves_Root_Cause_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Root_Cause_Description = item.Root_Cause_Description,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_12, Inv_parameters_12, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Corrective_Actions != null && entity.L_Inves_Corrective_Actions.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Corrective_Actions)
                            {
                                var Inv_parameters_13 = new
                                {
                                    Inves_Corrective_Action_Id = item.Inves_Corrective_Action_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Description_Actions = item.Description_Actions,
                                    Person_Responsible = item.Person_Responsible,
                                    Priority = item.Priority,
                                    Target_Date = item.Target_Date,
                                    CreatedBy = entity.CreatedBy,
                                    Action_Taken = item.Action_Taken,
                                    Upload_Evidence = item.Upload_Evidence
                                };
                                await connection.ExecuteAsync(Inv_procedure_13, Inv_parameters_13, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Declarations_Approvals != null && entity.L_Inves_Declarations_Approvals.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Declarations_Approvals)
                            {
                                var Inv_parameters_14 = new
                                {
                                    Inves_Declarations_Approvals_Id = item.Inves_Declarations_Approvals_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Report_Status = item.Report_Status,
                                    HSSE_Representative_Id = item.HSSE_Representative_Id,
                                    Department_Representative_Id = item.Department_Representative_Id,
                                    Other_Representative_Id = item.Other_Representative_Id,
                                    Date = item.Date,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(Inv_procedure_14, Inv_parameters_14, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Attachements != null && entity.L_Inves_Attachements.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Attachements)
                            {
                                var Inv_parameters_15 = new
                                {
                                    Inves_Attachements_Id = item.Inves_Attachements_Id,
                                    Inc_Id = Obj.Inc_Id,
                                    Title = item.Title,
                                    Is_Attachements = item.Is_Attachements,
                                    Attachements_Description = item.Attachements_Description,
                                    CreatedBy = entity.CreatedBy,
                                    File_Path = item.File_Path,

                                };
                                await connection.ExecuteAsync(Inv_procedure_15, Inv_parameters_15, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_8 = new
                        {
                            Inc_Notification_Id = Obj.Inc_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_9 = new
                        {
                            Inc_Id = Obj.Inc_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(procedure_9, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        //var parameters_10 = new
                        //{
                        //    Schedule_Type_Id = Obj.Inc_Id,
                        //    Zone_Id = entity.Zone,
                        //    Community_Id = entity.Community_Id,
                        //    Building_Id = entity.Building,
                        //    Module_Name = "Incident Report",
                        //    Hyper_Link = "/Incident/IncidentReporting",
                        //    CreatedBy = entity.CreatedBy,
                        //    Role_Id = "5",
                        //    Status = "1",
                        //    Remarks = Obj.Inc_Id
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure_10, parameters_10, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

        public async Task<IReadOnlyList<M_Incident_Report>> IncidentNotificationCardView(M_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Inc_Notification_Dashboard_PopupDetails";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Zone_Id = entity.Zone,
                        Cid = entity.Action,
                    };
                    return (await connection.QueryAsync<M_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Master IncidentNotificationCardView";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}
