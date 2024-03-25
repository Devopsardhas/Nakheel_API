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
using System.Globalization;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class ControlofWork_MasterRepo : IControlofWork_MasterRepo
    {
        private readonly IConfiguration configuration;
        public ControlofWork_MasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        #region[COW MAJOR HSE RISK]
        public async Task<IReadOnlyList<M_ControlofWork_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Risk_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_ControlofWork_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_HSE_Master : GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_ControlofWork_Master entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Risk_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Major_HSE_Work_Id = entity.Major_HSE_Work_Id,
                        Major_HSE_Work_Name = entity.Major_HSE_Work_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_HSE_Master : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_ControlofWork_Master entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Risk_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Major_HSE_Work_Id = entity.Major_HSE_Work_Id,
                        Major_HSE_Work_Name = entity.Major_HSE_Work_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_HSE_Master : UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_ControlofWork_Master> GetByIdAsync(M_ControlofWork_Master entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Risk_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Major_HSE_Work_Id = entity.Major_HSE_Work_Id
                    };
                    return (await connection.QueryAsync<M_ControlofWork_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_HSE_Master : GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_ControlofWork_Master entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Risk_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Major_HSE_Work_Id = entity.Major_HSE_Work_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_HSE_Master : DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region
        public async Task<IReadOnlyList<M_MajorQuestion>> Major_Ques_GetAll()
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Question_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_Ques_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_MajorQuestion>> Major_Ques_GetById(M_MajorQuestion entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Question_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Major_HSE_Work_Id = entity.Major_HSE_Work_Id,
                    };
                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_Ques_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Major_Ques_Add(List<M_MajorQuestion> entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Question_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Major_HSE_Ques_Id = item.Major_HSE_Ques_Id,
                            Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                            Major_Questionnaires_Name = item.Major_Questionnaires_Name,
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
                string Repo = "Major_Ques_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Major_Ques_Delete(M_MajorQuestion entity)
        {
            try
            {
                string procedure = "Sp_tbl_Major_HSE_Question_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Major_HSE_Ques_Id = entity.Major_HSE_Ques_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Major_Ques_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }



        public async Task<IReadOnlyList<M_MajorQuestion>> Get_All_Questionnaire_Work()
        {
            try
            {
                string procedure = "sp_Load_Confined_Space_Questionaries";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Questionnaire_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        #endregion

        #region [Confined Space Permit to Work]
        public async Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Confined_Space_Req(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Community_Name = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
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
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
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
                string procedure = "sp_Ptw_CSP_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Confined_Space_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Confined_Space_Req(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_Request";
                string procedure_Questionaire = "sp_Ptw_CSP_Add_Request_Questionnaire";
                string procedure_Ques_delete = "sp_Ptw_CSP_Delete_Request_Questionnaire";
                string procedure_History = "sp_Ptw_CSP_Add_History_Approval";
                string procedure_Staff_Files = "sp_Ptw_CSP_Add_Staff_Comp_Files";
                string procedure_Method_Files = "sp_Ptw_CSP_Add_Method_State_Files";
                string procedure_Risk_Files = "sp_Ptw_CSP_Add_Risk_Assess_Files";
                string procedure_Emergency_Files = "sp_Ptw_CSP_Add_Emr_Plan_Files";
                string procedure_HSE_Files = "sp_Ptw_CSP_Add_HSE_Plan_Files";
                string procedure_Signed_Files = "sp_Ptw_CSP_Add_Signature_Files";

                string procedure_Del_Method = "sp_Ptw_CSP_Delete_Method_Files";
                string procedure_Del_Risk = "sp_Ptw_CSP_Delete_Risk_Files";
                string procedure_Del_EMR = "sp_Ptw_CSP_Delete_EMR_Files";
                string procedure_Del_HSE = "sp_Ptw_CSP_Delete_HSE_Files";
                string procedure_Del_Staff = "sp_Ptw_CSP_Delete_Staff_Files";
                string procedure_Del_Signed = "sp_Ptw_CSP_Delete_Signed_Files";

                string Procedure_Sp_Req = "sp_Ptw_CSP_Add_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id,
                        Date_Time_of_Observation = entity.Date_Time_of_Observation,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Company_Name = entity.Company_Name,
                        Contrator_Title_No = entity.Contrator_Title_No,
                        Competent_Person = entity.Competent_Person,
                        Name = entity.Name,
                        Position = entity.Position,
                        Contact = entity.Contact,
                        Email_Id = entity.Email_Id,
                        Date_and_Time = entity.Date_and_Time,
                        Description_of_Work = entity.Description_of_Work,
                        Approved_Method = entity.Approved_Method,
                        Additional_Precautions = entity.Additional_Precautions,
                        Work_Duration_From_Date = entity.Work_Duration_From_Date,
                        Work_Duration_To_Date = entity.Work_Duration_To_Date,
                        Night_Schedule = entity.Night_Schedule,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Location_Address = entity.Location_Address,
                        Exact_Loc_Address = entity.Exact_Loc_Address,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        Building_Id = entity.Building_Id,
                        Contractor_Name = entity.Contractor_Name,
                        Contractor_Start_Date = entity.Contractor_Start_Date,
                        Contractor_End_Date = entity.Contractor_End_Date,
                        DMS_No_Id = entity.DMS_No_Id,
                        Competent_Number = entity.Competent_Number,
                        HSE_Officer_Name = entity.HSE_Officer_Name,
                        HSE_Mobile_Number = entity.HSE_Mobile_Number,
                        Declare_Name = entity.Declare_Name,
                        Declare_Designation = entity.Declare_Designation,
                        Declare_Chk = entity.Declare_Chk
                    };

                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var Email_Param = new
                    {
                        CSP_Id = CSP_List!.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(Procedure_Sp_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_CSP_Ques != null && entity._Add_CSP_Ques.Count > 0)
                    {

                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Ques_delete, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_CSP_Ques)
                        {
                            var param_Ques = new
                            {
                                Ques_CSP_ID = item.Ques_CSP_ID,
                                CSP_Id = CSP_List!.CSP_Id!,
                                Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                                CSP_Ques_Name = item.CSP_Ques_Name,
                                CSP_Ques_Radio_Btn = item.CSP_Ques_Radio_Btn,
                                CSP_Remarks = item.CSP_Remarks,
                                CreatedBy = item.CreatedBy,

                            };
                            var Quest_list = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure_Questionaire, param_Ques, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }                      
                    }
                    if(entity._Staff_Comptency_Files != null && entity._Staff_Comptency_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Staff, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Staff_Comptency_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                File_Id = photos.File_Id,
                                File_Path = photos.File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Photos_list = (await connection.QueryAsync<Staff_Comptency_Files>(procedure_Staff_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Method_Statement_Files != null && entity._Method_Statement_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Method, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Method_Statement_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Method_File_Id = photos.Method_File_Id,
                                Method_File_Path = photos.Method_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Method_list = (await connection.QueryAsync<Method_Statement_Files>(procedure_Method_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Risk_Assess_Files != null && entity._Risk_Assess_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Risk, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Risk_Assess_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Risk_File_Id = photos.Risk_File_Id,
                                Risk_File_Path = photos.Risk_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Risk_list = (await connection.QueryAsync<Risk_Assess_Files>(procedure_Risk_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Emr_Plan_Files != null && entity._Emr_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_EMR, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Emr_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Emr_File_Id = photos.Emr_File_Id,
                                Emr_File_Path = photos.Emr_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Emr_list = (await connection.QueryAsync<Emr_Plan_Files>(procedure_Emergency_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._HSE_Plan_Files != null && entity._HSE_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_HSE, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._HSE_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Hse_File_Id = photos.Hse_File_Id,
                                Hse_File_Path = photos.Hse_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<HSE_Plan_Files>(procedure_HSE_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Signed_Files != null && entity._Sp_Signed_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Signed, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity!._Sp_Signed_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Sign_File_Id = photos.Sign_File_Id,
                                Sign_File_Path = photos.Sign_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<Sp_Signed_Files>(procedure_Signed_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }

                    if (entity._Ptw_History_List != null)
                    {
                        foreach(var obj in entity._Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "1",
                                Remarks = "Zone Supervisor Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Confined_Space_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Confined_Space_Add> Edit_Confined_Space(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Request_Edit";
                string procedure1 = "sp_Ptw_CSP_Request_Questionnaire_Edit";
                string procedure2 = "sp_Business_Unit_Master_GetAll";
                string procedure3 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";

                //Zone Reject Get
                string procedure6 = "sp_Ptw_CSP_Get_Zone_Reject_Details";

                //Zone Approve Get
                //string procedure7 = "sp_Ptw_CSP_Get_Zone_Approval_Details";

                //Hse Reject Get
                string procedure8 = "sp_Ptw_CSP_Get_Hse_Reject_Details";

                //Hse Approve Get
                //string procedure9 = "sp_Ptw_CSP_Get_Hse_Approval_Details";

                //Get History of Approval
                string procedure10 = "sp_Ptw_Csp_Get_History_Approval";

                //Staff File Get
                string Procedure11 = "sp_Ptw_CSP_Staff_Files_Get";

                string procedure12 = "sp_Ptw_CSP_Additional_Details_Edit";
                string procedure13 = "sp_Ptw_CSP_Personal_Tools_Edit";
                string procedure14 = "sp_Ptw_CSP_Evidence_Files_Edit";

                string procedure15 = "sp_Ptw_CSP_Renewal_Details_Edit";

                string Procedure16 = "sp_Ptw_CSP_Method_Files_Get";
                string Procedure17 = "sp_Ptw_CSP_Risk_Assess_Get";
                string Procedure18 = "sp_Ptw_CSP_Emr_Plan_Get";
                string Procedure19 = "sp_Ptw_CSP_HSE_Plan_Get";
                string procedure20 = "sp_Ptw_CSP_Closure_Evd_Get";
                string procedure21 = "sp_Ptw_CSP_Signed_Files_Get";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (CSP_List != null)
                    {
                        var Ques_List = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Ques_List != null)
                        {
                            CSP_List._Add_CSP_Ques = Ques_List;
                        }
                        CSP_List!.CSP_Comman_Master_List = new Basic_Master_Data();
                        CSP_List!.CSP_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var parameters_Zone = new
                        {
                            Zone_Id = CSP_List.Zone_Id,
                            Community_Id = CSP_List.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();

                        //Zone Reject Get 
                        var Zone_Reject_Get_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure6, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        //Hse Reject Get 
                        var Hse_Reject_Get_List = (await connection.QueryAsync<Confined_Space_HSE_Approve_Reject>(procedure8, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        //Get History of Approval
                        var History_Approval_Get_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure10, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        //Get_Staff_Files
                        var Staff_Files_List = (await connection.QueryAsync<Staff_Comptency_Files>(Procedure11, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Method_Files_List = (await connection.QueryAsync<Method_Statement_Files>(Procedure16, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Risk_Files_List = (await connection.QueryAsync<Risk_Assess_Files>(Procedure17, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Emr_Files_List = (await connection.QueryAsync<Emr_Plan_Files>(Procedure18, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var HSE_Files_List = (await connection.QueryAsync<HSE_Plan_Files>(Procedure19, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Signed_Files_List = (await connection.QueryAsync<Sp_Signed_Files>(procedure21, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Add_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Renewal_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Details>(procedure15, parameters, commandType: CommandType.StoredProcedure)).ToList();



                        if (Business_Unit_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if(Zone_Reject_Get_List != null && Zone_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Zone_Reject_List = Zone_Reject_Get_List;
                        }                       
                        if (Hse_Reject_Get_List != null && Hse_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Hse_Approval_List = Hse_Reject_Get_List;
                        }                       
                        if (History_Approval_Get_List != null)
                        {
                            CSP_List._Ptw_History_List = History_Approval_Get_List;
                        }
                        if(Staff_Files_List != null && Staff_Files_List.Count > 0)
                        {
                            CSP_List._Staff_Comptency_Files = Staff_Files_List;
                        }
                        if (Method_Files_List != null && Method_Files_List.Count > 0)
                        {
                            CSP_List._Method_Statement_Files = Method_Files_List;
                        }
                        if (Risk_Files_List != null && Risk_Files_List.Count > 0)
                        {
                            CSP_List._Risk_Assess_Files = Risk_Files_List;
                        }
                        if (Emr_Files_List != null && Emr_Files_List.Count > 0)
                        {
                            CSP_List._Emr_Plan_Files = Emr_Files_List;
                        }
                        if (HSE_Files_List != null && HSE_Files_List.Count > 0)
                        {
                            CSP_List._HSE_Plan_Files = HSE_Files_List;
                        }
                        if (Add_Details_List != null)
                        {
                            CSP_List._Evidence_Details = Add_Details_List;
                        }
                        if (Signed_Files_List != null && Signed_Files_List.Count > 0)
                        {
                            CSP_List._Sp_Signed_Files = Signed_Files_List;
                        }

                        if (CSP_List._Evidence_Details!= null && CSP_List._Evidence_Details.Count > 0)
                        {
                            foreach(var item in CSP_List._Evidence_Details)
                            {
                                var param = new
                                {
                                    CSP_Id = item.CSP_Id,
                                };
                                var Personal_Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure13, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Personnel_Tools = Personal_Tools_List;

                                if(item._Add_Personnel_Tools != null && item._Add_Personnel_Tools.Count > 0)
                                {
                                    foreach (var obj in item._Add_Personnel_Tools)
                                    {
                                        var param_Tools = new
                                        {
                                            CSP_Pers_Tools_Id = obj.CSP_Pers_Tools_Id
                                        };
                                        var Closure_Evd_List = (await connection.QueryAsync<Ptw_Sp_Add_Closure_Evidence>(procedure20, param_Tools, commandType: CommandType.StoredProcedure)).ToList();
                                        obj._Closure_Evidences = Closure_Evd_List;
                                    }
                                }
                               
                                var Evidence_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Renewal_Evidences = Evidence_List;
                            }
                        }

                       
                        if(Renewal_Details_List != null && Renewal_Details_List.Count > 0)
                        {
                            CSP_List._Get_Renewal_Details = Renewal_Details_List;
                        }
                    }
                    return CSP_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Edit_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Zone_HSE_Csp_Approve(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string Proc_App_Comments = "sp_Ptw_CSP_Add_Approval_Comments";
                string proc_App_Mail_Req_Zone = "sp_Ptw_CSP_Zone_Request_Approve_Email";
                string proc_App_Mail_Req_HSE = "sp_Ptw_CSP_HSE_Request_Approve_Email";
                string proc_App_Mail_Renewal_Req_Zone = "sp_Ptw_CSP_Zone_Renewal_App_Email";
                string proc_App_Mail_Evd_App_Zone = "sp_Ptw_CSP_Zone_Supervisor_Evd_App_Email";
                string proc_App_Mail_Evd_App_HSE = "sp_Ptw_CSP_HSE_Evd_App_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    var CSP_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var CSP_App_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_App_Comments, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity.Status == "2")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "8")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Renewal_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Zone_Csp_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string procedure1 = "sp_Ptw_CSP_Add_Zone_Reject";
                string proc_Rej_Mail_Req_Zone = "sp_Ptw_CSP_Zone_Supervisor_Req_Rej_Email";
                string proc_Rej_Mail_Req_HSE = "sp_Ptw_CSP_HSE_Req_Rej_Email";
                string proc_Rej_Mail_Renewal_Zone = "sp_Ptw_CSP_Zone_Renewal_Rej_Email";
                string proc_Rej_Mail_Evd_Zone = "sp_Ptw_CSP_Zone_Evd_Rej_Email";
                string proc_Rej_Mail_Evd_HSE = "sp_Ptw_CSP_HSE_Evd_Rej_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                   if(entity._Zone_HSE_Reject != null)
                    {
                        foreach(var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Reject_Id = item.Zone_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Zone_Approver_Name = item.Zone_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Status == "3")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "13")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_HSE_Csp_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string procedure1 = "sp_Ptw_CSP_Add_HSE_Staff_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Hse_Reject_Id = item.Hse_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                                Hse_Approver_Name = item.Hse_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Zone_Evd_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string procedure1 = "sp_Ptw_CSP_Add_Zone_Evd_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Evd_Reject_Id = item.Zone_Evd_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                                Zone_Evd_Approver_Name = item.Zone_Evd_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Evd_Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_CSP_Add_Additional_Details";
                string procedure2 = "sp_Ptw_CSP_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_CSP_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_CSP_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_CSP_Add_Closure_Evd_Files";
                string proc_Sp_Evd_Req = "sp_Ptw_CSP_Zone_Evd_App_Email"; //SP EVD Req MAil
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role =  entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if(entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {                      
                        foreach(var item in entity._Add_Personnel_Tools)
                        {
                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Count = item.Personnel_Tools_Count,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault(); 
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if(entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if(entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_CSP_Update_Additional_Details";
                string procedure2 = "sp_Ptw_CSP_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_CSP_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_CSP_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_CSP_Add_Closure_Evd_Files";
                string proc_Evd_Del = "sp_Ptw_CSP_Delete_Renewal_Evidence_Files";
                string proc_Pers_tools = "sp_Ptw_CSP_Delete_Personnel_Tools";
                string proc_Pers_Cls_Evd = "sp_Ptw_CSP_Delete_Personnel_Cls_Evidence";
                string proc_Sp_Evd_Req = "sp_Ptw_CSP_Zone_Evd_App_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Pers_tools, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Personnel_Tools)
                        {

                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Count = item.Personnel_Tools_Count,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                               
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    //var param_del_Cls = new
                                    //{
                                    //    CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id
                                    //};
                                    //await connection.ExecuteAsync(proc_Pers_Cls_Evd, param_del_Cls, commandType: CommandType.StoredProcedure);
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Evd_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<M_Return_Message> Add_Sp_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_CSP_Add_History_Approval";
                string proc_SP_Renewal_Req = "sp_Ptw_CSP_SP_Renewal_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<M_Return_Message> Edit_Sp_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_CSP_Add_History_Approval";
                string procedure_Del = "sp_Ptw_CSP_Delete_Renewal";
                string proc_SP_Renewal_Req = "sp_Ptw_CSP_SP_Renewal_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param_del = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    await connection.ExecuteAsync(procedure_Del, param_del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Contractor_Load_Details> Get_Contractor_Load(Ptw_Contractor_Load_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_Csp_Contractor_Drp_Get";
                string procedure1 = "sp_Ptw_Csp_Competent_Drp_Get";
                string procedure2 = "sp_Ptw_Csp_Building_Drp_Get";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                    };
                    var Contract_List = (await connection.QueryAsync<Ptw_Contractor_Load_Details>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if(Contract_List != null)
                    {
                        var Comp_List = (await connection.QueryAsync<Ptw_Competent_Person>(procedure1, parameters, commandType: CommandType.StoredProcedure)).AsList();
                        Contract_List._Competent_Person = Comp_List;

                        var Build_List = (await connection.QueryAsync<Ptw_Building>(procedure2, parameters, commandType: CommandType.StoredProcedure)).AsList();
                        Contract_List._Building_List = Build_List;
                    }
                   
                    return Contract_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Get_Contractor_Load";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Ptw_Contractor_Load_Details>> Get_Con_Pur_Drp(Ptw_Contractor_Load_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_Csp_Con_Purchase_Drp_Get"; 
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Official_Email_Id = entity.Official_Email_Id,
                    };
                    return (await connection.QueryAsync<Ptw_Contractor_Load_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Get_Con_Pur_Drp";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<Ptw_Competent_Number> Get_Competent_Number(Ptw_Competent_Number entity)
        {
            try
            {
                string procedure = "sp_Ptw_Csp_Comp_Number_Get";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Work_Superviosor_Id = entity.Work_Superviosor_Id,
                    };
                    return (await connection.QueryAsync<Ptw_Competent_Number>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Get_Con_Pur_Drp";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Zone_Renewal_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string procedure1 = "sp_Ptw_CSP_Add_Zone_Renewal_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Renewal_Reject_Id = item.Zone_Renewal_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                                Zone_Renewal_Approver_Name = item.Zone_Renewal_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Evd_Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_HSE_Evd_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_CSP_Add_History_Approval";
                string procedure1 = "sp_Ptw_CSP_Add_HSE_Evd_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                HSE_Evd_Reject_Id = item.HSE_Evd_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                                HSE_Evd_Approver_Name = item.HSE_Evd_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Evd_Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        #endregion

        #region [Electrical Work Permit]
        public async Task<IReadOnlyList<M_MajorQuestion>> Get_All_Electrical_Question()
        {
            try
            {
                string procedure = "Sp_Load_Electrical_Work_Questionaries";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Electrical_Question";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Electrical_Work(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Community_Name = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
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
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
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
                string procedure = "sp_Ptw_EWP_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Electrical_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Electrical_Work_Req(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Add_Request";
                string procedure_Questionaire = "sp_Ptw_EWP_Add_Request_Questionnaire";
                string procedure_Ques_delete = "sp_Ptw_EWP_Delete_Request_Questionnaire";
                string procedure_History = "sp_Ptw_EWP_Add_History_Approval";
                string procedure_Staff_Files = "sp_Ptw_EWP_Add_Staff_Comp_Files";
                string procedure_Method_Files = "sp_Ptw_EWP_Add_Method_State_Files";
                string procedure_Risk_Files = "sp_Ptw_EWP_Add_Risk_Assess_Files";
                string procedure_Emergency_Files = "sp_Ptw_EWP_Add_Emr_Plan_Files";
                string procedure_HSE_Files = "sp_Ptw_EWP_Add_HSE_Plan_Files";
                string procedure_Signed_Files = "sp_Ptw_EWP_Add_Signature_Files";

                string procedure_Del_Method = "sp_Ptw_EWP_Delete_Method_Files";
                string procedure_Del_Risk = "sp_Ptw_EWP_Delete_Risk_Files";
                string procedure_Del_EMR = "sp_Ptw_EWP_Delete_EMR_Files";
                string procedure_Del_HSE = "sp_Ptw_EWP_Delete_HSE_Files";
                string procedure_Del_Staff = "sp_Ptw_EWP_Delete_Staff_Files";
                string procedure_Del_Signed = "sp_Ptw_EWP_Delete_Signed_Files";

                string procedure_Add_Req_Email = "sp_Ptw_EWP_Add_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        EWP_Id = entity.EWP_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Company_Name = entity.Company_Name,
                        Contrator_Title_No = entity.Contrator_Title_No,
                        Competent_Person = entity.Competent_Person,
                        Name = entity.Name,
                        Position = entity.Position,
                        Contact = entity.Contact,
                        Email_Id = entity.Email_Id,
                        Date_and_Time = entity.Date_and_Time,
                        Description_of_Work = entity.Description_of_Work,
                        Additional_Precautions = entity.Additional_Precautions,
                        Work_Duration_From_Date = entity.Work_Duration_From_Date,
                        Work_Duration_To_Date = entity.Work_Duration_To_Date,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Location_Address = entity.Location_Address,
                        Exact_Loc_Address = entity.Exact_Loc_Address,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        Building_Id = entity.Building_Id,
                        Contractor_Name = entity.Contractor_Name,
                        Contractor_Start_Date = entity.Contractor_Start_Date,
                        Contractor_End_Date = entity.Contractor_End_Date,
                        DMS_No_Id = entity.DMS_No_Id,
                        Competent_Number = entity.Competent_Number,
                        HSE_Officer_Name = entity.HSE_Officer_Name,
                        HSE_Mobile_Number = entity.HSE_Mobile_Number,
                        Declare_Name = entity.Declare_Name,
                        Declare_Designation = entity.Declare_Designation,
                        Declare_Chk = entity.Declare_Chk
                    };

                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var Email_Param = new
                    {
                        EWP_Id = CSP_List!.EWP_Id,
                    };
                    var CSP_Mail = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure_Add_Req_Email, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_CSP_Ques != null && entity._Add_CSP_Ques.Count > 0)
                    {

                        var param_del = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        await connection.ExecuteAsync(procedure_Ques_delete, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_CSP_Ques)
                        {
                            var param_Ques = new
                            {
                                Ques_EWP_ID = item.Ques_EWP_ID,
                                EWP_Id = CSP_List!.EWP_Id!,
                                Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                                EWP_Ques_Name = item.EWP_Ques_Name,
                                EWP_Ques_Radio_Btn = item.EWP_Ques_Radio_Btn,
                                EWP_Remarks = item.EWP_Remarks,
                                CreatedBy = item.CreatedBy,

                            };
                            var Quest_list = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure_Questionaire, param_Ques, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity._Staff_Comptency_Files != null && entity._Staff_Comptency_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Staff, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Staff_Comptency_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                File_Id = photos.File_Id,
                                File_Path = photos.File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Photos_list = (await connection.QueryAsync<Staff_Comptency_Files>(procedure_Staff_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Method_Statement_Files != null && entity._Method_Statement_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Method, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Method_Statement_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                Method_File_Id = photos.Method_File_Id,
                                Method_File_Path = photos.Method_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Method_list = (await connection.QueryAsync<Method_Statement_Files>(procedure_Method_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Risk_Assess_Files != null && entity._Risk_Assess_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Risk, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Risk_Assess_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                Risk_File_Id = photos.Risk_File_Id,
                                Risk_File_Path = photos.Risk_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Risk_list = (await connection.QueryAsync<Risk_Assess_Files>(procedure_Risk_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Emr_Plan_Files != null && entity._Emr_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_EMR, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Emr_Plan_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                Emr_File_Id = photos.Emr_File_Id,
                                Emr_File_Path = photos.Emr_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Emr_list = (await connection.QueryAsync<Emr_Plan_Files>(procedure_Emergency_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._HSE_Plan_Files != null && entity._HSE_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_HSE, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._HSE_Plan_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                Hse_File_Id = photos.Hse_File_Id,
                                Hse_File_Path = photos.Hse_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<HSE_Plan_Files>(procedure_HSE_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Signed_Files != null && entity._Sp_Signed_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Signed, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity!._Sp_Signed_Files)
                        {
                            var param_photos = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                Sign_File_Id = photos.Sign_File_Id,
                                Sign_File_Path = photos.Sign_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<Sp_Signed_Files>(procedure_Signed_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }

                    if (entity._Ptw_History_List != null)
                    {
                        foreach (var obj in entity._Ptw_History_List)
                        {
                            var param_History = new
                            {
                                EWP_Id = CSP_List!.EWP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "1",
                                Remarks = "Zone Supervisor Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Electrical_Work_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Confined_Space_Add> Edit_Electrical_Work(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Request_Edit";
                string procedure1 = "sp_Ptw_EWP_Request_Questionnaire_Edit";
                string procedure2 = "sp_Business_Unit_Master_GetAll";
                string procedure3 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure6 = "sp_Ptw_EWP_Get_History_Approval";
                string Procedure7 = "sp_Ptw_EWP_Method_Files_Get";
                string Procedure8 = "sp_Ptw_EWP_Risk_Assess_Get";
                string Procedure9 = "sp_Ptw_EWP_Emr_Plan_Get";
                string Procedure10 = "sp_Ptw_EWP_HSE_Plan_Get";
                string Procedure11 = "sp_Ptw_EWP_Staff_Files_Get";
                string procedure12 = "sp_Ptw_EWP_Evidence_Details_Edit";
                string procedure13 = "sp_Ptw_EWP_Personal_Tools_Edit";
                string procedure14 = "sp_Ptw_EWP_Evidence_Files_Edit";
                string procedure15 = "sp_Ptw_EWP_Closure_Evd_Get";
                string procedure16 = "sp_Ptw_EWP_Renewal_Details_Edit";

                string procedure17 = "sp_Ptw_EW_Get_Zone_Reject_Details";
                string procedure18 = "sp_Ptw_ewp_Signed_Files_Get";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        EWP_Id = entity.EWP_Id
                    };
                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (CSP_List != null)
                    {
                        var Ques_List = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Ques_List != null)
                        {
                            CSP_List._Add_CSP_Ques = Ques_List;
                        }
                        CSP_List!.CSP_Comman_Master_List = new Basic_Master_Data();
                        CSP_List!.CSP_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var parameters_Zone = new
                        {
                            Zone_Id = CSP_List.Zone_Id,
                            Community_Id = CSP_List.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var History_Approval_Get_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure6, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Method_Files_List = (await connection.QueryAsync<Method_Statement_Files>(Procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Risk_Files_List = (await connection.QueryAsync<Risk_Assess_Files>(Procedure8, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Emr_Files_List = (await connection.QueryAsync<Emr_Plan_Files>(Procedure9, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var HSE_Files_List = (await connection.QueryAsync<HSE_Plan_Files>(Procedure10, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Staff_Files_List = (await connection.QueryAsync<Staff_Comptency_Files>(Procedure11, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Add_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Renewal_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Details>(procedure16, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Reject_Get_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure17, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Signed_Files_List = (await connection.QueryAsync<Sp_Signed_Files>(procedure18, parameters, commandType: CommandType.StoredProcedure)).ToList();


                        if (Business_Unit_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (History_Approval_Get_List != null)
                        {
                            CSP_List._Ptw_History_List = History_Approval_Get_List;
                        }
                        if (Staff_Files_List != null && Staff_Files_List.Count > 0)
                        {
                            CSP_List._Staff_Comptency_Files = Staff_Files_List;
                        }
                        if (Method_Files_List != null && Method_Files_List.Count > 0)
                        {
                            CSP_List._Method_Statement_Files = Method_Files_List;
                        }
                        if (Risk_Files_List != null && Risk_Files_List.Count > 0)
                        {
                            CSP_List._Risk_Assess_Files = Risk_Files_List;
                        }
                        if (Emr_Files_List != null && Emr_Files_List.Count > 0)
                        {
                            CSP_List._Emr_Plan_Files = Emr_Files_List;
                        }
                        if (HSE_Files_List != null && HSE_Files_List.Count > 0)
                        {
                            CSP_List._HSE_Plan_Files = HSE_Files_List;
                        }
                        if (Signed_Files_List != null && Signed_Files_List.Count > 0)
                        {
                            CSP_List._Sp_Signed_Files = Signed_Files_List;
                        }
                        if (Add_Details_List != null)
                        {
                            CSP_List._Evidence_Details = Add_Details_List;
                        }
                        if (CSP_List._Evidence_Details != null && CSP_List._Evidence_Details.Count > 0)
                        {
                            foreach (var item in CSP_List._Evidence_Details)
                            {
                                var param = new
                                {
                                    EWP_Id = item.EWP_Id,
                                };
                                var Personal_Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure13, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Personnel_Tools = Personal_Tools_List;

                                if (item._Add_Personnel_Tools != null && item._Add_Personnel_Tools.Count > 0)
                                {
                                    foreach (var obj in item._Add_Personnel_Tools)
                                    {
                                        var param_Tools = new
                                        {
                                            CSP_Pers_Tools_Id = obj.CSP_Pers_Tools_Id
                                        };
                                        var Closure_Evd_List = (await connection.QueryAsync<Ptw_Sp_Add_Closure_Evidence>(procedure15, param_Tools, commandType: CommandType.StoredProcedure)).ToList();
                                        obj._Closure_Evidences = Closure_Evd_List;
                                    }
                                }

                                var Evidence_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Renewal_Evidences = Evidence_List;
                            }
                           
                        }
                        if (Renewal_Details_List != null && Renewal_Details_List.Count > 0)
                        {
                            CSP_List._Get_Renewal_Details = Renewal_Details_List;
                        }
                        if(Zone_Reject_Get_List != null && Zone_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Zone_Reject_List = Zone_Reject_Get_List;
                        }
                    }
                    return CSP_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EWP_Request_Form : Edit_Electrical_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Zone_HSE_EWP_Approve(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Add_History_Approval";
                string Proc_App_Comments = "sp_Ptw_EWP_Add_Approval_Comments";
                string proc_App_Mail_Req_Zone = "sp_Ptw_EWP_Zone_Request_Approve_Email";
                string proc_App_Mail_Req_HSE = "sp_Ptw_EWP_HSE_Request_Approve_Email";
                string proc_App_Mail_Renewal_Zone = "sp_Ptw_EWP_Zone_Renewal_App_Email";
                string proc_App_Mail_Evd_App_Zone = "sp_Ptw_EWP_Zone_Supervisor_Evd_App_Email";
                string proc_App_Mail_Evd_App_HSE =  "sp_Ptw_EWP_HSE_Evd_App_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        EWP_Id = entity.EWP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    var CSP_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var EWP_App_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_App_Comments, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Status == "2")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "8")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_HSE_EWP_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_EWP_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_EWP_Add_Evidence_Details";
                string procedure2 = "sp_Ptw_EWP_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_EWP_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_EWP_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_EWP_Add_Closure_Evd_Files";
                string proc_Sp_Evd_Req = "sp_Ptw_EWP_Zone_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        EWP_Id = entity.EWP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        foreach (var item in entity._Add_Personnel_Tools)
                        {
                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                EWP_Id = item.EWP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        EWP_Id = obj.EWP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                EWP_Id = item.EWP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                EWP_Id = entity.EWP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        EWP_Id = entity.EWP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_EWP_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_EWP_Update_Additional_Details";
                string procedure2 = "sp_Ptw_EWP_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_EWP_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_EWP_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_EWP_Add_Closure_Evd_Files";
                string proc_Evd_Del = "sp_Ptw_EWP_Delete_Renewal_Evidence_Files";
                string proc_Pers_tools = "sp_Ptw_EWP_Delete_Personnel_Tools";
                string proc_Sp_Evd_Req = "sp_Ptw_EWP_Zone_Evd_Req_Email";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        EWP_Id = entity.EWP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        var param_del = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(proc_Pers_tools, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Personnel_Tools)
                        {

                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                EWP_Id = item.EWP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {

                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    //var param_del_Cls = new
                                    //{
                                    //    CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id
                                    //};
                                    //await connection.ExecuteAsync(proc_Pers_Cls_Evd, param_del_Cls, commandType: CommandType.StoredProcedure);
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        EWP_Id = obj.EWP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        var param_del = new
                        {
                            EWP_Id = entity.EWP_Id
                        };
                        await connection.ExecuteAsync(proc_Evd_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                EWP_Id = item.EWP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                EWP_Id = entity.EWP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        EWP_Id = entity.EWP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_EWP_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_EWP_Add_History_Approval";
                string proc_SP_Renewal_Req = "sp_Ptw_EWP_SP_Renewal_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        EWP_Id = entity.EWP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                EWP_Id = entity.EWP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        EWP_Id = entity.EWP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_EWP_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_EWP_Add_History_Approval";
                string procedure_Del = "sp_Ptw_EWP_Delete_Renewal";
                string proc_SP_Renewal_Req = "sp_Ptw_EWP_SP_Renewal_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param_del = new
                    {
                        EWP_Id = entity.EWP_Id
                    };
                    await connection.ExecuteAsync(procedure_Del, param_del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        EWP_Id = entity.EWP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                EWP_Id = entity.EWP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        EWP_Id = entity.EWP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        //Reject
        public async Task<M_Return_Message> Add_Zone_EWP_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_EWP_Add_History_Approval";
                string procedure1 = "sp_Ptw_EWP_Add_Zone_Reject";
                string proc_Rej_Mail_Req_Zone = "sp_Ptw_EWP_Zone_Supervisor_Req_Rej_Email";
                string proc_Rej_Mail_Req_HSE = "sp_Ptw_EWP_HSE_Rej_Email";
                string proc_Rej_Mail_Renewal_Zone = "sp_Ptw_EWP_Zone_Renewal_Rej_Email";
                string proc_Rej_Mail_Evd_Zone = "sp_Ptw_EWP_Zone_Evd_Rej_Email";
                string proc_Rej_Mail_Evd_HSE = "sp_Ptw_EWP_HSE_Evd_Rej_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        EWP_Id = entity.EWP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Reject_Id = item.Zone_Reject_Id,
                                EWP_Id = item.EWP_Id,
                                Zone_Approver_Name = item.Zone_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Status == "3")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "13")
                    {
                        var Email_Param = new
                        {
                            EWP_Id = entity.EWP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        #endregion 

        #region [Hot Work Permit]
        public async Task<IReadOnlyList<M_MajorQuestion>> Get_All_HotWork_Question()
        {
            try
            {
                string procedure = "Sp_Load_Hot_Work_Questionaries";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_HotWork_Question";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Hot_Work(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Community_Name = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
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
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
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
                string procedure = "sp_Ptw_HW_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Hot_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Hot_Work_Req(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Add_Request";
                string procedure_Questionaire = "sp_Ptw_HW_Add_Request_Questionnaire";
                string procedure_Ques_delete = "sp_Ptw_HW_Delete_Request_Questionnaire";
                string procedure_History = "sp_Ptw_HW_Add_History_Approval";
                string procedure_Staff_Files = "sp_Ptw_HW_Add_Staff_Comp_Files";
                string procedure_Method_Files = "sp_Ptw_HW_Add_Method_State_Files";
                string procedure_Risk_Files = "sp_Ptw_HW_Add_Risk_Assess_Files";
                string procedure_Emergency_Files = "sp_Ptw_HW_Add_Emr_Plan_Files";
                string procedure_HSE_Files = "sp_Ptw_HW_Add_HSE_Plan_Files";
                string procedure_Signed_Files = "sp_Ptw_HW_Add_Signature_Files";

                string procedure_Del_Method = "sp_Ptw_HW_Delete_Method_Files";
                string procedure_Del_Risk = "sp_Ptw_HW_Delete_Risk_Files";
                string procedure_Del_EMR = "sp_Ptw_HW_Delete_EMR_Files";
                string procedure_Del_HSE = "sp_Ptw_HW_Delete_HSE_Files";
                string procedure_Del_Staff = "sp_Ptw_HW_Delete_Staff_Files";
                string procedure_Del_Signed = "sp_Ptw_HW_Delete_Signed_Files";

                string procedure_Add_Req_Email = "sp_Ptw_HW_Add_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Company_Name = entity.Company_Name,
                        Contrator_Title_No = entity.Contrator_Title_No,
                        Competent_Person = entity.Competent_Person,
                        Name = entity.Name,
                        Position = entity.Position,
                        Contact = entity.Contact,
                        Email_Id = entity.Email_Id,
                        Date_and_Time = entity.Date_and_Time,
                        Description_of_Work = entity.Description_of_Work,
                        Additional_Precautions = entity.Additional_Precautions,
                        Work_Duration_From_Date = entity.Work_Duration_From_Date,
                        Work_Duration_To_Date = entity.Work_Duration_To_Date,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Location_Address = entity.Location_Address,
                        Exact_Loc_Address = entity.Exact_Loc_Address,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        Building_Id = entity.Building_Id,
                        Contractor_Name = entity.Contractor_Name,
                        Contractor_Start_Date = entity.Contractor_Start_Date,
                        Contractor_End_Date = entity.Contractor_End_Date,
                        DMS_No_Id = entity.DMS_No_Id,
                        Competent_Number = entity.Competent_Number,
                        HSE_Officer_Name = entity.HSE_Officer_Name,
                        HSE_Mobile_Number = entity.HSE_Mobile_Number,
                        Declare_Name = entity.Declare_Name,
                        Declare_Designation = entity.Declare_Designation,
                        Declare_Chk = entity.Declare_Chk
                    };

                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var Email_Param = new
                    {
                        CSP_Id = CSP_List!.CSP_Id,
                    };
                    var CSP_Mail = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure_Add_Req_Email, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_CSP_Ques != null && entity._Add_CSP_Ques.Count > 0)
                    {

                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Ques_delete, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_CSP_Ques)
                        {
                            var param_Ques = new
                            {
                                Ques_CSP_ID = item.Ques_CSP_ID,
                                CSP_Id = CSP_List!.CSP_Id!,
                                Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                                CSP_Ques_Name = item.CSP_Ques_Name,
                                CSP_Ques_Radio_Btn = item.CSP_Ques_Radio_Btn,
                                CSP_Remarks = item.CSP_Remarks,
                                CreatedBy = item.CreatedBy,

                            };
                            var Quest_list = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure_Questionaire, param_Ques, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity._Staff_Comptency_Files != null && entity._Staff_Comptency_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Staff, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Staff_Comptency_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                File_Id = photos.File_Id,
                                File_Path = photos.File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Photos_list = (await connection.QueryAsync<Staff_Comptency_Files>(procedure_Staff_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Method_Statement_Files != null && entity._Method_Statement_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Method, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Method_Statement_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Method_File_Id = photos.Method_File_Id,
                                Method_File_Path = photos.Method_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Method_list = (await connection.QueryAsync<Method_Statement_Files>(procedure_Method_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Risk_Assess_Files != null && entity._Risk_Assess_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Risk, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Risk_Assess_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Risk_File_Id = photos.Risk_File_Id,
                                Risk_File_Path = photos.Risk_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Risk_list = (await connection.QueryAsync<Risk_Assess_Files>(procedure_Risk_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Emr_Plan_Files != null && entity._Emr_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_EMR, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Emr_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Emr_File_Id = photos.Emr_File_Id,
                                Emr_File_Path = photos.Emr_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Emr_list = (await connection.QueryAsync<Emr_Plan_Files>(procedure_Emergency_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._HSE_Plan_Files != null && entity._HSE_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_HSE, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._HSE_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Hse_File_Id = photos.Hse_File_Id,
                                Hse_File_Path = photos.Hse_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<HSE_Plan_Files>(procedure_HSE_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Signed_Files != null && entity._Sp_Signed_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Signed, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity!._Sp_Signed_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Sign_File_Id = photos.Sign_File_Id,
                                Sign_File_Path = photos.Sign_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<Sp_Signed_Files>(procedure_Signed_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }

                    if (entity._Ptw_History_List != null)
                    {
                        foreach (var obj in entity._Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "1",
                                Remarks = "Zone Supervisor Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Confined_Space_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Confined_Space_Add> Edit_Hot_Work(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Request_Edit";
                string procedure1 = "sp_Ptw_HW_Request_Questionnaire_Edit";
                string procedure2 = "sp_Business_Unit_Master_GetAll";
                string procedure3 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure6 = "sp_Ptw_HW_Get_History_Approval";
                string Procedure7 = "sp_Ptw_HW_Staff_Files_Get";
                string Procedure8 = "sp_Ptw_HW_Method_Files_Get";
                string Procedure9 = "sp_Ptw_HW_Risk_Assess_Get";
                string Procedure10 = "sp_Ptw_HW_Emr_Plan_Get";
                string Procedure11 = "sp_Ptw_HW_HSE_Plan_Get";

                string procedure12 = "sp_Ptw_HW_Evidence_Details_Edit";
                string procedure13 = "sp_Ptw_HW_Personal_Tools_Edit";
                string procedure14 = "sp_Ptw_HW_Evidence_Files_Edit";
                string procedure15 = "sp_Ptw_HW_Closure_Evd_Get";
                string procedure16 = "sp_Ptw_HW_Renewal_Details_Edit";
                string procedure17 = "sp_Ptw_HW_Get_Zone_Reject_Details";
                string procedure18 = "sp_Ptw_HW_Signed_Files_Get";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if(CSP_List != null)
                    {
                        var Ques_List = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Ques_List != null)
                        {
                            CSP_List._Add_CSP_Ques = Ques_List;
                        }
                        CSP_List!.CSP_Comman_Master_List = new Basic_Master_Data();
                        CSP_List!.CSP_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var parameters_Zone = new
                        {
                            Zone_Id = CSP_List.Zone_Id,
                            Community_Id = CSP_List.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var History_Approval_Get_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure6, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Staff_Files_List = (await connection.QueryAsync<Staff_Comptency_Files>(Procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Method_Files_List = (await connection.QueryAsync<Method_Statement_Files>(Procedure8, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Risk_Files_List = (await connection.QueryAsync<Risk_Assess_Files>(Procedure9, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Emr_Files_List = (await connection.QueryAsync<Emr_Plan_Files>(Procedure10, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var HSE_Files_List = (await connection.QueryAsync<HSE_Plan_Files>(Procedure11, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Signed_Files_List = (await connection.QueryAsync<Sp_Signed_Files>(procedure18, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Add_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Renewal_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Details>(procedure16, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Reject_Get_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure17, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Business_Unit_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (History_Approval_Get_List != null)
                        {
                            CSP_List._Ptw_History_List = History_Approval_Get_List;
                        }
                        if (Staff_Files_List != null && Staff_Files_List.Count > 0)
                        {
                            CSP_List._Staff_Comptency_Files = Staff_Files_List;
                        }
                        if (Method_Files_List != null && Method_Files_List.Count > 0)
                        {
                            CSP_List._Method_Statement_Files = Method_Files_List;
                        }
                        if (Risk_Files_List != null && Risk_Files_List.Count > 0)
                        {
                            CSP_List._Risk_Assess_Files = Risk_Files_List;
                        }
                        if (Emr_Files_List != null && Emr_Files_List.Count > 0)
                        {
                            CSP_List._Emr_Plan_Files = Emr_Files_List;
                        }
                        if (HSE_Files_List != null && HSE_Files_List.Count > 0)
                        {
                            CSP_List._HSE_Plan_Files = HSE_Files_List;
                        }
                        if (Signed_Files_List != null && Signed_Files_List.Count > 0)
                        {
                            CSP_List._Sp_Signed_Files = Signed_Files_List;
                        }
                        if (Add_Details_List != null)
                        {
                            CSP_List._Evidence_Details = Add_Details_List;
                        }

                        if (CSP_List._Evidence_Details != null && CSP_List._Evidence_Details.Count > 0)
                        {
                            foreach (var item in CSP_List._Evidence_Details)
                            {
                                var param = new
                                {
                                    CSP_Id = item.CSP_Id,
                                };
                                var Personal_Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure13, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Personnel_Tools = Personal_Tools_List;

                                if (item._Add_Personnel_Tools != null && item._Add_Personnel_Tools.Count > 0)
                                {
                                    foreach (var obj in item._Add_Personnel_Tools)
                                    {
                                        var param_Tools = new
                                        {
                                            CSP_Pers_Tools_Id = obj.CSP_Pers_Tools_Id
                                        };
                                        var Closure_Evd_List = (await connection.QueryAsync<Ptw_Sp_Add_Closure_Evidence>(procedure15, param_Tools, commandType: CommandType.StoredProcedure)).ToList();
                                        obj._Closure_Evidences = Closure_Evd_List;
                                    }
                                }

                                var Evidence_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Renewal_Evidences = Evidence_List;
                            }
                        }


                        if (Renewal_Details_List != null && Renewal_Details_List.Count > 0)
                        {
                            CSP_List._Get_Renewal_Details = Renewal_Details_List;
                        }
                        if (Zone_Reject_Get_List != null && Zone_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Zone_Reject_List = Zone_Reject_Get_List;
                        }
                    }
                    return CSP_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Edit_Hot_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Zone_HSE_HW_Approve(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Add_History_Approval";
                string Proc_App_Comments = "sp_Ptw_HW_Add_Approval_Comments";
                string proc_App_Mail_Req_Zone = "sp_Ptw_HW_Zone_Request_Approve_Email";
                string proc_App_Mail_Req_HSE = "sp_Ptw_HW_HSE_Request_Approve_Email";
                string proc_App_Mail_Renewal_Zone = "sp_Ptw_HW_Zone_Renewal_App_Email";
                string proc_App_Mail_Evd_App_Zone = "sp_Ptw_HW_Zone_Supervisor_Evd_App_Email";
                string proc_App_Mail_Evd_App_HSE = "sp_Ptw_HW_HSE_Evd_App_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    var CSP_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var CSP_App_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_App_Comments, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Status == "2")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "8")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_HSE_EWP_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_HW_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_HW_Add_Evidence_Details";
                string procedure2 = "sp_Ptw_HW_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_HW_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_HW_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_HW_Add_Closure_Evd_Files";
                string proc_Sp_Evd_Req = "sp_Ptw_HW_SP_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        foreach (var item in entity._Add_Personnel_Tools)
                        {
                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_HW_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_HW_Update_Additional_Details";
                string procedure2 = "sp_Ptw_HW_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_HW_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_HW_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_HW_Add_Closure_Evd_Files";
                string proc_Evd_Del = "sp_Ptw_HW_Delete_Renewal_Evidence_Files";
                string proc_Pers_tools = "sp_Ptw_HW_Delete_Personnel_Tools";
                string proc_Sp_Evd_Req = "sp_Ptw_HW_SP_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Pers_tools, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Personnel_Tools)
                        {

                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {

                                foreach (var obj in item._Closure_Evidences!)
                                {                                  
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Evd_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Edit_Sp_HW_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_HW_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_HW_Add_History_Approval";
                string proc_SP_Renewal_Req = "sp_Ptw_HW_SP_Renewal_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_HW_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_HW_Add_History_Approval";
                string procedure_Del = "sp_Ptw_HW_Delete_Renewal";
                string proc_SP_Renewal_Req = "sp_Ptw_HW_SP_Renewal_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param_del = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    await connection.ExecuteAsync(procedure_Del, param_del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        //Reject
        public async Task<M_Return_Message> Add_Zone_HW_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_HW_Add_History_Approval";
                string procedure1 = "sp_Ptw_HW_Add_Zone_Reject";
                string proc_Rej_Mail_Req_Zone = "sp_Ptw_HW_Zone_Supervisor_Req_Rej_Email";
                string proc_Rej_Mail_Req_HSE = "sp_Ptw_HW_HSE_Req_Rej_Email";
                string proc_Rej_Mail_Renewal_Zone = "sp_Ptw_HW_Zone_Renewal_Rej_Email";
                string proc_Rej_Mail_Evd_Zone = "sp_Ptw_HW_Zone_Evd_Rej_Email";
                string proc_Rej_Mail_Evd_HSE = "sp_Ptw_HW_HSE_Evd_Rej_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Reject_Id = item.Zone_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Zone_Approver_Name = item.Zone_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Status == "3")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "13")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        #endregion

        #region [Work At Height Permit]
        public async Task<IReadOnlyList<M_MajorQuestion>> Get_All_Work_Height_Question()
        {
            try
            {
                string procedure = "Sp_Load_Work_AT_Height_Questionaries";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_HotWork_Question";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Work_Height(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Community_Name = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
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
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
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
                string procedure = "sp_Ptw_WAH_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Hot_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Work_Height_Req(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Add_Request";
                string procedure_Questionaire = "sp_Ptw_WAH_Add_Request_Questionnaire";
                string procedure_Ques_delete = "sp_Ptw_WAH_Delete_Request_Questionnaire";
                string procedure_History = "sp_Ptw_WAH_Add_History_Approval";
                string procedure_Staff_Files = "sp_Ptw_WAH_Add_Staff_Comp_Files";
                string procedure_Method_Files = "sp_Ptw_WAH_Add_Method_State_Files";
                string procedure_Risk_Files = "sp_Ptw_WAH_Add_Risk_Assess_Files";
                string procedure_Emergency_Files = "sp_Ptw_WAH_Add_Emr_Plan_Files";
                string procedure_HSE_Files = "sp_Ptw_WAH_Add_HSE_Plan_Files";
                string procedure_Signed_Files = "sp_Ptw_WAH_Add_Signature_Files";

                string procedure_Del_Method = "sp_Ptw_WAH_Delete_Method_Files";
                string procedure_Del_Risk = "sp_Ptw_WAH_Delete_Risk_Files";
                string procedure_Del_EMR = "sp_Ptw_WAH_Delete_EMR_Files";
                string procedure_Del_HSE = "sp_Ptw_WAH_Delete_HSE_Files";
                string procedure_Del_Staff = "sp_Ptw_WAH_Delete_Staff_Files";
                string procedure_Del_Signed = "sp_Ptw_WAH_Delete_Signed_Files";

                string procedure_Add_Req_Email = "sp_Ptw_WAH_Add_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Company_Name = entity.Company_Name,
                        Contrator_Title_No = entity.Contrator_Title_No,
                        Competent_Person = entity.Competent_Person,
                        Name = entity.Name,
                        Position = entity.Position,
                        Contact = entity.Contact,
                        Email_Id = entity.Email_Id,
                        Date_and_Time = entity.Date_and_Time,
                        Description_of_Work = entity.Description_of_Work,
                        Additional_Precautions = entity.Additional_Precautions,
                        Work_Duration_From_Date = entity.Work_Duration_From_Date,
                        Work_Duration_To_Date = entity.Work_Duration_To_Date,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Location_Address = entity.Location_Address,
                        Exact_Loc_Address = entity.Exact_Loc_Address,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        Building_Id = entity.Building_Id,
                        Contractor_Name = entity.Contractor_Name,
                        Contractor_Start_Date = entity.Contractor_Start_Date,
                        Contractor_End_Date = entity.Contractor_End_Date,
                        DMS_No_Id = entity.DMS_No_Id,
                        Competent_Number = entity.Competent_Number,
                        HSE_Officer_Name = entity.HSE_Officer_Name,
                        HSE_Mobile_Number = entity.HSE_Mobile_Number,
                        Declare_Name = entity.Declare_Name,
                        Declare_Designation = entity.Declare_Designation,
                        Declare_Chk = entity.Declare_Chk
                    };

                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var Email_Param = new
                    {
                        CSP_Id = CSP_List!.CSP_Id
                    };
                    var CSP_Mail = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure_Add_Req_Email, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                    if (entity._Add_CSP_Ques != null && entity._Add_CSP_Ques.Count > 0)
                    {

                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Ques_delete, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_CSP_Ques)
                        {
                            var param_Ques = new
                            {
                                Ques_CSP_ID = item.Ques_CSP_ID,
                                CSP_Id = CSP_List!.CSP_Id!,
                                Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                                CSP_Ques_Name = item.CSP_Ques_Name,
                                CSP_Ques_Radio_Btn = item.CSP_Ques_Radio_Btn,
                                CSP_Remarks = item.CSP_Remarks,
                                CreatedBy = item.CreatedBy,

                            };
                            var Quest_list = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure_Questionaire, param_Ques, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity._Staff_Comptency_Files != null && entity._Staff_Comptency_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Staff, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Staff_Comptency_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                File_Id = photos.File_Id,
                                File_Path = photos.File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Photos_list = (await connection.QueryAsync<Staff_Comptency_Files>(procedure_Staff_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Method_Statement_Files != null && entity._Method_Statement_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Method, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Method_Statement_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Method_File_Id = photos.Method_File_Id,
                                Method_File_Path = photos.Method_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Method_list = (await connection.QueryAsync<Method_Statement_Files>(procedure_Method_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Risk_Assess_Files != null && entity._Risk_Assess_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Risk, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Risk_Assess_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Risk_File_Id = photos.Risk_File_Id,
                                Risk_File_Path = photos.Risk_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Risk_list = (await connection.QueryAsync<Risk_Assess_Files>(procedure_Risk_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Emr_Plan_Files != null && entity._Emr_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_EMR, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Emr_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Emr_File_Id = photos.Emr_File_Id,
                                Emr_File_Path = photos.Emr_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Emr_list = (await connection.QueryAsync<Emr_Plan_Files>(procedure_Emergency_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._HSE_Plan_Files != null && entity._HSE_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_HSE, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._HSE_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Hse_File_Id = photos.Hse_File_Id,
                                Hse_File_Path = photos.Hse_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<HSE_Plan_Files>(procedure_HSE_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Signed_Files != null && entity._Sp_Signed_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Signed, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity!._Sp_Signed_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                Sign_File_Id = photos.Sign_File_Id,
                                Sign_File_Path = photos.Sign_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<Sp_Signed_Files>(procedure_Signed_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }

                    if (entity._Ptw_History_List != null)
                    {
                        foreach (var obj in entity._Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = CSP_List!.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "1",
                                Remarks = "Zone Supervisor Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Confined_Space_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Confined_Space_Add> Edit_Work_Height(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Request_Edit";
                string procedure1 = "sp_Ptw_WAH_Request_Questionnaire_Edit";
                string procedure2 = "sp_Business_Unit_Master_GetAll";
                string procedure3 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure6 = "sp_Ptw_WAH_Get_History_Approval";
                string Procedure7 = "sp_Ptw_WAH_Staff_Files_Get";
                string Procedure8 = "sp_Ptw_WAH_Method_Files_Get";
                string Procedure9 = "sp_Ptw_WAH_Risk_Assess_Get";
                string Procedure10 = "sp_Ptw_WAH_Emr_Plan_Get";
                string Procedure11 = "sp_Ptw_WAH_HSE_Plan_Get";
                string procedure18 = "sp_Ptw_WAH_Signed_Files_Get";
                //Renewal
                string procedure12 = "sp_Ptw_WAH_Evidence_Details_Edit";
                string procedure13 = "sp_Ptw_WAH_Personal_Tools_Edit";
                string procedure14 = "sp_Ptw_WAH_Evidence_Files_Edit";
                string procedure15 = "sp_Ptw_WAH_Closure_Evd_Get";
                string procedure16 = "sp_Ptw_WAH_Renewal_Details_Edit";

                string procedure17 = "sp_Ptw_WAH_Get_Zone_Reject_Details";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (CSP_List != null)
                    {
                        var Ques_List = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Ques_List != null)
                        {
                            CSP_List._Add_CSP_Ques = Ques_List;
                        }
                        CSP_List!.CSP_Comman_Master_List = new Basic_Master_Data();
                        CSP_List!.CSP_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var parameters_Zone = new
                        {
                            Zone_Id = CSP_List.Zone_Id,
                            Community_Id = CSP_List.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var History_Approval_Get_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure6, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Staff_Files_List = (await connection.QueryAsync<Staff_Comptency_Files>(Procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Method_Files_List = (await connection.QueryAsync<Method_Statement_Files>(Procedure8, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Risk_Files_List = (await connection.QueryAsync<Risk_Assess_Files>(Procedure9, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Emr_Files_List = (await connection.QueryAsync<Emr_Plan_Files>(Procedure10, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var HSE_Files_List = (await connection.QueryAsync<HSE_Plan_Files>(Procedure11, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Signed_Files_List = (await connection.QueryAsync<Sp_Signed_Files>(procedure18, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Add_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Renewal_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Details>(procedure16, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Reject_Get_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure17, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Business_Unit_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (History_Approval_Get_List != null)
                        {
                            CSP_List._Ptw_History_List = History_Approval_Get_List;
                        }
                        if (Staff_Files_List != null && Staff_Files_List.Count > 0)
                        {
                            CSP_List._Staff_Comptency_Files = Staff_Files_List;
                        }
                        if (Method_Files_List != null && Method_Files_List.Count > 0)
                        {
                            CSP_List._Method_Statement_Files = Method_Files_List;
                        }
                        if (Risk_Files_List != null && Risk_Files_List.Count > 0)
                        {
                            CSP_List._Risk_Assess_Files = Risk_Files_List;
                        }
                        if (Emr_Files_List != null && Emr_Files_List.Count > 0)
                        {
                            CSP_List._Emr_Plan_Files = Emr_Files_List;
                        }
                        if (HSE_Files_List != null && HSE_Files_List.Count > 0)
                        {
                            CSP_List._HSE_Plan_Files = HSE_Files_List;
                        }

                        if (Signed_Files_List != null && Signed_Files_List.Count > 0)
                        {
                            CSP_List._Sp_Signed_Files = Signed_Files_List;
                        }

                        if (Add_Details_List != null)
                        {
                            CSP_List._Evidence_Details = Add_Details_List;
                        }

                        if (CSP_List._Evidence_Details != null && CSP_List._Evidence_Details.Count > 0)
                        {
                            foreach (var item in CSP_List._Evidence_Details)
                            {
                                var param = new
                                {
                                    CSP_Id = item.CSP_Id,
                                };
                                var Personal_Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure13, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Personnel_Tools = Personal_Tools_List;

                                if (item._Add_Personnel_Tools != null && item._Add_Personnel_Tools.Count > 0)
                                {
                                    foreach (var obj in item._Add_Personnel_Tools)
                                    {
                                        var param_Tools = new
                                        {
                                            CSP_Pers_Tools_Id = obj.CSP_Pers_Tools_Id
                                        };
                                        var Closure_Evd_List = (await connection.QueryAsync<Ptw_Sp_Add_Closure_Evidence>(procedure15, param_Tools, commandType: CommandType.StoredProcedure)).ToList();
                                        obj._Closure_Evidences = Closure_Evd_List;
                                    }
                                }

                                var Evidence_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Renewal_Evidences = Evidence_List;
                            }
                        }


                        if (Renewal_Details_List != null && Renewal_Details_List.Count > 0)
                        {
                            CSP_List._Get_Renewal_Details = Renewal_Details_List;
                        }
                        if (Zone_Reject_Get_List != null && Zone_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Zone_Reject_List = Zone_Reject_Get_List;
                        }
                    }
                    return CSP_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Edit_Hot_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Zone_HSE_WAH_Approve(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Add_History_Approval";
                string Proc_App_Comments = "sp_Ptw_WAH_Add_Approval_Comments";
                string proc_App_Mail_Req_Zone = "sp_Ptw_WAH_Approve_Request_Email";
                string proc_App_Mail_Req_Hse = "sp_Ptw_WAH_Approve_Request_HSE_Email";
                string proc_App_Mail_Renewal_Zone = "sp_Ptw_WAH_Zone_Renewal_Approve_Email";
                string proc_App_Mail_Evd_Zone = "sp_Ptw_WAH_Zone_Approve_Evd_Req_Email";
                string proc_App_Mail_Evd_HSE = "sp_Ptw_WAH_HSE_Approve_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    var CSP_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var CSP_App_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_App_Comments, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity.Status == "2")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if(entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Hse, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "8")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_HSE_EWP_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_WAH_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_WAH_Add_Evidence_Details";
                string procedure2 = "sp_Ptw_WAH_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_WAH_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_WAH_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_WAH_Add_Closure_Evd_Files";
                string Proc_Sp_Evd_Req = "sp_Ptw_WAH_Sp_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        foreach (var item in entity._Add_Personnel_Tools)
                        {
                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }

                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_WAH_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_WAH_Update_Additional_Details";
                string procedure2 = "sp_Ptw_WAH_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_WAH_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_WAH_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_WAH_Add_Closure_Evd_Files";
                string proc_Evd_Del = "sp_Ptw_WAH_Delete_Renewal_Evidence_Files";
                string proc_Pers_tools = "sp_Ptw_WAH_Delete_Personnel_Tools";
                string Proc_Sp_Evd_Req = "sp_Ptw_WAH_Sp_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Pers_tools, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Personnel_Tools)
                        {

                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {

                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Evd_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Edit_Sp_HW_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_WAH_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_WAH_Add_History_Approval";
                string proc_Renewal_Req = "sp_Ptw_WAH_SP_Renewal_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_WAH_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_WAH_Add_History_Approval";
                string procedure_Del = "sp_Ptw_WAH_Delete_Renewal";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param_del = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    await connection.ExecuteAsync(procedure_Del, param_del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        //Reject
        public async Task<M_Return_Message> Add_Zone_WAH_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_WAH_Add_History_Approval";
                string procedure1 = "sp_Ptw_WAH_Add_Zone_Reject";
                string Proc_Zone_Req_Reject = "sp_Ptw_WAH_Zone_Reject_Request_Email";
                string Proc_HSE_Req_Reject = "sp_Ptw_WAH_HSE_Reject_Request_Email";
                string Proc_Zone_Renewal_Reject = "sp_Ptw_WAH_Zone_Reject_Renewal_Email";
                string Proc_Zone_Evd_Reject = "sp_Ptw_WAH_Zone_Reject_Evd_Email";
                string Proc_HSE_Evd_Reject = "sp_Ptw_WAH_HSE_Reject_Evd_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Reject_Id = item.Zone_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Zone_Approver_Name = item.Zone_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Status == "3")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_Zone_Req_Reject, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_HSE_Req_Reject, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_Zone_Renewal_Reject, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_Zone_Evd_Reject, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "13")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_HSE_Evd_Reject, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        #endregion

        #region [Fire & Safety Work Permit]
        public async Task<IReadOnlyList<M_MajorQuestion>> Get_All_Fire_Safety_Question()
        {
            try
            {
                string procedure = "sp_Load_Fire_Safety_Questionaries";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    return (await connection.QueryAsync<M_MajorQuestion>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Fire_Safety_Question";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Fire_Safety_Req(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Community_Name = "";
                var CreatedBy_Name = "";
                var CreatedDate = "";
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
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Community_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy_Name = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
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
                string procedure = "sp_PTW_FS_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Fire_Safety_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Fire_Safety_Req(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string Procedure = "sp_PTW_FS_Add_Request";
                string Procedure_Question = "sp_Ptw_FS_Add_Request_Questionnaire";
                string Procedure_Question_Del = "sp_Ptw_FS_Delete_Request_Questionnaire";
                string Procedure_Extent_Area = "sp_PTW_FS_Extent_Area_Affect_Add_More";
                string Procedure_Extent_Personnel = "sp_PTW_FS_Extent_Personnel_Affect_Add_More";
                string Procedur_Method_Isol = "sp_PTW_FS_Method_Isolation_Add_More";
                string procedure_Staff_Files = "sp_Ptw_FS_Add_Staff_Comp_Files";
                string procedure_Method_Files = "sp_Ptw_FS_Add_Method_State_Files";
                string procedure_Risk_Files = "sp_Ptw_FS_Add_Risk_Assess_Files";
                string procedure_Emergency_Files = "sp_Ptw_FS_Add_Emr_Plan_Files";
                string procedure_HSE_Files = "sp_Ptw_FS_Add_HSE_Plan_Files";
                string procedure_Signed_Files = "sp_Ptw_FS_Add_Signature_Files";

                string procedure_Del_Method = "sp_Ptw_FS_Delete_Method_Files";
                string procedure_Del_Risk = "sp_Ptw_FS_Delete_Risk_Files";
                string procedure_Del_EMR = "sp_Ptw_FS_Delete_EMR_Files";
                string procedure_Del_HSE = "sp_Ptw_FS_Delete_HSE_Files";
                string procedure_Del_Staff = "sp_Ptw_FS_Delete_Staff_Files";
                string procedure_Del_Signed = "sp_Ptw_FS_Delete_Signed_Files";
                string procedure_History = "sp_Ptw_FS_Add_History_Approval";

                string procedure_Extent_Area_Del = "sp_Ptw_FS_Delete_Extent_Areas";
                string procedure_Personnel_Affect_Del = "sp_Ptw_FS_Delete_Personnel_Affect";
                string procedure_Method_Iso_Del = "sp_Ptw_FS_Delete_Method_Isolation";
                string procedure_Add_Req_Email = "sp_Ptw_FS_Add_Request_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Company_Name = entity.Company_Name,
                        Contrator_Title_No = entity.Contrator_Title_No,
                        Competent_Person = entity.Competent_Person,
                        Name = entity.Name,
                        Position = entity.Position,
                        Contact = entity.Contact,
                        Email_Id = entity.Email_Id,
                        Date_and_Time = entity.Date_and_Time,
                        Description_of_Work = entity.Description_of_Work,
                        Approved_Method = entity.Approved_Method,
                        Additional_Precautions = entity.Additional_Precautions,
                        Work_Duration_From_Date = entity.Work_Duration_From_Date,
                        Work_Duration_To_Date = entity.Work_Duration_To_Date,
                        Night_Schedule = entity.Night_Schedule,
                        Status = entity.Status,
                        CreatedBy = entity.CreatedBy,
                        Latitude = entity.Latitude,
                        Longitude = entity.Longitude,
                        Location_Address = entity.Location_Address,
                        Exact_Loc_Address = entity.Exact_Loc_Address,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        Building_Id = entity.Building_Id,
                        Contractor_Name = entity.Contractor_Name,
                        Contractor_Start_Date = entity.Contractor_Start_Date,
                        Contractor_End_Date = entity.Contractor_End_Date,
                        DMS_No_Id = entity.DMS_No_Id,
                        Isolation_Impair_Coordinate = entity.Isolation_Impair_Coordinate,
                        Fire_Alarm_Chk = entity.Fire_Alarm_Chk,
                        Fire_Protection_Chk = entity.Fire_Protection_Chk,
                        PAVA_Chk = entity.PAVA_Chk,
                        Degree_Isolation = entity.Degree_Isolation,
                        Reason_Isolation = entity.Reason_Isolation,
                        During_Work_Hrs = entity.During_Work_Hrs,
                        Out_Work_Hrs = entity.Out_Work_Hrs,
                        alter_fire_fight_option = entity.alter_fire_fight_option,
                        Fire_watcher_Detail = entity.Fire_watcher_Detail,
                        Competent_Number = entity.Competent_Number,
                        HSE_Officer_Name = entity.HSE_Officer_Name,
                        HSE_Mobile_Number = entity.HSE_Mobile_Number,
                        Declare_Name = entity.Declare_Name,
                        Declare_Designation = entity.Declare_Designation,
                        Declare_Chk = entity.Declare_Chk
                    };

                    var FS_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(Procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var Email_Param = new
                    {
                        CSP_Id = FS_List!.CSP_Id,
                    };
                    var CSP_Mail = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure_Add_Req_Email, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_CSP_Ques != null && entity._Add_CSP_Ques.Count > 0)
                    {

                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(Procedure_Question_Del, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_CSP_Ques)
                        {
                            var param_Ques = new
                            {
                                Ques_CSP_ID = item.Ques_CSP_ID,
                                CSP_Id = FS_List!.CSP_Id!,
                                Major_HSE_Work_Id = item.Major_HSE_Work_Id,
                                CSP_Ques_Name = item.CSP_Ques_Name,
                                CSP_Ques_Radio_Btn = item.CSP_Ques_Radio_Btn,
                                CSP_Remarks = item.CSP_Remarks,
                                CreatedBy = item.CreatedBy,

                            };
                            var Quest_list = (await connection.QueryAsync<Confined_Space_Add_Ques>(Procedure_Question, param_Ques, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity._Area_Affected != null && entity._Area_Affected.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Extent_Area_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Area_Affected)
                        {
                            var Procedure_Extent = new
                            {
                                FS_Area_Affect_Id = item.FS_Area_Affect_Id,
                                CSP_Id = FS_List!.CSP_Id,
                                Extent_Area_Affected = item.Extent_Area_Affected,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(Procedure_Extent_Area, Procedure_Extent, commandType: CommandType.StoredProcedure);
                        }
                    }
                    if (entity._Personnel_Affected != null && entity._Personnel_Affected.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Personnel_Affect_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Personnel_Affected)
                        {
                            var Extent_Personnel = new
                            {
                                FS_Personnel_Affect_Id = item.FS_Personnel_Affect_Id,
                                CSP_Id = FS_List!.CSP_Id,
                                Extent_Personnel_Affected = item.Extent_Personnel_Affected,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(Procedure_Extent_Personnel, Extent_Personnel, commandType: CommandType.StoredProcedure);
                        }
                    }
                    if (entity._Method_Isolation != null && entity._Method_Isolation.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Method_Iso_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Method_Isolation)
                        {
                            var Method_Isol = new
                            {
                                FS_Method_Isolation_Id = item.FS_Method_Isolation_Id,
                                CSP_Id = FS_List!.CSP_Id,
                                Method_Isolation = item.Method_Isolation,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.ExecuteAsync(Procedur_Method_Isol, Method_Isol, commandType: CommandType.StoredProcedure);
                        }
                    }
                    if (entity._Staff_Comptency_Files != null && entity._Staff_Comptency_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Staff, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Staff_Comptency_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                File_Id = photos.File_Id,
                                File_Path = photos.File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Photos_list = (await connection.QueryAsync<Staff_Comptency_Files>(procedure_Staff_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Method_Statement_Files != null && entity._Method_Statement_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Method, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Method_Statement_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                Method_File_Id = photos.Method_File_Id,
                                Method_File_Path = photos.Method_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Method_list = (await connection.QueryAsync<Method_Statement_Files>(procedure_Method_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Risk_Assess_Files != null && entity._Risk_Assess_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Risk, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Risk_Assess_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                Risk_File_Id = photos.Risk_File_Id,
                                Risk_File_Path = photos.Risk_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Risk_list = (await connection.QueryAsync<Risk_Assess_Files>(procedure_Risk_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Emr_Plan_Files != null && entity._Emr_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_EMR, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._Emr_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                Emr_File_Id = photos.Emr_File_Id,
                                Emr_File_Path = photos.Emr_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Emr_list = (await connection.QueryAsync<Emr_Plan_Files>(procedure_Emergency_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._HSE_Plan_Files != null && entity._HSE_Plan_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_HSE, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity._HSE_Plan_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                Hse_File_Id = photos.Hse_File_Id,
                                Hse_File_Path = photos.Hse_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<HSE_Plan_Files>(procedure_HSE_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Signed_Files != null && entity._Sp_Signed_Files.Count > 0)
                    {
                        var param_del_Method = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(procedure_Del_Signed, param_del_Method, commandType: CommandType.StoredProcedure);
                        foreach (var photos in entity!._Sp_Signed_Files)
                        {
                            var param_photos = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                Sign_File_Id = photos.Sign_File_Id,
                                Sign_File_Path = photos.Sign_File_Path,
                                CreatedBy = photos.CreatedBy,
                            };
                            var Hse_list = (await connection.QueryAsync<Sp_Signed_Files>(procedure_Signed_Files, param_photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }

                    if (entity._Ptw_History_List != null)
                    {
                        foreach (var obj in entity._Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = FS_List!.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "1",
                                Remarks = "Zone Supervisor Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;

                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Confined_Space_Req";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<Ptw_Confined_Space_Add> Edit_Fire_Safety(Ptw_Confined_Space_Add entity)
        {
            try
            {
                string procedure = "sp_Ptw_FS_Request_Edit";
                string procedure1 = "sp_Ptw_FS_Request_Questionnaire_Edit";
                string procedure2 = "sp_Business_Unit_Master_GetAll";
                string procedure3 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure6 = "sp_Ptw_FS_Get_History_Approval";
                string Procedure7 = "sp_Ptw_FS_Staff_Files_Get";
                string Procedure8 = "sp_Ptw_FS_Method_Files_Get";
                string Procedure9 = "sp_Ptw_FS_Risk_Assess_Get";
                string Procedure10 = "sp_Ptw_FS_Emr_Plan_Get";
                string Procedure11 = "sp_Ptw_FS_HSE_Plan_Get";

                string procedure12 = "sp_Ptw_FS_Evidence_Details_Edit";
                string procedure13 = "sp_Ptw_FS_Personal_Tools_Edit";
                string procedure14 = "sp_Ptw_FS_Evidence_Files_Edit";
                string procedure15 = "sp_Ptw_FS_Closure_Evd_Get";
                string procedure16 = "sp_Ptw_FS_Renewal_Details_Edit";
                string procedure17 = "sp_Ptw_FS_Get_Zone_Reject_Details";

                string procedure18 = "sp_Ptw_FS_Extent_Area_Affected_Edit";
                string procedure19 = "sp_Ptw_FS_Personnel_Affected_Edit";
                string procedure20 = "sp_Ptw_FS_Method_Isolation_Edit";
                string procedure21 = "sp_Ptw_FS_Signed_Files_Get";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    var CSP_List = (await connection.QueryAsync<Ptw_Confined_Space_Add>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (CSP_List != null)
                    {
                        var Ques_List = (await connection.QueryAsync<Confined_Space_Add_Ques>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Ques_List != null)
                        {
                            CSP_List._Add_CSP_Ques = Ques_List;
                        }
                        CSP_List!.CSP_Comman_Master_List = new Basic_Master_Data();
                        CSP_List!.CSP_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        CSP_List!.CSP_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var parameters_Zone = new
                        {
                            Zone_Id = CSP_List.Zone_Id,
                            Community_Id = CSP_List.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var History_Approval_Get_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure6, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Staff_Files_List = (await connection.QueryAsync<Staff_Comptency_Files>(Procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Method_Files_List = (await connection.QueryAsync<Method_Statement_Files>(Procedure8, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Risk_Files_List = (await connection.QueryAsync<Risk_Assess_Files>(Procedure9, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Emr_Files_List = (await connection.QueryAsync<Emr_Plan_Files>(Procedure10, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var HSE_Files_List = (await connection.QueryAsync<HSE_Plan_Files>(Procedure11, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Signed_Files_List = (await connection.QueryAsync<Sp_Signed_Files>(procedure21, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Area_Affect_List = (await connection.QueryAsync<Extent_Area_Affected_AddMore>(procedure18, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Personnel_List = (await connection.QueryAsync<Extent_Personnel_Affected_AddMore>(procedure19, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Method_Isolation_List = (await connection.QueryAsync<Method_Isolation_AddMore>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        var Add_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Renewal_Details_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Details>(procedure16, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Reject_Get_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure17, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Business_Unit_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            CSP_List!.CSP_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (History_Approval_Get_List != null)
                        {
                            CSP_List._Ptw_History_List = History_Approval_Get_List;
                        }
                        if (Staff_Files_List != null && Staff_Files_List.Count > 0)
                        {
                            CSP_List._Staff_Comptency_Files = Staff_Files_List;
                        }
                        if (Method_Files_List != null && Method_Files_List.Count > 0)
                        {
                            CSP_List._Method_Statement_Files = Method_Files_List;
                        }
                        if (Risk_Files_List != null && Risk_Files_List.Count > 0)
                        {
                            CSP_List._Risk_Assess_Files = Risk_Files_List;
                        }
                        if (Emr_Files_List != null && Emr_Files_List.Count > 0)
                        {
                            CSP_List._Emr_Plan_Files = Emr_Files_List;
                        }
                        if (HSE_Files_List != null && HSE_Files_List.Count > 0)
                        {
                            CSP_List._HSE_Plan_Files = HSE_Files_List;
                        }
                        if(Area_Affect_List != null && Area_Affect_List.Count > 0)
                        {
                            CSP_List._Area_Affected = Area_Affect_List;
                        }
                        if (Personnel_List != null && Personnel_List.Count > 0)
                        {
                            CSP_List._Personnel_Affected = Personnel_List;
                        }
                        if (Method_Isolation_List != null && Method_Isolation_List.Count > 0)
                        {
                            CSP_List._Method_Isolation = Method_Isolation_List;
                        }
                        if (Add_Details_List != null)
                        {
                            CSP_List._Evidence_Details = Add_Details_List;
                        }
                        if (Signed_Files_List != null && Signed_Files_List.Count > 0)
                        {
                            CSP_List._Sp_Signed_Files = Signed_Files_List;
                        }

                        if (CSP_List._Evidence_Details != null && CSP_List._Evidence_Details.Count > 0)
                        {
                            foreach (var item in CSP_List._Evidence_Details)
                            {
                                var param = new
                                {
                                    CSP_Id = item.CSP_Id,
                                };
                                var Personal_Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure13, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Personnel_Tools = Personal_Tools_List;

                                if (item._Add_Personnel_Tools != null && item._Add_Personnel_Tools.Count > 0)
                                {
                                    foreach (var obj in item._Add_Personnel_Tools)
                                    {
                                        var param_Tools = new
                                        {
                                            CSP_Pers_Tools_Id = obj.CSP_Pers_Tools_Id
                                        };
                                        var Closure_Evd_List = (await connection.QueryAsync<Ptw_Sp_Add_Closure_Evidence>(procedure15, param_Tools, commandType: CommandType.StoredProcedure)).ToList();
                                        obj._Closure_Evidences = Closure_Evd_List;
                                    }
                                }

                                var Evidence_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                                item._Add_Renewal_Evidences = Evidence_List;
                            }
                        }


                        if (Renewal_Details_List != null && Renewal_Details_List.Count > 0)
                        {
                            CSP_List._Get_Renewal_Details = Renewal_Details_List;
                        }
                        if (Zone_Reject_Get_List != null && Zone_Reject_Get_List.Count > 0)
                        {
                            CSP_List._Get_Zone_Reject_List = Zone_Reject_Get_List;
                        }
                    }
                    return CSP_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "CSP_Request_Form : Edit_Hot_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Sp_FS_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_FS_Add_Evidence_Details";
                string procedure2 = "sp_Ptw_FS_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_FS_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_FS_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_FS_Add_Closure_Evd_Files";
                string proc_Sp_Evd_Req = "sp_Ptw_FS_SP_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        foreach (var item in entity._Add_Personnel_Tools)
                        {
                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {
                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_FS_Additional_Details(Ptw_Sp_Add_Evidence_Details entity)
        {
            try
            {
                string procedure1 = "sp_Ptw_FS_Update_Additional_Details";
                string procedure2 = "sp_Ptw_FS_Add_Personnel_Tools";
                string procedure3 = "sp_Ptw_FS_Add_Renewal_Evidence_Files";
                string procedure_History = "sp_Ptw_FS_Add_History_Approval";
                string procedure_Closure = "sp_Ptw_FS_Add_Closure_Evd_Files";
                string proc_Evd_Del = "sp_Ptw_FS_Delete_Renewal_Evidence_Files";
                string proc_Pers_tools = "sp_Ptw_FS_Delete_Personnel_Tools";
                string proc_Sp_Evd_Req = "sp_Ptw_FS_SP_Evd_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Add_Id = entity.CSP_Add_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Competent_Person = entity.Competent_Person,
                        Date_Time_Work_Comp = entity.Date_Time_Work_Comp,
                        Date_Time_Safe_Return = entity.Date_Time_Safe_Return,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Date_Time = entity.Date_Time,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Add_Personnel_Tools != null && entity._Add_Personnel_Tools.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Pers_tools, param_del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Personnel_Tools)
                        {

                            var Param_tools = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id!,
                                CSP_Id = item.CSP_Id,
                                CSP_Pers_Tools_Id = item.CSP_Pers_Tools_Id,
                                Personnel_Tools_Name = item.Personnel_Tools_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            var Tools_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure2, Param_tools, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (item._Closure_Evidences != null && item._Closure_Evidences.Count > 0)
                            {

                                foreach (var obj in item._Closure_Evidences!)
                                {
                                    var param_Closure = new
                                    {
                                        CSP_Add_Id = Add_List.CSP_Add_Id!,
                                        CSP_Pers_Tools_Id = Tools_List!.CSP_Pers_Tools_Id,
                                        CSP_Id = obj.CSP_Id,
                                        Closure_File_Id = obj.Closure_File_Id,
                                        Closure_File_Path = obj.Closure_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Closure_List = (await connection.QueryAsync<Ptw_Sp_Add_Personnel_Tools>(procedure_Closure, param_Closure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }
                    if (entity._Add_Renewal_Evidences != null && entity._Add_Renewal_Evidences.Count > 0)
                    {
                        var param_del = new
                        {
                            CSP_Id = entity.CSP_Id
                        };
                        await connection.ExecuteAsync(proc_Evd_Del, param_del, commandType: CommandType.StoredProcedure);
                        foreach (var item in entity._Add_Renewal_Evidences!)
                        {
                            var param_files = new
                            {
                                CSP_Add_Id = Add_List!.CSP_Add_Id,
                                CSP_Id = item.CSP_Id,
                                Evidence_File_Id = item.Evidence_File_Id,
                                Evidence_File_Path = item.Evidence_File_Path,
                                CreatedBy = item.CreatedBy,
                            };
                            var Files_List = (await connection.QueryAsync<Ptw_Sp_Add_Renewal_Evidence>(procedure3, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    if (entity._Sp_Ptw_History_List != null && entity._Sp_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity._Sp_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "6",
                                Remarks = "Sp uploaded,Waiting for Zone Supervisor Approval",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Sp_Evd_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Edit_Sp_HW_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Sp_FS_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_FS_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_FS_Add_History_Approval";
                string proc_SP_Renewal_Req = "sp_Ptw_FS_SP_Renewal_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Edit_Sp_FS_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity)
        {
            try
            {
                string procedure = "sp_Ptw_FS_Add_Renewal_Details";
                string procedure_History = "sp_Ptw_FS_Add_History_Approval";
                string procedure_Del = "sp_Ptw_FS_Delete_Renewal";
                string proc_SP_Renewal_Req = "sp_Ptw_FS_SP_Renewal_Req_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param_del = new
                    {
                        CSP_Id = entity.CSP_Id
                    };
                    await connection.ExecuteAsync(procedure_Del, param_del, commandType: CommandType.StoredProcedure);
                    var parameters = new
                    {
                        CSP_Renewal_Id = entity.CSP_Renewal_Id,
                        CSP_Id = entity.CSP_Id,
                        Action_Radio_Btn = entity.Action_Radio_Btn,
                        Renewal_From_Date = entity.Renewal_From_Date,
                        Renewal_To_Date = entity.Renewal_To_Date,
                        Competent_Person = entity.Competent_Person,
                        Remarks = entity.Remarks,
                        Service_Provider_Name = entity.Service_Provider_Name,
                        Service_Provider_Role = entity.Service_Provider_Role,
                        Service_DateTime = entity.Service_DateTime,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Sp_Renewal_Ptw_History_List != null && entity.Sp_Renewal_Ptw_History_List.Count > 0)
                    {
                        foreach (var obj in entity.Sp_Renewal_Ptw_History_List)
                        {
                            var param_History = new
                            {
                                CSP_Id = entity.CSP_Id,
                                History_Id = obj.History_Id,
                                Emp_Id = obj.Emp_Id,
                                Role_Id = obj.Role_Id,
                                Updated_DateTime = obj.Updated_DateTime,
                                Status = "7",
                                Remarks = "Renewal Approval Pending",
                            };
                            var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure_History, param_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }

                    }
                    var Email_Param = new
                    {
                        CSP_Id = entity.CSP_Id,
                    };
                    var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_SP_Renewal_Req, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }

            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Sp_Renewal_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        //Approve and Reject
        public async Task<M_Return_Message> Add_Zone_HSE_FS_Approve(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_FS_Add_History_Approval";
                string Proc_App_Comments = "sp_Ptw_FS_Add_Approval_Comments";
                string proc_App_Mail_Req_Zone = "sp_Ptw_FS_Zone_Request_Approve_Email";
                string proc_App_Mail_Req_HSE = "sp_Ptw_FS_HSE_Request_Approve_Email";
                string proc_App_Mail_Renewal_Zone = "sp_Ptw_FS_Zone_Renewal_App_Email";
                string proc_App_Mail_Evd_App_Zone = "sp_Ptw_FS_Zone_Supervisor_Evd_App_Email";
                string proc_App_Mail_Evd_App_HSE = "sp_Ptw_FS_HSE_Evd_App_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    var CSP_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var CSP_App_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(Proc_App_Comments, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity.Status == "2")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "8")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_App_Mail_Evd_App_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_HSE_EWP_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Add_Zone_FS_Reject(Ptw_History_of_Approval entity)
        {
            try
            {
                string procedure = "sp_Ptw_FS_Add_History_Approval";
                string procedure1 = "sp_Ptw_FS_Add_Zone_Reject";
                string proc_Rej_Mail_Req_Zone = "sp_Ptw_FS_Zone_Supervisor_Req_Rej_Email";
                string proc_Rej_Mail_Req_HSE = "sp_Ptw_FS_HSE_Req_Rej_Email";
                string proc_Rej_Mail_Renewal_Zone = "sp_Ptw_FS_Zone_Renewal_Rej_Email";
                string proc_Rej_Mail_Evd_Zone = "sp_Ptw_FS_Zone_Evd_Rej_Email";
                string proc_Rej_Mail_Evd_HSE = "sp_Ptw_FS_HSE_Evd_Rej_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        History_Id = entity.History_Id,
                        CSP_Id = entity.CSP_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Updated_DateTime = entity.Updated_DateTime,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var History_List = (await connection.QueryAsync<Ptw_History_of_Approval>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (entity._Zone_HSE_Reject != null)
                    {
                        foreach (var item in entity._Zone_HSE_Reject)
                        {
                            var param_reject = new
                            {
                                Zone_Reject_Id = item.Zone_Reject_Id,
                                CSP_Id = item.CSP_Id,
                                Zone_Approver_Name = item.Zone_Approver_Name,
                                Designation = item.Designation,
                                Date_Time = item.Date_Time,
                                Remarks = item.Remarks,
                                CreatedBy = item.CreatedBy,
                            };
                            var Reject_List = (await connection.QueryAsync<Confined_Space_Reject>(procedure1, param_reject, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity.Status == "3")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Req_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Renewal_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_Zone, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Status == "13")
                    {
                        var Email_Param = new
                        {
                            CSP_Id = entity.CSP_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Confined_Space_Approve_Reject>(proc_Rej_Mail_Evd_HSE, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        #endregion
#pragma warning restore CS8603 // Possible null reference return.
    }
}
