using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class EmergencyAlert : IEmergencyAlert
    {
        private readonly IConfiguration configuration;

        public EmergencyAlert(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<IReadOnlyList<EMR_Alert>> Alert_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
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
                string procedure = "sp_ALT_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<EMR_Alert>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<EMR_Alert>();
            }
        }
        public async Task<M_Return_Message> AddAsync(EMR_Alert entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Sub_Building_Id = entity.Sub_Building_Id,
                        Mitigation_Type = entity.Mitigation_Type,
                        Status = entity.Status,
                        Created_By = entity.Created_By,
                    };
                    procedure = "sp_Alt_M_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (return_Message.Status_Code == "200")
                    {
                        if (entity._Spots != null && entity._Spots.Count > 0)
                        {
                            var R1 = await Add_Spots(entity._Spots, return_Message.Return_1!, connection);
                        }

                    }

                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Return_Message> DeleteAsync(EMR_Alert entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<EMR_Alert>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EMR_Alert> GetByIdAsync(EMR_Alert entity)
        {
            throw new NotImplementedException();
        }
        public async Task<EMR_Alert> Alert_GetById(Drill_Alert_Param entity)
        {
            try
            {
                string procedure = "";
                Get_All_DrillSCH _All_DrillSCH = new Get_All_DrillSCH();
                _All_DrillSCH.Access = new List<Dropdown_Values>();
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        EMR_Alert_ID = entity.EMR_Alert_ID
                    };
                    procedure = "sp_Alt_M_AU";
                    EMR_Alert eMR_ = (await connection.QueryAsync<EMR_Alert>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (eMR_ != null)
                    {
                        procedure = "sp_Alt_SPOT_AU";
                        eMR_._Spots = (await connection.QueryAsync<Alert_Spot> (procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                        procedure = "sp_Alt_REJ_AU";
                        eMR_.Reject = (await connection.QueryAsync<EMR_Reject> (procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!; 
                        return eMR_;
                    }
                    else
                    {
                        return new EMR_Alert();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                return new EMR_Alert();
            }
        }

        public Task<M_Return_Message> UpdateAsync(EMR_Alert entity)
        {
            throw new NotImplementedException();
        }

        private async Task<M_Return_Message> Add_Spots(List<Alert_Spot> entity, string Alert_ID, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_Alt_SPOT_AU";
                var ImpActParam = entity.Select(action => new
                {
                    Action = 1,
                    EMR_Alert_ID = Alert_ID,
                    Address = action.Address,
                    Exact_Loc = action.Exact_Loc,
                    Latitude = action.Latitude,
                    Longitude = action.Longitude,
                    Status = action.Status,
                    Created_By = action.Created_By,
                    Reason = action.Reason,
                    Service_Provider = action.Service_Provider
                }).ToList();
                var res = await connection.ExecuteAsync(procedure, ImpActParam, commandType: CommandType.StoredProcedure);
                return new M_Return_Message()
                {
                    Status_Code = "200",
                    Status = true,
                    Message = "Success"
                };

            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Add_Spots";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }
        #region Spot
        public async Task<M_Return_Message> Alert_Spot_Delete(Drill_Alert_Param entity)
        {
            try
            {

                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Hot_Spot_Id = entity.EMR_Alert_ID,
                    };
                    procedure = "sp_Alt_SPOT_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_Spot_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<List<Alert_Spot>> Alert_Spot_GetBy_Mitig_ID(Drill_Alert_Param entity)
        {
            try
            {
                string procedure = "sp_Alt_SPOT_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Is_Active = entity.Building_ID,
                        Remarks = entity.Mitigation_ID,
                        Created_By = entity.Created_By,
                    };
                    return (await connection.QueryAsync<Alert_Spot>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_Spot_GetBy_Mitig_ID";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Alert_Spot>();
            }
        }


        #endregion

        #region Reject 
        public async Task<M_Return_Message> Alert_Spot_Reject_Add(EMR_Reject entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Alert_Rej_Id = entity.Alert_Rej_Id,
                        EMR_Alert_ID = entity.EMR_Alert_ID,
                        Reason = entity.Reason,
                        Rejected_By = entity.Rejected_By,
                        Hot_Spot_Id = entity.Hot_Spot_Id,
                    };
                    procedure = "sp_Alt_REJ_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_Spot_Reject_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
           
        }
        public async Task<M_Return_Message> Alert_Spot_Approve_Add(EMR_Reject entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Alert_Rej_Id = entity.Alert_Rej_Id,
                        EMR_Alert_ID = entity.EMR_Alert_ID,
                        Hot_Spot_Id = entity.Hot_Spot_Id,
                        Rejected_By = entity.Rejected_By,
                    };
                    procedure = "sp_Alt_REJ_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_Spot_Reject_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }

        #endregion

        #region Emergency Checklist 
        public async Task<IReadOnlyList<EMR_Alert_CHK>> Alert_CHK_GetAll()
        {
            try
            {
                string procedure = "sp_Alt_M_Checklist";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<EMR_Alert_CHK>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_CHK_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Alert_CHK_Add(List<EMR_Alert_CHK> entity)
        {
            try
            {
                string procedure = "sp_Alt_M_Checklist";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Param = entity.Select(action => new
                    {
                        Action = 1,
                        Alert_Checklist_Id = action.Alert_Checklist_Id,
                        Mitigation_Type = action.Mitigation_Type,
                        Check_List = action.Check_List,
                        Created_By = action.Created_By,
                    }).ToList();
                    var res = await connection.ExecuteAsync(procedure, Param, commandType: CommandType.StoredProcedure);
                    return new M_Return_Message()
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Add_Spots";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }

        public async Task<List<EMR_Alert_CHK>> Alert_CHK_GetByID(EMR_Alert_CHK entity)
        {
            try
            {
                string procedure = "sp_Alt_M_Checklist";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Mitigation_Type = entity.Mitigation_Type,
                    };
                    return (await connection.QueryAsync<EMR_Alert_CHK>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "EmergencyAlert/Alert_CHK_GetByID";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Alert_CHK_Delete(EMR_Alert_CHK entity)
        {
            try
            {
                string procedure = "sp_Alt_M_Checklist";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Alert_Checklist_Id = entity.Alert_Checklist_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Cat_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
    }
}
