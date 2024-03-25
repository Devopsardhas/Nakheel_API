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
using System.Reflection.Metadata;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AuditEnvRepo : IAuditEnvRepo
    {
        private readonly IConfiguration configuration;
        public AuditEnvRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<M_Return_Message> AddAsync(M_Audit_Env entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(M_Audit_Env entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<M_Audit_Env>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<M_Audit_Env>> GetAll_Env_Audit(DataTableAjaxPostModel entity)
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
                string procedure = "sp_Am_Get_All_Env_Audit";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Audit_Env>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Env_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            };
        }

        public async Task<M_Audit_Env> Edit_Env_Audit(M_Audit_Env entity)
        {
            try
            {
                string procedure1 = "sp_Am_Edit_Env_Audit";
                string procedure2 = "sp_Am_Env_Audit_Auditors_Filter";
                string procedure3 = "sp_Am_Env_Audit_SP_Filter";
                string procedure4 = "sp_Am_Env_Audit_Auditors_Team_Edit";
                string procedure5 = "sp_Am_Env_Audit_Service_Rep_Edit";

                string procedure6 = "sp_Am_Env_Audit_Topics_Master";
                string procedure8 = "sp_Am_Env_Audit_Questionnaire_Master";

                string procedure9 = "sp_Am_Env_Audit_Topics_Edit";
                string procedure11 = "sp_Am_Env_Audit_Sub_Topics_Ques_Edit";

                string procedure12 = "sp_Am_Env_Audit_Edit_Reject_Reason";

                string procedure13 = "sp_Am_Env_Audit_Get_History_Approval";
                string procedure14 = "sp_Am_Env_Audit_Evidence_Files_Get";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Env_Audit_Id = entity.Env_Audit_Id
                    };

                    var Env_List = (await connection.QueryAsync<M_Audit_Env>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if(Env_List != null)
                    {
                        Env_List._Env_Audit_Master = new AM_ENV_Basic_Master_Data();
                        Env_List._Env_Audit_Master.Audit_Team_List = new List<AM_Env_Dropdown_Values>();
                        Env_List._Env_Audit_Master.SP_Rep_List = new List<AM_Env_Dropdown_Values>();


                        var parameters_Comm = new
                        {
                            Zone_Id = Env_List.Zone_Id,
                            Community_Id = Env_List.Community_Id,
                        };

                        var var_Audit_Team_List = (await connection.QueryAsync<AM_Env_Dropdown_Values>(procedure2, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();
                        var var_SP_Rep_List = (await connection.QueryAsync<AM_Env_Dropdown_Values>(procedure3, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                        var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Env_Auditor_Team_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Env_Service_Rep>(procedure5, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (var_Audit_Team_List != null)
                        {
                            Env_List._Env_Audit_Master.Audit_Team_List = var_Audit_Team_List;
                        }
                        if (var_SP_Rep_List != null)
                        {
                            Env_List._Env_Audit_Master.SP_Rep_List = var_SP_Rep_List;
                        }
                        if (var_Audit_Team_Member_List != null)
                        {
                            Env_List.Am_Env_Audit_Team_Member_List = var_Audit_Team_Member_List;
                        }
                        if (var_SP_Rep_Member_List != null)
                        {
                            Env_List.Am_Env_Service_Rep_List = var_SP_Rep_Member_List;
                        }

                        var var_Topic_Mas_List = (await connection.QueryAsync<Am_Env_Topics_Master>(procedure6, commandType: CommandType.StoredProcedure)).ToList();
                                           
                        if(var_Topic_Mas_List != null && var_Topic_Mas_List.Count > 0)
                        {
                            Env_List.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                            foreach (var item in Env_List.Am_Sp_Topics_Master_List)
                            {
                                var param = new
                                {
                                    Value = item.Value
                                };
                                var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Env_Questionnaires_Master>(procedure8, param, commandType: CommandType.StoredProcedure)).ToList();
                                if (var_Questionnaires_Mas_List != null)
                                {
                                    item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                }
                            }
                        }

                        var var_Topic_Mas_List_Edit = (await connection.QueryAsync<Am_Env_Topics_Master>(procedure9, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (var_Topic_Mas_List_Edit != null && var_Topic_Mas_List_Edit.Count > 0)
                        {
                            Env_List.Am_Sp_Topics_Master_List = var_Topic_Mas_List_Edit;
                            if(Env_List.Am_Sp_Topics_Master_List != null && Env_List.Am_Sp_Topics_Master_List.Count > 0)
                            {
                                foreach (var item in Env_List.Am_Sp_Topics_Master_List!)
                                {
                                    var param = new
                                    {
                                        Value = item.Value,
                                        Env_Audit_Id = entity.Env_Audit_Id,
                                    };
                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Env_Questionnaires_Master>(procedure11, param, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }
                                }
                            }
                        }

                        var var_Reject_List = (await connection.QueryAsync<Env_Audit_Reject>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (var_Reject_List != null && var_Reject_List.Count > 0)
                        {
                            Env_List._Reject_List = var_Reject_List;
                        }

                        var History_List = (await connection.QueryAsync<Env_Audit_History_Approval>(procedure13,parameters,commandType:CommandType.StoredProcedure)).ToList();
                        if (History_List != null && History_List.Count > 0)
                        {
                            Env_List._History_List = History_List;
                        }

                        var Evd_List = (await connection.QueryAsync<Env_Audit_Evd_Files>(procedure14, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Evd_List != null && Evd_List.Count > 0)
                        {
                            Env_List._Get_Evidence_List = Evd_List;
                        }
                    }
                    return Env_List!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Edit_Env_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Env_Audit_ApprovalReject(M_Audit_Env entity)
        {
            try
            {
                string procedure = "sp_Am_Env_Audit_Questionnaire_App_Rej";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Env_Audit_Id = entity.Env_Audit_Id,
                        Status = entity.Status,
                        //Remarks = entity.Remarks,
                        Created_by = entity.Created_by,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Env_Audit_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Env_Audit(M_Audit_Env entity)
        {
            try
            {
                string procedure = "sp_Am_Env_Audit_Add_Auditors_Team";
                string procedure1 = "sp_Am_Env_Audit_Add_Service_Rep";
                string procedure2 = "sp_Am_Env_Audit_Status_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Am_Env_Audit_Team_Member_List != null && entity.Am_Env_Audit_Team_Member_List.Count > 0)
                    {
                        foreach (var item in entity.Am_Env_Audit_Team_Member_List)
                        {
                            var parameters = new
                            {
                                Env_Auditor_Team_Id = item.Env_Auditor_Team_Id,
                                Env_Audit_Id = entity.Env_Audit_Id,
                                Emp_Id = item.Emp_Id,
                                Created_by = entity.Created_by,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                        }
                    }

                    if (entity.Am_Env_Service_Rep_List != null && entity.Am_Env_Service_Rep_List.Count > 0)
                    {
                        foreach (var items in entity.Am_Env_Service_Rep_List)
                        {
                            var parameters1 = new
                            {
                                Env_Service_Rep_Id = items.Env_Service_Rep_Id,
                                Env_Audit_Id = entity.Env_Audit_Id,
                                Emp_Id = items.Emp_Id,
                                Created_by = entity.Created_by,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                        }
                    }

                    var parameters_Status = new
                    {
                        Env_Audit_Id = entity.Env_Audit_Id,
                        Created_by = entity.Created_by,
                        Building_Text = entity.Building_Text
                    };
                    var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Env_Audit_Questionnaire_Add(Am_Env_Audit_Add_Questionnaires_List entity)
        {
            try
            {
                string procedure = "sp_Am_Env_Audit_Add_Questionnaire";
                string procedure1 = "sp_Am_Env_Audit_Questionaire_Status_Update";
                string procedure2 = "sp_Am_Env_Audit_Questionaire_Delete";
                string procedure3 = "sp_Am_Env_Audit_Add_Evidence";
                string procedure4 = "sp_Am_Env_Audit_Evidence_Delete";
                string procedure5 = "sp_Am_Env_Audit_Add_Chk_Mail";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    if (entity._Add_Questionnaires_List != null && entity._Add_Questionnaires_List.Count > 0)
                    {
                        var parameters_Del = new
                        {
                            Env_Audit_Id = entity._Add_Questionnaires_List[0].Env_Audit_Id,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity._Add_Questionnaires_List)
                        {
                            var parameters = new
                            {
                                Am_Sp_Ques_Finding_Id = item.Am_Sp_Ques_Finding_Id,
                                Env_Audit_Id = item.Env_Audit_Id,
                                Audit_Topics_Id = item.Audit_Topics_Id,
                                Audit_Sub_Topics_Id = item.Audit_Sub_Topics_Id,
                                Audit_Questionnaires_Id = item.Audit_Questionnaires_Id,
                                Is_Questionnaires_Checked = item.Is_Questionnaires_Checked,
                                Objective_Evidence = item.Objective_Evidence,
                                Findings_Type_Name = item.Findings_Type_Name,
                                Find_Comments = item.Find_Comments,
                                CreatedBy = item.CreatedBy,
                                
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                        }

                        if(entity._List_Evd_Files != null && entity._List_Evd_Files.Count > 0)
                        {
                            var param_Del = new
                            {
                                Env_Audit_Id = entity.Env_Audit_Id,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure4, param_Del, commandType: CommandType.StoredProcedure);
                        }

                        foreach (var obj in entity._List_Evd_Files!)
                        {
                            
                            var parameters = new
                            {
                                Env_Audit_File_Id = obj.Env_Audit_File_Id,
                                CreatedBy = obj.CreatedBy,
                                Env_Audit_Id = entity.Env_Audit_Id,
                                Env_Ad_Env_File_Path = obj.Env_Ad_Env_File_Path,
                            };
                            var Evd_Files = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }

                        var parameters_Status = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                            CreatedBy = entity.Created_by,
                            Safety_Violation = entity.Safety_Violation,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Mail = (await connection.QueryAsync<M_Return_Message>(procedure5, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }


                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Env_Audit_HSE_Approve(Env_Audit_Approval entity)
        {
            try
            {
                string procedure = "sp_Am_Env_Audit_Add_Approval_Comments";
                string procedure1 = "sp_Am_Env_Audit_HSE_Approve_Mail";
                string procedure2 = "sp_Am_Env_Audit_Director_Approve_Mail";
                string procedure3 = "sp_Am_Env_Audit_Lead_Ad_Approve_Mail";
                string procedure4 = "sp_Am_Env_Audit_Final_Hse_Approve_Mail";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {

                        Env_Audit_Id = entity.Env_Audit_Id,
                        Env_Approve_Id = entity.Env_Approve_Id,
                        Emp_Id = entity.Emp_Id,
                        Role_Id = entity.Role_Id,
                        Remarks = entity.Remarks,
                        Status = entity.Status,
                        Approve_Comments = entity.Approve_Comments,
                    };
                    if (entity.Status == "5")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure1, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    if (entity.Status == "7")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure2, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    if (entity.Status == "10")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure3, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    if (entity.Status == "12")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure4, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;

                    
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Env_Audit_HSE_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Env_Audit_Reject(Env_Audit_Reject entity)
        {
            try
            {
                string procedure = "sp_Am_Env_Audit_Add_Reject_Comments";
                string procedure1 = "sp_Am_Env_Audit_HSE_Reject_Mail";
                string procedure2 = "sp_Am_Env_Audit_Director_Reject_Mail";
                string procedure3 = "sp_Am_Env_Audit_Lead_Reject_Mail";
                string procedure4 = "sp_Am_Env_Audit_Final_Hse_Reject_Mail";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {

                        Env_Audit_Id = entity.Env_Audit_Id,
                        Am_Env_Ques_Rej_Id = entity.Am_Env_Ques_Rej_Id,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                        Status = entity.Status,
                    };

                    if (entity.Status == "4")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure1, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    if (entity.Status == "6")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure2, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    if (entity.Status == "9")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure3, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    if (entity.Status == "11")
                    {
                        var Email_Param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                        };
                        var Approval_List = (await connection.QueryAsync<Env_Audit_Approval>(procedure4, Email_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Env_Audit_Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public Task<M_Audit_Env> GetByIdAsync(M_Audit_Env entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<M_Audit_Env>> Get_All_Env_Audit(DataTableAjaxPostModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(M_Audit_Env entity)
        {
            throw new NotImplementedException();
        }

        public async Task<M_Return_Message> Am_Env_Audit_Add_Sp_Target(M_Audit_Env entity)
        {
            try
            {
                string procedure1 = "sp_Am_Env_Audit_Sp_Target_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Env_Audit_Id = entity.Env_Audit_Id,
                        CA_Target_Date = entity.CA_Target_Date,
                        Safety_Violation = entity.Safety_Violation,
                        Created_by = entity.Created_by,
                    };
                    var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }


                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = "Added Successful",
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = "200",
                };
                return rETURN_MESSAGE;
            }

            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                string Repo = "Am_Env_Audit_Add_Sp_Target";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Am_Env_Audit_Add_NCR_Action(M_Audit_Env entity)
        {
            try
            {
                //string procedure = "sp_Am_Env_Audit_Add_NCR_Action";
                //string procedure1 = "sp_Am_Env_Audit_Add_NCR_Root_Cause_Analysis";
                //string procedure2 = "sp_Am_Env_Audit_Add_NCR_Desc_Root_Cause";
                string procedure3 = "sp_Am_Env_Audit_Questionaire_Action_Update";
                string procedure4 = "sp_Am_Env_Audit_NCR_Action_Status_Update";
                string procedure5 = "sp_Am_Env_Audit_Service_Provider_Mail";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity != null)
                    {
                        var var_Am_Sp_NCR_Action_Id = "0";                    
                      
                        if (entity.Add_Finding_Questionnaires_List != null && entity.Add_Finding_Questionnaires_List.Count > 0)
                        {
                            foreach (var item in entity.Add_Finding_Questionnaires_List)
                            {
                                var parameters3 = new
                                {
                                    Am_Sp_Ques_Finding_Id = item.Am_Sp_Ques_Finding_Id,
                                    Env_Audit_Id = item.Env_Audit_Id,
                                    Am_Env_NCR_Action_Id = var_Am_Sp_NCR_Action_Id,
                                    Closure_Description = item.Closure_Description,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.Created_by,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_Status = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id,
                            CreatedBy = entity.Created_by,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var param = new
                        {
                            Env_Audit_Id = entity.Env_Audit_Id
                        };
                        var Mail = (await connection.QueryAsync<M_Return_Message>(procedure5, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Am_Sp_NCR_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
    }
}
