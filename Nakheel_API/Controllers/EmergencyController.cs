using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MODELS;
using System.Data.SqlClient;

using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class EmergencyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public EmergencyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #region[Emer Mitigationt]
        [HttpPost]
        public async Task<IActionResult> Emer_Mitigation_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MEmergencyRepo.GetAll_Emer_Miti(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
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
                    Status_Code = M_Return_Status_Code.NODATA,
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Emer_Mitigation_Add(M_Emer_Mitigation_Add entity)
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
                var data = await unitOfWork.MEmergencyRepo.Add_Emer_Miti(entity);
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
        public async Task<IActionResult> Emer_Miti_GetById(M_Emer_Mitigation_Add entity)
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
                var data = await unitOfWork.MEmergencyRepo.Emer_Miti_GetById(entity);
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
        public async Task<IActionResult> UpdateEmergency_MitigationStatus(Emergency_Mitigation_Update_History entity)
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
                var data = await unitOfWork.MEmergencyRepo.UpdateEmergency_MitigationStatus(entity);
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
        #endregion

        #region [Emer mitidationt Upload File]
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


        [HttpGet]
        public async Task<IActionResult> Emer_Alert_GetAll()
        {
            var data = await unitOfWork.MEmergencyRepo.GetAll_Emer_Alert();
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Emer_Alert_Add(Emergency_Alert_Master entity)
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
                var data = await unitOfWork.MEmergencyRepo.Add_Emer_Alert(entity);
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
        public async Task<IActionResult> Emer_Alert_GetById(Emergency_Alert_Master entity)
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
                var data = await unitOfWork.MEmergencyRepo.Emer_Alert_GetById(entity);
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
    }
}
