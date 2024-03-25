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
    public class ServiceStatisticsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public ServiceStatisticsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> GetService_Monthly_Statics(ServiceMonthlyStatistics entity)
        {
            var data = await unitOfWork.MServiceMonthlyStatistics.Get_Service_Monthly_Statics(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Service_Monthly_Statics_Filter(ServiceMonthlyStatistics entity)
        {
            var data = await unitOfWork.MServiceMonthlyStatistics.Get_Service_Monthly_Statics_Filter(entity);
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
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_Service_Monthly_Statics(ServiceMonthlyStatistics entity)
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
                var data = await unitOfWork.MServiceMonthlyStatistics.Add_Service_Monthly_Statics(entity);
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
        public async Task<IActionResult> Edit_Service_Monthly_Statics(ServiceMonthlyStatistics entity)
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
                var data = await unitOfWork.MServiceMonthlyStatistics.Edit_Service_Monthly_Statics(entity);
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

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult Training_Evidence_Upload(List<IFormFile> formFiles)
        {
            var Module_Name = "Training_FilePath";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult Training_LegalEvidence_Upload(List<IFormFile> formFiles)
        {
            var Module_Name = "Training_LegalFilePath";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult Training_OtherEvidence_Upload(List<IFormFile> formFiles)
        {
            var Module_Name = "Training_OtherFilePath";
            var data = unitOfWork.CommonMediaUploadRepo.UploadImage(formFiles, Module_Name);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Service_Monthly_Statics_Approve(ServiceMonthlyStatistics entity)
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
                var data = await unitOfWork.MServiceMonthlyStatistics.Service_Monthly_Statics_Approve(entity);
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
        public async Task<IActionResult> Service_Monthly_Statics_Reject(Reject_Reason entity)
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
                var data = await unitOfWork.MServiceMonthlyStatistics.Service_Monthly_Statics_Reject(entity);
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
    }
}
