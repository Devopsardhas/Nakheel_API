using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MODELS;
using Microsoft.AspNetCore.Authorization;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ServiceProviderSignup_DashboardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ServiceProviderSignup_DashboardController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #region [Service Provider dashboard]
        [HttpPost]
        public async Task<IActionResult> ServiceProviderDashboard(ServiceProviderSignup_Dashboard entity)
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
                var data = await unitOfWork.MServiceProviderSignupDashboardRepo.ServiceProvider_Dashboard(entity);
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
        public async Task<IActionResult> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity)
        {
            var data = await unitOfWork.MServiceProviderSignupDashboardRepo.ServiceProv_Dashboard_Card_View(entity);

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
        #endregion
    }
}
