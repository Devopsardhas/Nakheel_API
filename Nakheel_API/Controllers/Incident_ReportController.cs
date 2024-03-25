using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class Incident_ReportController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Incident_ReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region [Incident Upload File]
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Incident";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);

        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Incident";
            var data = unitOfWork.CommonMediaUploadRepo.UploadFile(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult VideoUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Incident";
            var data = unitOfWork.CommonMediaUploadRepo.UploadVideo(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageFileUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Incident";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImageFile(formFiles, Module_Name);
            return Ok(data);
        }
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageFileVideosUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Incident";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImageFileVideos(formFiles, Module_Name);
            return Ok(data);
        }

        #endregion

        #region [Incident Notification]
        [HttpPost]
        public async Task<IActionResult> Inc_Category_Add(M_Incident_Report entity)
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
                var data = await unitOfWork.Incident_Report_Repo.AddAsync(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {

                    Mobile_User_Login _LOGIN = new Mobile_User_Login()
                    {
                        Role_Id = entity.Role_Id,
                        UserName = entity.CreatedBy
                    };
                    // AccountsController accountsController = new AccountsController();
                    //var ret = accountsController.Trigger_Master_Notification_Details_Alert(_LOGIN);
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
        public async Task<IActionResult> IncidentNotificationAdd(M_Investigation_Report_Add entity)
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
                var data = await unitOfWork.Incident_Report_Repo.IncidentNotificationAdd(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {

                    Mobile_User_Login _LOGIN = new Mobile_User_Login()
                    {
                        Role_Id = entity.Role_Id,
                        UserName = entity.CreatedBy
                    };
                    // AccountsController accountsController = new AccountsController();
                    //var ret = accountsController.Trigger_Master_Notification_Details_Alert(_LOGIN);
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
        public async Task<IActionResult> Inc_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.IncidentNotificationGetAll(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Incident_Notification = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200",
                    RecordsTotal = data[0].RecordsTotal,
                    RecordsFiltered = data[0].RecordsFiltered
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
        public async Task<IActionResult> Inc_GetBy_Id(M_Incident_Report entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.GetByIdAsync(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Incident_Notification = data,
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
        public async Task<IActionResult> Inc_Status_Update(M_Incident_Report entity)
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
                var data = await unitOfWork.Incident_Report_Repo.IncidentStatusUpdate(entity);
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
        public async Task<IActionResult> Inc_Investigation_Team(M_Inc_Investigation_Team entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_Investigation_Team(entity);
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
        public async Task<IActionResult> Inc_Add_Knowledge_Share(Inc_Knowledge_Share entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_Add_Knowledge_Share(entity);
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
        public async Task<IActionResult> Inc_Add_Knowledge_Share_No(Inc_Knowledge_Share entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_Add_Knowledge_Share_No(entity);
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
        public async Task<IActionResult> Inc_AddCorrective_Assign_Action(M_Corrective_Assign_Action entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_AddCorrective_Assign_Action(entity);
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
        public async Task<IActionResult> Inc_Action_Closure_Get_All(Corrective_Assign_Action entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.Inc_Action_Closure_Get_All(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Inc_Add_Corrective_Evidence_Upload(Add_Corrective_Action entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_Add_Corrective_Action(entity);
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
        public async Task<IActionResult> Incident_Closure_Evidence(Corrective_Assign_Action entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.Incident_Closure_Evidence(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Update_Corrective_Assign_Action(Corrective_Assign_Action entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Update_Corrective_Assign_Action(entity);
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
        public async Task<IActionResult> Update_Corrective_Assign_Status(Evidence_Upload_Photos entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Update_Corrective_Assign_Status(entity);
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
        public async Task<IActionResult> Incident_Status_History(M_Incident_Report entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.Incident_Status_History(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Inc_Status_Update_IsReq(M_Incident_Report entity)
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
                var data = await unitOfWork.Incident_Report_Repo.IncidentStatusUpdate_IsReq(entity);
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
        public async Task<IActionResult> Inc_AddReject_Reason_Action(M_Incident_Notification_Reject entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Inc_AddReject_Reason_Action(entity);
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
        public async Task<IActionResult> Re_Assign_Corrective_Assign_Action(Corrective_Assign_Action entity)
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
                var data = await unitOfWork.Incident_Report_Repo.Re_Assign_Corrective_Assign_Action(entity);
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
        public async Task<IActionResult> Action_Closure_Get_All_Approval(Corrective_Assign_Action entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.Action_Closure_Get_All_Approval(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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


        #region [Main Dashboard Count]
        [HttpPost]
        public async Task<IActionResult> Get_Dashboard(M_Incident_Report entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.Get_Dashboard(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Dashboard_Count = data,
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
                };

                return Ok(errormessage);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Get_IncidentNotificationCardView(M_Incident_Report entity)
        {
            var data = await unitOfWork.Incident_Report_Repo.IncidentNotificationCardView(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Incident_Notification = data,
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
    }
}
