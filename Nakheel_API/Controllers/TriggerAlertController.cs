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
    public class TriggerAlertController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public TriggerAlertController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpPost]
        public async Task<IActionResult> TRG_Alert_GetAll(DataTableAjaxPostModel entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.AlertTRG_GetAll(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.SuccessDT(data, data[0].RecordsTotal!, data[0].RecordsFiltered!);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Alert_Add(List<Trigger> entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.AddAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Alert_GetBy_Id(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.GetByIdAsync(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Alert_Assignee(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.Get_Mitigation_Assignee(entity);

            if (data != null && data.ServiceProviders != null && data.ServiceProviders.Count > 0)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        #region Assignee
        [HttpPost]
        public async Task<IActionResult> Alert_Assignee_GetAll(DataTableAjaxPostModel entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.Alert_Assignee_GetAll(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.SuccessDT(data, data[0].RecordsTotal!, data[0].RecordsFiltered!);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Assignee_Add(TRIG_Assignee entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Add_Assignee(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Alert_Action_Get(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.Alert_Act_GetById(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Checklist_Add(ChecklistMap entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Add_Assignee_Checklist(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        [HttpPost]
        public async Task<IActionResult> TRG_Checklist_Update(ChecklistMap entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Update_Assignee_Checklist(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Checklist_Update_ST(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Update_Checklist_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        [HttpPost]
        public async Task<IActionResult> TRG_CHK_GetBySpotID(Trigger_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.TriggerRepo.Checklist_GetBy_SpotId(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpGet]
        public async Task<IActionResult> Get_All_EMR_Category()
        {
            var data = await unitOfWork.TriggerRepo.Get_All_Emergency_Type();
            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region Reject
        [HttpPost]
        public async Task<IActionResult> TRG_Checklist_Reject(TRIG_Reject entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Alert_Trig_Reject(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> TRG_Checklist_Rej_Update(TRIG_Reject entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.TriggerRepo.Alert_Trig_Rej_Update(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region File Upload
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult UploadPhoto(List<IFormFile> formFiles)
        {
            var data = unitOfWork.CommonMediaUploadRepo.Drill_UploadPhoto(formFiles, "2");
            return Ok(data);
        }
        #endregion


    }
}
