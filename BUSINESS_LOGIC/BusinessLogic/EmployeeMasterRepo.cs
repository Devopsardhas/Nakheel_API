using BUSINESS_LOGIC.ErrorLogs;
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
using Dapper;
using System.Net;


namespace BUSINESS_LOGIC.BusinessLogic
{
    public class EmployeeMasterRepo : IEmployeeMasterRepo
    {
        private readonly IConfiguration configuration;
        public EmployeeMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        public async Task<M_Return_Message> AddAsync(M_Employee_Management entity)
        {
            try
            {
                string procedure_1 = "sp_Employee_Master_Crud";
                string procedure_2 = "sp_Emp_Community";
                string procedure_3 = "sp_Emp_Building_Crud";
                string procedure_4 = "sp_Emp_Master_Community_Crud";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 2,
                        Employee_Identity_Id = entity.Employee_Identity_Id,
                        Employee_Type = entity.Employee_Type,
                        First_Name = entity.First_Name,
                        Last_Name = entity.Last_Name,
                        Mobile_Number = entity.Mobile_Number,
                        Email_Id = entity.Email_Id,
                        Address = entity.Address,
                        State = entity.State,
                        Country = entity.Country,
                        Zone_Id = entity.Zone_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Department_Id = entity.Department_Id,
                        Role_Id = entity.Role_Id,
                        Designation_Id = entity.Designation_Id,
                        Line_Manager_Id = entity.Line_Manager_Id,
                        Password = entity.Password,
                        CreatedBy = entity.CreatedBy,
                        Employee_Id = entity.Employee_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Employee_Management>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Employee_Community_List != null && entity.L_Employee_Community_List.Count > 0)
                        {
                            foreach (var item in entity.L_Employee_Community_List)
                            {
                                var parameters_2 = new
                                {
                                    Action = 2,
                                    Emp_Community_Id = item.Emp_Community_Id,
                                    Employee_Identity_Id = Obj.Employee_Identity_Id,
                                    Community_Id = item.Community_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Employee_Building_List != null && entity.L_Employee_Building_List.Count > 0)
                        {
                            foreach (var item in entity.L_Employee_Building_List)
                            {
                                var parameters_3 = new
                                {
                                    Action = 2,
                                    Emp_Building_Id = item.Emp_Building_Id,
                                    Employee_Identity_Id = Obj.Employee_Identity_Id,
                                    Building_Id = item.Building_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Employee_Master_Community_List != null && entity.L_Employee_Master_Community_List.Count > 0)
                        {
                            foreach (var item in entity.L_Employee_Master_Community_List)
                            {
                                var parameters_4 = new
                                {
                                    Action = 2,
                                    Emp_Master_Community_Id = item.Emp_Master_Community_Id,
                                    Employee_Identity_Id = Obj.Employee_Identity_Id,
                                    Master_Community_Id = item.Master_Community_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
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

        public async Task<M_Return_Message> DeleteAsync(M_Employee_Management entity)
        {
            try
            {
                string procedure = "sp_Employee_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Employee_Identity_Id = entity.Employee_Identity_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_Employee_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Employee_Management> GetByIdAsync(M_Employee_Management entity)
        {
            try
            {
                string procedure1 = "sp_Employee_Master_GetById";
                //string procedure2 = "sp_Employee_Community_GetById";
                //string procedure3 = "sp_Employee_Building_GetById";
                string procedure2 = "sp_Employee_Community_Edit";
                string procedure3 = "sp_Employee_Building_Edit";
                string procedure4 = "sp_Employee_Master_Community_GetById";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 4,
                        Employee_Identity_Id = entity.Employee_Identity_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Employee_Management>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjCommunity = (await connection.QueryAsync<M_Employee_Community_Model>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Employee_Community_List = ObjCommunity;
                    }
                    if (Obj != null)
                    {
                        var ObjBuilding = (await connection.QueryAsync<M_Employee_Building_Model>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Employee_Building_List = ObjBuilding;
                    }
                    if (Obj != null)
                    {
                        var ObjMasterCom = (await connection.QueryAsync<M_Employee_Master_Community_Model>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Employee_Master_Community_List = ObjMasterCom;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Employee_Management> Get_Contact_GetByEmpID(M_Employee_Management entity)
        {
            try
            {
                string procedure = "SP_GET_EMPLOYESS_BY_CONTACT_NO";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Emp_Id = entity.Employee_Identity_Id
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_by_Role(M_Employee_Master_Filter_by_Role entity)
        {
            try
            {
                string procedure = "SP_GET_EMPLOYESS_BY_ROLE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Role_Name = entity.Role_Name,
                        Zone_Id = entity.Zone_Id,
                        Emp_Community_Id = entity.Emp_Community_Id
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Master Get_Employee_by_Role";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_by_Zone(M_Employee_Master_Filter_by_Role entity)
        {
            try
            {
                string procedure = "SP_GET_EMPLOYEE_BY_ZONE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Master Get_Employee_by_Role";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter(M_Employee_Master_Filter entity)
        {
            try
            {
                string procedure = "SP_GET_ALL_EMPLOYESS_BY_MAST_FILTER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        ZONE_ID = entity.Zone_Id,
                        COM_ID = entity.Emp_Community_Id,
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Employee_Master_Filter";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Employee_Management entity)
        {
            try
            {
                string procedure_1 = "sp_Employee_Master_Crud";
                string procedure_2 = "sp_Emp_Community";
                string procedure_3 = "sp_Emp_Building_Crud";
                string procedure_4 = "sp_Emp_Master_Community_Crud";
                string procedure_5 = "sp_Emp_Community_Delete";
                string procedure_6 = "sp_Emp_Building_Delete";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 3,
                        Employee_Identity_Id = entity.Employee_Identity_Id,
                        Employee_Type = entity.Employee_Type,
                        First_Name = entity.First_Name,
                        Last_Name = entity.Last_Name,
                        Mobile_Number = entity.Mobile_Number,
                        Email_Id = entity.Email_Id,
                        Address = entity.Address,
                        State = entity.State,
                        Country = entity.Country,
                        Zone_Id = entity.Zone_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Role_Id = entity.Role_Id,
                        Designation_Id = entity.Designation_Id,
                        Password = entity.Password,
                        CreatedBy = entity.CreatedBy,
                        Line_Manager_Id = entity.Line_Manager_Id,
                        Department_Id = entity.Department_Id,
                        Employee_Id = entity.Employee_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Employee_Management>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Employee_Community_List != null && entity.L_Employee_Community_List.Count > 0)
                        {
                            var param_del = new
                            {
                                Employee_Identity_Id = entity.Employee_Identity_Id
                            };
                            await connection.ExecuteAsync(procedure_5, param_del, commandType: CommandType.StoredProcedure);

                            foreach (var item in entity.L_Employee_Community_List)
                            {
                                var parameters_2 = new
                                {
                                    Action = 2,
                                    Emp_Community_Id = item.Emp_Community_Id,
                                    Employee_Identity_Id = entity.Employee_Identity_Id,
                                    Community_Id = item.Community_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Employee_Building_List != null && entity.L_Employee_Building_List.Count > 0)
                        {
                            var param_del = new
                            {
                                Employee_Identity_Id = entity.Employee_Identity_Id
                            };
                            await connection.ExecuteAsync(procedure_6, param_del, commandType: CommandType.StoredProcedure);

                            foreach (var item in entity.L_Employee_Building_List)
                            {
                                var parameters_3 = new
                                {
                                    Action = 2,
                                    Emp_Building_Id = item.Emp_Building_Id,
                                    Employee_Identity_Id = entity.Employee_Identity_Id,
                                    Building_Id = item.Building_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.L_Employee_Master_Community_List != null && entity.L_Employee_Master_Community_List.Count > 0)
                        {
                            foreach (var item in entity.L_Employee_Master_Community_List)
                            {
                                var parameters_4 = new
                                {
                                    Action = 3,
                                    Emp_Master_Community_Id = item.Emp_Master_Community_Id,
                                    Employee_Identity_Id = Obj.Employee_Id,
                                    Master_Community_Id = item.Master_Community_Id,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
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
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Filter(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure = "sp_Employee_Filter_Select";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {                    
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,

                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SP_Sign_Up_Users_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Gold()
        {
            try
            {
                string procedure = "SP_GET_ALL_EMPLOYESS_BY_MAST_FILTER_GOLD";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Get_Employee_Master_Filter_Gold";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Silver()
        {
            try
            {
                string procedure = "SP_GET_ALL_EMPLOYESS_BY_MAST_FILTER_SILVER";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Get_Employee_Master_Filter_Silver";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Bronze(M_Employee_Master_Filter entity)
        {
            try
            {
                string procedure = "SP_GET_ALL_EMPLOYESS_BY_MAST_FILTER_BRONZE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                    };
                    return (await connection.QueryAsync<M_Employee_Management>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Employee Get_Employee_Master_Filter_Bronze";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}
