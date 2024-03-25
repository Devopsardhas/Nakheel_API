using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;
using System.Data;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    //[Authorize(Roles = "25")]
    public class DrillScheduleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DrillScheduleController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
       
        public async Task<IActionResult> Drill_SCH_GetAll(DataTableAjaxPostModel entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Schedule_GetAll(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.SuccessDT(data, data[0].RecordsTotal!, data[0].RecordsFiltered!);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_SCH_Get_Assignee(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Sch_Get_Assignee(entity);

            if (data != null && ApiResponseFactory.AllListsNotEmpty(data))
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Schedule_Add(Drill_Schedule entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.UpdateAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Schedule_Get(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Sch_Get_Details(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Sch_Update_ST(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Update_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Sch_Update_Action(Drill_Action_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Update_Action(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Sch_Update_IMP_Action(Drill_Action_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Update_IMP_Act(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #region Fire
        [HttpPost]
        public async Task<IActionResult> Drill_SCH_Fire_Add(Drill_Fire entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Add_Fire(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_SCH_Fire_Obsr_Add(Drill_Fire_Obsr entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Add_Fire_Obsr(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region Common Forms
        [HttpPost]
        public async Task<IActionResult> Drill_SCH_CMM_Frms_Add(Drill_CommonFRM entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Drill_Sch_Add_Cm_Drill(entity);
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
            var data = unitOfWork.CommonMediaUploadRepo.Drill_UploadPhoto(formFiles, "1");
            return Ok(data);
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult UploadVideo(List<IFormFile> formFiles)
        {
            var data = unitOfWork.CommonMediaUploadRepo.Drill_UploadVideo(formFiles, "1");
            return Ok(data);
        }
        #endregion

        #region Drill Actions
        [HttpPost]
        public async Task<IActionResult> Drill_Action_GetAll(DataTableAjaxPostModel entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Action_GetAll(entity);

            if (data != null && data != null && data.Count > 0)
            {
                var response = ApiResponseFactory.SuccessDT(data, data[0].RecordsTotal!, data[0].RecordsFiltered!);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.ErrorDT());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Action_GetByID(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Sch_Get_Actions(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Add_Closure(Improvement_Act entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Drill_Sch_Add_Closure(entity);

            if (data != null)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Reassign(Improvement_Act entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillSchedule.Reassign_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion

        #region Reject
        [HttpPost]
        public async Task<IActionResult> Drill_SCH_REJ_Add(Drill_REJ entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Update_Reject_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }
            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Photo_Update(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Update_Photo_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        [HttpPost]
        public async Task<IActionResult> Drill_Video_Update(Drill_Schedule_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }
            var data = await unitOfWork.DrillSchedule.Update_Video_Status(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }
        #endregion
    }
}
