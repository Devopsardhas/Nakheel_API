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
    public class MitigationReport : IMitigationReport
    {
        private readonly IConfiguration configuration;

        public MitigationReport(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<M_Return_Message> AddAsync(Mitigation_Report entity)
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
                        Area = entity.Area,
                        Start_Time = entity.Start_Time,
                        End_Time = entity.End_Time,
                        Resp_Time = entity.Resp_Time,
                        Duration = entity.Duration,
                        Pumps_Deployed = entity.Pumps_Deployed,
                        Pump_OP_Duration = entity.Pump_OP_Duration,
                        Tankers_Deployed = entity.Tankers_Deployed,
                        No_Trips = entity.No_Trips,
                        Clear_Time = entity.Clear_Time,
                        Deployed_SP = entity.Deployed_SP,
                        Deployed_NCM = entity.Deployed_NCM,
                        Mitigation_Cost = entity.Mitigation_Cost,
                        Gauge_Reading = entity.Gauge_Reading,
                        Status = entity.Status,
                        Created_By = entity.Created_By,
                    };
                    procedure = "sp_Alt_Mitigation_Report_AU";
                    M_Return_Message return_Message = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (return_Message.Status_Code == "200" && entity._Files != null && entity._Files.Count() > 0)
                    {
                        var res = await Add_Files(entity._Files, return_Message.Return_1!, connection);
                    }
                    return return_Message;
                }
            }
            catch (Exception ex)
            {
                string Repo = "MitigationReport/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<M_Return_Message> DeleteAsync(Mitigation_Report entity)
        {

            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Mitigation_Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<Mitigation_Report>> GetAllAsync(Mitigation_Param entity)
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
                        From_Date = entity.From_Date,
                        To_Date = entity.To_Date,
                    };
                    procedure = "sp_Alt_Mitigation_Report_Zonewise";
                    var _Reports = (await connection.QueryAsync<Mitigation_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    return _Reports;
                }
            }
            catch (Exception ex)
            {
                string Repo = "MitigationReport/GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Mitigation_Report>();
            }
        }

        public Task<Mitigation_Report> GetByIdAsync(Mitigation_Report entity)
        {
            throw new NotImplementedException();
        }
        public async Task<Mitigation_Report> GetByIdAsync(Trigger_Param entity)
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Trigger_ID = entity.Trigger_ID,
                    };
                    procedure = "sp_Alt_Mitigation_Report_AU";
                    Mitigation_Report mitigation_ = (await connection.QueryAsync<Mitigation_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                    if (mitigation_ != null)
                    {
                        var para = new
                        {
                            Action = 2,
                            Alert_Report_Id = mitigation_.Alert_Report_Id,
                        };
                        procedure = "sp_Alt_Report_File";
                        mitigation_._Files = (await connection.QueryAsync<Report_File>(procedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                        return mitigation_;
                    }
                    else
                    {
                        return new Mitigation_Report();
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "MitigationReport/GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Mitigation_Report();
            }
        }

        public async Task<List<Dropdown_Values>> Get_All_REF_ID()
        {
            try
            {
                string procedure = "";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    procedure = "sp_Alt_Mitigation_Report_Zonewise";
                    var _Reports = (await connection.QueryAsync<Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    return _Reports;
                }
            }
            catch (Exception ex)
            {
                string Repo = "MitigationReport/Get_All_REF_ID";
                ErrorLog.ErrorLogs(ex, Repo);
                return new List<Dropdown_Values>();
            }
        }

        public Task<M_Return_Message> UpdateAsync(Mitigation_Report entity)
        {
            throw new NotImplementedException();
        }

        private async Task<M_Return_Message> Add_Files(List<Report_File> entity, string Alert_Report_Id, SqlConnection connection)
        {
            try
            {
                string procedure = "sp_Alt_Report_File";
                var ImpActParam = entity.Select(action => new
                {
                    Action = 1,
                    Alert_Report_Id = Alert_Report_Id,
                    File_Path = action.File_Path
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
    }
}
