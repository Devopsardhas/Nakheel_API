using BUSINESS_LOGIC.ErrorLogs;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBUSINESS_LOGIC.IBusinessLogic;
using Dapper;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AccountsRepo : IAccountsRepo
    {
        private readonly IConfiguration configuration;

        public AccountsRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Sign IN]
        public async Task<M_Accounts> User_Verification(M_Accounts entity)
        {
            try
            {
                // User Verification Validate

                //string[] Employee_Type = entity.User_Name!.Split("@");

                M_Accounts AccountsM_ReturnMsg = new M_Accounts();

                bool ADcheck = false;
                ADcheck = await LocalUser_Email_Password_Validate(entity.Email_Id!);
                string message = "Login Name  : " + entity.Email_Id!;
                message += Environment.NewLine;
                message += Environment.NewLine;
                message += string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

                if (ADcheck == true)
                {
                    message += ADcheck.ToString();
                    string procedure = "sp_Get_Nakheel_User_Details";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        message += Environment.NewLine;
                        message += Environment.NewLine;
                        message += "1";
                        var pass = "";

                        if (entity.Password == null || entity.Password == "")
                        {
                            pass = "test123";
                            message += Environment.NewLine;
                            message += Environment.NewLine;
                            message += string.Format("Password: {0}", pass);
                            message += entity.Device_Id;
                        }
                        else
                        {
                            pass = entity.Password;
                            message += Environment.NewLine;
                            message += Environment.NewLine;
                            message += string.Format("Password: {0}", pass);
                            message += entity.Device_Id;
                        }

                        var parameters = new
                        {
                            User_Name = entity.Email_Id,
                            Password = pass
                        };

                        var Obj = (await connection.QueryAsync<M_Accounts>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (Obj != null)
                        {
                            message += Environment.NewLine;
                            message += Environment.NewLine;
                            message += string.Format("Success EMP ID: {0}", Obj.Employee_Identity_Id);
                            string procedure_1 = "sp_Emp_Community_GetById";
                            string procedure_2 = "sp_Emp_Master_Community_GetById";
                            string procedure_3 = "sp_Emp_Building_GetById";
                            string procedure_4 = "sp_Get_Nakheel_User_Update_Firebase_Id";
                            var parameters_Id = new
                            {
                                Employee_Identity_Id = Obj.Employee_Identity_Id,
                            };
                            var Obj_Com = (await connection.QueryAsync<Employee_Sub_Model>(procedure_1, parameters_Id, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            var Obj_M_Com = (await connection.QueryAsync<Employee_Sub_Model>(procedure_2, parameters_Id, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            var Obj_Build = (await connection.QueryAsync<Employee_Sub_Model>(procedure_3, parameters_Id, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            Obj.Employee_Common_List = new Employee_Common_Model();
                            if (Obj_Com != null && Obj_Com.Count > 0)
                            {
                                Obj.Employee_Common_List!.Emp_Community_List = Obj_Com;
                            }
                            if (Obj_M_Com != null && Obj_M_Com.Count > 0)
                            {
                                Obj.Employee_Common_List!.Emp_Master_Community_List = Obj_M_Com;
                            }
                            if (Obj_Build != null && Obj_Build.Count > 0)
                            {
                                Obj.Employee_Common_List!.Emp_Building_List = Obj_Build;
                            }

                            if (entity.Device_Id != null && entity.Device_Id != "")
                            {
                                var Dev_parameters_Id = new
                                {
                                    Employee_Identity_Id = Obj.Employee_Identity_Id,
                                    Device_Id = entity.Device_Id,
                                };
                                var Dev_Obj = (await connection.QueryAsync<M_Return_Message>(procedure_4, Dev_parameters_Id, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                            }
                        }
                        message += Environment.NewLine;
                        message += Environment.NewLine;
                        message += string.Format("OBJ: {0}", Obj);
                        string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "FileUpload/logs.txt"));
                        using (StreamWriter writer = new StreamWriter(path, true))
                        {
                            writer.WriteLine(message);
                            writer.Close();
                        }
                        return Obj;
                    }
                }
                else
                {
                    string message1 = "AD Failed  : ";
                    message1 += Environment.NewLine;
                    message1 += Environment.NewLine;
                    message1 += string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    message1 += Environment.NewLine;
                    message1 += Environment.NewLine;
                    message1 += "Login Name  : " + entity.Email_Id!;
                    string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "FileUpload/logs.txt"));

                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(message1);
                        writer.Close();
                    }
                    AccountsM_ReturnMsg.Status_Code = "500";
                    AccountsM_ReturnMsg.Return_Status = false;

                    AccountsM_ReturnMsg.Message = "User Login Failed";
                }
                return AccountsM_ReturnMsg;
            }
            catch (Exception ex)
            {
                M_Accounts AccountsM_ReturnMsg = new M_Accounts();
                AccountsM_ReturnMsg.Status_Code = "500";
                AccountsM_ReturnMsg.Return_Status = false;
                if (ex.Message == "The server could not be contacted.")
                {
                    AccountsM_ReturnMsg.Message = "The AD server could not be contacted";
                }
                else
                {
                    AccountsM_ReturnMsg.Message = ex.Message;
                }

                string Repo = "User_Verification";
                ErrorLog.ErrorLogs(ex, Repo);
                return AccountsM_ReturnMsg;
            }
        }
        public async Task<bool> LocalUser_Email_Password_Validate(string User_Name)
        {
            try
            {
                string procedure = "sp_Nakheel_Users_UserName_Password_Validate";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        User_Name = User_Name,
                    };

                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Obj!.Status_Code == "200")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "LocalUser_Email_Password_Validate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> User_Mobile_Logout(M_Accounts entity)
        {
            try
            {
                string procedure = "sp_Get_User_Mobile_Logout";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Employee_Identity_Id = entity.Employee_Identity_Id,
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetWebBellNotification";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [BELLNOTIFICATION]
        public async Task<IReadOnlyList<BellNotificationModel>> GetWebBellNotification(BellNotificationModel entity)
        {
            try
            {
                string procedure = "sp_Get_Web_Bel_Notification";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Login_User_Id = entity.Login_User_Id,
                    };

                    return (await connection.QueryAsync<BellNotificationModel>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetWebBellNotification";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateWebBellReadStatus(BellNotificationModel entity)
        {
            try
            {
                string procedure = "sp_Web_Bell_Read_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        ANS_Notification_ID = entity.ANS_Notification_ID,
                        Login_User_Id = entity.Login_User_Id,
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "UpdateWebBellReadStatus";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [MOBILE LOGIN & NOTIFICATION]
        public async Task<Get_User_Details> User_Login(Mobile_User_Login entity)
        {
            try
            {
                string procedure = "sp_Nakheel_User_Login_Mobile";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        User_Name = entity.UserName,
                        Password = entity.Password,
                        FireBase_Id = entity.FireBase_Id
                    };
                    return (await connection.QueryAsync<Get_User_Details>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "User_Login";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Get_Notification_Count_List> Get_Notification_Count(Get_Notification_Count entity)
        {
            try
            {
                string procedure = "USP_GET_NOTIFICATION_COUNT";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        User_Id = entity.User_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<Get_Notification_Count_List>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Notification_Count";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Get_Notification_Count_Details>> Get_Notification_Count_List(Get_Notification_Count entity)
        {
            try
            {
                string procedure = "USP_GET_SEND_USER_NOTIFICATION_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        User_Id = entity.User_Id,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<Get_Notification_Count_Details>(procedure, parameters, commandType: CommandType.StoredProcedure)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Notification_Count_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Get_Notification_Details>> Get_Master_Notification_Details_Alert(Mobile_User_Login entity)
        {
            try
            {
                string procedure = "USP_GET_SEND_USER_NOTIFICATION_DETAILS";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        UserName = entity.UserName,
                        Role_Id = entity.Role_Id,
                    };
                    return (await connection.QueryAsync<Get_Notification_Details>(procedure, parameters, commandType: CommandType.StoredProcedure)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Master_Notification_Details_Alert";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> USP_Update_Notification_Send(string Notification_Id)
        {
            try
            {
                string procedure = "USP_UPDATE_NOTIFICATION_SEND";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Notification_Id = Notification_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "USP_Update_Notification_Send";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Read_Notification(Update_Read_Notification entity)
        {
            try
            {
                string procedure = "USP_UPDATE_READ_NOTIFICATION";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Notification_Id = entity.Notification_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "USP_Update_Notification_Send";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure_1 = "sp_Add_Service_Provider_Sign_Up";
                string procedure_2 = "sp_Add_Service_Provider_Sign_Up_Documents";
                string procedure_4 = "sp_Email_Service_Provider_Major_HSE_Risk";
                string procedure_5 = "sp_Add_Service_Provider_Work_Superviosor";
                string procedure_7 = "sp_Add_Service_Provider_Building_Details";
                //string procedure_8 = "sp_Service_Provider_Update_History";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Company_Name = entity.Company_Name,
                        Inc_Business_Unit_Type = entity.Inc_Business_Unit_Type,
                        Manager_Incharge = entity.Manager_Incharge,
                        Designation = entity.Designation,
                        Mobile_No = entity.Mobile_No,
                        Official_Email_Id = entity.Official_Email_Id,
                        Purchase_Order_Number = entity.Purchase_Order_Number,
                        DMS_Number = entity.DMS_Number,
                        HSE_Officer = entity.HSE_Officer,
                        HSE_Officer_Email = entity.HSE_Officer_Email,
                        HSE_Officer_Mobile_Number = entity.HSE_Officer_Mobile_Number,
                        Contract_Start_Date = entity.Contract_Start_Date,
                        Contract_End_Date = entity.Contract_End_Date,
                        W_Name_Position = entity.W_Name_Position,  //Project Title
                        W_Contact = entity.W_Contact, // Contract Type
                        W_Email_Id = entity.W_Email_Id,
                        W_Work_Description = entity.W_Work_Description,
                        W_Specific_Requirements = entity.W_Specific_Requirements,
                        W_From_Date = entity.W_From_Date,
                        W_To_date = entity.W_To_date,
                        W_Night_Schedule = "0",
                        W_Permit_Validity = entity.W_Permit_Validity,
                        W_Scope_of_work = entity.W_Scope_of_work,
                        Company_Id = entity.Company_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Work_Superviosor_List != null && entity.L_M_Work_Superviosor_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_Work_Superviosor_List)
                            {
                                var parameters_5 = new
                                {
                                    Work_Superviosor_Id = item.Work_Superviosor_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Name_Position = item.Name_Position,
                                    Contact = item.Contact,
                                    Email_Id = item.Email_Id
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Building_List != null && entity.L_M_Building_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_Building_List)
                            {
                                var parameters_7 = new
                                {
                                    M_Service_Provider_Bu_Id = item.M_Service_Provider_Bu_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Building_Id = item.Building_Id,
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_RequiredAttachments_List != null && entity.L_M_RequiredAttachments_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_RequiredAttachments_List)
                            {
                                var parameters_2 = new
                                {
                                    RequiredDcouments_Id = item.RequiredDcouments_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Document_Type = item.Document_Type,
                                    Required_File_Path = item.Required_File_Path,
                                    Expiry_Date = item.Expiry_Date,
                                    Description = item.Description
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Major_HSE_Risk_List != null && entity.L_M_Major_HSE_Risk_List.Count > 0)
                        {
                            foreach (var item2 in entity.L_M_Major_HSE_Risk_List)
                            {
                                var parameters_2 = new
                                {
                                    Major_HSE_Risk_Id = item2.Major_HSE_Risk_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Major_HSE_Work_Id = item2.Major_HSE_Work_Id,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        //var parameters_8 = new
                        //{
                        //    SignUp_Id = Obj.Status_Code,
                        //    Status = entity.W_Work_Description,
                        //    Remarks = entity.W_Specific_Requirements,
                        //    CreatedBy = entity.CreatedBy,
                        //    Role_Id = entity.Role_Id,
                        //    Remarks_1 = entity.ApproveRes_1
                        //};
                        //var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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

        public async Task<M_Return_Message> UpdateDelete_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure_8 = "sp_Delete_Service_Provider_Sign_Up_Details";
                string procedure_1 = "sp_Updadate_Service_Provider_Sign_Up";
                string procedure_2 = "sp_Add_Service_Provider_Sign_Up_Documents";
                string procedure_4 = "sp_Email_Service_Provider_Major_HSE_Risk";
                string procedure_5 = "sp_Add_Service_Provider_Work_Superviosor";
                string procedure_7 = "sp_Add_Service_Provider_Building_Details";
                string procedure_9 = "sp_Email_Service_Provider_Sign_Up_Create_Resubbmit"; //Supervisoer Mail

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_0 = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                    };

                    var DeleObj = (await connection.QueryAsync<M_Return_Message>(procedure_8, parameters_0, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    var parameters_1 = new
                    {
                        SignUp_Id = "0",
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Company_Name = entity.Company_Name,
                        Inc_Business_Unit_Type = entity.Inc_Business_Unit_Type,
                        Manager_Incharge = entity.Manager_Incharge,
                        Designation = entity.Designation,
                        Mobile_No = entity.Mobile_No,
                        Official_Email_Id = entity.Official_Email_Id,
                        Purchase_Order_Number = entity.Purchase_Order_Number,
                        DMS_Number = entity.DMS_Number,
                        HSE_Officer = entity.HSE_Officer,
                        HSE_Officer_Email = entity.HSE_Officer_Email,
                        HSE_Officer_Mobile_Number = entity.HSE_Officer_Mobile_Number,
                        Contract_Start_Date = entity.Contract_Start_Date,
                        Contract_End_Date = entity.Contract_End_Date,
                        W_Name_Position = entity.W_Name_Position,  //Project Title
                        W_Contact = entity.W_Contact, // Contract Type
                        W_Email_Id = entity.W_Email_Id,
                        W_Work_Description = entity.W_Work_Description,
                        W_Specific_Requirements = entity.W_Specific_Requirements,
                        W_From_Date = entity.W_From_Date,
                        W_To_date = entity.W_To_date,
                        W_Night_Schedule = "0",
                        W_Permit_Validity = entity.W_Permit_Validity,
                        W_Scope_of_work = entity.W_Scope_of_work,
                        Company_Id = entity.Company_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_Work_Superviosor_List != null && entity.L_M_Work_Superviosor_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_Work_Superviosor_List)
                            {
                                var parameters_5 = new
                                {
                                    Work_Superviosor_Id = item.Work_Superviosor_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Name_Position = item.Name_Position,
                                    Contact = item.Contact,
                                    Email_Id = item.Email_Id
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Building_List != null && entity.L_M_Building_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_Building_List)
                            {
                                var parameters_7 = new
                                {
                                    M_Service_Provider_Bu_Id = item.M_Service_Provider_Bu_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Building_Id = item.Building_Id,
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_RequiredAttachments_List != null && entity.L_M_RequiredAttachments_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_RequiredAttachments_List)
                            {
                                var parameters_2 = new
                                {
                                    RequiredDcouments_Id = item.RequiredDcouments_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Document_Type = item.Document_Type,
                                    Required_File_Path = item.Required_File_Path,
                                    Expiry_Date = item.Expiry_Date,
                                    Description = item.Description
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Major_HSE_Risk_List != null && entity.L_M_Major_HSE_Risk_List.Count > 0)
                        {
                            foreach (var item2 in entity.L_M_Major_HSE_Risk_List)
                            {
                                var parameters_2 = new
                                {
                                    Major_HSE_Risk_Id = item2.Major_HSE_Risk_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Major_HSE_Work_Id = item2.Major_HSE_Work_Id,
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_9 = new
                        {
                            SignUp_Id = Obj.Status_Code,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_9, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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

        public async Task<M_Return_Message> UpdateDetails_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure_1 = "sp_Update_Service_Provider_Sign_Up";
                string procedure_2 = "sp_Add_Service_Provider_Sign_Up_Documents";
                string procedure_3 = "sp_Email_Service_Provider_Sign_Up_Create";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Company_Name = entity.Company_Name,
                        Inc_Business_Unit_Type = entity.Inc_Business_Unit_Type,
                        Manager_Incharge = entity.Manager_Incharge,
                        Designation = entity.Designation,
                        Mobile_No = entity.Mobile_No,
                        Official_Email_Id = entity.Official_Email_Id,
                        Purchase_Order_Number = entity.Purchase_Order_Number,
                        DMS_Number = entity.DMS_Number,
                        HSE_Officer = entity.HSE_Officer,
                        HSE_Officer_Email = entity.HSE_Officer_Email,
                        HSE_Officer_Mobile_Number = entity.HSE_Officer_Mobile_Number,
                        Contract_Start_Date = entity.Contract_Start_Date,
                        Contract_End_Date = entity.Contract_End_Date,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_M_RequiredAttachments_List != null && entity.L_M_RequiredAttachments_List.Count > 0)
                        {
                            foreach (var item in entity.L_M_RequiredAttachments_List)
                            {
                                var parameters_2 = new
                                {
                                    RequiredDcouments_Id = item.RequiredDcouments_Id,
                                    SignUp_Id = Obj.Status_Code,
                                    Document_Type = item.Document_Type,
                                    Required_File_Path = item.Required_File_Path,
                                    Expiry_Date = item.Expiry_Date
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters_3 = new
                        {
                            SignUp_Id = Obj.Status_Code,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "UpdateDetails_Service_Provider_Sign_Up";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<IReadOnlyList<ServiceProviderSignUp>> SP_Sign_Up_Users_List(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure = "sp_ServiceProv_Sign_Up_Users_List";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = entity.Action,
                        Status = entity.Status,
                        Zone_Id = entity.Zone_Id,
                    };
                    return (await connection.QueryAsync<ServiceProviderSignUp>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SP_Sign_Up_Users_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }


        public async Task<IReadOnlyList<ServiceProviderSignUp>> SP_Sign_Up_Users_List_Email(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure = "sp_ServiceProv_Sign_Up_Users_List_By_Email";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Official_Email_Id = entity.Official_Email_Id,
                    };
                    return (await connection.QueryAsync<ServiceProviderSignUp>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SP_Sign_Up_Users_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<ServiceProviderSignUp> Get_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure1 = "sp_Get_Service_Provider_Sign_Up_byId";
                string procedure2 = "sp_Get_Service_Provider_Sign_UpReqAtt_byId";
                string procedure3 = "sp_Get_Service_Provider_Sign_UpMajor_HSE_Risk_byId";
                string procedure4 = "sp_Get_Service_Provider_Sign_UpUpdate_HistoryId";
                string procedure5 = "sp_Get_Service_Provider_Sign_Work_Superviosor";
                string procedure6 = "sp_Get_Service_Provider_Building_List";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SignUp_Id = entity.SignUp_Id
                    };
                    var Obj = (await connection.QueryAsync<ServiceProviderSignUp>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjRequiredAttachments = (await connection.QueryAsync<L_M_RequiredAttachments_List>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_RequiredAttachments_List = ObjRequiredAttachments;

                        var ObjRMajor_HSE_Risk = (await connection.QueryAsync<L_M_Major_HSE_Risk_List>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Major_HSE_Risk_List = ObjRMajor_HSE_Risk;

                        var ObjUpdate_History = (await connection.QueryAsync<L_M_Service_Provider_Update_History>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Service_Provider_Update_History = ObjUpdate_History;

                        var ObjL_M_Work_Superviosor_List = (await connection.QueryAsync<L_M_Work_Superviosor_List>(procedure5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Work_Superviosor_List = ObjL_M_Work_Superviosor_List;

                        var ObjL_M_Building_List = (await connection.QueryAsync<L_M_Building_List>(procedure6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Building_List = ObjL_M_Building_List;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Service_Provider_Sign_Up";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<ServiceProviderSignUp> Update_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure1 = "sp_Update_Service_Provider_Sign_Up_byId";
                string procedure2 = "sp_Update_Service_Provider_Sign_UpReqAtt_byId";
                string procedure3 = "sp_Update_Service_Provider_Sign_Up_Major_HSE_Risk";
                string procedure4 = "sp_Update_Service_Provider_Sign_Work_Superviosor_Det";
                string procedure5 = "sp_Update_Service_Provider_Sign_Building_Details";
                string procedure6 = "sp_Get_Service_Provider_Sign_UpUpdate_HistoryId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SignUp_Id = entity.SignUp_Id
                    };
                    var Obj = (await connection.QueryAsync<ServiceProviderSignUp>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjRequiredAttachments = (await connection.QueryAsync<L_M_RequiredAttachments_List>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_RequiredAttachments_List = ObjRequiredAttachments;

                        var ObjUpdate_History = (await connection.QueryAsync<L_M_Service_Provider_Update_History>(procedure6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Service_Provider_Update_History = ObjUpdate_History;
                    }
                    if (Obj != null)
                    {
                        var ObjMajor_HSE_Risk_List = (await connection.QueryAsync<L_M_Major_HSE_Risk_List>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Major_HSE_Risk_List = ObjMajor_HSE_Risk_List;
                    }
                    if (Obj != null)
                    {
                        var ObjWork_Superviosor_List = (await connection.QueryAsync<L_M_Work_Superviosor_List>(procedure4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Work_Superviosor_List = ObjWork_Superviosor_List;
                    }
                    if (Obj != null)
                    {
                        var ObjBuilding_List = (await connection.QueryAsync<L_M_Building_List>(procedure5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Building_List = ObjBuilding_List;
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Incident Report GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateSignUpStatus(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure = "sp_Update_SignUp_Status";
                string procedure_1 = "sp_Send_Email_Notification_to_HSE_Team_SP_Approved";
                string procedure_2 = "sp_Send_Email_Notification_to_SP_Team_HSE_Approved";
                string procedure_3 = "sp_Send_Email_Notification_to_HSE_Team_SP_Reject";
                string procedure_4 = "sp_Service_Provider_Update_History";
                string procedure_5 = "sp_Send_Email_Notification_to_HSE_Team_SP_Required";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        DMS_Number = entity.DMS_Number,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (entity.Status == "2")
                    {
                        var parameters_3 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_4 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                            Status = entity.W_Work_Description,
                            Remarks = entity.W_Specific_Requirements,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Remarks_1 = entity.ApproveRes_1
                        };
                        var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                        //var parameters_44 = new
                        //{
                        //    Schedule_Type_Id = entity.Company_Id,
                        //    Zone_Id = "0",
                        //    Community_Id = "0",
                        //    Building_Id = "0",
                        //    Module_Name = "Service Provider Approval Request HSE",
                        //    Hyper_Link = "/Master/SP_Sign_Up_List",
                        //    CreatedBy = entity.CreatedBy,
                        //    Role_Id = "0",
                        //    Status = "2",
                        //    Remarks = entity.SignUp_Id
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_44, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }
                    if (entity.Status == "4")
                    {
                        var parameters_3 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        var parameters_4 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                            Status = entity.W_Work_Description,
                            Remarks = entity.W_Specific_Requirements,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Remarks_1 = entity.ApproveRes_1

                        };
                        var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    //REJECT SUPERVISOR
                    if (entity.Status == "3")
                    {
                        var parameters_3 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_4 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                            Status = entity.W_Work_Description,
                            Remarks = entity.W_Specific_Requirements,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Remarks_1 = entity.ApproveRes_1

                        };
                        var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    if (entity.Status == "5")
                    {
                        var parameters_3 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                        };
                        var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_5, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        var parameters_4 = new
                        {
                            SignUp_Id = entity.SignUp_Id,
                            Status = entity.W_Work_Description,
                            Remarks = entity.W_Specific_Requirements,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                            Remarks_1 = entity.ApproveRes_1
                        };
                        var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_4, parameters_4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "sp_Update_SignUp_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        public async Task<M_Return_Message> Email_Id_Check_Duilpcate(M_Accounts entity)
        {
            try
            {
                string procedure = "sp_Email_Id_Check_Duilpcate";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Email_Id = entity.User_Name,
                        Company_Id = entity.Company_Name
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Email_Id_Check_Duilpcate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_SignUp_Document_Submission(L_M_RequiredAttachments_List entity)
        {
            try
            {
                string procedure = "sp_Update_SignUp_Document_Submission";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Description = entity.Description,
                        Required_File_Path = entity.Required_File_Path,
                        RequiredDcouments_Id = entity.RequiredDcouments_Id,
                        Expiry_Date = entity.Expiry_Date
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Email_Id_Check_Duilpcate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Company_Name_Check_Duilpcate(M_Accounts entity)
        {
            try
            {
                string procedure = "SP_COMPANY_NAME_CHECK_DUILPCATE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Company_Name = entity.Company_Name,
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Email_Id_Check_Duilpcate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Purchase_Order_Number_Check_Duilpcate(M_Accounts entity)
        {
            try
            {
                string procedure = "SP_PURCHASE_ORDER_NUMBER_CHECK_DUILPCATE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Purchase_Order_Number = entity.Company_Name,
                    };

                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Email_Id_Check_Duilpcate";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Company_Details(Company_Details entity)
        {
            try
            {
                string procedure_1 = "sp_Add_Service_Provider_Company_Details";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Company_Id = entity.Company_Id,
                        Company_Name = entity.Company_Name,
                        Company_MobileNo = entity.Company_MobileNo,
                        Company_Email = entity.Company_Email,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
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
                string Repo = "Add_Company_Details";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<Company_Details> Get_Company_Details(Company_Details entity)
        {
            try
            {
                string procedure1 = "sp_Get_Service_Provider_Company_byId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Company_Id = entity.Company_Id
                    };
                    var Obj = (await connection.QueryAsync<Company_Details>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Service_Provider_Sign_Up";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<ServiceProviderSignUp>> Get_Service_Provider_DetailsbyId(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure1 = "sp_Get_Service_Provider_Details_by_Id";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Company_Id = entity.Company_Id
                    };
                    var Obj = (await connection.QueryAsync<ServiceProviderSignUp>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Service_Provider_Sign_Up";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateService_Provider_Id(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure_1 = "sp_Service_ProviderUpdate_SignUp_Status";
                string procedure_2 = "sp_Email_Service_Provider_Sign_Up_Create"; //Supervisoer Mail
                string procedure_3 = "sp_Service_Provider_Update_History";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Company_Id = entity.Company_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    var parameters_2 = new
                    {
                        SignUp_Id = entity.Company_Id,
                    };
                    var Objre = (await connection.QueryAsync<M_Return_Message>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_3 = new
                    {
                        SignUp_Id = entity.SignUp_Id,
                        Status = "1",
                        Remarks = "Newly Registered",
                        CreatedBy = entity.CreatedBy,
                        Role_Id = entity.Role_Id,
                        Remarks_1 = "Company Has Newly Registered"
                    };
                    var ObjHist = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();



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
                string Repo = "sp_Update_SignUp_Status";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<ServiceProviderSignUp>> Get_SP_Sign_Up_Users_List(ServiceProviderSignUp entity)
        {
            try
            {
                string procedure = "sp_ServiceProv_Sign_Up_Users_List_Test";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                        Status = entity.Status,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        ApproveRes_1 = entity.ApproveRes_1,
                    };
                    return (await connection.QueryAsync<ServiceProviderSignUp>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "SP_Sign_Up_Users_List";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<MainDashBoards_Model> Get_MainDashBoards_Details(MainDashBoards_Model entity)
        {
            try
            {
                string procedure_1 = "sp_Get_Nakheel_Dashboard_Upcoming_Activity";
                string procedure_2 = "sp_Inc_Notification_Dashboard_Count";
                string procedure_3 = "sp_Get_Nakheel_Dashboard_Upcoming_Activity_teamtask";
                string procedure_4 = "sp_Get_Nakheel_Dashboard_Upcoming_Activity_mytask";
                string procedure_5 = "sp_Get_Nakheel_Dashb_Upco_Acti_Emer_Escal";
                string procedure_6 = "sp_Get_EM_Emergency_SubZone_Alert_Master_Dashboard";
                string procedure_7 = "sp_Dash_Insp_Management_MainDash_GetbyId";
                string procedure_8 = "sp_Dash_Hse_Bulletin_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_2 = new
                    {
                        CreatedBy = entity.CreatedBy,
                        Zone_Id = entity.Zone_Id
                    };

                    MainDashBoards_Model mainDashBoards_Model = new MainDashBoards_Model();

                    var ObjActivity = (await connection.QueryAsync<Upcoming_Activity_Dashboard>(procedure_1, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjDash = (await connection.QueryAsync<Notification_Dashboard_Count>(procedure_2, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjActivityMy = (await connection.QueryAsync<Upcoming_Activity_Dashboard_My_Task>(procedure_4, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjActivityTeam = (await connection.QueryAsync<Upcoming_Activity_Dashboard_Team_Task>(procedure_3, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjActivityEmer_Escal = (await connection.QueryAsync<Upcoming_Activity_Dashboard_Emer_Escal>(procedure_5, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjEmergency_SubZone_Alert = (await connection.QueryAsync<Emergency_SubZone_Alert_Master_Dashboard>(procedure_6, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ObjDash_Insp = (await connection.QueryAsync<Notification_Dashboard_Count>(procedure_7, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var objBulletins = (await connection.QueryAsync<Hse_Bulletin>(procedure_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();

                    mainDashBoards_Model.L_M_Upcoming_Activity = ObjActivity;
                    mainDashBoards_Model.L_M_Notification_Dashboard_Count = ObjDash;
                    mainDashBoards_Model.L_M_Upcoming_Activity_Team = ObjActivityTeam;
                    mainDashBoards_Model.L_M_Upcoming_Activity_My = ObjActivityMy;
                    mainDashBoards_Model.L_M_Upcoming_Activity_Emer_Escal = ObjActivityEmer_Escal;
                    mainDashBoards_Model.L_M_Emergency_SubZone_Alert_Master_Dashboard = ObjEmergency_SubZone_Alert;
                    mainDashBoards_Model.Main_Dash_Insp_Count = ObjDash_Insp;
                    mainDashBoards_Model.L_Hse_Bulletins = objBulletins;
                    return mainDashBoards_Model;
                }
            }
            catch (Exception ex)
            {
                string Repo = "HealthSafety Building GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }



        public async Task<IReadOnlyList<ServiceProvider_Model>> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity)
        {
            try
            {
                string Procedure_01 = "sp_Dash_ServiceProv_CardView_Data_Dashboard";
                var parameter = new
                {
                    CreatedBy = entity.CreatedBy,
                    Category_Name = entity.Category_Name,
                    Card_View_Id = entity.Card_View_Id,
                    Zone_Id = entity.Zone_ID,
                    Community_Id = entity.Community_Id,
                    Building_Id = entity.Building_ID,
                    From_Date = entity.From_Date,
                    To_date = entity.To_date
                };
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<ServiceProvider_Model>(Procedure_01, parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Permit Dashboard";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

#pragma warning restore CS8603 // Possible null reference return.
    }
}
