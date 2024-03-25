using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class HandOverInspectionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public HandOverInspectionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #region [HandOver Building]
        [HttpPost]
        public async Task<IActionResult> Insp_HandOver_Building_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HandOver_Building_GetAllAsync(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Insp_HandOver_Building_Qn_Add(M_Insp_HandOver entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Update_HndOver_Building_Pending(M_Insp_HandOver entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_HndOver_Building_Pending(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_HandOver_Building_Qn_GetAll(M_Insp_HandOver entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_HandOver_Building_Qn_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HandOver_Bldg_View = data,
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
        public async Task<IActionResult> Insp_HandOver_Building_GetByID(M_Insp_HandOver entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.GetByIdAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Insp_HandOver_Building = data,
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
                        RecordsTotal = "0",
                        RecordsFiltered = "0"
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update_HndOver_Bldg_Qns_Approval(M_Insp_HandOver entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_HndOver_Bldg_Qns_Approval(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> HndOver_Insp_Reject(M_Insp_HndOver_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.HndOver_Insp_Reject(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Get_HndOver_Bldg_Qns_View(M_Insp_HandOver entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Get_HndOver_Bldg_Qns_View(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HandOver_Building = data,
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HndOver_Building_Assign_Action(M_Insp_HndOver_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.HndOver_Building_Assign_Action(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Add_HndOver_Bldg_Closure_Action(M_Insp_HndOver_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Add_HndOver_Bldg_Closure_Action(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> HandOver_Action_Closure_GetAll(M_Insp_HndOver_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HandOver_Action_Closure_GetAll(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    GetAll_HandOver_CA = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HandOver_Closure_GetById(M_Insp_HndOver_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.HandOver_Closure_GetById(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Insp_HandOver_Building = data,
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
                        Status_Code = "404"
                    };
                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> HandOver_Closure_Action_Approval(M_Insp_HndOver_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HandOver_Closure_Action_Approval(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HandOver_Closure_Action_Reject(M_Insp_HndOver_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HandOver_Closure_Action_Reject(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        #endregion
        #region [Health & Safety Building]
        [HttpPost]
        public async Task<IActionResult> Insp_HealthSafety_Building_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_GetAllAsync(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Insp_HealthSafety_Building_Add(M_Insp_HealthSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_HealthSafety(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2= data.Return_2
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
        public async Task<IActionResult> Insp_HealthSafety_Building_GetByID(M_Insp_HealthSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.GetByIdAsync_HealthSafety(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Insp_HealthSafety_Building = data,
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
        public async Task<IActionResult> Update_HealthSafety_Building_Pending(M_Insp_HealthSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_HealthSafety_Building_Pending(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_HealthSafety_CheckList_Qn_GetAll(M_Insp_HealthSafety_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_HealthSafety_CheckList_Qn_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HealthSafety_Bldg_View = data,
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
        public async Task<IActionResult> Insp_HealthSafety_Qns_GetAll(M_Insp_HealthSafety_Questionnaires entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_HealthSafety_Qns_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HealthSafety_Building = data,
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
        public async Task<IActionResult> Insp_HealthSafety_Qn_Add(M_Insp_HealthSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_Qns_HealthSafety(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = data.Return_2
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
        public async Task<IActionResult> Get_HealthSafety_Bldg_Qns_View(M_Insp_HealthSafety_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Get_HealthSafety_Bldg_Qns_View(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HealthSafety_Building = data,
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
                    Status_Code = "404"
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update_HealthSafety_Bldg_Qns_Approval(M_Insp_HealthSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_HealthSafety_Bldg_Qns_Approval(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> HealthSafety_Insp_Reject(M_Insp_HealthSafety_Assign_Team entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Insp_Reject(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Add_HealthSafety_Assign_Team(M_Insp_HealthSafety_Assign_Team entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Add_HealthSafety_Assign_Team(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> HealthSafety_Closure_Action_Add(M_Insp_HealthSafety_Assign_Team entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Closure_Action_Add(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> HealthSafety_Action_Closure_GetAll(M_Insp_HealthSafety_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Action_Closure_GetAll(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    GetAll_HealthSafety_CA = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HealthSafety_Closure_GetById(M_Insp_HealthSafety_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Closure_GetById(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_HealthSafety_Building = data,
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HealthSafety_Closure_Action_Approval(M_Insp_HealthSafety_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Closure_Action_Approval(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> HealthSafety_Closure_Action_Reject(M_Insp_HealthSafety_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.HealthSafety_Closure_Action_Reject(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        #endregion
        #region [Service Provider Inspection]
        [HttpPost]
        public async Task<IActionResult> Insp_ServiceProvider_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_GetAllAsync(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Insp_Service_Provider_Add(M_Insp_ServiceProvider_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_ServiceProvider(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_ServiceProvider_GetByID(M_Insp_ServiceProvider_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.GetByIdAsync_ServiceProvider(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Insp_Service_Provider = data,
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
        public async Task<IActionResult> Update_ServiceProvider_Schedule(M_Insp_ServiceProvider_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_ServiceProvider_Schedule(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_ServiceProvider_Qn_GetAll(M_Insp_ServiceProvider_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_ServiceProvider_Qn_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_Service_Provider = data,
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
        public async Task<IActionResult> Insp_ServiceProvider_Qn_Add(M_Insp_ServiceProvider_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_Qns_ServiceProvider(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 =  data.Return_2
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
        public async Task<IActionResult> Insp_ServiceProvider_Qn_HSSETeam(M_Insp_ServiceProvider_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Insp_ServiceProvider_Qn_HSSETeam(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Get_ServiceProvider_Qns_View(M_Insp_ServiceProvider_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Get_ServiceProvider_Qns_View(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_Service_Provider = data,
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
                    Status_Code = "404"
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update_ServiceProvider_Qns_Approval(M_Insp_Safety_Violation entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_ServiceProvider_Qns_Approval(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> ServiceProvider_Insp_Qns_Reject(M_Insp_ServiceProvider_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Insp_Qns_Reject(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add_ServiceProvider_Assign_Team(M_Insp_ServiceProvider_Assign_Team entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Add_ServiceProvider_Assign_Team(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> ServiceProvider_Closure_Action_Add(M_Insp_ServiceProvider_Assign_Team entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Closure_Action_Add(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> ServiceProvider_Action_Closure_GetAll(M_Insp_ServiceProvider_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Action_Closure_GetAll(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    GetAll_ServiceProvider_CA = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ServiceProvider_Closure_GetById(M_Insp_ServiceProvider_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Closure_GetById(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_Service_Provider = data,
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ServiceProvider_Closure_Action_Approval(M_Insp_ServiceProvider_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Closure_Action_Approval(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ServiceProvider_Closure_Action_Reject(M_Insp_ServiceProvider_Assign_Team entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.ServiceProvider_Closure_Action_Reject(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        #endregion
        #region [Fire & Life Safety Inspection]
        [HttpPost]
        public async Task<IActionResult> Insp_FireLifeSafety_Qns_GetAll(M_Insp_FireLifeSafety_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_FireLifeSafety_Qns_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_FireLifeSafety_Qns = data,
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
        public async Task<IActionResult> Insp_FireLifeSafety_GetAll(DataTableAjaxPostModel entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_GetAllAsync(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
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
        public async Task<IActionResult> Insp_FireLifeSafety_Add(M_Insp_FireLifeSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_FireLifeSafety(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_FireLifeSafety_GetByID(M_Insp_FireLifeSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Insp_FireLifeSafety_GetByID(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_Insp_FireLifeSafety = data,
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
        public async Task<IActionResult> Update_FireLifeSafety_Schedule(M_Insp_FireLifeSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_FireLifeSafety_Schedule(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Insp_FireLifeSafetyCS_Qns_GetAll(M_Insp_FireLifeSafety_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Insp_FireLifeSafetyCS_Qns_GetAll(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_FireLifeSafety = data,
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
        public async Task<IActionResult> Insp_FireLifeSafety_QnObs_Add(M_Insp_FireLifeSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.AddAsync_Qns_FireLifeSafety(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
                {
                    var b = new
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_2 = data.Return_2
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
        public async Task<IActionResult> Get_FireLifeSafety_Qns_View(M_Insp_FireLifeSafety_Master entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.Get_FireLifeSafety_Qns_View(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_FireLifeSafety = data,
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update_FireLifeSafety_Qns_Approval(M_Insp_FireLifeSafety_Master entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Update_FireLifeSafety_Qns_Approval(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> Add_FireLifeSafety_Assign_Team(M_Insp_FireLifeSafety_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.Add_FireLifeSafety_Assign_Team(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> FireLifeSafety_Closure_Action_Add(M_Insp_FireLifeSafety_Assign_Action entity)
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
                var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_Closure_Action_Add(entity);
                if (data.Status_Code == M_Return_Status_Code.OK)
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
        public async Task<IActionResult> FireLifeSafety_Action_Closure_GetAll(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_Action_Closure_GetAll(entity);
            if (data.Count > 0)
            {
                var b = new
                {
                    Get_All = data,
                    MESSAGE = "Success",
                    STATUS = true,
                    STATUS_CODE = "200"
                };
                return Ok(b);
            }
            else
            {
                M_Return_Message errormessage = new M_Return_Message()
                {
                    Message = "No Records Found",
                    Status = false,
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> FireLifeSafety_Closure_GetById(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_Closure_GetById(entity);
            if (data != null)
            {
                var b = new
                {
                    Get_Insp_FireLifeSafety = data,
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> FireLifeSafety_Closure_Action_Approval(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_Closure_Action_Approval(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> FireLifeSafety_Closure_Action_Reject(M_Insp_FireLifeSafety_Assign_Action entity)
        {
            var data = await unitOfWork.MHandOverInspectionRepo.FireLifeSafety_Closure_Action_Reject(entity);
            if (data != null)
            {
                var b = new
                {
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
                    Status_Code = "404"
                };
                return Ok(errormessage);
            }
        }
        #endregion
        #region [CheckList Upload Files]
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult UploadImage(List<IFormFile> formFiles)
        {
            var data = unitOfWork.MHandOverInspectionRepo.UploadImage(formFiles);
            return Ok(data);
        }
        [RequestSizeLimit(2147483648)]
        [HttpPost]
        public IActionResult Upload_Picture(List<IFormFile> formFiles)
        {
            var data = unitOfWork.MHandOverInspectionRepo.Upload_Picture(formFiles);
            return Ok(data);
        }
        #endregion
    }
}
