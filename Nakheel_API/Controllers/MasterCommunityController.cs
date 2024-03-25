using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODELS;

namespace Nakheel_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterCommunityController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public MasterCommunityController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #region [Master Community]
        [HttpPost]
        public async Task<IActionResult> MasterCommunity_Master_Add(M_MasterCommunity_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.AddAsync(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> MasterCommunity_Master_Update(M_MasterCommunity_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.UpdateAsync(entity);
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

        [HttpGet]
        public async Task<IActionResult> MasterCommunity_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.GetAllAsync();
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
        public async Task<IActionResult> Master_Community_GetById(M_MasterCommunity_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.GetByIdAsync(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Master_Community_Delete(M_MasterCommunity_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.DeleteAsync(entity);
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
        public async Task<IActionResult> Sub_Master_Community_Delete(M_MasterCommunity_List entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.SubDeleteAsync(entity);
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
        public async Task<IActionResult> Get_All_MasterCommunity_byZone(M_MasterCommunity_Master entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_MasterCommunity_byZone(entity);
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

        [HttpPost]
        public async Task<IActionResult> CheckMasterCommunity_Name(M_MasterCommunity_List entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.CheckMasterCommunity_Name(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        #endregion

        #region [LevelM Master]
        [HttpPost]
        public async Task<IActionResult> LevelM_Master_Add(Level_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.LevelM_Add(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> LevelM_Master_Update(Level_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.LevelM_Update(entity);
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
        [HttpGet]
        public async Task<IActionResult> LevelM_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_LevelM();
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
        public async Task<IActionResult> LevelM_GetById(Level_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Get_ById_LevelM(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> LevelM_Delete(Level_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.LevelM_Delete(entity);
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
        #endregion

        #region [Crisis Master]
        [HttpPost]
        public async Task<IActionResult> Crisis_Master_Add(Crisis_Team_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_Add(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> Crisis_Master_Update(Crisis_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_Update(entity);
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
        [HttpGet]
        public async Task<IActionResult> Crisis_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_Crisis();
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
        public async Task<IActionResult> Crisis_GetById(Crisis_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Get_ById_Crisis(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crisis_Delete(Crisis_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_Delete(entity);
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
        public async Task<IActionResult> Crisis_View(Crisis_Team_Master entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_View(entity);
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
        [HttpPost]
        public async Task<IActionResult> Crisis_Emp_List_Level_Id(Crisis_Master entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_Get_Emp_Level(entity);
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
                    Status_Code = M_Return_Status_Code.NODATA
                };

                return Ok(errormessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Crisis_Viewby_Emp(Crisis_Team_Master entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Crisis_Viewby_Emp(entity);
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
        #endregion

        #region [Emergency Category]
        [HttpPost]
        public async Task<IActionResult> Emergency_Category_Add(Emergency_Category_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Emergency_Category_Add(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> Emergency_Category_Update(Emergency_Category_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Emergency_Category_Update(entity);
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
        [HttpGet]
        public async Task<IActionResult> Emergency_Category_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_Emergency_Category();
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
        public async Task<IActionResult> Emergency_Category_GetById(Emergency_Category_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Get_ById_Emergency_Category(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Emergency_Category_Delete(Emergency_Category_Master entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Emergency_Category_Delete(entity);
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
        #endregion

        #region [Scope_of_Work]
        [HttpPost]
        public async Task<IActionResult> Scope_of_Work_Add(Service_Provider_Scope_of_Work entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Scope_of_Work_Add(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> Scope_of_Work_Update(Service_Provider_Scope_of_Work entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Scope_of_Work_Update(entity);
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
        [HttpGet]
        public async Task<IActionResult> Scope_of_Work_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_Scope_of_Work();
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
        public async Task<IActionResult> Scope_of_Work_GetById(Service_Provider_Scope_of_Work entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Get_ById_Scope_of_Work(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> Scope_of_Work_Delete(Service_Provider_Scope_of_Work entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Scope_of_Work_Delete(entity);
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
        #endregion

        #region [ERT Team]
        [HttpPost]
        public async Task<IActionResult> ERT_Team_Add(ERT_Team_Details entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.ERT_Team_Details_Add(entity);
                if (data != null)
                {
                    var b = new
                    {
                        Message = data.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = data.Status_Code
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
        public async Task<IActionResult> ERT_Team_Update(ERT_Team_Details entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.ERT_Team_Details_Update(entity);
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
        [HttpGet]
        public async Task<IActionResult> ERT_Team_Master_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Team_Details();
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
        public async Task<IActionResult> ERT_Team_GetById(ERT_Team_Details entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.Get_ById_ERT_Team_Details(entity);
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
                        Message = M_Return_Status_Text.NODATA,
                        Status = M_Return_Status_Code.FALSE,
                        Status_Code = M_Return_Status_Code.NODATA
                    };

                    return Ok(errormessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> ERT_Team_Delete(ERT_Team_Details entity)
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
                var data = await unitOfWork.MMasterCommunityMasterRepo.ERT_Team_Details_Delete(entity);
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
        public async Task<IActionResult> ERT_Team_Master_GetAll_Filter(ERT_Team_Details entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Team_Details_Filter(entity);
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
        #endregion

        #region [ERT TEAM DETAILS MASTERS ONLY --GET ALL]
        [HttpGet]
        public async Task<IActionResult> ERT_Department_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Department();
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

        [HttpGet]
        public async Task<IActionResult> ERT_Building_No_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Building_No();
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

        [HttpGet]
        public async Task<IActionResult> ERT_FloorNo_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_FloorNo();
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

        [HttpGet]
        public async Task<IActionResult> ERT_Role_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Role();
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

        [HttpGet]
        public async Task<IActionResult> ERT_Training_Status_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Training_Status();
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

        [HttpGet]
        public async Task<IActionResult> ERT_Type_GetAll()
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Get_All_ERT_Type();
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
        #endregion


        [HttpPost]
        public async Task<IActionResult> SafetyPer_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.SafetyPer_Main_Dash_Card_View_Data(entity);
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
        public async Task<IActionResult> Audit_Main_Dash_Card_View_Data(DashboardParam entity)
        {
            var data = await unitOfWork.MMasterCommunityMasterRepo.Audit_Main_Dash_Card_View_Data(entity);
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
