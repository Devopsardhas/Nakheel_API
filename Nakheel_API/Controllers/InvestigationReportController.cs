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
    public class InvestigationReportController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public InvestigationReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> IncInve_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MInvestigationReportRepo.IncNotificationGetAll(entity);
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
        public async Task<IActionResult> Investigation_Add(M_Investigation_Report entity)
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
                var data = await unitOfWork.MInvestigationReportRepo.AddAsync(entity);
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

        [HttpPost]
        public async Task<IActionResult> Investigation_Update(M_Investigation_Report entity)
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
                var data = await unitOfWork.MInvestigationReportRepo.UpdateAsync(entity);
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
        public async Task<IActionResult> Get_Investigation_Details(M_Investigation_Report entity)
        {
            var data = await unitOfWork.MInvestigationReportRepo.GetByIdAsync(entity);
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
                };

                return Ok(errormessage);
            }

        }
    }
}
