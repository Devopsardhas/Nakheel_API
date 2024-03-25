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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class ERT : IERT
    {
        private readonly IConfiguration configuration;

        public ERT(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<M_Return_Message> AddAsync(EMR_Team entity)
        {
            try
            {
                string procedure = "sp_Emr_Team_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        EMR_Type = entity.EMR_Type,
                        Mem_ID = entity.Mem_ID,
                        Role = entity.Role,
                        Sub_Building_ID = entity.Sub_Building_ID,
                        Training_Status = entity.Training_Status,
                        Certificate_Date = entity.Certificate_Date,
                        Expiry_Date = entity.Expiry_Date,
                        Certificate_Path = entity.Certificate_Path,
                        Created_By = entity.Created_By,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault()!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "ERT/AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new M_Return_Message();
            }
        }

        public Task<M_Return_Message> DeleteAsync(EMR_Team entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<EMR_Team>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Get_EMR_Team> GetAllAsync(ERT_Param _Param)
        {
            try
            {
                Get_EMR_Team _EMR_Team = new Get_EMR_Team();
                string procedure = "sp_Emr_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Zone_Id = _Param.Zone_Id,
                        Community_Id = _Param.Community_Id,
                        Building_Id = _Param.Building_Id,
                    };
                    _EMR_Team.EMR_Teams = (await connection.QueryAsync<EMR_Team>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                    procedure = "sp_EMR_Team_Mem_List";
                    _EMR_Team.Team_Members = (await connection.QueryAsync<Dropdown_Values>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    return _EMR_Team;
                }
            }
            catch (Exception ex)
            {
                string Repo = "ERT/GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return new Get_EMR_Team();
            }
        }

        public Task<EMR_Team> GetByIdAsync(EMR_Team entity)
        {
            throw new NotImplementedException();
        }

        public async Task<M_Return_Message> UpdateAsync(EMR_Team entity)
        {
            try
            {
                string procedure = "sp_Emr_Team_AU";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        ERT_ID=entity.ERT_ID,
                        EMR_Type = entity.EMR_Type,
                        Mem_ID = entity.Mem_ID,
                        Role = entity.Role,
                        Sub_Building_ID = entity.Sub_Building_ID,
                        Training_Status = entity.Training_Status,
                        Certificate_Date = entity.Certificate_Date,
                        Expiry_Date = entity.Expiry_Date,
                        Certificate_Path = entity.Certificate_Path,
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
