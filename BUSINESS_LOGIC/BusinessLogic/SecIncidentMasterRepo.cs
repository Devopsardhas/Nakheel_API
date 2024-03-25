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
   public class SecIncidentMasterRepo: ISecIncidentMasterRepo
   {
        private readonly IConfiguration configuration;

        public SecIncidentMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        #region [Sec_Inc_Category_Master]
        public async Task<IReadOnlyList<M_Sec_Inc_Category_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Sec_Inc_Category_Master_Crud";
                    using(var connection=new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Sec_Inc_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Inc Category Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Sec_Incident_Report>> Sec_Get_Location(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Get_All_Loction_Load";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Incident Location Master";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_Sec_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Inc_Category_Name = entity.Sec_Inc_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Inc Category Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Sec_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Inc_Category_Name = entity.Sec_Inc_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Inc Category Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Sec_Inc_Category_Master> GetByIdAsync(M_Sec_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Inc_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Inc Category Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> DeleteAsync(M_Sec_Inc_Category_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sec Inc Category Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Sec_Inc_Type_Master]
        public async Task<IReadOnlyList<M_Sec_Inc_Type_Master>> Sec_Inc_Type_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Sec_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Sec_Inc_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Type Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Sec_Inc_Type_AddAsync(M_Sec_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Sec_Inc_Type_Id = entity.Sec_Inc_Type_Id,
                        Sec_Inc_Type_Name = entity.Sec_Inc_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Type Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Sec_Inc_Type_UpdateAsync(M_Sec_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Sec_Inc_Type_Id = entity.Sec_Inc_Type_Id,
                        Sec_Inc_Type_Name = entity.Sec_Inc_Type_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Type Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Sec_Inc_Type_Master> Sec_Inc_Type_GetByIdAsync(M_Sec_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Sec_Inc_Type_Id = entity.Sec_Inc_Type_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Inc_Type_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Type Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Sec_Inc_Type_DeleteAsync(M_Sec_Inc_Type_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Inc_Type_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Sec_Inc_Type_Id = entity.Sec_Inc_Type_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Type Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #region [Type Security Master]
        public async Task<IReadOnlyList<M_Sub_Security_Incident_Master>> Sub_Security_GetAllAsync()
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Sub_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Sec_Incident_Report>> Sub_SecurityCategory_GetId(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_SubCategory_DeptSection_GetId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Sec_Incident_Report>> Sub_SecDeptSection_GetId(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Sec_SubCategory_DeptSection_GetId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Sec_Sub_Cat_Id = entity.Sec_Sub_Cat_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Sub_Security_AddAsync(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Sec_Inc_Sub_cat_Id = entity.Sec_Inc_Sub_cat_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Inc_Sub_Name = entity.Sec_Inc_Sub_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Sub_Security_UpdateAsync(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Sec_Inc_Sub_cat_Id = entity.Sec_Inc_Sub_cat_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Inc_Sub_Name = entity.Sec_Inc_Sub_Name,
                        Description = entity.Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Sub_Security_Incident_Master> Sub_Security_GetByIdAsync(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Sec_Inc_Sub_cat_Id = entity.Sec_Inc_Sub_cat_Id
                    };
                    return (await connection.QueryAsync<M_Sub_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Sub_Security_DeleteAsync(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Sec_Inc_Sub_cat_Id = entity.Sec_Inc_Sub_cat_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Sub_Security_Incident_Master>> Sub_Security_GetAllbyCatid(M_Sub_Security_Incident_Master entity)
        {
            try
            {
                string procedure = "sp_Sec_Sub_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id
                    };
                    return (await connection.QueryAsync<M_Sub_Security_Incident_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Security Master GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Inc_Mechanism_Injury_Master> GetByIdAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> AddAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(M_Inc_Mechanism_Injury_Master entity)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region [Security Incident Form]
        public async Task<IReadOnlyList<M_Sec_Incident_Report>> Get_All_Security_Inc_req(DataTableAjaxPostModel entity)
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
                string procedure = "sp_Sec_Incident_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Security_Inc_req";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Security_Inc_Report(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Security_Inc_Report_Add";
                string procedure_2 = "Sp_Incident_Security_Photo_Add";
                string procedure_3 = "Sp_Sec_Incident_Videos_Add";
                string procedure_4 = "sp_Sec_Incident_ActionTaken_Add";
                string procedure_5 = "sp_Sec_Incident_FollowUp_ReportedTo_Add";
                string procedure_6 = "sp_Sec_Incident_FollowUp_AssignedTo_Add";
                string procedure_7 = "sp_Send_Email_and_Noti_Security_Incident_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameter_1 = new
                    {
                        Action = 1,
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Sub_Cat_Id=entity.Sec_Sub_Cat_Id,
                        Sec_Inc_Severity = entity.Sec_Inc_Severity,
                        Sec_Inc_Complaint = entity.Sec_Inc_Complaint,
                        Sec_Inc_Method = entity.Sec_Inc_Method,
                        Zone_Id = entity.Zone_Id,
                        Sec_Inc_Occur = entity.Sec_Inc_Occur,
                        Sec_ReportedBy = entity.Sec_ReportedBy,
                        Incident_Date = entity.Incident_Date,
                        Incident_Time = entity.Incident_Time,
                        Sec_Reported_To = entity.Sec_Reported_To,
                        Sec_Assigned_To = entity.Sec_Assigned_To,
                        Sec_Related_Incident = entity.Sec_Related_Incident,
                        Sec_Escalation = entity.Sec_Escalation,
                        Sec_Further_Action = entity.Sec_Further_Action,
                        Sec_Inc_Status = entity.Sec_Inc_Status,
                        Sec_Search_key = entity.Sec_Search_key,
                        Sec_Medical_Assistance = entity.Sec_Medical_Assistance,
                        Sec_Provider = entity.Sec_Provider,
                        Sec_Police_Enquire = entity.Sec_Police_Enquire,
                        Sec_Police = entity.Sec_Police,
                        Sec_Recovery_Vechicle = entity.Sec_Recovery_Vechicle,
                        Sec_CID = entity.Sec_CID,
                        Sec_Ambulance = entity.Sec_Ambulance,
                        Sec_Ambulance_no = entity.Sec_Ambulance_no,
                        Sec_Injure_Person = entity.Sec_Injure_Person,
                        Sec_Address = entity.Sec_Address,
                        Sec_Approxi_Age = entity.Sec_Approxi_Age,
                        Sec_Witnesses = entity.Sec_Witnesses,
                        Sec_Damage = entity.Sec_Damage,
                        Sec_Details_Damage = entity.Sec_Details_Damage,
                        Sec_DeptSection = entity.Sec_DeptSection,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Location_Id = entity.Location_Id,
                        Sub_Location_Id = entity.Sub_Location_Id,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Sec_Incident_Report>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Sec_Inc_Photos != null && entity.L_Sec_Inc_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Sec_Inc_Photos)
                            {
                                var parameters_2 = new
                                {
                                    Sec_Inc_Photo_Id = item.Sec_Inc_Photo_Id,
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Sec_Inc_Videos != null && entity.L_Sec_Inc_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Sec_Inc_Videos)
                            {
                                var parameters_3 = new
                                {
                                    Sec_Inc_Video_Id = item.Sec_Inc_Video_Id,
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters = new
                        {
                            Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                            Action_Taken = entity.Sec_Action,
                            Comments = entity.Sec_Comments,
                            Recommended = entity.Sec_Recommended,
                            CreatedBy = entity.CreatedBy
                        };
                        await connection.ExecuteAsync(procedure_4, parameters, commandType: CommandType.StoredProcedure);
                        if (entity.L_M_Sec_FollowUp_ReportedTo != null && entity.L_M_Sec_FollowUp_ReportedTo.Count > 0)
                        {
                            foreach (var item in entity.L_M_Sec_FollowUp_ReportedTo)
                            {
                                var parameters_5 = new
                                {
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    ReportedTo_Emp = item.Emp_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Sec_FollowUp_AssignedTo != null && entity.L_M_Sec_FollowUp_AssignedTo.Count > 0)
                        {
                            foreach (var item in entity.L_M_Sec_FollowUp_AssignedTo)
                            {
                                var parameters_6 = new
                                {
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    AssignedTo_Emp = item.Emp_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_6, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters_7 = new
                        {
                            Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                        };
                        await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
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
        public async Task<M_Return_Message> Sec_Inc_Report_Update(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Security_Inc_Report_Add";
                string procedure_2 = "Sp_Incident_Security_Photo_Add";
                string procedure_3 = "Sp_Sec_Incident_Videos_Add";
                string procedure_4 = "sp_Sec_Incident_ActionTaken_Add";
                string procedure_5 = "sp_Sec_Incident_FollowUp_ReportedTo_Add";
                string procedure_6 = "sp_Sec_Incident_FollowUp_AssignedTo_Add";
                string procedure_7 = "sp_Send_Email_and_Noti_Security_Incident_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameter_1 = new
                    {
                        Action = 2,
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Sub_Cat_Id = entity.Sec_Sub_Cat_Id,
                        Sec_Inc_Severity = entity.Sec_Inc_Severity,
                        Sec_Inc_Complaint = entity.Sec_Inc_Complaint,
                        Sec_Inc_Method = entity.Sec_Inc_Method,
                        Zone_Id = entity.Zone_Id,
                        Sec_Inc_Occur = entity.Sec_Inc_Occur,
                        Sec_ReportedBy = entity.Sec_ReportedBy,
                        Incident_Date = entity.Incident_Date,
                        Incident_Time = entity.Incident_Time,
                        Sec_Reported_To = entity.Sec_Reported_To,
                        Sec_Assigned_To = entity.Sec_Assigned_To,
                        Sec_Related_Incident = entity.Sec_Related_Incident,
                        Sec_Escalation = entity.Sec_Escalation,
                        Sec_Further_Action = entity.Sec_Further_Action,
                        Sec_Inc_Status = entity.Sec_Inc_Status,
                        Sec_Search_key = entity.Sec_Search_key,
                        Sec_Medical_Assistance = entity.Sec_Medical_Assistance,
                        Sec_Provider = entity.Sec_Provider,
                        Sec_Police_Enquire = entity.Sec_Police_Enquire,
                        Sec_Police = entity.Sec_Police,
                        Sec_Recovery_Vechicle = entity.Sec_Recovery_Vechicle,
                        Sec_CID = entity.Sec_CID,
                        Sec_Ambulance = entity.Sec_Ambulance,
                        Sec_Ambulance_no = entity.Sec_Ambulance_no,
                        Sec_Injure_Person = entity.Sec_Injure_Person,
                        Sec_Address = entity.Sec_Address,
                        Sec_Approxi_Age = entity.Sec_Approxi_Age,
                        Sec_Witnesses = entity.Sec_Witnesses,
                        Sec_Damage = entity.Sec_Damage,
                        Sec_Details_Damage = entity.Sec_Details_Damage,
                        Sec_DeptSection = entity.Sec_DeptSection,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Location_Id = entity.Location_Id,
                        Sub_Location_Id = entity.Sub_Location_Id,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Sec_Incident_Report>(procedure_1, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Sec_Inc_Photos != null && entity.L_Sec_Inc_Photos.Count > 0)
                        {
                            foreach (var item in entity.L_Sec_Inc_Photos)
                            {
                                var parameters_2 = new
                                {
                                    Sec_Inc_Photo_Id = item.Sec_Inc_Photo_Id,
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    Photo_File_Path = item.Photo_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Sec_Inc_Videos != null && entity.L_Sec_Inc_Videos.Count > 0)
                        {
                            foreach (var item in entity.L_Sec_Inc_Videos)
                            {
                                var parameters_3 = new
                                {
                                    Sec_Inc_Video_Id = item.Sec_Inc_Video_Id,
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    Video_File_Path = item.Video_File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters = new
                        {
                            Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                            Action_Taken = entity.Sec_Action,
                            Comments = entity.Sec_Comments,
                            Recommended = entity.Sec_Recommended,
                            CreatedBy = entity.CreatedBy
                        };
                        await connection.ExecuteAsync(procedure_4, parameters, commandType: CommandType.StoredProcedure);
                        if (entity.L_M_Sec_FollowUp_ReportedTo != null && entity.L_M_Sec_FollowUp_ReportedTo.Count > 0)
                        {
                            foreach (var item in entity.L_M_Sec_FollowUp_ReportedTo)
                            {
                                var parameters_5 = new
                                {
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    ReportedTo_Emp = item.Emp_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_M_Sec_FollowUp_AssignedTo != null && entity.L_M_Sec_FollowUp_AssignedTo.Count > 0)
                        {
                            foreach (var item in entity.L_M_Sec_FollowUp_AssignedTo)
                            {
                                var parameters_6 = new
                                {
                                    Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                                    AssignedTo_Emp = item.Emp_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_6, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters_7 = new
                        {
                            Sec_Inc_Report_Id = Obj.Sec_Inc_Report_Id,
                        };
                        await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
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
        public async Task<M_Sec_Incident_Report> View_Security_Incident(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure = "Sp_Sec_Incident_Report_GetById";
                string procedure_1 = "sp_Get_Security_Incident_Photos_byId";
                string procedure_2 = "sp_Get_Security_Incident_Video_byId";
                string procedure_3 = "sp_Sec_Incident_ActionTaken_GetbyId";
                string procedure_4 = "sp_Sec_Incident_FollowUp_GetbyId";
                string procedure_5 = "sp_Sec_Inc_FollowUp_Attach_GetbyId";
                string procedure_6 = "sp_Sec_Incident_ReportTeam_GetbyId";
                string procedure_7 = "sp_Sec_Incident_AssignTeam_GetbyId";
                string procedure_8 = "sp_Zone_Master_GetAll";
                string procedure_9 = "sp_Community_Master_GetbyId_Zone";
                string procedure_10 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure_11 = "sp_Sec_Location_Master_GetAll";
                string procedure_12 = "sp_Sec_Sub_Location_Master_GetAll";
                string procedure_13 = "sp_Sec_Sub_Category_Master_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Sec_Comman_Master_List = new Basic_Security_Master_Data();
                        Obj!.Sec_Comman_Master_List.Zone_Master_List = new List<Sec_Dropdown_Values>();
                        Obj!.Sec_Comman_Master_List.Community_Master_List = new List<Sec_Dropdown_Values>();
                        Obj!.Sec_Comman_Master_List.Building_Master_List = new List<Sec_Dropdown_Values>();
                        Obj!.Sec_Comman_Master_List.Location_Master_List = new List<Sec_Dropdown_Values>();
                        Obj!.Sec_Comman_Master_List.Sub_Location_Master_List = new List<Sec_Dropdown_Values>();
                        Obj!.Sec_Comman_Master_List.Category_Master_List = new List<Sec_Dropdown_Values>();
                        var parameters_Comm = new
                        {
                            Zone_Id = Obj.Zone_Id,
                            Community_Id = 0,
                        };
                        var parameters_Building = new
                        {
                            Zone_Id = Obj.Zone_Id,
                            Community_Id = Obj.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_9, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_10, parameters_Building, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_8, commandType: CommandType.StoredProcedure)).ToList();
                        var Location_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_11, commandType: CommandType.StoredProcedure)).ToList();
                        var Sub_Location_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_12, commandType: CommandType.StoredProcedure)).ToList();
                        var Category_Master = (await connection.QueryAsync<Sec_Dropdown_Values>(procedure_13, commandType: CommandType.StoredProcedure)).ToList();

                        if (Zone_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Community_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (Zone_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Location_Master_List = Location_Master;
                        }
                        if (Community_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Sub_Location_Master_List = Sub_Location_Master;
                        }
                        if (Building_Master != null)
                        {
                            Obj!.Sec_Comman_Master_List.Category_Master_List = Category_Master;
                        }
                        var ObjPhotos = (await connection.QueryAsync<M_Sec_Inc_Photos>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Sec_Inc_Photos = ObjPhotos;

                        var ObjVideos = (await connection.QueryAsync<M_Sec_Inc_Videos>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_Sec_Inc_Videos = ObjVideos;

                        var ObjAction = (await connection.QueryAsync<M_Sec_Incident_ActionTaken>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_M_Security_ActionTaken = ObjAction;

                        var ObjReport = (await connection.QueryAsync<M_Sec_FollowUp_AssignEmp>(procedure_6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_M_Sec_FollowUp_ReportedTo = ObjReport;
                        var ObjAssign = (await connection.QueryAsync<M_Sec_FollowUp_AssignEmp>(procedure_7, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_M_Sec_FollowUp_AssignedTo = ObjAssign;

                        var ObjFollowUp = (await connection.QueryAsync<M_Sec_Incident_FollowUpAction>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj!.L_M_Sec_Incident_FollowUp = ObjFollowUp;

                        List<M_Sec_FollowUp_Attachments> m_Sec_FollowUp_Attachments = new List<M_Sec_FollowUp_Attachments>();
                        if (Obj!.L_M_Sec_Incident_FollowUp != null && Obj!.L_M_Sec_Incident_FollowUp.Count > 0)
                        {
                            foreach (var item in Obj!.L_M_Sec_Incident_FollowUp!)
                            {
                                var paramFollowup = new
                                {
                                    FollowUp_Id = item.FollowUp_Id
                                };
                                var ObjFUAttach = (await connection.QueryAsync<M_Sec_FollowUp_Attachments>(procedure_5, paramFollowup, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                                item.L_M_Sec_FollowUp_Attachments = ObjFUAttach;
                            }
                        }
                        //var ObjFinding = (await connection.QueryAsync<M_Sec_Investigation_Find>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        //Obj!.L_Sec_Investigation_Finding = ObjFinding;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "ViewGetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Invest_Finding_Details(M_Sec_Investigation_Find_List entity)
        {
            try
            {
                string procedure1 = "sp_Sec_Investigation_Finding_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.L_Sec_Invest_Finding != null && entity.L_Sec_Invest_Finding.Count > 0)
                    {
                        foreach (var item in entity.L_Sec_Invest_Finding)
                        {
                            var parameters = new
                            {
                                Inves_Find_Id = item.Inves_Find_Id,
                                Sec_Inc_Report_Id = item.Sec_Inc_Report_Id,
                                Sec_Doc_Type = item.Sec_Doc_Type,
                                Sec_Description = item.Sec_Description,
                                Sec_File_Upload = item.Sec_File_Upload,
                                Other_Document = item.Other_Document,
                                CreatedBy = item.CreatedBy,
                            };
                            var Add_List = (await connection.QueryAsync<Ptw_Sp_Add_Evidence_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Add_Sp_Additional_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        #region [Action Taken New]
        public async Task<M_Return_Message> Security_Inc_ActionTaken_AddNew(M_Sec_Incident_ActionTaken entity)
        {
            try
            {
                string procedure1 = "sp_Sec_Incident_ActionTaken_Add";
                //string procedure_2 = "sp_Insp_FireLifeSafety_Reject_Add";
                //string procedure_3 = "sp_Insp_FireLifeSafety_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Action_Taken = entity.Action_Taken,
                        Comments = entity.Comments,
                        Recommended = entity.Recommended,
                        File_Path = entity.File_Path,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Sec_Incident_Report>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    
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
                string Repo = "Security Action Taken AddNew";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Security_Inc_FollowUpAction_Add(M_Sec_Incident_FollowUpAction entity)
        {
            try
            {
                string procedure1 = "sp_Sec_Incident_FollowUpAction_Add";
                string procedure_2 = "sp_Sec_Incident_FollowUp_Attachments_Add";
                //string procedure_3 = "sp_Insp_FireLifeSafety_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Reference_No = entity.Reference_No,
                        Action_Details = entity.Action_Details,
                        Photo_File_Path = entity.Photo_File_Path,
                        Video_File_Path = entity.Video_File_Path,
                        File_Path = entity.File_Path,
                        CreatedBy = entity.CreatedBy
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Sec_FollowUp_Attachments != null && entity.L_M_Sec_FollowUp_Attachments.Count > 0)
                        {
                            foreach (var item in entity.L_M_Sec_FollowUp_Attachments)
                            {
                                var parameters_2 = new
                                {
                                    Sec_Inc_Report_Id = item.Sec_Inc_Report_Id,
                                    FollowUp_Id = Obj.Return_1,
                                    File_Path = item.File_Path,
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
                string Repo = "Security Action Taken AddNew";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> SecurityIncActionStatus(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Sec_Incident_ActionTaken_Update";
                string procedure_2 = "sp_Security_Inc_Report_Add";
                //string procedure_3 = "sp_Insp_FireLifeSafety_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameter_1 = new
                    {
                        Action = 2,
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        //Sec_Sub_Cat_Id = entity.Sec_Sub_Cat_Id,
                        Sec_Inc_Severity = entity.Sec_Inc_Severity,
                        Sec_Inc_Complaint = entity.Sec_Inc_Complaint,
                        Sec_Inc_Method = entity.Sec_Inc_Method,
                        Zone_Id = entity.Zone_Id,
                        //Sec_Inc_Occur = entity.Sec_Inc_Occur,
                        //Sec_ReportedBy = entity.Sec_ReportedBy,
                        //Incident_Date = entity.Incident_Date,
                        //Incident_Time = entity.Incident_Time,
                        //Sec_Reported_To = entity.Sec_Reported_To,
                        //Sec_Assigned_To = entity.Sec_Assigned_To,
                        //Sec_Related_Incident = entity.Sec_Related_Incident,
                        //Sec_Escalation = entity.Sec_Escalation,
                        //Sec_Further_Action = entity.Sec_Further_Action,
                        //Sec_Inc_Status = entity.Sec_Inc_Status,
                        //Sec_Search_key = entity.Sec_Search_key,
                        //Sec_Medical_Assistance = entity.Sec_Medical_Assistance,
                        //Sec_Provider = entity.Sec_Provider,
                        //Sec_Police_Enquire = entity.Sec_Police_Enquire,
                        //Sec_Police = entity.Sec_Police,
                        //Sec_Recovery_Vechicle = entity.Sec_Recovery_Vechicle,
                        //Sec_CID = entity.Sec_CID,
                        //Sec_Ambulance = entity.Sec_Ambulance,
                        //Sec_Ambulance_no = entity.Sec_Ambulance_no,
                        //Sec_Injure_Person = entity.Sec_Injure_Person,
                        //Sec_Address = entity.Sec_Address,
                        //Sec_Approxi_Age = entity.Sec_Approxi_Age,
                        //Sec_Witnesses = entity.Sec_Witnesses,
                        //Sec_Damage = entity.Sec_Damage,
                        //Sec_Details_Damage = entity.Sec_Details_Damage,
                        //Sec_DeptSection = entity.Sec_DeptSection,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Location_Id = entity.Location_Id,
                        Sub_Location_Id = entity.Sub_Location_Id,
                        CreatedBy = entity.CreatedBy
                    };
                    var ObjUpdate = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameter_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (entity.Role_Id == "14" && entity.Recommended == "Yes")
                    { 
                    var parameters = new
                    {
                        Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                        Action_Taken = entity.Action_Taken,
                        Comments = entity.Comments,
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Status = '2'
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else
                    {
                        var parameters = new
                        {
                            Sec_Inc_Report_Id = entity.Sec_Inc_Report_Id,
                            Action_Taken = entity.Action_Taken,
                            Comments = entity.Comments,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Status = '3'
                        };
                        var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Security Action Taken Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Sec_Incident_Report>> Get_Filter_Sec_Inc_List(M_Sec_Incident_Report entity)
        {
            try
            {
                string procedure = "sp_Sec_Incident_Filter_List";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Status = entity.Status,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Sec_Inc_Category_Id = entity.Sec_Inc_Category_Id,
                        Sec_Sub_Cat_Id = entity.Sec_Sub_Cat_Id
                    };
                    return (await connection.QueryAsync<M_Sec_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Filter_Sec_Inc_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        #endregion
#pragma warning restore CS8603 // Possible null reference return.

    }
}