using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class Incident_Observation_ReportController: ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Incident_Observation_ReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region [Incident Observation]

        [HttpPost]
        public async Task<IActionResult> Inc_Observation_Report_Add(M_Incident_Observation_Report entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.AddAsync(entity);
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
        public async Task<IActionResult> Inc_Observation_Report_Update(M_Incident_Observation_Report entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.UpdateAsync(entity);
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
        public async Task<IActionResult> Inc_Observation_Report_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.ObservationReportGetAllAsync(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Observation_Report = data,
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
        public async Task<IActionResult> Inc_Observation_Report_GetByID(M_Incident_Observation_Report entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.GetByIdAsync(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Observation_Report = data,
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
        public async Task<IActionResult> Inc_Observation_Supervisor_GetByID(M_Observation_Corrective_Action entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.Inc_Observation_Supervisor_GetByID(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Obs_Corrective_Action = data,
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
        public async Task<IActionResult> Update_Observation_Corrective_Action(M_Observation_Corrective_Action entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Update_Observation_Corrective_Action(entity);
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
        public async Task<IActionResult> Re_Assign_Corrective_Assign_Action(M_Observation_Corrective_Action entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Re_Assign_Corrective_Assign_Action(entity);
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
        public async Task<IActionResult> Update_Observation_Corrective_Action_HSE(M_Observation_Corrective_Action entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Update_Observation_Corrective_Action_HSE(entity);
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
        public async Task<IActionResult> Update_Observation_Corrective_Action_HSE_Reject(M_Observation_Corrective_Action entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Update_Observation_Corrective_Action_HSE_Reject(entity);
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
        public async Task<IActionResult> Inc_Observation_Team(M_Inc_Observation_Team entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Inc_Observation_Team(entity);
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
        public async Task<IActionResult> Obs_Action_Closure_Get_All(Observation_Corrective_Action entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.Obs_Action_Closure_Get_All(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Add_Observation_Corrective_Action(M_Observation_Corrective_Action entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Add_Observation_Corrective_Action(entity);
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
        public async Task<IActionResult> UpdateObservationPriority(M_Incident_Observation_Report entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.UpdateObservationPriority(entity);
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
        public async Task<IActionResult> Update_Obs_Category_Positive(M_Incident_Observation_Report entity)
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
                var data = await unitOfWork.MInc_Observation_Report_Repo.Update_Obs_Category_Positive(entity);
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
        public async Task<IActionResult> Observation_Status_History(M_Incident_Observation_Report entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.Observation_Status_History(entity);
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

        #region [Observation Upload File]
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Observation";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult FileUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Observation";
            var data = unitOfWork.CommonMediaUploadRepo.UploadFile(formFiles, Module_Name);
            return Ok(data);
        }


        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult VideoUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Observation";
            var data = unitOfWork.CommonMediaUploadRepo.UploadVideo(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageFileUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Observation";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImageFile(formFiles, Module_Name);
            return Ok(data);
        }
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageFileVideosUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Observation";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImageFileVideos(formFiles, Module_Name);
            return Ok(data);
        }

        #endregion

        [HttpPost]
        public async Task<IActionResult> Get_ObservationNotificationCardView(M_Incident_Observation_Report entity)
        {
            var data = await unitOfWork.MInc_Observation_Report_Repo.ObservationNotificationCardView(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Observation_Report = data,
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
    }
}
