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
    public class MitigationReportController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public MitigationReportController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Alert_Report_Get_All(Mitigation_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.MitigationRepo.GetAllAsync(entity);
            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Alert_Report_Add(Mitigation_Report entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.MitigationRepo.AddAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Alert_Report_GetBy_Id(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.MitigationRepo.GetByIdAsync(entity);
            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpGet]
        public async Task<IActionResult> Get_All_REF_ID()
        {
            var data = await unitOfWork.MitigationRepo.Get_All_REF_ID();
            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
    }
}
