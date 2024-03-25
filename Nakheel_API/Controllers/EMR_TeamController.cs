using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class EMR_TeamController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EMR_TeamController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> ERT_GetAll(ERT_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.ERTRepo.GetAllAsync(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> ERT_Add(EMR_Team entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.ERTRepo.AddAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> ERT_Update(EMR_Team entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.ERTRepo.UpdateAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

    }
}
