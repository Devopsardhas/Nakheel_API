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
    public class DashboardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> Get_Incident_Dashboard1(DashboardParam entity)
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
                var data = await unitOfWork.MDashboardRepo.Incident_Dashboard_New(entity);
                if (data != null)
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
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };
                    return Ok(errormessage);
                }

            }

        }


        [HttpPost]
        public async Task<IActionResult> Get_Incident_Dashboard(DashboardParam entity)
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
                var data = await unitOfWork.MDashboardRepo.Incident_Dashboard(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Data = data,
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
        public async Task<IActionResult> Incident_Dashboard_Card_View(Dashboard_Table_View_Param entity)
        {
            var data = await unitOfWork.MDashboardRepo.Incident_Dashboard_Card_View(entity);

            if (data.Count > 0)
            {
                var b = new
                {
                    Get_Data = data,
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
        public async Task<IActionResult> Inc_Dash_Card_View(Dashboard_Table_View_Param entity)
        {
            var data = await unitOfWork.MDashboardRepo.Inc_Dash_Card_View(entity);

            if (data.Count > 0)
            {
                var b = new
                {
                    Get_Data = data,
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
        public async Task<IActionResult> Get_Observation_Dashboard(DashboardParam entity)
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
                var data = await unitOfWork.MDashboardRepo.Get_Observation_Dashboard(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Data = data,
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
        public async Task<IActionResult> Observation_Dashboard_Card_View(Dashboard_Table_View_Param entity)
        {
            var data = await unitOfWork.MDashboardRepo.Observation_Dashboard_Card_View(entity);

            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Observation_Report = data,
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
