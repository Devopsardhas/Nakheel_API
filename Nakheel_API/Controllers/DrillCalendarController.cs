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
    public class DrillCalendarController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public DrillCalendarController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Drill_GetAllSchedule(Drill_Calendar_Param entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillCalendar.GetAllAsync(entity);

            if (data != null && data.Drill_SCH != null && data.Drill_SCH.Count > 0)
            {
                var response = ApiResponseFactory.Success(data);
                return Ok(response);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Schedule_Add(Drill_Calendar entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillCalendar.AddAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Schedule_Update(Drill_Calendar entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillCalendar.UpdateAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

        [HttpPost]
        public async Task<IActionResult> Drill_Schedule_Delete(Drill_Calendar entity)
        {
            if (entity == null)
            {
                return BadRequest(ApiResponseFactory.Invalid_Json());
            }

            var data = await unitOfWork.DrillCalendar.DeleteAsync(entity);
            if (data.Status_Code == "200")
            {
                return Ok(data);
            }

            return BadRequest(ApiResponseFactory.Error());
        }

    }
}
