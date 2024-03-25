using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using static Dapper.SqlMapper;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class EmergencyAlertController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmergencyAlertController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Emr_Alert_GetAll(DataTableAjaxPostModel entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.AlertRepo.Alert_GetAll(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.SuccessDT(data, data[0].RecordsTotal!, data[0].RecordsFiltered!);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> Alert_M_Add(EMR_Alert entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.AddAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Emr_Alert_GetBy_Id(Drill_Alert_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.AlertRepo.Alert_GetById(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        #region Spot

        [HttpPost]
        public async Task<IActionResult> Alert_Spot_Delete(Drill_Alert_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_Spot_Delete(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Alert_Mitigation_CHG(Drill_Alert_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.AlertRepo.Alert_Spot_GetBy_Mitig_ID(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region Reject Reason
        [HttpPost]
        public async Task<IActionResult> Alert_M_Reject(EMR_Reject entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_Spot_Reject_Add(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        [HttpPost]
        public async Task<IActionResult> Alert_M_Approve(EMR_Reject entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_Spot_Approve_Add(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region Checklist

        [HttpGet]
        public async Task<IActionResult> EMR_CHK_GetAll()
        {
            var data = await unitOfWork.AlertRepo.Alert_CHK_GetAll();

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }
        [HttpPost]
        public async Task<IActionResult> EMR_CHK_Add(List<EMR_Alert_CHK> entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_CHK_Add(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> EMR_CHK_GetByID(EMR_Alert_CHK entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_CHK_GetByID(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> EMR_CHK_Delete(EMR_Alert_CHK entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.AlertRepo.Alert_CHK_Delete(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion
    }
}
