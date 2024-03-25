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
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public EmployeeMasterController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> Employee_Master_GetAll()
        {
            var data = await unitOfWork.EmployeeMaster.GetAllAsync();
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
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Employee_Master_Add(M_Employee_Management entity)
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
                var data = await unitOfWork.EmployeeMaster.AddAsync(entity);
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
        public async Task<IActionResult> Employee_Master_Delete(M_Employee_Management entity)
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
                var data = await unitOfWork.EmployeeMaster.DeleteAsync(entity);
                if (data != null)
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
        public async Task<IActionResult> Employee_Master_GetByID(M_Employee_Management entity)
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
                var data = await unitOfWork.EmployeeMaster.GetByIdAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_ById = data,
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
        public async Task<IActionResult> Employee_Master_Update(M_Employee_Management entity)
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
                var data = await unitOfWork.EmployeeMaster.UpdateAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_ById = data,
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
        public async Task<IActionResult> Get_Employee_Master_Filter(M_Employee_Master_Filter entity)
        {
            var data = await unitOfWork.EmployeeMaster.Get_Employee_Master_Filter(entity);
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
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Contact_GetByEmpID(M_Employee_Management entity)
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
                var data = await unitOfWork.EmployeeMaster.Get_Contact_GetByEmpID(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Get_ById = data,
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
        public async Task<IActionResult> Get_Employee_by_Role(M_Employee_Master_Filter_by_Role entity)
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
                var data = await unitOfWork.EmployeeMaster.Get_Employee_by_Role(entity);
                if (data != null)
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
        public async Task<IActionResult> Get_Employee_by_Zone(M_Employee_Master_Filter_by_Role entity)
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
                var data = await unitOfWork.EmployeeMaster.Get_Employee_by_Zone(entity);
                if (data != null)
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
        public async Task<IActionResult> Get_Employee_Filter(ServiceProviderSignUp entity)
        {
            var data = await unitOfWork.EmployeeMaster.Get_Employee_Filter(entity);
            if (data != null)
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

        [HttpGet]
        public async Task<IActionResult> Get_Employee_Master_Filter_Gold()
        {
            var data = await unitOfWork.EmployeeMaster.Get_Employee_Master_Filter_Gold();
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
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get_Employee_Master_Filter_Silver()
        {
            var data = await unitOfWork.EmployeeMaster.Get_Employee_Master_Filter_Silver();
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
                    Status_Code = "404",
                    RecordsTotal = "0",
                    RecordsFiltered = "0"
                };

                return Ok(errormessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Get_Employee_Master_Filter_Bronze(M_Employee_Master_Filter entity)
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
                var data = await unitOfWork.EmployeeMaster.Get_Employee_Master_Filter_Bronze(entity);
                if (data != null)
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
    }
}
