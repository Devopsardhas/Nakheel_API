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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class DrillSchedule : IDrillSchedule
    {
        private readonly IConfiguration configuration;

        public DrillSchedule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<M_Return_Message> AddAsync(Drill_Schedule entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> DeleteAsync(Drill_Schedule entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<Drill_Schedule>> Drill_Schedule_GetAll(DataTableAjaxPostModel entity)
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
                    Card_Id = entity.Card_Id
                };
                string procedure = "sp_EMR_Drill_SCH_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Drill_Schedule>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Schedule_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Drill_Schedule>();
            }
        }
        #region Fire
        public async Task<M_Return_Message> Drill_Sch_Add_Fire(Drill_Fire entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Fire_Drill_ID = entity.Fire_Drill_ID,
                        Weather_Condition = entity.Weather_Condition,
                        Start_Time = entity.Start_Time,
                        End_Time = entity.End_Time,
                        LP_Reporting = entity.LP_Reporting,
                        PLP_Reporting = entity.PLP_Reporting,
                        Total_Participants = entity.Total_Participants,
                        Assembly_Point = entity.Assembly_Point,
                        Total_FW = entity.Total_FW,
                        TT_Evacuation = entity.TT_Evacuation,
                        Extinguish_Fire = entity.Extinguish_Fire,
                        Smoke_Mgmt = entity.Smoke_Mgmt,
                        ERT_Mgmt = entity.ERT_Mgmt,
                        Rating = entity.Rating,
                        Drill_Comments = entity.Drill_Comments,
                        Created_By = entity.Created_By,
                    };
                    procedure = "sp_EMR_Drill_Fire_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (return_Message.Status_Code == "200")
                    {
                        if (entity._Acts != null && entity._Acts.Count > 0)
                        {
                            var R1 = await Drill_Sch_Add_ImprovementAct(entity._Acts, entity.Drill_Schedule_ID!, "1", connection);
                        }
                        if (entity.Drill_Photos != null && entity.Drill_Photos.Count > 0)
                        {
                            var R2 = await Drill_Sch_Add_DrillPhotos(entity.Drill_Photos, entity.Drill_Schedule_ID!, "1", connection);
                        }
                    }


                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Add_Fire";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Drill_Sch_Add_Fire_Obsr(Drill_Fire_Obsr entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Fire_Drill_OBS_ID = entity.Fire_Drill_OBS_ID,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        First_Sound = entity.First_Sound,
                        First_Occupant = entity.First_Occupant,
                        Last_Occupant = entity.Last_Occupant,
                        Ocuupant_Nature = entity.Ocuupant_Nature,
                        Life_Safety_Equip = entity.Life_Safety_Equip,
                        Lift_Status = entity.Lift_Status,
                        Pantry_Status = entity.Pantry_Status,
                        Evac_Process = entity.Evac_Process,
                        Status = entity.Status,
                        Created_By = entity.Created_By,
                    };
                    procedure = "sp_EMR_Drill_Fire_Obsr_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (return_Message.Status_Code == "200")
                    {
                        if (entity._Acts != null && entity._Acts.Count > 0)
                        {
                            var R1 = await Drill_Sch_Add_ImprovementAct(entity._Acts, entity.Drill_Schedule_ID!, "2", connection);
                        }
                        if (entity.Drill_Photos != null && entity.Drill_Photos.Count > 0)
                        {
                            var R2 = await Drill_Sch_Add_DrillPhotos(entity.Drill_Photos, entity.Drill_Schedule_ID!, "2", connection);
                        }
                        if (entity.Drill_Vedios != null && entity.Drill_Vedios.Count > 0)
                        {
                            var R2 = await Drill_Sch_Add_DrillVideo(entity.Drill_Vedios, entity.Drill_Schedule_ID!, "2", connection);
                        }
                    }

                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Add_Fire";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        private async Task<M_Return_Message> Drill_Sch_Add_ImprovementAct(List<Improvement_Act> entity, string Drill_ID, string Rmk, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_EMR_Drill_ImpAct_AU";
                var ImpActParam = entity.Select(action => new
                {
                    Action = 1,
                    Drill_Schedule_ID = Drill_ID,
                    Drill_CRR_ID = action.Drill_CRR_ID,
                    Action_Des = action.Action_Des,
                    Assignee_Id = action.Assignee_Id,
                    Target_Date = action.Target_Date,
                    Created_By = action.Created_By,
                    Corrective_Action = action.Corrective_Action,
                    Photo_Path = action.Photo_Path,
                    Remarks = Rmk,
                    Close_On_Spot = action.Close_On_Spot,
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
                string Repo = "DrillSchedule/Drill_Sch_Add_Fire_Obsr";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }
        private async Task<M_Return_Message> Drill_Sch_Update_ImprovementAct(List<Improvement_Act> entity, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_EMR_Drill_ImpAct_AU";
                var ImpActParam = entity.Select(action => new
                {
                    Action = 3,
                    Drill_CRR_ID = action.Drill_CRR_ID,
                    Assignee_Id = action.Assignee_Id,
                    Assign_Type = action.Assign_Type,
                    Target_Date = action.Target_Date,
                    Created_By = action.Created_By,
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
                string Repo = "DrillSchedule/Drill_Sch_Update_ImprovementAct";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }
        private async Task<M_Return_Message> Drill_Sch_Add_DrillPhotos(List<Drill_Photos> entity, string Drill_ID, string Rmk, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Photo_AU";
                var PhotoParam = entity.Select(photo => new
                {
                    Action = 1,
                    Drill_Photo_Id = photo.Drill_Photo_Id,
                    Drill_Schedule_ID = Drill_ID,
                    Photo_File_Name = photo.Photo_File_Name,
                    Photo_File_Path = photo.Photo_File_Path,
                    Photo_File_Size = photo.Photo_File_Size,
                    Photo_File_Type = photo.Photo_File_Type,
                    Created_By = photo.Created_By,
                    Remarks = Rmk,
                }).ToList();
                var res = await connection.ExecuteAsync(procedure, PhotoParam, commandType: CommandType.StoredProcedure);
                return new M_Return_Message()
                {
                    Status_Code = "200",
                    Status = true,
                    Message = "Success"
                };

            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Add_DrillPhotos";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }

        private async Task<M_Return_Message> Drill_Sch_Add_DrillVideo(List<Drill_Videos> entity, string Drill_ID, string Rmk, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Video_AU";

                var PhotoParam = entity.Select(photo => new
                {
                    Action = 1,
                    Drill_Video_Id = photo.Drill_Photo_Id,
                    Drill_Schedule_ID = Drill_ID,
                    Video_File_Name = photo.Video_File_Name,
                    Video_File_Path = photo.Video_File_Path,
                    Video_File_Size = photo.Video_File_Size,
                    Video_File_Type = photo.Video_File_Type,
                    Created_By = photo.Created_By,
                    Remarks = Rmk,
                }).ToList();
                var res = await connection.ExecuteAsync(procedure, PhotoParam, commandType: CommandType.StoredProcedure);
                return new M_Return_Message()
                {
                    Status_Code = "200",
                    Status = true,
                    Message = "Success"
                };

            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Add_DrillPhotos";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message()
                {
                    Status_Code = "400",
                    Status = false,
                    Message = "Failed"
                };
            }
        }
        #endregion

        #region Common Forms
        public async Task<M_Return_Message> Drill_Sch_Add_Cm_Drill(Drill_CommonFRM entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Dril_Loc = entity.Dril_Loc,
                        Rating = entity.Rating,
                        ERT = entity.ERT,
                        Security_Res = entity.Security_Res,
                        Drill_Comments = entity.Drill_Comments,
                        Common_Ques = entity.Common_Ques,
                        Created_By = entity.Created_By,
                        Common_ID = entity.Common_ID,
                    };
                    switch (entity.Drill_Type_ID)
                    {
                        case "1":
                            procedure = "sp_EMR_Drill_Drowning_AU";
                            break;
                        case "2":
                            procedure = "sp_EMR_Drill_Elevator_AU";
                            break;
                        case "3":
                            procedure = "sp_EMR_Drill_Spill_Ctrl_AU";
                            break;
                        default:
                            break;
                    }
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (return_Message.Status_Code == "200" && entity._Acts != null && entity._Acts.Count > 0)
                    {
                        M_Return_Message m_Return_ = await Drill_Sch_Add_ImprovementAct(entity._Acts, entity.Drill_Schedule_ID!, "2", connection);
                    }
                    if (return_Message.Status_Code == "200" && entity.Drill_Photos != null && entity.Drill_Photos.Count > 0)
                    {
                        var R2 = await Drill_Sch_Add_DrillPhotos(entity.Drill_Photos, entity.Drill_Schedule_ID!, "1", connection);
                    }
                    if (entity.Drill_Vedios != null && entity.Drill_Vedios.Count > 0)
                    {
                        var R2 = await Drill_Sch_Add_DrillVideo(entity.Drill_Vedios, entity.Drill_Schedule_ID!, "1", connection);
                    }
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Add_Cm_Drill";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion
        public async Task<Drill_Sch_Assignee> Drill_Sch_Get_Assignee(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Assignees";
                Drill_Sch_Assignee sch_Assignee = new Drill_Sch_Assignee()
                {
                    ServiceProviders = new List<Dropdown_Values>(),
                    Commanders = new List<Dropdown_Values>()
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
                            Drill_Schedule_ID = entity.Drill_Schedule_ID,
                            Created_By = entity.Created_By,
                        };
                        return (await connection.QueryAsync<Dropdown_Values>(procedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }
                    sch_Assignee.ServiceProviders = await ExecuteAssigneeProcedureAsync("1");
                    sch_Assignee.Commanders = await ExecuteAssigneeProcedureAsync("2");
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

        public async Task<Get_All_DrillSCH> Drill_Sch_Get_Details(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "";
                Get_All_DrillSCH _All_DrillSCH = new Get_All_DrillSCH();
                _All_DrillSCH.Access = new List<Dropdown_Values>();
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    async Task<List<T>> GetDataAsync<T>(string storedProcedure, string remarks, int act)
                    {
                        var para = new
                        {
                            Action = act,
                            Drill_Schedule_ID = entity.Drill_Schedule_ID,
                            Remarks = remarks,
                        };
                        return (await connection.QueryAsync<T>(storedProcedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }

                    Drill_Schedule schedule = new Drill_Schedule()
                    {
                        Drill_Schedule_ID = entity.Drill_Schedule_ID
                    };
                    var parameters = new
                    {
                        Action = 2,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID
                    };

                    _All_DrillSCH.Schedule = await GetByIdAsync(schedule);
                    int status = Convert.ToInt16(_All_DrillSCH.Schedule.Status);

                    _All_DrillSCH.Access = (await connection.QueryAsync<Dropdown_Values>("sp_EMR_Drill_Access", parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!; ;


                    if (_All_DrillSCH.Schedule != null && status >= 2)
                    {

                        if (_All_DrillSCH.Schedule.Drill_Type_ID == "4")
                        {
                            procedure = "sp_EMR_Drill_Fire_AU";
                            _All_DrillSCH._Fire = (await connection.QueryAsync<Drill_Fire>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                            procedure = "sp_EMR_Drill_Fire_Obsr_AU";
                            _All_DrillSCH.Drill_Obsr = (await connection.QueryAsync<Drill_Fire_Obsr>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                            int FireST = Convert.ToInt16(_All_DrillSCH._Fire.Status);
                            int FireObsST = Convert.ToInt16(_All_DrillSCH.Drill_Obsr.Status);
                            if (FireST > 1)
                            {
                                _All_DrillSCH._Fire.Drill_Photos = await GetDataAsync<Drill_Photos>("sp_EMR_Drill_Photo_AU", "1", 2);
                                _All_DrillSCH._Fire.Drill_Vedios = await GetDataAsync<Drill_Videos>("sp_EMR_Drill_Video_AU", "1", 2);
                            }
                            if (FireObsST > 1)
                            {

                                _All_DrillSCH.Drill_Obsr.Drill_Photos = await GetDataAsync<Drill_Photos>("sp_EMR_Drill_Photo_AU", "2", 2);
                                _All_DrillSCH.Drill_Obsr.Drill_Vedios = await GetDataAsync<Drill_Videos>("sp_EMR_Drill_Video_AU", "2", 2);
                            }

                            if (FireST > 1 && (status == 2 || status == 3))
                            {
                                _All_DrillSCH._Fire._Acts = await GetDataAsync<Improvement_Act>("sp_EMR_Drill_ImpAct_AU", "1", 2);

                            }
                            if (FireObsST > 1 && (status == 2 || status == 3))
                            {
                                _All_DrillSCH.Drill_Obsr._Acts = await GetDataAsync<Improvement_Act>("sp_EMR_Drill_ImpAct_AU", "2", 2);

                            }
                        }
                        else
                        {
                            procedure = "sp_EMR_Drill_GetCommon_Frm";
                            _All_DrillSCH.Drill_Common = (await connection.QueryAsync<Drill_CommonFRM>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                            int CMMT = Convert.ToInt16(_All_DrillSCH.Drill_Common!.Status!);
                            if (CMMT > 1)
                            {
                                _All_DrillSCH.Drill_Common.Drill_Photos = await GetDataAsync<Drill_Photos>("sp_EMR_Drill_Photo_AU", "1", 2);
                                _All_DrillSCH.Drill_Common.Drill_Vedios = await GetDataAsync<Drill_Videos>("sp_EMR_Drill_Video_AU", "1", 2);
                            }
                            if (CMMT > 1 && (status == 2 || status == 3))
                            {
                                _All_DrillSCH.Drill_Common._Acts = await GetDataAsync<Improvement_Act>("sp_EMR_Drill_ImpAct_AU", "2", 2);
                            }
                        }
                        if (status >= 4)
                        {
                            _All_DrillSCH.TotalActions = await GetDataAsync<Improvement_Act>("sp_EMR_Drill_ImpAct_AU", "0", 2);
                        }
                        if (status == 6 || status == 7)
                        {
                            _All_DrillSCH.HseTeam = await GetDataAsync<Dropdown_Values>("sp_EMR_Drill_Get_EMP_RW", "0", 1);
                            _All_DrillSCH.ServiceProvider = await GetDataAsync<Dropdown_Values>("sp_EMR_Drill_Get_EMP_RW", "0", 2);
                        }
                        _All_DrillSCH.Histories = await GetDataAsync<Appr_History>("sp_EMR_Drill_History", "0", 2);
                        _All_DrillSCH.Rej = await GetDataAsync<Drill_REJ>("sp_EMR_Drill_Rej_AU", "0", 2);
                        return _All_DrillSCH;
                    }
                    else
                    {
                        return new Get_All_DrillSCH();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Get_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Get_All_DrillSCH();
            }
        }

        private async Task<List<Dropdown_Values>> GetDrillAccess(string Access, string Drill_ID)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Access";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Drill_Schedule_ID = Drill_ID,
                        Remarks = Access
                    };
                    return (await connection.QueryAsync<Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/GetDrillAccess";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Dropdown_Values>();
            }

        }

        public Task<IReadOnlyList<Drill_Schedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Drill_Schedule> GetByIdAsync(Drill_Schedule entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Schedule_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                    };
                    return (await connection.QueryAsync<Drill_Schedule>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Drill_Schedule();
            }
        }

        public async Task<M_Return_Message> UpdateAsync(Drill_Schedule entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Schedule_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Commander = entity.Commander,
                        Service_Provider = entity.Service_Provider,
                        Created_By = entity.Created_By,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public async Task<M_Return_Message> Drill_Sch_Update_Status(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Schedule_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Created_By = entity.Created_By,
                        Status = entity.Status,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Update_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public async Task<M_Return_Message> Drill_Sch_Update_Action(Drill_Action_Param entity)
        {
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity._Acts != null && entity._Acts.Count > 0)
                    {
                        var R1 = await Drill_Sch_Add_ImprovementAct(entity._Acts, entity.Drill_Schedule_ID!, "3", connection);
                    }
                    Drill_Schedule_Param drill_Schedule = new Drill_Schedule_Param()
                    {
                        Created_By = entity.Created_By,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Status = entity.Status,
                    };
                    M_Return_Message status = await Drill_Sch_Update_Status(drill_Schedule);
                    return status;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Update_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public async Task<M_Return_Message> Drill_Sch_Update_IMP_Act(Drill_Action_Param entity)
        {
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    M_Return_Message status = new M_Return_Message();
                    if (entity._Acts != null && entity._Acts.Count > 0)
                    {
                        var R1 = await Drill_Sch_Update_ImprovementAct(entity._Acts, connection);
                    }
                    Drill_Schedule_Param drill_Schedule = new Drill_Schedule_Param()
                    {
                        Created_By = entity.Created_By,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Status = entity.Status,
                    };
                    status = await Drill_Sch_Update_Status(drill_Schedule);
                    return status;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Update_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }
        #region Drill Action
        public async Task<IReadOnlyList<Drill_Schedule>> Drill_Action_GetAll(DataTableAjaxPostModel entity)
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
                string procedure = "sp_EMR_Drill_Action_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Drill_Schedule>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Action_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Drill_Schedule>();
            }
        }

        public async Task<Get_All_DrillSCH> Drill_Sch_Get_Actions(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "";
                Get_All_DrillSCH _All_DrillSCH = new Get_All_DrillSCH();
                _All_DrillSCH.Access = new List<Dropdown_Values>();
                _All_DrillSCH.ServiceProvider = new List<Dropdown_Values>();
                _All_DrillSCH.HseTeam = new List<Dropdown_Values>();
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    async Task<List<T>> GetDataAsync<T>(string storedProcedure, string remarks, int act)
                    {
                        var para = new
                        {
                            Action = act,
                            Drill_Schedule_ID = entity.Drill_Schedule_ID,
                            Remarks = remarks,
                        };
                        return (await connection.QueryAsync<T>(storedProcedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }

                    Drill_Schedule schedule = new Drill_Schedule()
                    {
                        Drill_Schedule_ID = entity.Drill_Schedule_ID
                    };
                    var parameters = new
                    {
                        Action = 2,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID
                    };

                    _All_DrillSCH.Schedule = await GetByIdAsync(schedule);

                    if (_All_DrillSCH.Schedule.Drill_Type_ID == "4")
                    {
                        procedure = "sp_EMR_Drill_Fire_AU";
                        _All_DrillSCH._Fire = (await connection.QueryAsync<Drill_Fire>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                        procedure = "sp_EMR_Drill_Fire_Obsr_AU";
                        _All_DrillSCH.Drill_Obsr = (await connection.QueryAsync<Drill_Fire_Obsr>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;

                        _All_DrillSCH._Fire.Drill_Photos = new List<Drill_Photos>();
                        _All_DrillSCH._Fire.Drill_Vedios = new List<Drill_Videos>();
                        _All_DrillSCH._Fire._Acts = new List<Improvement_Act>();

                        _All_DrillSCH.Drill_Obsr.Drill_Photos = new List<Drill_Photos>();
                        _All_DrillSCH.Drill_Obsr.Drill_Vedios = new List<Drill_Videos>();
                        _All_DrillSCH.Drill_Obsr._Acts = new List<Improvement_Act>();

                    }
                    else
                    {
                        procedure = "sp_EMR_Drill_GetCommon_Frm";
                        _All_DrillSCH.Drill_Common = (await connection.QueryAsync<Drill_CommonFRM>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;

                        _All_DrillSCH.Drill_Common.Drill_Photos = await GetDataAsync<Drill_Photos>("sp_EMR_Drill_Photo_AU", "1", 2);
                        _All_DrillSCH.Drill_Common.Drill_Vedios = await GetDataAsync<Drill_Videos>("sp_EMR_Drill_Video_AU", "1", 2);
                        _All_DrillSCH.Drill_Common._Acts = new List<Improvement_Act>();
                    }
                    _All_DrillSCH.TotalActions = await GetDataAsync<Improvement_Act>("sp_EMR_Drill_ImpAct_AU", entity.Created_By!, 4);
                    _All_DrillSCH.HseTeam = await GetDataAsync<Dropdown_Values>("sp_EMR_Drill_Get_EMP_RW", "0", 1);
                    return _All_DrillSCH;

                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Drill_Sch_Get_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Get_All_DrillSCH();
            }
        }

        public async Task<M_Return_Message> Drill_Sch_Add_Closure(Improvement_Act entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_ImpAct_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Drill_CRR_ID = entity.Drill_CRR_ID,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Corrective_Action = entity.Corrective_Action,
                        Photo_Path = entity.Photo_Path,
                        Created_By = entity.Created_By,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }
        #endregion

        #region Reject
        public async Task<M_Return_Message> Update_Reject_Status(Drill_REJ entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Drill_Schedule_ID = entity.Drill_Schedule_ID,
                        Reject_Reason = entity.Reject_Reason,
                        Drill_CRR_ID = entity.Drill_CRR_ID,
                        CreatedBy = entity.Reject_By
                    };
                    procedure = "sp_EMR_Drill_Rej_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Update_Reject_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Photo_Status(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Drill_Photo_Id = entity.Drill_Schedule_ID,
                        Created_By = entity.Created_By
                    };
                    procedure = "sp_EMR_Drill_Photo_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Update_Photo_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Video_Status(Drill_Schedule_Param entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Drill_Photo_Id = entity.Drill_Schedule_ID,
                        CreatedBy = entity.Created_By
                    };
                    procedure = "sp_EMR_Drill_Video_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Update_Photo_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Reassign_Status(Improvement_Act entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                        Drill_CRR_ID = entity.Drill_CRR_ID,
                        Assignee_Id = entity.Assignee_Id
                    };
                    procedure = "sp_EMR_Drill_ImpAct_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillSchedule/Update_Reject_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

    }
}
