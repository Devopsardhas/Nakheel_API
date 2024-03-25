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
using System.Xml;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AlertTrigger : IAlertTrigger
    {
        private readonly IConfiguration configuration;

        public AlertTrigger(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public async Task<IReadOnlyList<Trigger>> AlertTRG_GetAll(DataTableAjaxPostModel entity)
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
                string procedure = "sp_Alt_Trig_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Trigger>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/AlertTRG_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Trigger>();
            }
        }

        public async Task<M_Return_Message> AddAsync(Trigger entity)
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
                        Mitigation_Id = entity.Mitigation_Id,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_Alt_TRIG";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(List<Trigger> entity)
        {
            try
            {
                string procedure = "sp_Alt_TRIG";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity != null && entity.Count > 0)
                    {
                        var parameters = new
                        {
                            Action = 4,
                        };
                        var R1 = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                        var Param = entity.Select(action => new
                        {
                            Action = 1,
                            Zone_Id = action.Zone_Id,
                            Mitigation_Id = action.Mitigation_Id,
                            Created_By = action.Created_By,
                            Remarks = R1.Message
                        }).ToList();
                        var res = await connection.ExecuteAsync(procedure, Param, commandType: CommandType.StoredProcedure);
                        return new M_Return_Message()
                        {
                            Status_Code = "200",
                            Status = true,
                            Message = "Success"
                        };
                    }
                    else
                    {
                        return new M_Return_Message()
                        {
                            Status_Code = "500"
                        };
                    }

                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public Task<M_Return_Message> DeleteAsync(Trigger entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Trigger>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Trigger> GetByIdAsync(Trigger entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(Trigger entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Trigger> GetByIdAsync(Trigger_Param entity)
        {
            try
            {
                string procedure = "";
                Trigger _Trigger = new Trigger();
                _Trigger._Building_Lists = new List<TRG_Building_List>();
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Trigger_ID = entity.Trigger_ID
                    };
                    procedure = "sp_Alt_TRIG";
                    _Trigger = (await connection.QueryAsync<Trigger>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (_Trigger != null)
                    {
                        var param = new
                        {
                            Action = 3,
                            Trigger_ID = entity.Trigger_ID
                        };
                        _Trigger._Building_Lists = (await connection.QueryAsync<TRG_Building_List>(procedure, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                        return _Trigger;
                    }
                    else
                    {
                        return new Trigger();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Trigger();
            }
        }

        public async Task<Drill_Sch_Assignee> Get_Mitigation_Assignee(Trigger_Param entity)
        {
            try
            {
                string procedure = "sp_Mitigation_Assignees";
                Drill_Sch_Assignee sch_Assignee = new Drill_Sch_Assignee()
                {
                    ServiceProviders = new List<Dropdown_Values>(),
                    Commanders = new List<Dropdown_Values>(),
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    async Task<List<Dropdown_Values>> ExecuteAssigneeProcedureAsync(string Act)
                    {
                        var para = new
                        {
                            Action = Act,
                            Sub_Building_Id = entity.Sub_Building_Id,
                            Created_By = "1",
                        };
                        return (await connection.QueryAsync<Dropdown_Values>(procedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }
                    sch_Assignee.ServiceProviders = await ExecuteAssigneeProcedureAsync("1");
                    return sch_Assignee;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Schedule_Get_Assignee";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Drill_Sch_Assignee();
            }
        }

        #region Assignee

        public async Task<IReadOnlyList<TRIG_Assignee>> Alert_Assignee_GetAll(DataTableAjaxPostModel entity)
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
                string procedure = "sp_ALT_Assignee_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<TRIG_Assignee>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Alert_Assignee_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<TRIG_Assignee>();
            }
        }
        public async Task<M_Return_Message> Add_Assignee(TRIG_Assignee entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Trigger_ID = entity.Trigger_ID,
                        Sub_Building_Id = entity.Sub_Building_Id,
                        Service_Provider = entity.Service_Provider,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_Alt_TRIG_Assignee";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Add_Assignee";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Trigger> Alert_Act_GetById(Trigger_Param entity)
        {
            try
            {
                string procedure = "";
                Trigger _Trigger = new Trigger();
                _Trigger._Building_Lists = new List<TRG_Building_List>();
                _Trigger.ChecklistMaps = new List<ChecklistMap>();

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    async Task<List<T>> GetDataAsync<T>(string storedProcedure, int act)
                    {
                        var para = new
                        {
                            Action = act,
                            Alert_Task_Id = entity.Alert_Task_Id
                        };
                        return (await connection.QueryAsync<T>(storedProcedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }
                    var parameters = new
                    {
                        Action = 2,
                        Trigger_ID = "0",
                        Unique_ID = entity.Alert_Task_Id
                    };
                    procedure = "sp_Alt_TRIG";
                    _Trigger = (await connection.QueryAsync<Trigger>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (_Trigger != null)
                    {
                        //_Trigger.ChecklistMaps = await GetDataAsync<ChecklistMap>("sp_Alt_TRIG_Assignee", 2);
                        _Trigger._Spots = await GetDataAsync<Alert_Spot>("sp_Alt_TRIG_Assignee", 3);
                        _Trigger._Reject = await GetDataAsync<TRIG_Reject>("sp_Alt_TRIG_REJ_AU", 2);
                        return _Trigger;
                    }
                    else
                    {
                        return new Trigger();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Alert_Act_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Trigger();
            }
        }
        public async Task<M_Return_Message> Add_Assignee_Checklist(ChecklistMap entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Hot_Spot_Id = entity.Hot_Spot_Id,
                        Alert_Checklist_Id = entity.Alert_Checklist_Id,
                        Alert_Task_Id = entity.Alert_Task_Id,
                        Action_Taken = entity.Action_Taken,
                        File_Path = entity.File_Path,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_Alt_TRIG_Check_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Add_Assignee_Checklist";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Assignee_Checklist(ChecklistMap entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Chk_Map_Id = entity.Chk_Map_Id,
                        Action_Taken = entity.Action_Taken,
                        File_Path = entity.File_Path,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_Alt_TRIG_Check_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Update_Assignee_Checklist";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Checklist_Status(Trigger_Param entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Alert_Task_Id = entity.Alert_Task_Id,
                        Hot_Spot_Id = entity.Hot_Spot_Id,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_Alt_TRIG_Check_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Update_Checklist_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<List<ChecklistMap>> Checklist_GetBy_SpotId(Trigger_Param entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Alert_Task_Id = entity.Alert_Task_Id,
                        Hot_Spot_Id = entity.Hot_Spot_Id
                    };
                    procedure = "sp_Alt_TRIG_Assignee";
                    List<ChecklistMap> checklistMaps = (await connection.QueryAsync<ChecklistMap>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    if (checklistMaps != null && checklistMaps.Count > 0)
                    {
                        return checklistMaps;
                    }
                    else
                    {
                        return new List<ChecklistMap>();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Checklist_GetBy_SpotId";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<ChecklistMap>();
            }
        }

        public async Task<List<Dropdown_Values>> Get_All_Emergency_Type()
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    procedure = "sp_Alt_Mitigation_Type";
                    List<Dropdown_Values> checklistMaps = (await connection.QueryAsync<Dropdown_Values>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    if (checklistMaps != null && checklistMaps.Count > 0)
                    {
                        return checklistMaps;
                    }
                    else
                    {
                        return new List<Dropdown_Values>();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Get_All_Emergency_Type";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Dropdown_Values>();
            }
        }
        #endregion

        #region Reject
        public async Task<M_Return_Message> Alert_Trig_Reject(TRIG_Reject entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Alert_Task_Id = entity.Alert_Task_Id,
                        Trigger_ID = entity.Trigger_ID,
                        Reason = entity.Reason,
                        Rejected_By = entity.Rejected_By,
                    };
                    procedure = "sp_Alt_TRIG_REJ_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Alert_Trig_Reject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }

        public async Task<M_Return_Message> Alert_Trig_Rej_Update(TRIG_Reject entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Alert_Task_Id = entity.Alert_Task_Id,
                        Trigger_ID = entity.Trigger_ID,
                    };
                    procedure = "sp_Alt_TRIG_REJ_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "AlertTrigger/Alert_Trig_Rej_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion
    }
}
