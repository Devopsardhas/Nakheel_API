using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
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
using System.Reflection.Metadata;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AuditNCMFormRepo : IAuditNCMFormRepo
    {
        private readonly IConfiguration configuration;
        private IHostingEnvironment Environment;

        public AuditNCMFormRepo(IConfiguration configuration, IHostingEnvironment _environment)
        {
            this.configuration = configuration;
            Environment = _environment;
        }


#pragma warning disable CS8603 // Possible null reference return.

        #region [Basic]
        public Task<M_Return_Message> AddAsync(MAuditNCMForm entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(MAuditNCMForm entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<MAuditNCMForm>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MAuditNCMForm> GetByIdAsync(MAuditNCMForm entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(MAuditNCMForm entity)
        {
            throw new NotImplementedException();
        }
        #endregion
        public async Task<IReadOnlyList<MAuditNCMForm>> Audit_NCM_Form_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
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
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
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
                    Card_Id = entity.Card_Id,
                };
                string procedure = "sp_Am_Sp_NCR_Form_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<MAuditNCMForm>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_NCM_Form_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<MAuditNCMForm> Am_Sp_NCR_Form_GetbyId(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCR_Form_GetbyId";
                string procedure1 = "sp_Am_Sp_Audit_NCR_CA_GetbyId";
                string procedure2 = "sp_Am_Sp_Audit_NCR_CA_Rej_GetbyId";
                string procedure3 = "sp_Am_Sp_NCR_History_Approval_GetbyId";
                string procedure4 = "sp_Am_Sp_Audit_NCR_Form_Rej_GetbyId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id
                    };

                    var Obj = (await connection.QueryAsync<MAuditNCMForm>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj.Audit_NCM_CA_List = new List<M_AuditNCM_CA>();
                        Obj.Audit_NCM_CA_Rej_List = new List<M_AuditNCM_CA_Rej>();
                        Obj.Am_Sp_NCR_History_Approval_List = new List<Am_Sp_NCR_History_Approval>();
                        Obj.Audit_NCM_Form_Rej_List = new List<M_AuditNCM_CA_Rej>();

                        var Obj_CA = (await connection.QueryAsync<M_AuditNCM_CA>(procedure1, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_CA_Rej = (await connection.QueryAsync<M_AuditNCM_CA_Rej>(procedure2, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_NCR_History = (await connection.QueryAsync<Am_Sp_NCR_History_Approval>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Form_Rej = (await connection.QueryAsync<M_AuditNCM_CA_Rej>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_NCR_History != null)
                        {
                            Obj.Am_Sp_NCR_History_Approval_List = Obj_NCR_History;
                        }
                        if (Obj_Form_Rej != null)
                        {
                            Obj.Audit_NCM_Form_Rej_List = Obj_Form_Rej;
                        }
                        if (Obj_CA != null)
                        {
                            Obj.Audit_NCM_CA_List = Obj_CA;
                        }
                        if (Obj_CA_Rej != null)
                        {
                            Obj.Audit_NCM_CA_Rej_List = Obj_CA_Rej;
                        }

                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_NCR_Form_GetbyId";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<MAuditNCMForm> Audit_NCM_Form_Create_GetById(MAuditNCMForm entity)
        {
            try
            {
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    MAuditNCMForm Obj = new MAuditNCMForm();
                    Obj.Am_Sp_NCR_Id = "0";
                    Obj.Audit_Date = @DateTime.Now.ToString("yyyy-MM-dd");
                    Obj.CreatedBy = entity.CreatedBy;
                    Obj!.Business_Master_List = new List<Dropdown_Values>();
                    Obj!.Zone_Master_List = new List<Dropdown_Values>();

                    var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                    var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();

                    if (Business_Unit_Master != null && Business_Unit_Master.Count > 0)
                    {
                        Obj.Business_Master_List = Business_Unit_Master;
                    }
                    if (Zone_Master != null && Zone_Master.Count > 0)
                    {
                        Obj.Zone_Master_List = Zone_Master;
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_NCM_Form_Create_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Audit_NCM_Form_Add(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_NCR_Form_Create";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Building_Name = entity.Building_Name,
                        Audit_Date = entity.Audit_Date,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Non_Conformity_Desc = entity.Non_Conformity_Desc,
                        AS_Procedure_Require = entity.AS_Procedure_Require,
                        CreatedBy = entity.CreatedBy,
                        Target_Date = entity.Target_Date,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public async Task<M_Return_Message> Audit_NCM_CA_Action_Add(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_NCR_Form_CA_Update";
                string procedure1 = "sp_Am_Sp_NCR_Form_CA_Action_Add";
                string procedure2 = "sp_Am_Sp_NCR_Form_CA_Action_Delete";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Root_Cause_Analysis = entity.Root_Cause_Analysis,
                        Description_Root_Cause = entity.Description_Root_Cause,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.Audit_NCM_CA_List != null)
                        {
                            var parameters_Del = new
                            {
                                Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Del, commandType: CommandType.StoredProcedure);

                            foreach (var item in entity.Audit_NCM_CA_List)
                            {
                                var parameters1 = new
                                {
                                    Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                                    NCR_Form_CA_Id = item.NCR_Form_CA_Id,
                                    Closure_Description = item.Closure_Description,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
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

                string Repo = "Audit_NCM_CA_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public async Task<M_Return_Message> Audit_NCM_CA_Action_HSE_ApprovalReject(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCR_CA_HSE_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_NCM_CA_Action_HSE_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> NCM_CA_Action_Lead_Auditor_ApprovalReject(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCR_CA_Lead_Auditor_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "NCM_CA_Action_Lead_Auditor_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Audit_NCM_Report_Form_Add(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCM_Report_Form_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Non_Conformity_Desc = entity.Non_Conformity_Desc,
                        AS_Procedure_Require = entity.AS_Procedure_Require,
                        CreatedBy = entity.CreatedBy,
                        Target_Date = entity.Target_Date,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public async Task<M_Return_Message> Audit_NCM_Form_HSE_ApprovalReject(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCR_Form_HSE_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_NCM_Form_HSE_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Audit_NCM_Form_Dir_ApprovalReject(MAuditNCMForm entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_NCR_Form_Dir_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_Sp_NCR_Id = entity.Am_Sp_NCR_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_NCM_Form_Dir_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}
