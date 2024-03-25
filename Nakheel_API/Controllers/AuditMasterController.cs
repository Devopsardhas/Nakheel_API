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
    public class AuditMasterController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public AuditMasterController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region [FILE UPLOAD]
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageUpload(List<IFormFile> formFiles)
        {
            var Module_Name = "Internal_Audit";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);

        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult ImageUpload_ServiceProvider(List<IFormFile> formFiles)
        {
            var Module_Name = "Service_Provider_Audit";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);

        }
        #endregion

        #region [Audit Category]
        [HttpGet]
        public async Task<IActionResult> Audit_Category_GetAll()
        {
            var data = await unitOfWork.MAuditMasterRepo.GetAllAsync();
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Audit_Category_Add(M_Audit_Category entity)
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
                var data = await unitOfWork.MAuditMasterRepo.AddAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
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
        public async Task<IActionResult> Audit_Category_Update(M_Audit_Category entity)
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
                var data = await unitOfWork.MAuditMasterRepo.UpdateAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.UPDATED,
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
        public async Task<IActionResult> Audit_Category_GetById(M_Audit_Category entity)
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
                var data = await unitOfWork.MAuditMasterRepo.GetByIdAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_ById = data,
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
        }
        [HttpPost]
        public async Task<IActionResult> Audit_Category_Delete(M_Audit_Category entity)
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
                var data = await unitOfWork.MAuditMasterRepo.DeleteAsync(entity);
                if (data != null)
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
        #endregion

        #region [Audit Topics]
        [HttpGet]
        public async Task<IActionResult> Audit_Topics_GetAll()
        {
            var data = await unitOfWork.MAuditMasterRepo.GetAll_AM_Topics();
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Audit_Topics_GetById(M_Audit_Topics entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.GetById_AM_Topics(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Audit_Topics_Add(List<M_Audit_Topics> entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_AM_Topics(entity);
                if (data != null)
                {
                    var b = new
                    {
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
        public async Task<IActionResult> Audit_Topics_Delete(M_Audit_Topics entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Delete_AM_Topics(entity);
                if (data != null)
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
        #endregion

        #region [Audit Sub Topics]
        [HttpGet]
        public async Task<IActionResult> Audit_Sub_Topics_GetAll()
        {
            var data = await unitOfWork.MAuditMasterRepo.GetAll_AM_Sub_Topics();
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Audit_Sub_Topics_GetById(M_Audit_Sub_Topics entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.GetById_AM_Sub_Topics(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Audit_Sub_Topics_Add(List<M_Audit_Sub_Topics> entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_AM_Sub_Topics(entity);
                if (data != null)
                {
                    var b = new
                    {
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
        public async Task<IActionResult> Audit_Sub_Topics_Delete(M_Audit_Sub_Topics entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Delete_AM_Sub_Topics(entity);
                if (data != null)
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
        #endregion

        #region [Audit Questionnaires]
        [HttpGet]
        public async Task<IActionResult> Audit_Questionnaires_GetAll()
        {
            var data = await unitOfWork.MAuditMasterRepo.GetAll_AM_Questionnaires();
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Audit_Questionnaires_GetById(M_Audit_Questionnaires entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.GetById_AM_Questionnaires(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Env_Sp_Questionaire(M_Audit_Questionnaires entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_Env_Sp_Questionaire(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Audit_Questionnaires_Add(List<M_Audit_Questionnaires> entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_AM_Questionnaires(entity);
                if (data != null)
                {
                    var b = new
                    {
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
        public async Task<IActionResult> Audit_Questionnaires_Delete(M_Audit_Questionnaires entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Delete_AM_Questionnaires(entity);
                if (data != null)
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
        #endregion

        #region [Load_Questionnaire]
        [HttpPost]
        public async Task<IActionResult> Get_All_Questionnaire_Chk(M_Audit_QuestionnaireDetails entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_All_Questionnaire_Chk(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Questionnaire = data,
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
        #endregion

        #region [Audit Findings]
        [HttpGet]
        public async Task<IActionResult> GetAll_Am_AuditFindings()
        {
            var data = await unitOfWork.MAuditMasterRepo.GetAll_Am_AuditFindings();
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Findings = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message Error_Message = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };
                return Ok(Error_Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Am_Audit_Findings(List<M_AuditFindings> entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_Am_Audit_Findings(entity);
                if (data != null) {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update_Am_Audit_Findings(M_AuditFindings entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Update_Am_Audit_Findings(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.UPDATED,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(errorMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetByID_AuditFindings(M_AuditFindings entity)
        {
            if(entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b); ;
            }
            else
            {
                var data = await unitOfWork.MAuditMasterRepo.GetByID_AuditFindings(entity);
                if(data != null)
                {
                    var b = new
                    {
                        Get_ById_Findings = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };
                    return Ok(errorMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete_AM_Audit_Findings(M_AuditFindings entity)
        {
            if(entity == null)
            {
                var b = new
                {
                    Message = M_Return_Status_Text.INVALID_JSON,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.INVALID_JSON
                };
                return Ok(b );
            }
            else
            {
                var data = await unitOfWork.MAuditMasterRepo.Delete_AM_Audit_Findings(entity);
                if (data != null)
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
                    M_Return_Message errorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(errorMessage);
                }
            }
        }
        #endregion

        #region [Audit Type]
        [HttpGet]
        public async Task<IActionResult> Get_All_Audit_Type()
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_All_Audit_Type();
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Type = data,
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
        #endregion

        #region[Audit Schedule - Service Provider]
        [HttpPost]
        public async Task<IActionResult> Get_All_Audit_Schedule(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_All_Audit_Schedule(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add_Audit_Schedule(Audit_Schedule_Model entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_Audit_Schedule(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetById_AM_AuditSchedule(Audit_Schedule_Model entity)
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
                var data = await unitOfWork.MAuditMasterRepo.GetById_AM_AuditSchedule(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_By_Sch = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };
                    return Ok(errorMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Audit_Findings_Chk(Audit_Schedule_Model entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_Audit_Findings_Chk(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetbyIdAudit_CheckList(Audit_Schedule_Model entity)
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
                var data = await unitOfWork.MAuditMasterRepo.GetbyIdAudit_CheckList(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_ByID_Chk = data,
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message errorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };
                    return Ok(errorMessage);
                }
            }
        }

        #endregion

        #region [Audit Schedule - Internal Audit]
        [HttpPost]
        public async Task<IActionResult> Get_All_Internal_Audit(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_All_Internal_Audit(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Aud_Internal_Audit = data,
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
        public async Task<IActionResult> Add_Internal_Audit(Aud_Internal_Audit entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_Internal_Audit(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetBy_Id_Internal_Audit(Aud_Internal_Audit entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.GetByIdInternalAudit(entity);
            if (data != null)
            {
                var b = new
                {
                    Getby_Aud_Internal_Audit = data,
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
        public async Task<IActionResult> GetByIdInternalAuditSed(Aud_Internal_Audit entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.GetByIdInternalAuditSed(entity);
            if (data != null)
            {
                var b = new
                {
                    Getby_Aud_Internal_Audit = data,
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
        public async Task<IActionResult> Add_Internal_Aud_CheckList(List<Internal_Aud_CheckList> entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_Internal_Aud_CheckList(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Internal_Aud_CheckList(Aud_Internal_Audit entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_Internal_Aud_CheckList(entity);
            if (data != null)
            {
                var b = new
                {
                    GetbyId_Aud_Internal_Audit_Checklist = data,
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
        public async Task<IActionResult> Add_NCR_Report_Form(Aud_Internal_NCR_Form entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Add_NCR_Report_Form(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update_NCR_Report_Form(Aud_Internal_NCR_Form entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Update_NCR_Report_Form(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Internal_Audit_Audit_Team(Aud_Internal_Audit entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Get_Internal_Audit_Audit_Team(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Complete_NCR_Report_Form(Aud_Internal_Audit entity)
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
                var data = await unitOfWork.MAuditMasterRepo.Complete_NCR_Report_Form(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code,
                    };
                    return Ok(b);
                }
                else
                {
                    M_Return_Message ErrorMessage = new M_Return_Message()
                    {
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(ErrorMessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_NCR_Report_Form_Details(Aud_Internal_NCR_Form entity)
        {
            var data = await unitOfWork.MAuditMasterRepo.Get_NCR_Report_Form_Details(entity);
            if (data != null)
            {
                var b = new
                {
                    Getby_Aud_Internal_NCR_Form = data,
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
