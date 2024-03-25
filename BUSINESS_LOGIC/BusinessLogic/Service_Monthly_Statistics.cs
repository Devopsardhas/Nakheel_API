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
    public class Service_Monthly_Statistics : IServiceMonthlyStatistics
    {
        private readonly IConfiguration configuration;
        public Service_Monthly_Statistics(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Task<M_Return_Message> AddAsync(ServiceMonthlyStatistics entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<ServiceMonthlyStatistics>> Get_Service_Monthly_Statics(ServiceMonthlyStatistics entity)
        {
            try
            {
                string procedure = "sp_Get_Service_Montly_Statistics";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy
                    };
                    return (await connection.QueryAsync<ServiceMonthlyStatistics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Service_Monthly_Statics : GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Service_Monthly_Statics(ServiceMonthlyStatistics entity)
        {
            try
            {
                string procedure = "sp_Add_Service_Monthly_Statistics";
                string proc_Legal_Files = "sp_Service_Monthly_Add_Legal_Complaince";
                string proc_Other_Files = "sp_Service_Monthly_Add_Other_Files";
                string proc_TR_Name = "sp_Service_Monthly_Add_Training_Name";
                string proc_TR_Files = "sp_Service_Monthly_Add_Training_Files";
                string proc_TR_Name_Other = "sp_Service_Monthly_Add_Other_Training_Name";
                string proc_TR_Files_Other = "sp_Service_Monthly_Add_Other_Training_Files";

                string proc_Legal_Files_Del = "sp_Service_Monthly_Delete_Legal_Complaince";
                string proc_Other_Files_Del = "sp_Service_Monthly_Delete_Other_Files";
                string proc_TR_Name_Del = "sp_Service_Monthly_Delete_Training_Name";
                string proc_TR_Files_Del = "sp_Service_Monthly_Delete_Training_Files";
                string proc_TR_Name_Del_Other = "sp_Service_Monthly_Delete_Other_Training_Name";
                string proc_TR_Files_Del_Other = "sp_Service_Monthly_Delete_Other_Training_Files";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Service_Monthly_Id = entity.Service_Monthly_Id,
                        Service_Year = entity.Service_Year,
                        Service_Month = entity.Service_Month,
                        Service_Total_Employees = entity.Service_Total_Employees,
                        Service_Man_of_Hours = entity.Service_Man_of_Hours,
                        Service_Training_Conducted = entity.Service_Training_Conducted,
                        CreatedBy = entity.CreatedBy,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        DMS_Number_Id = entity.DMS_Number_Id,
                    };
                    var List = (await connection.QueryAsync<ServiceMonthlyStatistics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (entity._Legal_Files != null && entity._Legal_Files.Count > 0)
                    {
                        var param_del_Legal = new
                        {
                            Service_Monthly_Id = entity.Service_Monthly_Id
                        };
                        await connection.ExecuteAsync(proc_Legal_Files_Del, param_del_Legal, commandType: CommandType.StoredProcedure);
                        foreach (var file in entity._Legal_Files)
                        {
                            var param = new
                            {
                                TR_Legal_File_Id = file.TR_Legal_File_Id,
                                Service_Monthly_Id = List!.Service_Monthly_Id,
                                Legal_File_Path = file.Legal_File_Path,
                                CreatedBy = file.CreatedBy,
                            };
                            var Legal_List = (await connection.QueryAsync<Training_Legal_Compliance>(proc_Legal_Files, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }
                    if (entity._Other_Files != null && entity._Other_Files.Count > 0)
                    {
                        var param_del_Other = new
                        {
                            Service_Monthly_Id = entity.Service_Monthly_Id
                        };
                        await connection.ExecuteAsync(proc_Other_Files_Del, param_del_Other, commandType: CommandType.StoredProcedure);
                        foreach (var file in entity._Other_Files)
                        {
                            var param = new
                            {
                                TR_Other_File_Id = file.TR_Other_File_Id,
                                Service_Monthly_Id = List!.Service_Monthly_Id,
                                Other_File_Path = file.Other_File_Path,
                                CreatedBy = file.CreatedBy,
                            };
                            var Other_List = (await connection.QueryAsync<Training_Other_Files>(proc_Other_Files, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                    }

                    if (entity._Training_List != null && entity._Training_List.Count > 0)
                    {
                        foreach (var file in entity._Training_List)
                        {
                            var param_del = new
                            {
                                Service_Training_Id = file.Service_Training_Id
                            };
                            await connection.ExecuteAsync(proc_TR_Name_Del, param_del, commandType: CommandType.StoredProcedure);
                        }

                        foreach (var file in entity._Training_List)
                        {

                            var param = new
                            {
                                Service_Training_Id = file.Service_Training_Id,
                                Service_Monthly_Id = List!.Service_Monthly_Id,
                                Service_Training_Name = file.Service_Training_Name,
                                Service_Remarks = file.Service_Remarks,
                                CreatedBy = file.CreatedBy,
                            };
                            var Training_List = (await connection.QueryAsync<Training_Name>(proc_TR_Name, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                            if (file._Training_Files != null && file._Training_Files.Count > 0)
                            {
                                foreach (var obj in file._Training_Files)
                                {
                                    var param_del_File = new
                                    {
                                        Service_Training_Id = file.Service_Training_Id
                                    };
                                    await connection.ExecuteAsync(proc_TR_Files_Del, param_del_File, commandType: CommandType.StoredProcedure);
                                }
                                foreach (var obj in file._Training_Files)
                                {                                    
                                    var param_files = new
                                    {
                                        TR_File_Id = obj.TR_File_Id,
                                        Service_Monthly_Id = List!.Service_Monthly_Id,
                                        Service_Training_Id = Training_List!.Service_Training_Id,
                                        Training_File_Path = obj.Training_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Training_File_List = (await connection.QueryAsync<Training_Files>(proc_TR_Files, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
                        }
                    }

                    if (entity._Training_Other_List != null && entity._Training_Other_List.Count > 0)
                    {
                        foreach (var file in entity._Training_Other_List)
                        {
                            var param_del = new
                            {
                                Service_Other_Training_Id = file.Service_Other_Training_Id
                            };
                            await connection.ExecuteAsync(proc_TR_Name_Del_Other, param_del, commandType: CommandType.StoredProcedure);
                        }

                        foreach (var file in entity._Training_Other_List)
                        {

                            var param = new
                            {
                                Service_Other_Training_Id = file.Service_Other_Training_Id,
                                Service_Monthly_Id = List!.Service_Monthly_Id,
                                Service_Other_Training_Name = file.Service_Other_Training_Name,
                                Service_Other_Remarks = file.Service_Other_Remarks,
                                CreatedBy = file.CreatedBy,
                            };
                            var Training_List = (await connection.QueryAsync<Training_Name_Other>(proc_TR_Name_Other, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                            if (file._Training_Other_Files != null && file._Training_Other_Files.Count > 0)
                            {
                                foreach (var obj in file._Training_Other_Files)
                                {
                                    var param_del_File = new
                                    {
                                        Service_Other_Training_Id = file.Service_Other_Training_Id
                                    };
                                    await connection.ExecuteAsync(proc_TR_Files_Del_Other, param_del_File, commandType: CommandType.StoredProcedure);
                                }
                                foreach (var obj in file._Training_Other_Files)
                                {
                                    var param_files = new
                                    {
                                        TR_Other_File_Id = obj.TR_Other_File_Id,
                                        Service_Monthly_Id = List!.Service_Monthly_Id,
                                        Service_Other_Training_Id = Training_List!.Service_Other_Training_Id,
                                        Training_Other_File_Path = obj.Training_Other_File_Path,
                                        CreatedBy = obj.CreatedBy,
                                    };
                                    var Training_File_List = (await connection.QueryAsync<Training_Name_Other_Files>(proc_TR_Files_Other, param_files, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                                }
                            }
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
                string Repo = "Add_Service_Monthly_Statics";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<ServiceMonthlyStatistics> Edit_Service_Monthly_Statics(ServiceMonthlyStatistics entity)
        {
            try
            {
                string procedure = "sp_View_Service_Monthly_Statistics";
                string proc_Legal = "sp_View_Service_Monthly_Legal_Complaince";
                string proc_Other = "sp_View_Service_Monthly_Other_Files";
                string proc_Training = "sp_View_Service_Monthly_Training_Names";
                string proc_Training_Files = "sp_View_Service_Monthly_Training_Files";
                string proc_Training_Other = "sp_View_Service_Monthly_Other_Training_Names";
                string proc_Training_Files_Other = "sp_View_Service_Monthly_Other_Training_Files";
                string proc_Reject_Reason = "sp_View_Service_Monthly_Reject_Reason";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Service_Monthly_Id = entity.Service_Monthly_Id
                    };

                    var Service_List = (await connection.QueryAsync<ServiceMonthlyStatistics>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Service_List != null)
                    {
                        var Legal_Files_List = (await connection.QueryAsync<Training_Legal_Compliance>(proc_Legal, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Other_Files_List = (await connection.QueryAsync<Training_Other_Files>(proc_Other, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Legal_Files_List != null)
                        {
                            Service_List._Legal_Files = Legal_Files_List;
                        }
                        if (Other_Files_List != null)
                        {
                            Service_List._Other_Files = Other_Files_List;
                        }

                        
                        var Traing_Name_List = (await connection.QueryAsync<Training_Name>(proc_Training, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        var Traing_Name_List_Other = (await connection.QueryAsync<Training_Name_Other>(proc_Training_Other, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                        if (Traing_Name_List.Count > 0)
                        {
                            Service_List._Training_List = Traing_Name_List;
                        }

                        if (Traing_Name_List_Other.Count > 0)
                        {
                            Service_List._Training_Other_List = Traing_Name_List_Other;
                        }

                        if (Service_List._Training_List != null && Service_List._Training_List.Count > 0)
                        {
                            foreach (var item in Service_List._Training_List)
                            {
                                var param_file = new
                                {
                                    Service_Training_Id = item.Service_Training_Id,
                                    Service_Monthly_Id = item.Service_Monthly_Id
                                };
                                var Tr_Files = (await connection.QueryAsync<Training_Files>(proc_Training_Files, param_file, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                                item._Training_Files = Tr_Files;
                            }
                        }

                        if (Service_List._Training_Other_List != null && Service_List._Training_Other_List.Count > 0)
                        {
                            foreach (var item in Service_List._Training_Other_List)
                            {
                                var param_file = new
                                {
                                    Service_Other_Training_Id = item.Service_Other_Training_Id,
                                    Service_Monthly_Id = item.Service_Monthly_Id
                                };
                                var Tr_Files = (await connection.QueryAsync<Training_Name_Other_Files>(proc_Training_Files_Other, param_file, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                                item._Training_Other_Files = Tr_Files;
                            }
                        }

                        var Reject_List = (await connection.QueryAsync<Reject_Reason>(proc_Reject_Reason, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                        if (Reject_List.Count > 0 && Reject_List != null)
                        {
                            Service_List._Reject_List = Reject_List;
                        }

                    }

                    return Service_List!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Edit_Service_Monthly_Statics : Edit_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<ServiceMonthlyStatistics>> Get_Service_Monthly_Statics_Filter(ServiceMonthlyStatistics entity)
        {
            try
            {
                string procedure = "sp_Get_Service_Montly_Statistics_Filter";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Service_Year = entity.Service_Year,
                        Service_Month = entity.Service_Month,
                    };
                    return (await connection.QueryAsync<ServiceMonthlyStatistics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ServiceMonthlyStatistics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Service_Monthly_Statics_Approve(ServiceMonthlyStatistics entity)
        {
            try
            {
                string procedure = "sp_Service_Monthly_Approve";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param = new
                    {
                        Service_Monthly_Id = entity.Service_Monthly_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                    };
                    var List = (await connection.QueryAsync<ServiceMonthlyStatistics>(procedure, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Service_Monthly_Statics_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Service_Monthly_Statics_Reject(Reject_Reason entity)
        {
            try
            {
                string procedure = "sp_Service_Montly_Statistics_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var param = new
                    {
                        Service_Monthly_Id = entity.Service_Monthly_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        HSE_Reject_Id = entity.HSE_Reject_Id,
                        Rejected_By = entity.Rejected_By,
                    };
                    var List = (await connection.QueryAsync<Reject_Reason>(procedure, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Service_Monthly_Statics_Approve";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public Task<M_Return_Message> DeleteAsync(ServiceMonthlyStatistics entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ServiceMonthlyStatistics>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceMonthlyStatistics> GetByIdAsync(ServiceMonthlyStatistics entity)
        {
            throw new NotImplementedException();
        }

        public Task<M_Return_Message> UpdateAsync(ServiceMonthlyStatistics entity)
        {
            throw new NotImplementedException();
        }
    }
}
