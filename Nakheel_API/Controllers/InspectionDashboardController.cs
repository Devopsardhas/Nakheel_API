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
    public class InspectionDashboardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public InspectionDashboardController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Insp_Dash_Zone_GetAll(Insp_Dash_ZoneWise Login)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dash_Zone_GetAll(Login);
            if (data.Count > 0)
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
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Insp_Dash_Community_GetAll(M_Community_Master entity)
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
                var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dash_CommunityByZone(entity);
                if (data.Count > 0)
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
                        Message = M_Return_Status_Text.FAILED,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.FAILED
                    };

                    return Ok(errormessage);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insp_Dash_Building_GetAll(M_Building_Master entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dash_Building_byZone(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All_Sub = data,
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

        [HttpGet]
        public async Task<IActionResult> Insp_Dash_Filter_HSETeam_GetAll()
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dash_Filter_HSETeam_GetAll();
            if (data.Count > 0)
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
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Inspection_Dashboard(DashboardParam entity)
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
                var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dashboard(entity);
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
        public async Task<IActionResult> Get_Insp_Dash_Cat_Onchange(DashboardParam entity)
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
                var data = await unitOfWork.MInspectionDashboardRepo.Insp_Dash_Cat_Onchange(entity);
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
        public async Task<IActionResult> Get_Insp_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Get_Insp_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Insp_Sch_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Get_Insp_Sch_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Insp_Walk_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Get_Insp_Walk_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Insp_Type_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Get_Insp_Type_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Get_Insp_Service_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Get_Insp_Service_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Insp_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MInspectionDashboardRepo.Insp_Main_Dash_Card_View_Data(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    Message = M_Return_Status_Text.SUCCESS,
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = M_Return_Status_Code.OK,
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = M_Return_Status_Text.NODATA,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.NODATA,
                };

                return Ok(errormessage);
            }

        }
    }
}
