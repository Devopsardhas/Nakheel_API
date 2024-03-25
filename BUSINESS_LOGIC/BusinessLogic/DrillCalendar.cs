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
    public class DrillCalendar : IDrillCalendar
    {
        private readonly IConfiguration configuration;

        public DrillCalendar(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<M_Return_Message> AddAsync(Drill_Calendar entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Calendar_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Sub_Building_Id = entity.Sub_Building_Id,
                        Initial_Date = entity.Initial_Date,
                        Frequency = entity.Frequency,
                        HSE_Officer = entity.HSE_Officer,
                        Commander = entity.Commander,
                        Service_Provider = entity.Service_Provider,
                        Drill_Type_ID = entity.Drill_Type_ID,
                        Created_By = entity.Created_By,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillCalendar/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public async Task<M_Return_Message> DeleteAsync(Drill_Calendar entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Calendar_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Drill_Calendar_ID = entity.Drill_Calendar_ID,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillCalendar/DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public Task<IReadOnlyList<Drill_Calendar>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Get_Drill_Calendar> GetAllAsync(Drill_Calendar_Param _Param)
        {
            try
            {
                Get_Drill_Calendar drill_Calendar = new Get_Drill_Calendar();
                string procedure = "sp_EMR_Drill_Calendar";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Zone_Id=_Param.Zone_Id,
                        Community_Id = _Param.Community_Id,
                        Building_Id = _Param.Building_Id,
                        Drill_Type_ID = _Param.Drill_Type_ID,
                    };
                    drill_Calendar.Drill_SCH=(await connection.QueryAsync<Drill_Calendar>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                    procedure = "sp_EMR_Drill_HSE_Team";
                    drill_Calendar.HSE_Team= (await connection.QueryAsync<Dropdown_Values>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    
                    procedure = "sp_EMR_Drill_Assignees_New";
                    Drill_Sch_Assignee sch_Assignee = new Drill_Sch_Assignee()
                    {
                        ServiceProviders = new List<Dropdown_Values>(),
                        Commanders = new List<Dropdown_Values>()
                    };
                    async Task<List<Dropdown_Values>> ExecuteAssigneeProcedureAsync(string Act)
                    {
                        var para = new
                        {
                            Action = Act,
                            Zone_Id = _Param.Zone_Id,
                        };
                        return (await connection.QueryAsync<Dropdown_Values>(procedure, para, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList()!;
                    }
                    drill_Calendar.SP_Team = await ExecuteAssigneeProcedureAsync("1");
                    drill_Calendar.Commander_Team = await ExecuteAssigneeProcedureAsync("2");
                    return drill_Calendar;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillCalendar/GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Get_Drill_Calendar();
            }
        }

        public Task<Drill_Calendar> GetByIdAsync(Drill_Calendar entity)
        {
            throw new NotImplementedException();
        }

        public async Task<M_Return_Message> UpdateAsync(Drill_Calendar entity)
        {
            try
            {
                string procedure = "sp_EMR_Drill_Calendar_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Drill_Calendar_ID = entity.Drill_Calendar_ID,
                        Initial_Date = entity.Initial_Date,
                        Frequency = entity.Frequency,
                        HSE_Officer = entity.HSE_Officer,
                        Commander = entity.Commander,
                        Service_Provider = entity.Service_Provider,
                        Created_By = entity.Created_By
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "DrillCalendar/UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }
    }
}
