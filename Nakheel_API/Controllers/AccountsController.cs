using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MODELS;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration _configuration;
        public AccountsController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ServiceProviderFileUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "ServiceProvider";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImageFile(formFiles, Module_Name);
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> User_Verification(M_Accounts entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.User_Verification(entity);
                if (data != null)
                {
                    data.JWT_Token = CreateToken(data.Email_Id!, data.Role_Id!);
                    var b = new
                    {
                        Get_User = data,
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> User_Mobile_Logout(M_Accounts entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.User_Mobile_Logout(entity);
                if (data.Status_Code == "200")
                {
                    var b = new
                    {
                        Get_User = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        #region [Web Bell Notification]

        [HttpPost]
        public async Task<IActionResult> GetWebBellNotification(BellNotificationModel entity)
        {
            var data = await unitOfWork.MAccountsRepo.GetWebBellNotification(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_All_Notifications = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404"
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateWebBellReadStatus(BellNotificationModel entity)
        {
            var data = await unitOfWork.MAccountsRepo.UpdateWebBellReadStatus(entity);
            if (data != null)
            {
                var b = new
                {
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "Failed",
                    Status = false,
                    Status_Code = "404"
                };

                return Ok(errormessage);
            }
        }

        #endregion

        #region [MOBILE LOGIN]
        [HttpPost]
        public async Task<IActionResult> User_Login(Mobile_User_Login entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.User_Login(entity);
                if (data.STATUS == "200")
                {
                    var b = new
                    {
                        Get_User = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Notification_Count(Get_Notification_Count entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Get_Notification_Count(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Notification_Count = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Notification_Count_List(Get_Notification_Count entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Get_Notification_Count_List(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Notification_Count = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update_Read_Notification(Update_Read_Notification entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Update_Read_Notification(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Update_Read_Notification = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        //        [HttpPost]
        //        public async Task<IActionResult> Trigger_Master_Notification_Details_Alert(Mobile_User_Login entity)
        //        {
        //            if (entity == null)
        //            {
        //                var b = new
        //                {
        //                    Message = M_Return_Status_Text.INVALID_JSON,
        //                    Status = M_Return_Status_Code.FALSE,
        //                    Status_Code = M_Return_Status_Code.INVALID_JSON
        //                };
        //                return Ok(b);
        //            }
        //            else
        //            {
        //                var data = await unitOfWork.MAccountsRepo.Get_Master_Notification_Details_Alert(entity);
        //                if (data.Count > 0)
        //                {
        //                    foreach (var item in data)
        //                    {

        //                        string FIREBASE_ID = item.ULS_FIREBASEID;
        //                        string APPLICATIONID = item.NUD_APPLICATIONID;
        //                        string SENDERID = item.NUD_SENDERID;
        //                        string MESSAGE = item.MSG_MESSAGE;
        //                        string Name = item.NAME_DISCRIPTION;
        //                        string Type = item.MSG_DEFAULT_TITLE;
        //                        string MSG_DEFAULT_TITLE = item.MSG_DEFAULT_TITLE;
        //                        string NOTIFICATION_COUNT = item.NOTIFICATION_COUNT;
        //                        string NOTIFICATION_ID = item.NOTIFICATION_ID;
        //                        string VISIT_TYPE = "0";

        //                        SendNotification_alert(APPLICATIONID, SENDERID, FIREBASE_ID, Name, MESSAGE, Type, NOTIFICATION_COUNT, NOTIFICATION_ID, VISIT_TYPE);
        //                    }

        //                    var b = new
        //                    {
        //                        Message = M_Return_Status_Text.SUCCESS,
        //                        Status = M_Return_Status_Code.TRUE,
        //                        Status_Code = M_Return_Status_Code.OK
        //                    };
        //                    return Ok(b);
        //                }
        //                else
        //                {
        //                    M_Return_Message errormessage = new M_Return_Message()
        //                    {
        //                        Message = M_Return_Status_Text.FAILED,
        //                        Status = M_Return_Status_Code.FALSE,
        //                        Status_Code = M_Return_Status_Code.FAILED
        //                    };

        //                    return Ok(errormessage);
        //                }
        //            }
        //        }

        //        [HttpPost]
        //        public void SendNotification_alert(string APPLICATIONID, string SENDERID, string FIREBASE_ID, string Name, string MESSAGE, string Type, string NOTIFICATION_COUNT, string NOTIFICATION_ID, string VISIT_TYPE)
        //        {
        //            //Common C = new Common();
        //            try
        //            {
        //                // Disable the warning.
        //#pragma warning disable SYSLIB0014
        //                var applicationID = APPLICATIONID;
        //                var senderId = SENDERID;
        //                var deviceId = FIREBASE_ID;
        //                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
        //                tRequest.Method = "post";
        //                tRequest.ContentType = "application/json";

        //                var data = new
        //                {
        //                    to = deviceId,
        //                    priority = "high",
        //                    notification = new
        //                    {
        //                        body = Name + " \n " + MESSAGE,
        //                        title = "NAKHEEL :: " + Type,
        //                        icon = "myicon",
        //                        notification_count = NOTIFICATION_COUNT,
        //                        visit_type = VISIT_TYPE,
        //                        sound = NOTIFICATION_COUNT
        //                    }
        //                };

        //                var serializer = new JavaScriptSerializer();
        //                var json = serializer.Serialize(data);
        //                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
        //                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
        //                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
        //                tRequest.ContentLength = byteArray.Length;
        //                using (Stream dataStream = tRequest.GetRequestStream())
        //                {
        //                    dataStream.Write(byteArray, 0, byteArray.Length);
        //                    using (WebResponse tResponse = tRequest.GetResponse())
        //                    {
        //                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
        //                        {
        //                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
        //                            {
        //                                String sResponseFromServer = tReader.ReadToEnd();
        //                                string str = sResponseFromServer;
        //                                string status = string.Empty;

        //                                dynamic responsejson = JsonContent.DeserializeObject<dynamic>(str);

        //                                status = responsejson.success.ToString();

        //                                if (status == "1")
        //                                {
        //                                    var response = unitOfWork.MAccountsRepo.USP_Update_Notification_Send(NOTIFICATION_ID);
        //                                }
        //                                else
        //                                {

        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            // Re-enable the warning.
        //#pragma warning restore SYSLIB0014

        //            catch (Exception ex)
        //            {
        //                string Repo = "SendNotification_alert";
        //                ErrorLog.ErrorLogs(ex, Repo);
        //                throw;
        //            }
        //        }
        #endregion

        #region [SERVICE_PROVIDER_SIGN_UP]
        [HttpPost]
        public async Task<IActionResult> Add_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Add_Service_Provider_Sign_Up(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }

            }

        }


        [HttpPost]
        public async Task<IActionResult> UpdateDelete_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.UpdateDelete_Service_Provider_Sign_Up(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.UpdateDetails_Service_Provider_Sign_Up(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> Update_SignUp_Document_Submission(L_M_RequiredAttachments_List entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Update_SignUp_Document_Submission(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> SP_Sign_Up_Users_List(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.MAccountsRepo.SP_Sign_Up_Users_List(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK

                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> SP_Sign_Up_Users_List_Email(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.MAccountsRepo.SP_Sign_Up_Users_List_Email(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK

                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.MAccountsRepo.Get_Service_Provider_Sign_Up(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_ById = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200",
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSignUpStatus(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.UpdateSignUpStatus(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update_Service_Provider_Sign_Up(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.MAccountsRepo.Update_Service_Provider_Sign_Up(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_ById = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200",
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }

        }
        #endregion

        #region [EMAIL_ID_CHECK_DUILPCATE]
        [HttpPost]
        public async Task<IActionResult> Email_Id_Check_Duilpcate(M_Accounts entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Email_Id_Check_Duilpcate(entity);
                if (data.Status_Code == M_Return_Status_Code.ISDATA)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                        Return_1 = data.Return_1,
                        Return_2 = data.Return_2,
                        Return_3 = data.Return_3,
                    };
                    return Ok(b);
                }
                else if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.ALREADYEXIST,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.OK
                    };

                    return Ok(errormessage);
                }

                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.INVALID_JSON
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> Company_Name_Check_Duilpcate(M_Accounts entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Company_Name_Check_Duilpcate(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.EMAILEXIST,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                        Return_1 = data.Return_1,
                        Return_2 = data.Return_2,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = data.Status_Code,
                        Return_1 = data.Return_1,
                        Return_2 = data.Return_2,
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> Purchase_Order_Number_Check_Duilpcate(M_Accounts entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Purchase_Order_Number_Check_Duilpcate(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.ALLEXIST,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = data.Status_Code,
                    };

                    return Ok(errormessage);
                }

            }

        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Add_Company_Details(Company_Details entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Add_Company_Details(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }

            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Company_Details(Company_Details entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Get_Company_Details(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Company_Details = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Service_Provider_DetailsbyId(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.Get_Service_Provider_DetailsbyId(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_All = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService_Provider_Id(ServiceProviderSignUp entity)
        {
            if (entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b);
            }
            else
            {
                var data = await unitOfWork.MAccountsRepo.UpdateService_Provider_Id(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errormessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_SP_Sign_Up_Users_List(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.MAccountsRepo.Get_SP_Sign_Up_Users_List(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK

                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Get_MainDashBoards_Details(MainDashBoards_Model entity)
        {
            var data = await unitOfWork.MAccountsRepo.Get_MainDashBoards_Details(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK

                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }

        }


        [HttpPost]
        public async Task<IActionResult> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity)
        {
            var data = await unitOfWork.MAccountsRepo.ServiceProv_Dashboard_Card_View(entity);

            if (data.Count > 0)
            {
                var b = new
                {
                    Get_Data1 = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };
                return Ok(errormessage);
            }
        }


        #region JWT Token

        //private string CreateToken(string username, string role)
        //{
        //    try
        //    {
        //        if (username != null && !string.IsNullOrEmpty(role))
        //        {
                    
        //            var claims = new[]
        //            {
        //                  new Claim(ClaimTypes.Name, username),
        //                  new Claim(ClaimTypes.Role, role)
        //            };

        //            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
        //                _configuration.GetSection("ConnectionStrings:Token").Value!));

        //            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //            var token = new JwtSecurityToken(
        //                claims: claims,
        //                expires: DateTime.UtcNow.AddHours(15), // Adjust the expiration time as needed
        //                signingCredentials: creds);

        //            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        //            return jwt;
        //        }
        //        else
        //        {
        //            return "Failed";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return "Failed";
        //    }
        //}

        private string CreateToken(string username, string role)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name,username),
                   new Claim(ClaimTypes.Role, role)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("ConnectionStrings:Token").Value!));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(200),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        #endregion
    }
}
