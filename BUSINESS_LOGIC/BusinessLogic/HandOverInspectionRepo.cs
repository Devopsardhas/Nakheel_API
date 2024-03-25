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
using static Dapper.SqlMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class HandOverInspectionRepo : IHandOverInspectionRepo
    {
        private readonly IConfiguration configuration;
        private IHostingEnvironment Environment;
        public HandOverInspectionRepo(IConfiguration configuration, IHostingEnvironment _environment)
        {
            this.configuration = configuration;
            this.Environment = _environment;
        }
#pragma warning disable CS8603 // Possible null reference return.
        #region [HandOver Inspection]
        public async Task<M_Return_Message> AddAsync(M_Insp_HandOver entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_HandOver_Building_Crud";
                string procedure_2 = "sp_Qns_HandOver_Building_Add";
                string procedure_3 = "sp_Insp_HandOver_QnObservation_Add";
                string procedure_4 = "sp_Insp_HandOver_Building_History_Add";
                string procedure_5 = "sp_Insp_HandOver_Building_History_HSE";
                string procedure_6 = "sp_Send_Email_and_Noti_Insp_HandOver_Add";
                string procedure_7 = "sp_Insp_HandOver_Qns_Rej_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Insp_HndOver_Building_Id == "0")
                    {
                        var parameters_1 = new
                        {
                            Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                            Company_Name = entity.Company_Name,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            Zone_Id = entity.Zone_Id,
                            Building_Id = entity.Building_Id,
                            Community_Id = entity.Community_Id,
                            Business_Unit_Type_Name = entity.Business_Unit_Type_Name,
                            Date_of_Audit = entity.Date_of_Audit,
                            Zone_Representative = entity.Zone_Representative,
                            SP_Attended = entity.SP_Attended,
                            Service_Provider = entity.Service_Provider,
                            Others_SP = entity.Others_SP,
                            Inspected_By_Name = entity.Inspected_By_Name,
                            HandOver_Type = entity.HandOver_Type,
                            HandOver_Type_List = entity.HandOver_Type_List,
                            Consultant_Name = entity.Consultant_Name,
                            Consultant_MNo = entity.Consultant_MNo,
                            Contractor_Name = entity.Contractor_Name,
                            Contractor_MNo = entity.Contractor_MNo,
                            CreatedBy = entity.CreatedBy,
                            Description = entity.Description
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_HandOver>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj != null)
                        {
                            var entityHis = new
                            {
                                Insp_HndOver_Building_Id = Obj.Insp_HndOver_Building_Id,
                                CreatedBy = entity.CreatedBy,
                                Role_Id = entity.Role_Id
                            };
                            var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            var parameters_5 = new
                            {
                                Insp_HndOver_Building_Id = Obj.Insp_HndOver_Building_Id,
                            };
                            var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    else
                    {
                        if (entity.L_Insp_HandOver_Questionnaires != null && entity.L_Insp_HandOver_Questionnaires.Count > 0)
                        {
                            var parameters_Del = new
                            {
                                Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure_7, parameters_Del, commandType: CommandType.StoredProcedure);
                            foreach (var item in entity.L_Insp_HandOver_Questionnaires)
                            {
                                var parameters_2 = new
                                {
                                    Insp_Qns_Building_Id = 0,
                                    Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                                    Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                    Qns_Action = item.Qns_Action,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Risk_Level = item.Risk_Level,
                                    Risk_Description = item.Risk_Description,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Insp_HandOver_Observation != null && entity.L_Insp_HandOver_Observation.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_HandOver_Observation)
                            {
                                var parameters_3 = new
                                {
                                    Insp_HealthSafety_Id = entity.Insp_HndOver_Building_Id,
                                    Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        var entityHis = new
                        {
                            Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_5, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_5 = new
                        {
                            Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
        public Task<M_Return_Message> DeleteAsync(M_Insp_HandOver entity)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<M_Insp_HandOver>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<M_Insp_HandOver>> HandOver_Building_GetAllAsync(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var HandOver_Type = "";
                var Zone_Name = "";
                var Community_Name = "";
                var Date_of_Audit = "";
                var Status = "";
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
                                HandOver_Type = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                Date_of_Audit = item.Search!.Value;
                                break;
                            case 5:
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
                    CreatedBy = entity.CreatedBy
                };
                string procedure = "sp_GetAll_Inspection_HandOver_Building";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_HandOver>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "InspHandOverBuildingGetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HandOver> GetByIdAsync(M_Insp_HandOver entity)
        {
            try
            {
                string procedure1 = "sp_Get_Insp_HandOver_Building_GetById";
                string procedure2 = "sp_Insp_History_By_HndOver_Building_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HandOver>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Insp_HandOver_Building_History>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_HandOver_Building_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HandOver Building GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public Task<M_Return_Message> UpdateAsync(M_Insp_HandOver entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<M_Insp_HandOver_Questionnaires>> Insp_HandOver_Building_Qn_GetAll(M_Insp_HandOver entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_HandOver_Questionnaires";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id
                    };
                    return (await connection.QueryAsync<M_Insp_HandOver_Questionnaires>(procedure, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_HandOver_Building_Qn_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_HndOver_Building_Pending(M_Insp_HandOver entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_HndOver_Building_Pending";
                string procedure_1 = "sp_Send_Email_and_Noti_Insp_HandOver_Manager";
                string procedure_2 = "sp_Insp_HandOver_Building_History_Manager"; 

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Date_of_Audit = entity.Date_of_Audit
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id
                    };
                    var objMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Update_HndOver_Building_Pending";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_HndOver_Bldg_Qns_Approval(M_Insp_HandOver entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_HndOver_Bldg_Qns_Approval";
                string procedure_1 = "sp_Send_Email_and_Noti_Insp_HandOver_Manager";
                //string procedure_1 = "sp_Update_Insp_HndOver_Bldg_Qns_Approval";
                string procedure_2 = "sp_Insp_HandOver_Building_History_Manager"; 

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var objMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
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
                string Repo = "Update_HndOver_Building_Pending";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HndOver_Insp_Reject(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_Handover_Reject";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Handover Insp Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HandOver> Get_HndOver_Bldg_Qns_View(M_Insp_HandOver entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_HndOver_Bldg_Common";
                string procedure_1 = "sp_Get_Insp_HndOver_Bldg_Qns_View";
                string procedure_2 = "sp_Insp_HndOver_Bldg_GetAll_Obs_View";
                string procedure_3 = "sp_Get_Insp_HandOver_CA_View";
                string procedure_4 = "sp_Insp_History_By_HndOver_Building_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HandOver>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_HandOver_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_Questionnaires = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_HndOver_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_CA = ObjCA;
                    var ObjHis = (await connection.QueryAsync<Insp_HandOver_Building_History>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_HandOver_Building_History = ObjHis;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_HndOver_Bldg_Qns_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HndOver_Building_Assign_Action(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_HndOver_Bldg_Assign_Action_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_HandOver_Assign"; 
                string procedure_3 = "sp_Insp_HandOver_Building_History_Assign"; 

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Bldg_Action_Id = entity.Bldg_Action_Id,
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Responsible_Id = entity.Responsible_Id,
                        Target_Date = entity.Target_Date,
                        Description_Action = entity.Description_Action,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    //connection.Execute(procedure, entity.L_M_Inc_Observation_Emp, commandType: CommandType.StoredProcedure);
                    //foreach (var item in entity.L_M_Inc_Observation_Emp!) M_Insp_HndOver_Assign_Action
                    //{
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id
                    };
                    var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //}
                    var parameters_3 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
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
                string Repo = "HandOverStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_HndOver_Bldg_Closure_Action(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_HndOver_Bldg_Closure_Action_Add";
                string procedure_1 = "sp_Insp_HndOver_CA_Photos_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_HandOver_Zone"; //HSE Team
                string procedure_3 = "sp_Insp_HandOver_Building_History_CA";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Description_Action = entity.Description_Action
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_Insp_HndOver_Photos != null && entity.L_Insp_HndOver_Photos.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_HndOver_Photos)
                        {
                            var parameters_1 = new
                            {
                                Bldg_Photo_Id = item.Bldg_Photo_Id,
                                Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                                Photo_File_Path = item.Photo_File_Path,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(procedure_1, parameters_1, commandType: CommandType.StoredProcedure);
                        }
                    }
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
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
                string Repo = "HandOverStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_HndOver_Assign_Action>> HandOver_Action_Closure_GetAll(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_HandOver_Action_Closure_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.Responsible_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_HndOver_Assign_Action>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "HandOver_Action_Closure_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HandOver> HandOver_Closure_GetById(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_HandOver_Building_GetById";
                string procedure_1 = "sp_Get_Insp_HndOver_Bldg_Qns_View";
                string procedure_2 = "sp_Insp_HndOver_Bldg_GetAll_Obs_View";
                string procedure_3 = "sp_Get_Insp_HandOver_CA_View";
                string procedure_4 = "sp_Insp_History_By_HndOver_Building_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HandOver>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_HandOver_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_Questionnaires = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_HndOver_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HandOver_CA = ObjCA;
                    var ObjHis = (await connection.QueryAsync<Insp_HandOver_Building_History>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_HandOver_Building_History = ObjHis;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HandOver Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HandOver_Closure_Action_Approval(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure_1 = "sp_HandOver_Action_Closure_Approval";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_HandOver_CA_Manager";
                string procedure_3 = "sp_Insp_HandOver_Building_History_CA_HSE"; 
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HndOver_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
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
                string Repo = "HandOver Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HandOver_Closure_Action_Reject(M_Insp_HndOver_Assign_Action entity)
        {
            try
            {
                string procedure_1 = "sp_HandOver_Action_Closure_Reject";
                string procedure_2 = "sp_Insp_HandOver_CA_Reject";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_HandOver_CA_Reject";
                string procedure_4 = "sp_Insp_HandOver_Building_History_CA_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HndOver_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_2 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_4 = new
                    {
                        Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "HandOver Closure Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Health & Safety Inspection]
        public async Task<M_Return_Message> AddAsync_HealthSafety(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_HealthSafety_Building_Add";
                string procedure_2 = "sp_Qns_HealthSafety_Building_Add";
                string procedure_3 = "sp_Insp_HealthSafety_Qns_Observation_Add";
                string procedure_6 = "sp_Insp_HS_Safety_Violation_Add";
                string procedure_4 = "sp_Update_HealthSafety_History_Add";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_Health_Add";
                var Safe_Id = "0";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Company_Name = entity.Company_Name,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Building_Id = entity.Building_Id,
                        Community_Id = entity.Community_Id,
                        Business_Unit_Type_Name = entity.Business_Unit_Type_Name,
                        Date_of_Inspection = entity.Date_of_Inspection,
                        Schedule_Type = entity.Schedule_Type,
                        Health_Safety_Type = entity.Health_Safety_Type,
                        Zone_Supervisor = entity.Zone_Supervisor,
                        Zone_Manager = entity.Zone_Manager,
                        Inspected_By_Id = entity.Inspected_By_Id,
                        Inspected_By_Name = entity.Inspected_By_Name,
                        CreatedBy = entity.CreatedBy,
                        Safety_Violation = entity.Safety_Violation,
                        Description = entity.Description
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Insp_HealthSafety_Questionnaires != null && entity.L_Insp_HealthSafety_Questionnaires.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_HealthSafety_Questionnaires)
                            {
                                var parameters_2 = new
                                {
                                    Insp_Hs_Qns_Id = "0",
                                    Insp_HealthSafety_Id = Obj.Insp_HealthSafety_Id,
                                    Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                    Qns_Action = item.Qns_Action,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        if (entity.L_Insp_HealthSafety_Observation != null && entity.L_Insp_HealthSafety_Observation.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_HealthSafety_Observation)
                            {
                                var parameters_3 = new
                                {
                                    Insp_Hs_Obs_Id = "0",
                                    Insp_HealthSafety_Id = Obj.Insp_HealthSafety_Id,
                                    Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        var entityHis = new
                        {
                            Insp_HealthSafety_Id = Obj.Insp_HealthSafety_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_5 = new
                        {
                            Insp_HealthSafety_Id = Obj.Insp_HealthSafety_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (entity.Safety_Violation == "Yes")
                        {
                            var Params_SV = new
                            {
                                Insp_Request_Id = Obj.Insp_HealthSafety_Id,
                                Business_Unit_Id = entity.Business_Unit_Id,
                                Zone_Id = entity.Zone_Id,
                                Building_Id = entity.Building_Id,
                                Community_Id = entity.Community_Id,
                                Inspection_Date = entity.Date_of_Inspection,
                                Req_Unique_Id = Obj.Unique_Id,
                                Req_CreatedBy = entity.CreatedBy,
                                CreatedBy = entity.CreatedBy,
                                //Requirement = entity.Requirement
                            };
                            var objSV = (await connection.QueryAsync<M_Return_Message>(procedure_6, Params_SV, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            
                            if (objSV != null)
                            {
                                Safe_Id = objSV.Return_2;
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = Safe_Id
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
        public async Task<IReadOnlyList<M_Insp_HealthSafety_Master>> HealthSafety_GetAllAsync(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var HandOver_Type = "";
                var Zone_Name = "";
                var Community_Name = "";
                var Date_of_Inspection = "";
                var Status = "";
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
                                HandOver_Type = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                Date_of_Inspection = item.Search!.Value;
                                break;
                            case 5:
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
                    CreatedBy = entity.CreatedBy
                };
                string procedure = "sp_GetAll_Inspection_HealthSafety_Building";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "InspHealthSafetyBuildingGetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HealthSafety_Master> GetByIdAsync_HealthSafety(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure1 = "sp_Get_Insp_HealthSafety_Building_GetById";
                string procedure2 = "sp_Insp_HistoryBy_HealthSafety_GetById";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Insp_HealthSafety_History>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Insp_HealthSafety_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HealthSafety Building GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_HealthSafety_Building_Pending(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_HS_Building_Pending";
                //string procedure_1 = "sp_Upcoming_Activity_Add";
                //string procedure_1 = "sp_Send_Email_and_Noti_Obs_Category_Positive";
                //string procedure_2 = "sp_Obs_Status_History_Category_Positive";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Date_of_Inspection = entity.Date_of_Inspection,
                        Zone_Manager = entity.Zone_Manager,
                        Zone_Supervisor = entity.Zone_Supervisor,
                        Description = entity.Description
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //var parameters_1 = new
                    //{
                    //    Schedule_Type_Id = entity.Insp_HealthSafety_Id,
                    //    Zone_Id = entity.Zone_Id,
                    //    Community_Id = entity.Community_Id,
                    //    Building_Id = entity.Building_Id,
                    //    Module_Name = entity.Module_Name,
                    //    Hyper_Link = entity.Hyper_Link,
                    //    CreatedBy = entity.CreatedBy
                    //};
                    //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //var parameters_2 = new
                    //{
                    //    Insp_HndOver_Building_Id = entity.Insp_HndOver_Building_Id,
                    //    CreatedBy = entity.CreatedBy,
                    //    Role_Id = entity.Role_Id
                    //};
                    //var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Update_HealthSafety_Building_Pending";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_HealthSafety_Questionnaires>> Insp_HealthSafety_CheckList_Qn_GetAll(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure = "sp_tbl_Insp_HealthSafety_Questionnaires";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Health_Safety_Type == "HealthSafetyBuilding")
                    {
                        var parameters_1 = new
                    {
                        Action = 2
                    };
                    return (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    }
                    else
                    {
                        var parameters_2 = new
                        {
                            Action = 3
                        };
                        return (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_HealthSafety_Building_Qn_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HealthSafety_Master> Insp_HealthSafety_Qns_GetAll(M_Insp_HealthSafety_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_HealthSafety_Bldg_Common";
                string procedure_1 = "sp_tbl_Insp_HealthSafety_Questionnaires";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj!.Health_Safety_Type == "HealthSafetyBuilding")
                    {
                        var parameters_1 = new
                        {
                            Action = 2
                        };
                        var ObjQns = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Insp_HealthSafety_Questionnaires = ObjQns;
                    }
                    else
                    {
                        var parameters_2 = new
                        {
                            Action = 3
                        };
                        var ObjMCQns = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_1, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Insp_HealthSafety_Questionnaires = ObjMCQns;
                    }
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_HealthSafety_Building_Qn_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync_Qns_HealthSafety(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_HealthSafety_Bldg_Qns_Add";
                string procedure_1 = "sp_Qns_HealthSafety_Building_Add";
                string procedure_2 = "sp_Insp_HealthSafety_Qns_Observation_Add";
                string procedure_3 = "sp_Insp_HS_Safety_Violation_Add";
                string procedure_4 = "sp_Update_HealthSafety_History_Add";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_Health_HSE_Manager";
                string procedure_6 = "sp_Insp_HealthSafety_Qns_Rej_Delete";
                var Safe_Id = "0";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Del = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id
                    };
                    await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_Del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Safety_Violation = entity.Safety_Violation,
                        Date_of_Inspection = entity.Date_of_Inspection,
                        Zone_Manager = entity.Zone_Manager,
                        Zone_Supervisor = entity.Zone_Supervisor,
                        Description = entity.Description,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_Insp_HealthSafety_Questionnaires != null && entity.L_Insp_HealthSafety_Questionnaires.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_HealthSafety_Questionnaires)
                        {
                            var parameters_1 = new
                            {
                                Insp_Hs_Qns_Id = "0",
                                Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                                Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                Qns_Action = item.Qns_Action,
                                Photo_File_Path = item.Photo_File_Path,
                                Hazard_Risk = item.Hazard_Risk,
                                Requirements = item.Requirements,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.L_Insp_HealthSafety_Observation != null && entity.L_Insp_HealthSafety_Observation.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_HealthSafety_Observation)
                        {
                            var parameters_2 = new
                            {
                                Insp_Hs_Obs_Id = "0",
                                Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                                Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                Photo_File_Path = item.Photo_File_Path,
                                Hazard_Risk = item.Hazard_Risk,
                                Requirements = item.Requirements,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Safety_Violation == "Yes")
                    {
                        var Params_SV = new
                        {
                            Insp_Request_Id = entity.Insp_HealthSafety_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            Zone_Id = entity.Zone_Id,
                            Building_Id = entity.Building_Id,
                            Community_Id = entity.Community_Id,
                            Inspection_Date = entity.Date_of_Inspection,
                            Req_Unique_Id = entity.Unique_Id,
                            Req_CreatedBy = entity.CreatedBy,
                            CreatedBy = entity.CreatedBy,
                            Requirement = entity.Description
                        };
                        var objSV = (await connection.QueryAsync<M_Return_Message>(procedure_3, Params_SV, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (objSV != null)
                        {
                            Safe_Id = objSV.Return_2;
                        }
                    }
                    var entityHis = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var entityMail = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, entityMail, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = Safe_Id
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
                string Repo = "AddAsync_HealthSafetyQns";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Insp_HealthSafety_Master> Get_HealthSafety_Bldg_Qns_View(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_HealthSafety_Bldg_Common";
                string procedure_1 = "sp_Get_Insp_HealthSafety_Bldg_Qns_View";
                string procedure_2 = "sp_Get_Insp_HealthSafety_Observation_View";
                string procedure_3 = "sp_Get_Insp_HealthSafety_CA_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_1 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var ObjQns = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_Questionnaires = ObjQns;

                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_Observation = ObjObs;

                    var ObjCA = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Action>(procedure_3, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_CA = ObjCA;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_HealthSafety_Bldg_Qns_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_HealthSafety_Bldg_Qns_Approval(M_Insp_HealthSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_HealthSafety_Bldg_Qns_Approval";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_Health_Zone";
                string procedure_3 = "sp_Update_HealthSafety_History_Manager";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Update_HealthSafety_Bldg_Qns_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HealthSafety_Insp_Reject(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure_1 = "sp_HealthSafety_Insp_Reject";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason_Description = entity.Reject_Reason_Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "HealthSafety Insp Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_HealthSafety_Assign_Team(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_Insp_HealthSafety_Assign_Team";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_Health_Assign";
                //string procedure_3 = "sp_Update_HealthSafety_History_Assign";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_M_Insp_HealthSafety_Team, commandType: CommandType.StoredProcedure);
                    var parameters_2 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //var parameters_3 = new
                    //{
                    //    Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    //    CreatedBy = entity.CreatedBy,
                    //    Role_Id = entity.Role_Id,
                    //    Status = '5',
                    //    Remarks = "Service Provider/Zone Team Submission"
                    //};
                    //var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
        public async Task<M_Return_Message> HealthSafety_Closure_Action_Add(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_HealthSafety_Closure_Action_Add";
                string procedure_1 = "sp_Insp_HealthSafety_CA_Photos_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_Health_CA_Zone";
                string procedure_3 = "sp_Update_HealthSafety_History_Assign";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Assign_Action_Id = entity.Assign_Action_Id,
                        Action_Taken = entity.Action_Taken,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_M_Insp_HealthSafety_Photos != null && entity.L_M_Insp_HealthSafety_Photos.Count > 0)
                    {
                        foreach (var item in entity.L_M_Insp_HealthSafety_Photos)
                        {
                            var parameters_1 = new
                            {
                                Hs_Photo_Id = item.Hs_Photo_Id,
                                Assign_Action_Id = entity.Assign_Action_Id,
                                Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                                Photo_File_Path = item.Photo_File_Path,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(procedure_1, parameters_1, commandType: CommandType.StoredProcedure);
                        }
                    }
                    var parameters_2 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
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
                string Repo = "HandOverStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_HealthSafety_Assign_Team>> HealthSafety_Action_Closure_GetAll(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_HealthSafety_Action_Closure_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.Responsible_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Team>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "HealthSafety_Action_Closure_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_HealthSafety_Master> HealthSafety_Closure_GetById(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_HealthSafety_Bldg_Common";
                string procedure_1 = "sp_Get_Insp_HealthSafety_Bldg_Qns_View";
                string procedure_2 = "sp_Get_Insp_HealthSafety_Observation_View";
                string procedure_3 = "sp_Get_Insp_HealthSafety_CA_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_1 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                    };
                    var ObjQns = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_Questionnaires = ObjQns;

                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_Observation = ObjObs;

                    var ObjCA = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Action>(procedure_3, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_HealthSafety_CA = ObjCA;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HealthSafety Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HealthSafety_Closure_Action_Approval(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure_1 = "sp_HealthSafety_Action_Closure_Approval";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_Health_CA_HSE";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_Health_CA_HSE_Manager";
                string procedure_4 = "sp_Update_HealthSafety_History_Supervisor";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                            Assign_Action_Id = entity.Assign_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_2 = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        };
                        var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_3 = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                            Assign_Action_Id = entity.Assign_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_2 = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        };
                        var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_3 = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "HealthSafety Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> HealthSafety_Closure_Action_Reject(M_Insp_HealthSafety_Assign_Team entity)
        {
            try
            {
                string procedure_1 = "sp_HealthSafety_Action_Closure_Reject";
                string procedure_2 = "sp_Insp_HealthSafety_Reject";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_Health_CA_Reject";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Assign_Action_Id = entity.Assign_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Assign_Action_Id = entity.Assign_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_HealthSafety_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_2 = new
                    {
                        Insp_HealthSafety_Id = entity.Assign_Action_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason_Description = entity.Reject_Reason_Description,
                        CreatedBy = entity.CreatedBy,

                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_HealthSafety_Id = entity.Insp_HealthSafety_Id,
                        Assign_Action_Id = entity.Assign_Action_Id
                    };
                    var ObjAssignMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "HealthSafety Closure Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Service Provider Inspection]
        public async Task<M_Return_Message> AddAsync_ServiceProvider(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_Service_Provider_Add";
                string procedure_2 = "sp_Insp_ServiceProvider_Qns_Add";
                string procedure_3 = "sp_Insp_ServiceProvider_Qns_Obs_Add";
                string procedure_4 = "sp_Update_Service_Provider_History";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_ServiceProvider_Add";
                string procedure_6 = "sp_Insp_SP_Safety_Violation_Add";
                var Safe_Id = "0";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        Company_Name = entity.Company_Name,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Building_Id = entity.Building_Id,
                        Community_Id = entity.Community_Id,
                        Business_Unit_Type_Name = entity.Business_Unit_Type_Name,
                        Inspection_Date = entity.Inspection_Date,
                        Schedule_Type = entity.Schedule_Type,
                        Service_Provider_Type = entity.Service_Provider_Type,
                        Zone_In_Charge_Id = entity.Zone_In_Charge_Id,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Inspected_By_Id = entity.Inspected_By_Id,
                        Inspected_By_Name = entity.Inspected_By_Name,
                        CreatedBy = entity.CreatedBy,
                        Description = entity.Description
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Insp_ServiceProvider_Qns != null && entity.L_Insp_ServiceProvider_Qns.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_ServiceProvider_Qns)
                            {
                                var parameters_2 = new
                                {
                                    Insp_Service_Provider_Id = Obj.Insp_ServiceProvider_Id,
                                    Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                    Qns_Action = item.Qns_Action,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        if (entity.L_Insp_ServiceProvider_Observation != null && entity.L_Insp_ServiceProvider_Observation.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_ServiceProvider_Observation)
                            {
                                var parameters_3 = new
                                {
                                    Insp_Hs_Obs_Id = "0",
                                    Insp_ServiceProvider_Id = Obj.Insp_ServiceProvider_Id,
                                    Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        var entityHis = new
                        {
                            Insp_ServiceProvider_Id = Obj.Insp_ServiceProvider_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '1'
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_5 = new
                        {
                            Insp_Service_Provider_Id = Obj.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (entity.Safety_Violation == "Yes")
                        {
                            var Params_SV = new
                            {
                                Insp_Request_Id = Obj.Insp_ServiceProvider_Id,
                                Business_Unit_Id = entity.Business_Unit_Id,
                                Zone_Id = entity.Zone_Id,
                                Building_Id = entity.Building_Id,
                                Community_Id = entity.Community_Id,
                                Inspection_Date = entity.Inspection_Date,
                                Req_Unique_Id = Obj.Unique_Id,
                                Req_CreatedBy = entity.CreatedBy,
                                CreatedBy = entity.CreatedBy
                            };
                            var objSV = (await connection.QueryAsync<M_Return_Message>(procedure_6, Params_SV, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                            if (objSV != null)
                            {
                                Safe_Id = objSV.Return_2;
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = Safe_Id
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
        public async Task<IReadOnlyList<M_Insp_ServiceProvider_Master>> ServiceProvider_GetAllAsync(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var HandOver_Type = "";
                var Zone_Name = "";
                var Community_Name = "";
                var Date_of_Inspection = "";
                var Status = "";
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
                                HandOver_Type = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                Date_of_Inspection = item.Search!.Value;
                                break;
                            case 5:
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
                    CreatedBy = entity.CreatedBy
                };
                string procedure = "sp_GetAll_Inspection_Service_Provider";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ServiceProvider_GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_ServiceProvider_Master> GetByIdAsync_ServiceProvider(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure1 = "sp_Get_Insp_Service_Provider_GetById";
                string procedure2 = "sp_Insp_HistoryBy_ServiceProvider_GetById";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Insp_Service_Provider_History>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Insp_ServiceProvider_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Service Provider GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_ServiceProvider_Schedule(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_Service_Provider_Schedule";
                string procedure_2 = "sp_Update_Service_Provider_History";
                //string procedure_1 = "sp_Send_Email_and_Noti_Obs_Category_Positive";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        Inspection_Date = entity.Inspection_Date
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Status = '2'
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
                string Repo = "Update_ServiceProvider_Schedule";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_ServiceProvider_Master> Insp_ServiceProvider_Qn_GetAll(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_ServiceProvider_Questionnaires";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    
                    if (Obj!.Service_Provider_Type == "ServiceProviderBuilding")
                    {
                        var parameters_1 = new
                        {
                            Action = 2
                        };
                        var ObjQns = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Insp_ServiceProvider_Qns = ObjQns;
                    }
                    else
                    {
                        var parameters_2 = new
                        {
                            Action = 3
                        };
                        var ObjMCQns = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Insp_ServiceProvider_Qns = ObjMCQns;
                    }
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_HealthSafety_Building_Qn_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync_Qns_ServiceProvider(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_ServiceProvider_Qns_Add";
                string procedure_2 = "sp_Insp_ServiceProvider_Qns_Obs_Add";
                string procedure_3 = "sp_Insp_SP_Safety_Violation_Add";
                string procedure_4 = "sp_Update_Service_Provider_History_Add";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_ServiceProvider_HSE";
                string procedure_6 = "sp_Insp_Service_Qns_Rej_Delete";
                var Safe_Id = "0";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.L_Insp_ServiceProvider_Qns != null && entity.L_Insp_ServiceProvider_Qns.Count > 0)
                    {
                        var parameters_Del = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_Del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity.L_Insp_ServiceProvider_Qns)
                        {
                            var parameters_2 = new
                            {
                                Insp_Sp_Qns_Id = "0",
                                Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                                Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                Qns_Action = item.Qns_Action,
                                Photo_File_Path = item.Photo_File_Path,
                                Hazard_Risk = item.Hazard_Risk,
                                Requirements = item.Requirements,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.L_Insp_ServiceProvider_Observation != null && entity.L_Insp_ServiceProvider_Observation.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_ServiceProvider_Observation)
                        {
                            var parameters_2 = new
                            {
                                Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                                Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                Photo_File_Path = item.Photo_File_Path,
                                Hazard_Risk = item.Hazard_Risk,
                                Requirements = item.Requirements,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Safety_Violation == "Yes")
                    {
                        var Params_SV = new
                        {
                            Insp_Request_Id = entity.Insp_ServiceProvider_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            Zone_Id = entity.Zone_Id,
                            Building_Id = entity.Building_Id,
                            Community_Id = entity.Community_Id,
                            Inspection_Date = entity.Inspection_Date,
                            Req_Unique_Id = entity.Unique_Id,
                            Req_CreatedBy = entity.CreatedBy,
                            CreatedBy = entity.CreatedBy,
                            Requirement = entity.Description
                        };
                        var objSV = (await connection.QueryAsync<M_Return_Message>(procedure_3, Params_SV, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (objSV != null)
                        {
                            Safe_Id = objSV.Return_2;
                        }
                    }
                    var entityHis = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_5 = new
                    {
                        Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = Safe_Id
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
                string Repo = "AddAsync_HealthSafetyQns";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Insp_ServiceProvider_Qn_HSSETeam(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_Service_Provider_Safety_Violation";
                string procedure_2 = "sp_Update_Service_Provider_History_HSE_Team";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_SP_HSE_Manager";
                string procedure_4 = "sp_Send_Email_and_Noti_Insp_SP_Zone";
                string procedure_5 = "sp_Update_Service_Provider_History_Manager";
                string procedure_6 = "sp_Insp_Service_Qns_Rej_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id == "10" && entity.Status== "4")
                    {
                        var parameters_Del = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_Del, commandType: CommandType.StoredProcedure);
                        var parameters_1 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Status = '5'
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var entityHis = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_5, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_2 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_Del = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure_6, parameters_Del, commandType: CommandType.StoredProcedure);
                        var parameters_1 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Status = '4'
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var entityHis = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_2 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Insp_ServiceProvider_Qn_HSSETeam";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Insp_ServiceProvider_Master> Get_ServiceProvider_Qns_View(M_Insp_ServiceProvider_Master entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_Service_Provider_Common";
                string procedure_1 = "sp_Get_Insp_Service_Provider_Qns_View";
                string procedure_2 = "sp_Get_Insp_ServiceProvider_Observation_View";
                string procedure_3 = "sp_Get_Insp_ServiceProvider_CA_View";
                string procedure_4 = "sp_Insp_HistoryBy_ServiceProvider_GetById";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_Qns = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_CA = ObjCA; 
                    var ObjHis = (await connection.QueryAsync<Insp_Service_Provider_History>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_History = ObjHis;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_ServiceProvider_Bldg_Qns_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_ServiceProvider_Qns_Approval(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure = "sp_Update_Insp_Service_Provider_Qns_Approval";
                string procedure_1 = "sp_Send_Email_and_Noti_Insp_SP_HSE_Manager";
                string procedure_2 = "sp_Update_Service_Provider_History_Manager";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_Request_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var params_2 = new
                    {
                        Insp_Service_Provider_Id = entity.Insp_Request_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, params_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_2 = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Emp_Service_provider,
                        Status = '5'
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
                string Repo = "Update_HealthSafety_Bldg_Qns_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> ServiceProvider_Insp_Qns_Reject(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure_1 = "sp_ServiceProvider_Insp_Qns_Reject";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Service Provider Insp Qns Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_ServiceProvider_Assign_Team(M_Insp_ServiceProvider_Assign_Team entity)
         {
            try
            {
                string procedure = "sp_Insp_ServiceProvider_Assign_Team";
                string procedure_1 = "sp_Send_Email_and_Noti_Insp_SP_Assign";
                //string procedure_2 = "sp_Update_Service_Provider_History";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_M_Insp_ServiceProvider_Team, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //var parameters_3 = new
                    //{
                    //    Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                    //    CreatedBy = entity.CreatedBy,
                    //    Role_Id = entity.Role_Id,
                    //    Status = '6'
                    //};
                    //var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
        public async Task<M_Return_Message> ServiceProvider_Closure_Action_Add(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_Insp_ServiceProvider_Closure_Action_Add";
                string procedure_1 = "sp_Insp_ServiceProvider_CA_Photos_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_SP_CA";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_SP_CA_Service";
                string procedure_4 = "sp_Update_Service_Provider_History_CA_SP";
                string procedure_5 = "sp_Update_Service_Provider_History_CA_Zone";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        Action_Taken = entity.Action_Taken,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_M_Insp_ServiceProvider_Photos != null && entity.L_M_Insp_ServiceProvider_Photos.Count > 0)
                    {
                        foreach (var item in entity.L_M_Insp_ServiceProvider_Photos)
                        {
                            var parameters_1 = new
                            {
                                Sp_Photo_Id = item.Sp_Photo_Id,
                                Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                                Corrective_Action_Id = entity.Corrective_Action_Id,
                                Photo_File_Path = item.Photo_File_Path,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(procedure_1, parameters_1, commandType: CommandType.StoredProcedure);
                        }
                    }
                    if (entity.Responsible_Name == "Zone Team")
                    {
                        var parameters_2 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_3 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '7'
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_2 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_3 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '7'
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "HandOverStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_ServiceProvider_Assign_Team>> ServiceProvider_Action_Closure_GetAll(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_Insp_ServiceProvider_Action_Closure_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.Responsible_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Team>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ServiceProvider_Action_Closure_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_ServiceProvider_Master> ServiceProvider_Closure_GetById(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_Service_Provider_Common";
                string procedure_1 = "sp_Get_Insp_Service_Provider_Qns_View";
                string procedure_2 = "sp_Get_Insp_ServiceProvider_Observation_View";
                string procedure_3 = "sp_Get_Insp_ServiceProvider_CA_View";
                string procedure_4 = "sp_Insp_HistoryBy_ServiceProvider_GetById";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_Qns = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_ServiceProvider_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_CA = ObjCA;
                    var ObjHis = (await connection.QueryAsync<Insp_Service_Provider_History>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_ServiceProvider_History = ObjHis;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HealthSafety Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> ServiceProvider_Closure_Action_Approval(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure1 = "sp_Insp_ServiceProvider_CA_Approval";
                string procedure2 = "sp_Update_Service_Provider_History_CA_Supervisor";
                string procedure3 = "sp_Send_Email_and_Noti_Insp_SP_CA_HSE_Team";
                string procedure_4 = "sp_Send_Email_and_Noti_Insp_SP_Completed";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Team>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Team>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    if (entity.Role_Id! == "5")
                    {
                        var parameters_2 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '8'
                        };
                        var ObjUpdate_History = (await connection.QueryAsync<Observation_Status_History>(procedure2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        var parameters_3 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_2 = new
                        {
                            Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '9'
                        };
                        var ObjUpdate_History = (await connection.QueryAsync<Observation_Status_History>(procedure2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        var parameters_3 = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Service Provider Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> ServiceProvider_Closure_Action_Reject(M_Insp_ServiceProvider_Assign_Team entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_ServiceProvider_CA_Reject";
                string procedure_2 = "sp_Insp_ServiceProvider_Reject_Add";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_SP_Rejected";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_ServiceProvider_Assign_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_2 = new
                    {
                        Insp_ServiceProvider_Id = entity.Insp_ServiceProvider_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_Service_Provider_Id = entity.Insp_ServiceProvider_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Service Provider Closure Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Fire & Life Safety Inspection]
        public async Task<IReadOnlyList<M_Insp_FireLifeSafety_Questionnaires>> Insp_FireLifeSafety_Qns_GetAll(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Qns_All";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 2
                    };
                    return (await connection.QueryAsync<M_Insp_FireLifeSafety_Questionnaires>(procedure, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_FireLifeSafety_Qn_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync_FireLifeSafety(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_FireLifeSafety_Add";
                string procedure_2 = "sp_Insp_FireLifeSafety_Qns_Add";
                string procedure_3 = "sp_Insp_FireLifeSafety_Qns_Observation_Add";
                string procedure_4 = "sp_Insp_FireLifeSafety_History_Add";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_FireSafety_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Company_Name = entity.Company_Name,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Building_Id = entity.Building_Id,
                        Community_Id = entity.Community_Id,
                        Business_Unit_Type_Name = entity.Business_Unit_Type_Name,
                        Inspection_Date = entity.Inspection_Date,
                        Schedule_Type = entity.Schedule_Type,
                        Fire_Life_Type = entity.Fire_Life_Type,
                        Zone_Rep_Id = entity.Zone_Rep_Id,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Zone_Rep_Attended = entity.Zone_Rep_Attended,
                        Service_Provider_Attended = entity.Service_Provider_Attended,
                        Access_Schedule = entity.Access_Schedule,
                        Inspected_By_Name = entity.Inspected_By_Name,
                        CreatedBy = entity.CreatedBy,
                        Description = entity.Description
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Insp_FireLifeSafety_Qns != null && entity.L_Insp_FireLifeSafety_Qns.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_FireLifeSafety_Qns)
                            {
                                var parameters_2 = new
                                {
                                    Insp_Question_Id = "0",
                                    Insp_Request_Id = Obj.Insp_Request_Id,
                                    Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                    Qns_Action = item.Qns_Action,
                                    Details_of_Evidence = item.Details_of_Evidence,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level,
                                    Risk_Description = item.Risk_Description
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        if (entity.L_Insp_FireLifeSafety_Observation != null && entity.L_Insp_FireLifeSafety_Observation.Count > 0)
                        {
                            foreach (var item in entity.L_Insp_FireLifeSafety_Observation)
                            {
                                var parameters_3 = new
                                {
                                    Insp_Request_Id = Obj.Insp_Request_Id,
                                    Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                    Photo_File_Path = item.Photo_File_Path,
                                    Hazard_Risk = item.Hazard_Risk,
                                    Requirements = item.Requirements,
                                    Description_Action = item.Description_Action,
                                    Category = item.Category,
                                    Sub_Category = item.Sub_Category,
                                    Risk_Level = item.Risk_Level
                                };
                                var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        var entityHis = new
                        {
                            Insp_Request_Id = Obj.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_5 = new
                        {
                            Insp_Request_Id = Obj.Insp_Request_Id,
                        };
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Fire & Life Safety AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<IReadOnlyList<M_Insp_FireLifeSafety_Master>> FireLifeSafety_GetAllAsync(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var HandOver_Type = "";
                var Zone_Name = "";
                var Community_Name = "";
                var Date_of_Inspection = "";
                var Status = "";
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
                                HandOver_Type = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                Date_of_Inspection = item.Search!.Value;
                                break;
                            case 5:
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
                    CreatedBy = entity.CreatedBy
                };
                string procedure = "sp_Insp_Fire_Life_Safety_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Fire & Life Safety GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_FireLifeSafety_Master> Insp_FireLifeSafety_GetByID(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure1 = "sp_Insp_FireLifeSafety_GetById";
                string procedure2 = "sp_Insp_FireLifeSafety_HistoryBy_GetById";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Insp_FireLifeSafety_History>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Insp_FireLifeSafety_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Fire & Life Safety GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_FireLifeSafety_Schedule(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Schedule_Update";
                //string procedure_1 = "sp_Send_Email_and_Noti_Obs_Category_Positive";
                string procedure_2 = "sp_Insp_FireLifeSafety_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Zone_Rep_Attended = entity.Zone_Rep_Attended,
                        Service_Provider_Attended = entity.Service_Provider_Attended,
                        Zone_Rep_Id = entity.Zone_Rep_Id,
                        Service_Provider_Id = entity.Service_Provider_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Status = '2',
                        Remarks = "HSE Team Findings"
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
                string Repo = "Fire & Life Safety Schedule";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_FireLifeSafety_Master> Insp_FireLifeSafetyCS_Qns_GetAll(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Questionnaires";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var parameters_2 = new
                        {
                            Action = 2
                        };
                        var ObjCSQns = (await connection.QueryAsync<M_Insp_FireLifeSafety_Questionnaires>(procedure, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Insp_FireLifeSafety_Qns = ObjCSQns;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Fire & Life Safety Questions GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync_Qns_FireLifeSafety(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Schedule_Update";
                string procedure_1 = "sp_Insp_FireLifeSafety_Qns_Add";
                string procedure_2 = "sp_Insp_FireLifeSafety_Qns_Observation_Add"; 
                string procedure_3 = "sp_Insp_FLS_Safety_Violation_Add";
                string procedure_4 = "sp_Insp_FireLifeSafety_History_Add";
                string procedure_5 = "sp_Send_Email_and_Noti_Insp_FireSafety_Manager";
                var Safe_Id = "0";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Zone_Rep_Attended = entity.Zone_Rep_Attended,
                        Zone_Rep_Id = entity.Zone_Rep_Id,
                        Service_Provider_Attended = entity.Service_Provider_Attended,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Safety_Violation = entity.Safety_Violation,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_Insp_FireLifeSafety_Qns != null && entity.L_Insp_FireLifeSafety_Qns.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_FireLifeSafety_Qns)
                        {
                            var parameters_1 = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Questionnaires_Id = item.Insp_Questionnaires_Id,
                                Qns_Action = item.Qns_Action,
                                Photo_File_Path = item.Photo_File_Path,
                                Details_of_Evidence = item.Details_of_Evidence,
                                Risk_Description = item.Risk_Description,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.L_Insp_FireLifeSafety_Observation != null && entity.L_Insp_FireLifeSafety_Observation.Count > 0)
                    {
                        foreach (var item in entity.L_Insp_FireLifeSafety_Observation)
                        {
                            var parameters_2 = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Questionnaires_Name = item.Insp_Questionnaires_Name,
                                Photo_File_Path = item.Photo_File_Path,
                                Hazard_Risk = item.Hazard_Risk,
                                Requirements = item.Requirements,
                                Description_Action = item.Description_Action,
                                Category = item.Category,
                                Sub_Category = item.Sub_Category,
                                Risk_Level = item.Risk_Level
                            };
                            var ObjQns = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Safety_Violation == "Yes")
                    {
                        var Params_SV = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            Zone_Id = entity.Zone_Id,
                            Building_Id = entity.Building_Id,
                            Community_Id = entity.Community_Id,
                            Inspection_Date = entity.Inspection_Date,
                            Req_Unique_Id = entity.Unique_Id,
                            Req_CreatedBy = entity.CreatedBy,
                            CreatedBy = entity.CreatedBy
                        };
                        var objSV = (await connection.QueryAsync<M_Return_Message>(procedure_3, Params_SV, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (objSV != null)
                        {
                            Safe_Id = objSV.Return_2;
                        }
                    }
                    var entityHis = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, entityHis, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_5 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = Safe_Id
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
                string Repo = "Fire & Life Safety AddAsync Qns";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Insp_FireLifeSafety_Master> Get_FireLifeSafety_Qns_View(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Get_Common";
                string procedure_1 = "sp_Insp_FireLifeSafety_Get_Qns_View";
                string procedure_2 = "sp_Get_Insp_FireLifeSafety_Obs_View";
                string procedure_3 = "sp_Get_Insp_FireLifeSafety_CA_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_FireLifeSafety_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_Qns = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_CA = ObjCA;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_FireLifeSafety_Qns_View";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Update_FireLifeSafety_Qns_Approval(M_Insp_FireLifeSafety_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_FireLifeSafety_Update_Qns_Approval";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_FireSafety_Zone";
                string procedure_3 = "sp_Insp_FireLifeSafety_History_Manager";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var objHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Update_FireLifeSafety_Qns_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_FireLifeSafety_Assign_Team(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Assign_Team";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_FireSafety_CA_Team";
                //string procedure_3 = "sp_Insp_FireLifeSafety_History_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Execute(procedure, entity.L_M_Insp_FireLifeSafety_Team, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    //var parameters_3 = new
                    //{
                    //    Insp_Request_Id = entity.Insp_Request_Id,
                    //    CreatedBy = entity.CreatedBy,
                    //    Role_Id = entity.Role_Id,
                    //    Status = '5',
                    //    Remarks = "Evidence Pending"
                    //};
                    //var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "FireLifeSafetyStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> FireLifeSafety_Closure_Action_Add(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Closure_Action_Add";
                string procedure_1 = "sp_Insp_FireLifeSafety_CA_Photos_Add";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_FireSafety_CA";
                string procedure_3 = "sp_Insp_FireLifeSafety_History_CA_SP";
                string procedure_4 = "sp_Insp_FireLifeSafety_History_CA_Zone";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Action_Taken = entity.Action_Taken,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.L_M_Insp_FireLifeSafety_Photos != null && entity.L_M_Insp_FireLifeSafety_Photos.Count > 0)
                    {
                        foreach (var item in entity.L_M_Insp_FireLifeSafety_Photos)
                        {
                            var parameters_1 = new
                            {
                                Photo_Id = item.Photo_Id,
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Corrective_Action_Id = entity.Corrective_Action_Id,
                                Photo_File_Path = item.Photo_File_Path,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(procedure_1, parameters_1, commandType: CommandType.StoredProcedure);
                        }
                    }
                    var parameters_2 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if(entity.Role_Id! == "5")
                    { 
                    var parameters_3 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters_3 = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id
                        };
                        var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "FireLifeSafetyStatusUpdate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_FireLifeSafety_Master>> FireLifeSafety_Action_Closure_GetAll(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Action_Closure_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "FireLifeSafety_Action_Closure_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_FireLifeSafety_Master> FireLifeSafety_Closure_GetById(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_FireLifeSafety_Get_Common";
                string procedure_1 = "sp_Insp_FireLifeSafety_Get_Qns_View";
                string procedure_2 = "sp_Get_Insp_FireLifeSafety_Obs_View";
                string procedure_3 = "sp_Get_Insp_FireLifeSafety_CA_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var ObjQns = (await connection.QueryAsync<M_Insp_FireLifeSafety_Questionnaires>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_Qns = ObjQns;
                    var ObjObs = (await connection.QueryAsync<M_Insp_HealthSafety_Questionnaires>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_Observation = ObjObs;
                    var ObjCA = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    Obj!.L_Insp_FireLifeSafety_CA = ObjCA;
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "FireLifeSafety Closure GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> FireLifeSafety_Closure_Action_Approval(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_FireLifeSafety_CA_Approval";
                string procedure_2 = "sp_Send_Email_and_Noti_Insp_FireSafety_CA_Approval";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_FireSafety_CA_Closed";
                string procedure_4 = "sp_Insp_FireLifeSafety_History_CA_Supervisor";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_2 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "FireLifeSafety Closure Action";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> FireLifeSafety_Closure_Action_Reject(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            try
            {
                string procedure_1 = "sp_Insp_FireLifeSafety_CA_Reject";
                string procedure_2 = "sp_Insp_FireLifeSafety_Reject_Add";
                string procedure_3 = "sp_Send_Email_and_Noti_Insp_FireSafety_CA_Reject";
                string procedure_4 = "sp_Insp_FireLifeSafety_History_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Role_Id! == "5")
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '2'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = entity.Corrective_Action_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Insp_FireLifeSafety_Assign_Action>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    var parameters_2 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Reject_Stage = entity.Reject_Stage,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy
                    };
                    var ObjRej = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_1 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Status = '3'
                    };
                    var ObjMail = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var parameters_3 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id
                    };
                    var ObjHis = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "FireLife Closure Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Upload Image]
        public List<string> UploadImage(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("HandOverFilePath");

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/InspChecklistImages"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "video/mp4" || postedFile.ContentType == "video/avi" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.presentationml.presentation" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "application/vnd.ms-powerpoint" || postedFile.ContentType == "docx" || postedFile.ContentType == "doc")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }
                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public List<string> Upload_Picture(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("HandOverFilePath");

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/InspChecklistImages"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "image/bmp")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }
                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion
#pragma warning restore CS8603 // Possible null reference return.
    }
}