using BUSINESS_LOGIC.ErrorLogs;
using Dapper;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class HSE_BulletinRepo : IHSE_BulletinRepo
    {
        private readonly IConfiguration configuration;

        public HSE_BulletinRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.
        public async Task<M_Return_Message> AddAsync(HSE_BulletinMaster entity)
        {
            try
            {
                string procedure1 = "sp_Hse_Bulletin_Add";
                string procedure2 = "sp_Hse_Bulletin_FileUpl_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        HSE_Bulletin_Id = entity.HSE_Bulletin_Id,
                        HSE_Bulletin_Name = entity.HSE_Bulletin_Name,
                        CreatedBy = entity.CreatedBy
                    };
                    var Hse_Bulletin = (await connection.QueryAsync<HSE_BulletinMaster>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if(Hse_Bulletin != null)
                    {
                        if(entity.File_Upl_List != null)
                        {
                            foreach (var item in entity.File_Upl_List)
                            {
                                var parameters_1 = new
                                {
                                    HSE_Bulletin_Id = Hse_Bulletin.HSE_Bulletin_Id,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure2, parameters_1, commandType: CommandType.StoredProcedure);
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
                string Repo = "Hse Bulletin AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(HSE_BulletinMaster entity)
        {
            try
            {
                string procedure = "sp_Hse_Bulletin_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        HSE_Bulletin_Id = entity.HSE_Bulletin_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Hse Bulletin DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<HSE_BulletinMaster>> GetAllAsync()
        {
            try
            {
                string procedure1 = "sp_Hse_Bulletin_Get";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<HSE_BulletinMaster>(procedure1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }

               
            }
            catch (Exception ex)
            {
                string Repo = "Hse Bulletin GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public Task<HSE_BulletinMaster> GetByIdAsync(HSE_BulletinMaster entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(HSE_BulletinMaster entity)
        {
            throw new NotImplementedException();
        }
    }
}
