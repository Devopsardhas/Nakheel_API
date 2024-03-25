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
using System.Xml.Linq;
using System.Reflection;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class MasterCommunityRepo : IMasterCommunityRepo
    {
        private readonly IConfiguration configuration;

        public MasterCommunityRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Master Community]
        public async Task<M_Return_Message> AddAsync(M_MasterCommunity_Master entity)
        {
            try
            {
                string procedure_1 = "sp_MasterCommunity_Master_Add";
                string procedure_2 = "sp_Sub_MasterCommunity_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_MasterCommunity_List != null && entity.L_M_MasterCommunity_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_MasterCommunity_List)
                            {
                                var parameters_2 = new
                                {
                                    MasterCommunity_Id = Obj.Status_Code,
                                    MasterCommunity_Name = item.MasterCommunity_Name,
                                    MasterCommunity_Description = item.MasterCommunity_Description,
                                    CreatedBy = item.CreatedBy,
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
                string Repo = "Master Community AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> DeleteAsync(M_MasterCommunity_Master entity)
        {
            try
            {
                string procedure = "sp_MasterCommunity_Master_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,
                        MasterCommunity_Id = entity.MasterCommunity_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Master Community DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> SubDeleteAsync(M_MasterCommunity_List entity)
        {
            try
            {
                string procedure = "sp_Sub_MasterCommunity_Master_ID_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,
                        Sub_MasterCommunity_Id = entity.Sub_MasterCommunity_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Sub Master Community SubDeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_MasterCommunity_Master>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_MasterCommunity_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<M_MasterCommunity_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Master Community GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_MasterCommunity_Master> GetByIdAsync(M_MasterCommunity_Master entity)
        {
            try
            {
                string procedure = "sp_Master_Community_GetByID";
                string procedureBList = "sp_Master_Community_SubList";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 4,
                        MasterCommunity_Id = entity.MasterCommunity_Id
                    };
                    var Obj = (await connection.QueryAsync<M_MasterCommunity_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjMasterCommunity = (await connection.QueryAsync<M_MasterCommunity_List>(procedureBList, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_MasterCommunity_List = ObjMasterCommunity;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Master Community GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_MasterCommunity_Master entity)
        {
            try
            {
                string procedure_1 = "sp_Inc_Master_Community_Update";
                string procedure_2 = "sp_Sub_Master_Community_Add_New";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        MasterCommunity_Id = entity.MasterCommunity_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_MasterCommunity_List != null && entity.L_M_MasterCommunity_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_MasterCommunity_List)
                            {
                                if (item.Sub_MasterCommunity_Id == null)
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_MasterCommunity_Id = 0,
                                        MasterCommunity_Id = Obj.Status_Code,
                                        MasterCommunity_Name = item.MasterCommunity_Name,
                                        MasterCommunity_Description = item.MasterCommunity_Description,
                                        CreatedBy = item.CreatedBy,
                                    };
                                    await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                                }
                                else
                                {
                                    var parameters_2 = new
                                    {
                                        Sub_MasterCommunity_Id = item.Sub_MasterCommunity_Id,
                                        MasterCommunity_Id = item.MasterCommunity_Id,
                                        MasterCommunity_Name = item.MasterCommunity_Name,
                                        MasterCommunity_Description = item.MasterCommunity_Description,
                                        CreatedBy = item.CreatedBy,
                                    };
                                    await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                                }

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
                string Repo = "Master Community Master UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_MasterCommunity_List>> Get_All_MasterCommunity_byZone(M_MasterCommunity_Master entity)
        {
            try
            {
                string procedure = "sp_Get_All_Master_Community_byZone";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id
                    };
                    return (await connection.QueryAsync<M_MasterCommunity_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Get_All_Building_byZone";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> CheckMasterCommunity_Name(M_MasterCommunity_List entity)
        {
            try
            {
                string procedure = "sp_Community_Name_Duplicate";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        //Action = 5,

                        MasterCommunity_Name = entity.MasterCommunity_Name
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Building Master DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        #endregion

        #region [Level Master]
        public async Task<IReadOnlyList<Level_Master>> Get_All_LevelM()
        {
            try
            {
                string procedure = "sp_EM_Level_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<Level_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> LevelM_Delete(Level_Master entity)
        {
            try
            {
                string procedure = "sp_EM_Level_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        LevelM_Id = entity.LevelM_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> LevelM_Add(Level_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Level_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        LevelM_Id = entity.LevelM_Id,
                        LevelM_Name = entity.LevelM_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<Level_Master> Get_ById_LevelM(Level_Master entity)
        {
            try
            {
                string procedure = "sp_EM_Level_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        LevelM_Id = entity.LevelM_Id
                    };
                    var Obj = (await connection.QueryAsync<Level_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> LevelM_Update(Level_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Level_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 5,
                        LevelM_Id = entity.LevelM_Id,
                        LevelM_Name = entity.LevelM_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

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
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Crisis Master]
        public async Task<IReadOnlyList<Crisis_Team_Master>> Get_All_Crisis()
        {
            try
            {
                string procedure = "sp_EM_Crisis_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<Crisis_Team_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Crisis_Delete(Crisis_Master entity)
        {
            try
            {
                string procedure = "sp_EM_Crisis_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Crisis_Master_Id = entity.Crisis_Master_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Crisis_Add(Crisis_Team_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Crisis_Master_Add";
                string procedure_2 = "sp_EM_Crisis_Sub_Emp_Master_Add";
                string procedure_3 = "sp_EM_Crisis_Team_Master_Add";
                string procedure_4 = "sp_EM_Crisis_Team_Master_Delete";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Community_Id = entity.Community_Id,
                        Zone_Id = entity.Zone_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    var delet_Obj = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Obj != null)
                    {
                        if (entity.L_M_Crisis_Team_Details != null && entity.L_M_Crisis_Team_Details.Count > 0)
                        {
                            foreach (var item in entity.L_M_Crisis_Team_Details)
                            {
                                var parameters_3 = new
                                {
                                    Crisis_Master_Id = Obj.Status_Code,
                                    Level_Id = item.Level_Id,
                                    Role = item.Role,
                                    Position = item.Position,
                                    Name = item.Name,
                                    Mobile = item.Mobile,
                                    A_Role = item.A_Role,
                                    A_Position = item.A_Position,
                                    A_Name = item.A_Name,
                                    A_Mobile = item.A_Mobile,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Crisis_Team_Details != null && entity.L_M_Crisis_Team_Details.Count > 0)
                        {
                            foreach (var item in entity.L_M_Crisis_Team_Details)
                            {
                                var parameters_2 = new
                                {
                                    Crisis_Master_Id = Obj.Status_Code,
                                    Zone_Id = entity.Zone_Id,
                                    LevelM_Id = item.Level_Id,
                                    Emp_Id = item.Name,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = entity.Community_Id,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }

                            foreach (var item in entity.L_M_Crisis_Team_Details)
                            {
                                var parameters_2 = new
                                {
                                    Crisis_Master_Id = Obj.Status_Code,
                                    Zone_Id = entity.Zone_Id,
                                    LevelM_Id = item.Level_Id,
                                    Emp_Id = item.A_Name,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = entity.Community_Id,
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
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Crisis_Master> Get_ById_Crisis(Crisis_Master entity)
        {
            try
            {
                string procedure = "sp_EM_Crisis_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        LevelM_Id = entity.LevelM_Id
                    };
                    var Obj = (await connection.QueryAsync<Crisis_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Crisis_Update(Crisis_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Crisis_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 5,
                        LevelM_Id = entity.LevelM_Id,
                        //LevelM_Name = entity.LevelM_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

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
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Crisis_Team_Master> Crisis_View(Crisis_Team_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Crisis_Master_View";
                //string procedure_2 = "sp_EM_Crisis_Sub_Emp_Master_View";
                string procedure_2 = "sp_EM_Crisis_Team_Master_View";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Crisis_Master_Id = entity.Crisis_Master_Id,
                    };
                    var Obj = (await connection.QueryAsync<Crisis_Team_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjSubEmp_Master_Details = (await connection.QueryAsync<Crisis_Emp_Team_Master>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Crisis_Team_Details = ObjSubEmp_Master_Details;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Crisis_Team_Master>> Crisis_Viewby_Emp(Crisis_Team_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Crisis_Master_View_Emp_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Emp_Id = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<Crisis_Team_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Crisis_SubEmp_Master>> Crisis_Get_Emp_Level(Crisis_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_Crisis_Sub_Emp_Master_ByLevel";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        LevelM_Id = entity.LevelM_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Remarks,
                    };
                    var Obj = (await connection.QueryAsync<Crisis_SubEmp_Master>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).AsList();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Crisis_Get_Emp_Level";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Emergency Category]
        public async Task<IReadOnlyList<Emergency_Category_Master>> Get_All_Emergency_Category()
        {
            try
            {
                string procedure = "sp_EM_EM_Emergency_Category_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<Emergency_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Emergency_Category";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Emergency_Category_Delete(Emergency_Category_Master entity)
        {
            try
            {
                string procedure = "sp_EM_EM_Emergency_Category_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Emergency_Category_Id = entity.Emergency_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency_Category_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Emergency_Category_Add(Emergency_Category_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_EM_Emergency_Category_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Emergency_Category_Id = entity.Emergency_Category_Id,
                        Emergency_Category_Name = entity.Emergency_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency_Category_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Emergency_Category_Master> Get_ById_Emergency_Category(Emergency_Category_Master entity)
        {
            try
            {
                string procedure = "sp_EM_EM_Emergency_Category_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Emergency_Category_Id = entity.Emergency_Category_Id
                    };
                    var Obj = (await connection.QueryAsync<Emergency_Category_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Emergency_Category_Update(Emergency_Category_Master entity)
        {
            try
            {
                string procedure_1 = "sp_EM_EM_Emergency_Category_Master_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 5,
                        Emergency_Category_Id = entity.Emergency_Category_Id,
                        Emergency_Category_Name = entity.Emergency_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

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
                string Repo = "_LevelM AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Scope of Work]
        public async Task<IReadOnlyList<Service_Provider_Scope_of_Work>> Get_All_Scope_of_Work()
        {
            try
            {
                string procedure = "sp_Service_Provider_Scope_of_Work";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<Service_Provider_Scope_of_Work>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Scope_of_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Scope_of_Work_Delete(Service_Provider_Scope_of_Work entity)
        {
            try
            {
                string procedure = "sp_Service_Provider_Scope_of_Work";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Scope_of_Work_Id = entity.Scope_of_Work_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency_Category_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Scope_of_Work_Add(Service_Provider_Scope_of_Work entity)
        {
            try
            {
                string procedure_1 = "sp_Service_Provider_Scope_of_Work";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        Scope_of_Work_Id = entity.Scope_of_Work_Id,
                        Scope_of_Work = entity.Scope_of_Work,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency_Category_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Service_Provider_Scope_of_Work> Get_ById_Scope_of_Work(Service_Provider_Scope_of_Work entity)
        {
            try
            {
                string procedure = "sp_Service_Provider_Scope_of_Work";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Scope_of_Work_Id = entity.Scope_of_Work_Id
                    };
                    var Obj = (await connection.QueryAsync<Service_Provider_Scope_of_Work>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "_LevelM Get_ById_Scope_of_Work";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Scope_of_Work_Update(Service_Provider_Scope_of_Work entity)
        {
            try
            {
                string procedure_1 = "sp_Service_Provider_Scope_of_Work";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 5,
                        Scope_of_Work_Id = entity.Scope_of_Work_Id,
                        Scope_of_Work = entity.Scope_of_Work,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

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
                string Repo = "_LevelM Scope_of_Work_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [ERT Details]

        public async Task<IReadOnlyList<ERT_Team_Details>> Get_All_ERT_Team_Details()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<ERT_Team_Details>> Get_All_ERT_Team_Details_Filter(ERT_Team_Details entity)
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Filter";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        BU_Id = entity.Business_Unit,
                        Role = entity.Role,
                        Type = entity.Type,
                        Training_Status = entity.Training_Status,
                        Card_Id = entity.Card_Id,

                    };
                    return (await connection.QueryAsync<ERT_Team_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> ERT_Team_Details_Delete(ERT_Team_Details entity)
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        ERT_Id = entity.ERT_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "ERT_Team_Details_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> ERT_Team_Details_Add(ERT_Team_Details entity)
        {
            try
            {
                string procedure_1 = "sp_EM_ERT_Team_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 1,
                        ERT_Id = entity.ERT_Id,
                        Employee_Name = entity.Employee_Name,
                        Gender = entity.Gender,
                        Langauge = entity.Langauge,
                        Nationality = entity.Nationality,
                        Age = entity.Age,
                        Department = entity.Department,
                        Position = entity.Position,
                        Role = entity.Role,
                        Type = entity.Type,
                        Certificate_Date = entity.Certificate_Date,
                        Exprity_Date = entity.Exprity_Date,
                        Staff_Status = entity.Staff_Status,
                        Training_Status = entity.Training_Status,
                        Business_Unit = entity.Business_Unit,
                        Building_No = entity.Building_No,
                        Floor_No = entity.Floor_No,
                        Declaration_Completed = entity.Declaration_Completed,
                        ERT_Upload_File = entity.ERT_Upload_File,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Emergency_Category_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<ERT_Team_Details> Get_ById_ERT_Team_Details(ERT_Team_Details entity)
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = entity.Status,
                        ERT_Id = entity.ERT_Id
                    };
                    var Obj = (await connection.QueryAsync<ERT_Team_Details>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_ById_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> ERT_Team_Details_Update(ERT_Team_Details entity)
        {
            try
            {
                string procedure_1 = "sp_EM_ERT_Team_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Action = 5,
                        ERT_Id = entity.ERT_Id,
                        Employee_Name = entity.Employee_Name,
                        Gender = entity.Gender,
                        Langauge = entity.Langauge,
                        Nationality = entity.Nationality,
                        Age = entity.Age,
                        Department = entity.Department,
                        Position = entity.Position,
                        Role = entity.Role,
                        Type = entity.Type,
                        Certificate_Date = entity.Certificate_Date,
                        Exprity_Date = entity.Exprity_Date,
                        Staff_Status = entity.Staff_Status,
                        Training_Status = entity.Training_Status,
                        Business_Unit = entity.Business_Unit,
                        Building_No = entity.Building_No,
                        Floor_No = entity.Floor_No,
                        Declaration_Completed = entity.Declaration_Completed,
                        ERT_Upload_File = entity.ERT_Upload_File,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

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
                string Repo = "ERT_Team_Details_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [ERT TEAM DETAILS MASTERS ONLY --GET ALL]
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Department()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Building_No()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_FloorNo()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Role()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Training_Status()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<ERT_Team_Details_Master>> Get_All_ERT_Type()
        {
            try
            {
                string procedure = "sp_EM_ERT_Team_Details_Masters";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                    };
                    return (await connection.QueryAsync<ERT_Team_Details_Master>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_ERT_Team_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        #endregion

        public async Task<IReadOnlyList<SafetyPer_Dash_Card_View_Data>> SafetyPer_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Main_Control_Work_Card_View_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Card_Access = entity.Card_Access,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<SafetyPer_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SafetyPer_Main_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Audit_Dash_Card_View_Data>> Audit_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            try
            {
                string procedure1 = "sp_Dash_Main_Audit_Card_View_Data";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Card_Access = entity.Card_Access,
                };

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Audit_Dash_Card_View_Data>(procedure1, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SafetyPer_Main_Dash_Card_View_Data";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}

