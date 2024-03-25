using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class InspectionFormRepo : IInspectionFormRepo
    {
        private readonly IConfiguration configuration;
        private IHostingEnvironment Environment;

        public InspectionFormRepo(IConfiguration configuration, IHostingEnvironment _environment)
        {
            this.configuration = configuration;
            Environment = _environment;

        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Spot Insp]

        #region [Insp Spot Request]
        public Task<IReadOnlyList<M_Insp_Request>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IReadOnlyList<M_Insp_Request>> Insp_Request_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Request_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_Add";
                string procedure1 = "sp_Insp_Request_Document_Review_Add";
                string procedure2 = "sp_Insp_Spot_History_Approval_Add";
                //string procedure8 = "sp_Upcoming_Activity_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Insp_Type_Id == "Document_Review")
                    {
                        entity.Category_Id = "0";
                    }
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_Req_Doc_Review_List != null && entity.Insp_Req_Doc_Review_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_Req_Doc_Review_List)
                            {
                                var parameters1 = new
                                {
                                    Req_Document_Review_Id = item.Req_Document_Review_Id,
                                    Insp_Request_Id = obj.Return_1,
                                    Req_Document_Name = item.Req_Document_Name,
                                    Req_Document_Description = item.Req_Document_Description,
                                    File_Path = item.File_Path,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters2 = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        //var Module_Name = "";
                        //if (entity.Insp_Type_Id == "Inspection")
                        //{
                        //    Module_Name = "Spot Inspection";
                        //}
                        //else
                        //{
                        //    Module_Name = "Document Review";
                        //}
                        //var parameters_8 = new
                        //{
                        //    Schedule_Type_Id = obj.Return_1,
                        //    Zone_Id = entity.Zone_Id,
                        //    Community_Id = entity.Community_Id,
                        //    Building_Id = entity.Building_Id,
                        //    Module_Name = @Module_Name,
                        //    Hyper_Link = "/Inspection/Insp_Request",
                        //    CreatedBy = entity.CreatedBy
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Request_Form : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_Update";
                string procedure1 = "sp_Insp_Request_Document_Review_Add";
                string procedure2 = "sp_Insp_Spot_History_Approval_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Req_Description = entity.Req_Description,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_Req_Doc_Review_List != null && entity.Insp_Req_Doc_Review_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_Req_Doc_Review_List)
                            {
                                var parameters1 = new
                                {
                                    Req_Document_Review_Id = item.Req_Document_Review_Id,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Req_Document_Name = item.Req_Document_Name,
                                    Req_Document_Description = item.Req_Document_Description,
                                    File_Path = item.File_Path,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters2 = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Request> GetByIdAsync(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Request_Reject_GetbyId";
                string procedure11 = "sp_Insp_Spot_Finding_GetbyId";
                string procedure12 = "sp_Insp_Spot_Sub_Finding_GetbyId";
                string procedure13 = "sp_Insp_Spot_Sub_Category_GetbyId";
                string procedure14 = "sp_Insp_Spot_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure17 = "sp_Insp_Sub_Category_Master_GetbyId";
                string procedure18 = "sp_Insp_Spot_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Spot_Corrective_Action_GetbyId";
                string procedure20 = "sp_Insp_Spot_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Spot_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Spot_CA_ReAssign_GetbyId";
                string procedure23 = "sp_Insp_Req_Document_Review_GetbyId";
                string procedure24 = "sp_Insp_Supervisor_Finding_GetbyId";
                string procedure25 = "sp_Insp_Spot_History_Approval_GetbyId";
                string procedure26 = "sp_Insp_Spot_Provider_Com_Name_GetbyId";


                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var Obj_Doc = (await connection.QueryAsync<Insp_Req_Doc_Review>(procedure23, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_App_His = (await connection.QueryAsync<Insp_Req_Approval_History>(procedure25, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Doc != null)
                        {
                            Obj.Insp_Req_Doc_Review_List = Obj_Doc;
                        }
                        if (Obj_App_His != null)
                        {
                            Obj.Insp_Req_Approval_History_List = Obj_App_His;
                        }
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = new List<M_Insp_Value_Text>();
                        Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                        Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                        }
                        else
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Request_Reject != null)
                            {
                                Obj!.Insp_Request_Reject_List = Request_Reject;
                            }
                        }
                        var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj_Finding != null)
                        {
                            Obj_Finding!.Insp_Spot_Provider_Com_Name_List = new List<M_Insp_Value_Text>();
                            Obj_Finding.Main_Status = Obj.Status;
                            Obj_Finding.Req_Createdby = Obj.CreatedBy;
                            Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                            Obj_Finding.Zone_Name = Obj.Zone_Name;
                            Obj_Finding.Community_Name = Obj.Community_Name;
                            Obj_Finding.Building_Name = Obj.Building_Name;
                            Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                            Obj_Finding.Req_Description = Obj.Req_Description;
                            DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                            Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                            Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                            Obj_Finding.Insp_Category_Name = Obj.Insp_Category_Name;
                            var parameters_Emp = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Rej = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                            };
                            if (Obj_App_His != null)
                            {
                                Obj_Finding.Insp_Req_Approval_History_List = Obj_App_His;
                            }
                            var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                            }
                            var Obj_Supervisor_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure24, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Supervisor_List != null && Obj_Supervisor_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Supervisor_Master_List = Obj_Supervisor_List;
                            }
                            var Obj_Cat_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();

                            if (Obj_Cat_List != null && Obj_Cat_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Category_Master_List = Obj_Cat_List;
                            }
                            var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                            {
                                Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                            }
                            var Obj_Provider_Com_Name_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure26, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Provider_Com_Name_List != null && Obj_Provider_Com_Name_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Provider_Com_Name_List = Obj_Provider_Com_Name_List;
                            }
                            var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                                foreach (var item in Obj_Sub_Finding)
                                {
                                    var parameters_Sub = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    };
                                    var parameters_Ca = new
                                    {
                                        Insp_Category_Id = item.Category,
                                    };
                                    var parameters_Sub1 = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                        CreatedBy = entity.CreatedBy,
                                    };
                                    var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                                    if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                                    {
                                        item.Insp_Spot_Category_Master_List = Obj_Cat_List_Mas;
                                    }
                                    var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure13, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure17, parameters_Ca, commandType: CommandType.StoredProcedure)).ToList();

                                    if (Obj_Sub_Cat_Mas_List != null && Obj_Sub_Cat_Mas_List.Count > 0)
                                    {
                                        item.Insp_Spot_Sub_Category_Master_List = Obj_Sub_Cat_Mas_List;
                                    }

                                    if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                                    }
                                    if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                    }
                                    if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                    {
                                        foreach (var itemss in Obj_Sub_Finding_CA)
                                        {
                                            var parameters_Cass = new
                                            {
                                                Corrective_Action_Id = itemss.Corrective_Action_Id,
                                            };
                                            var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                            }
                                            if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                            }
                                            if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                            }
                                        }
                                        item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                    }
                                }
                            }
                            Obj.Insp_Spot_Finding_List = Obj_Finding;
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Request_Form : GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> DeleteAsync(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Request_Form : DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Request_ApprovalReject(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Inspection_Date = entity.Inspection_Date,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Request_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImage(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("FilePath");

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/InspImages"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.presentationml.presentation" || postedFile.ContentType == "application/pdf" || postedFile.ContentType == "application/vnd.ms-powerpoint" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document" || postedFile.ContentType == "doc" || postedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadPicture(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("ImagePath");

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/Insp_Picture"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "image/bmp")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImagePdf(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("FilePath");

                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/InspImages"));

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "application/pdf")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<List<M_Insp_Value_Text>> Insp_Sub_Category_Master_GetbyId(M_Insp_Value_Text entity)
        {
            try
            {
                string procedure = "sp_Insp_Sub_Category_Master_GetbyId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Category_Id = entity.Value
                    };
                    return (await connection.QueryAsync<M_Insp_Value_Text>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Category_Master_GetbyId";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Req_Photo_Delete(Insp_Req_Doc_Review entity)
        {
            try
            {
                string procedure = "sp_Insp_Req_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Req_Document_Review_Id = entity.Req_Document_Review_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Req_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Insp Spot Finding]
        public async Task<M_Return_Message> Add_Insp_Spot_Finding(M_Insp_Spot_Finding entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Spot_Finding_Add";
                string procedure2 = "sp_Insp_Spot_Sub_Finding_Add";
                string procedure3 = "sp_Insp_Spot_Sub_Category_Add";
                string procedure4 = "sp_Insp_Spot_Sub_Photos_Add";
                string procedure5 = "sp_Insp_Request_Finding_Status_Update_GetbyId";
                string procedure6 = "sp_Insp_Spot_Sub_Category_Delete";
                string procedure7 = "sp_Insp_Spot_History_Approval_Find_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters1 = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        NCM_Supervisor = entity.NCM_Supervisor,
                        NCM_Community_Manager = entity.NCM_Community_Manager,
                        Zone_Rep_Attended = entity.Zone_Rep_Attended,
                        Service_Provider_Attended = entity.Service_Provider_Attended,
                        Zone_Rep_Id = entity.Zone_Rep_Id,
                        Service_Provider_ID = entity.Service_Provider_ID,
                        CreatedBy = entity.CreatedBy,
                        Safety_Violation = entity.Safety_Violation,
                        S_P_Representative_Name = entity.S_P_Representative_Name,
                    };
                    var parameters5 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Safe_Id = "0";
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.Insp_Spot_Sub_Finding_List != null && entity.Insp_Spot_Sub_Finding_List.Count > 0)
                        {
                            foreach (var item1 in entity.Insp_Spot_Sub_Finding_List!)
                            {
                                var parameters2 = new
                                {
                                    Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                    Insp_Finding_Id = Obj.Status_Code,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Observations = item1.Observations,
                                    Latitude = item1.Latitude,
                                    Longitude = item1.Longitude,
                                    Hazard_Risk = item1.Hazard_Risk,
                                    Requirements = item1.Requirements,
                                    Action_Required = item1.Action_Required,
                                    Category = item1.Category,
                                    Risk_Level = item1.Risk_Level,
                                    CreatedBy = entity.CreatedBy,
                                    Location_Address = item1.Location_Address,
                                    Exact_Location_Address = item1.Exact_Location_Address,
                                };
                                var Obj1 = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                if (Obj1 != null)
                                {
                                    if (item1.Insp_Spot_Find_Sub_Category_List != null && item1.Insp_Spot_Find_Sub_Category_List.Count > 0)
                                    {
                                        if (item1.Insp_Sub_Finding_Id != "0")
                                        {
                                            var parameters6 = new
                                            {
                                                Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                            };
                                            var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure6, parameters6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                        foreach (var item2 in item1.Insp_Spot_Find_Sub_Category_List!)
                                        {
                                            var parameters3 = new
                                            {
                                                Insp_Sub_Finding_Sub_Cat_Id = item2.Insp_Sub_Finding_Sub_Cat_Id,
                                                Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                Insp_Finding_Id = Obj.Status_Code,
                                                Insp_Request_Id = entity.Insp_Request_Id,
                                                Insp_Sub_Category_Id = item2.Insp_Sub_Category_Id,
                                                CreatedBy = entity.CreatedBy,
                                            };
                                            var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                    }

                                    if (item1.Insp_Spot_Find_Sub_Photo_List != null && item1.Insp_Spot_Find_Sub_Photo_List.Count > 0)
                                    {
                                        foreach (var item3 in item1.Insp_Spot_Find_Sub_Photo_List!)
                                        {
                                            var parameters4 = new
                                            {
                                                Insp_Sub_Photo_Id = item3.Insp_Sub_Photo_Id,
                                                Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                Insp_Finding_Id = Obj.Status_Code,
                                                Insp_Request_Id = entity.Insp_Request_Id,
                                                File_Path = item3.File_Path,
                                                CreatedBy = entity.CreatedBy,
                                            };
                                            var Obj3 = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    var parameters7 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure7, parameters7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var obj_Safe = (await connection.QueryAsync<M_Return_Message>(procedure5, parameters5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj_Safe != null)
                    {
                        Safe_Id = obj_Safe.Return_2;
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_1 = entity.Insp_Request_Id,
                        Return_2 = Safe_Id,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Add_Insp_Spot_Finding";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Insp_Find_ApprovalReject(M_Insp_Finding_Approval entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Finding_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Find_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Spot_Sub_Finding> Insp_Sub_Find_List_GetById(M_Insp_Spot_Sub_Finding entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Spot_Sub_Finding_Rej_GetbyId";
                string procedure2 = "sp_Insp_Spot_Sub_Category_GetbyId";
                string procedure3 = "sp_Insp_Spot_Sub_Photos_GetbyId";
                string procedure4 = "sp_Insp_Category_Master_GetAll";
                string procedure5 = "sp_Insp_Sub_Category_Master_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Finding_Id = entity.Insp_Sub_Finding_Id
                    };

                    var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj_Sub_Finding != null)
                    {
                        var parameters1 = new
                        {
                            Insp_Category_Id = Obj_Sub_Finding.Category,
                        };
                        var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure2, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure4, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Sub_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure5, parameters1, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                        }
                        if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                        }
                        if (Obj_Cat_Mas_List != null && Obj_Cat_Mas_List.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Category_Master_List = Obj_Cat_Mas_List;
                        }
                        if (Obj_Sub_Cat_Mas_List != null && Obj_Sub_Cat_Mas_List.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Sub_Category_Master_List = Obj_Sub_Cat_Mas_List;
                        }
                    }
                    return Obj_Sub_Finding;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Find_List_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Sub_Photos_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Photo_Id = entity.Insp_Sub_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Find_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Sub_Finding_Delete(M_Insp_Spot_Sub_Finding entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Sub_Finding_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Finding_Id = entity.Insp_Sub_Finding_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Finding_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Spot_WalkIn_Master> Load_Spot_Find_WalkinZone(M_Insp_Spot_WalkIn_Master entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Supervisor_Walkin_Master_GetbyId";
                string procedure2 = "sp_Insp_Rep_Walkin_Master_GetbyId";
                string procedure3 = "sp_Insp_SP_Com_Name_Walkin_Master_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    M_Insp_Spot_WalkIn_Master obj = new M_Insp_Spot_WalkIn_Master();
                    obj.Zone_Super_Master_List = new List<M_Insp_Value_Text>();
                    obj.Zone_Rep_Master_List = new List<M_Insp_Value_Text>();
                    obj.Zone_Service_Provider_Master_List = new List<M_Insp_Value_Text>();
                    var parameters = new
                    {
                        Zone_Id = entity.Value,
                    };
                    var ZoneSuper = (await connection.QueryAsync<M_Insp_Value_Text>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ZoneRep = (await connection.QueryAsync<M_Insp_Value_Text>(procedure2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    var ZoneSp = (await connection.QueryAsync<M_Insp_Value_Text>(procedure3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    if (ZoneSuper != null && ZoneSuper.Count > 0)
                    {
                        obj.Zone_Super_Master_List = ZoneSuper;
                    }
                    if (ZoneRep != null && ZoneRep.Count > 0)
                    {
                        obj.Zone_Rep_Master_List = ZoneRep;
                    }
                    if (ZoneSp != null && ZoneSp.Count > 0)
                    {
                        obj.Zone_Service_Provider_Master_List = ZoneSp;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Load_Spot_Find_WalkinZone";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Insp_Spot_Walk_In_Finding(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_Add";
                string procedure1 = "sp_Insp_Spot_Finding_Add";
                string procedure2 = "sp_Insp_Spot_Sub_Finding_Add";
                string procedure3 = "sp_Insp_Spot_Sub_Category_Add";
                string procedure4 = "sp_Insp_Spot_Sub_Photos_Add";
                string procedure5 = "sp_Insp_Request_Finding_Status_WalkIn_Update_GetbyId";
                string procedure6 = "sp_Insp_Spot_Sub_Category_Delete";
                string procedure7 = "sp_Insp_Spot_History_WalkIn_Approval_Find_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                    };
                    var Safe_Id = "0";
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        var parameters5 = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        if (entity.Insp_Spot_Finding_List != null)
                        {
                            var parameters1 = new
                            {
                                Insp_Finding_Id = entity.Insp_Spot_Finding_List.Insp_Finding_Id,
                                Insp_Request_Id = obj.Return_1,
                                NCM_Supervisor = entity.Insp_Spot_Finding_List.NCM_Supervisor,
                                NCM_Community_Manager = entity.Insp_Spot_Finding_List.NCM_Community_Manager,
                                Zone_Rep_Attended = entity.Insp_Spot_Finding_List.Zone_Rep_Attended,
                                Service_Provider_Attended = entity.Insp_Spot_Finding_List.Service_Provider_Attended,
                                Zone_Rep_Id = entity.Insp_Spot_Finding_List.Zone_Rep_Id,
                                Service_Provider_ID = entity.Insp_Spot_Finding_List.Service_Provider_ID,
                                CreatedBy = entity.CreatedBy,
                                Safety_Violation = entity.Insp_Spot_Finding_List.Safety_Violation,
                                S_P_Representative_Name = entity.Insp_Spot_Finding_List.S_P_Representative_Name,
                            };

                            var Obj_Find = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (Obj_Find != null)
                            {
                                if (entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List != null && entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List.Count > 0)
                                {
                                    foreach (var item1 in entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List)
                                    {
                                        var parameters2 = new
                                        {
                                            Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                            Insp_Finding_Id = Obj_Find.Status_Code,
                                            Insp_Request_Id = obj.Return_1,
                                            Observations = item1.Observations,
                                            Latitude = item1.Latitude,
                                            Longitude = item1.Longitude,
                                            Hazard_Risk = item1.Hazard_Risk,
                                            Requirements = item1.Requirements,
                                            Action_Required = item1.Action_Required,
                                            Category = item1.Category,
                                            Risk_Level = item1.Risk_Level,
                                            CreatedBy = entity.CreatedBy,
                                            Location_Address = item1.Location_Address,
                                            Exact_Location_Address = item1.Exact_Location_Address,
                                        };
                                        var Obj1 = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        if (Obj1 != null)
                                        {
                                            if (item1.Insp_Spot_Find_Sub_Category_List != null && item1.Insp_Spot_Find_Sub_Category_List.Count > 0)
                                            {
                                                if (item1.Insp_Sub_Finding_Id != "0")
                                                {
                                                    var parameters6 = new
                                                    {
                                                        Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                                    };
                                                    var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure6, parameters6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                                }
                                                foreach (var item2 in item1.Insp_Spot_Find_Sub_Category_List!)
                                                {
                                                    var parameters3 = new
                                                    {
                                                        Insp_Sub_Finding_Sub_Cat_Id = item2.Insp_Sub_Finding_Sub_Cat_Id,
                                                        Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                        Insp_Finding_Id = Obj_Find.Status_Code,
                                                        Insp_Request_Id = obj.Return_1,
                                                        Insp_Sub_Category_Id = item2.Insp_Sub_Category_Id,
                                                        CreatedBy = entity.CreatedBy,
                                                    };
                                                    var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                                }
                                            }

                                            if (item1.Insp_Spot_Find_Sub_Photo_List != null && item1.Insp_Spot_Find_Sub_Photo_List.Count > 0)
                                            {
                                                foreach (var item3 in item1.Insp_Spot_Find_Sub_Photo_List!)
                                                {
                                                    var parameters4 = new
                                                    {
                                                        Insp_Sub_Photo_Id = item3.Insp_Sub_Photo_Id,
                                                        Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                        Insp_Finding_Id = Obj_Find.Status_Code,
                                                        Insp_Request_Id = obj.Return_1,
                                                        File_Path = item3.File_Path,
                                                        CreatedBy = entity.CreatedBy,
                                                    };
                                                    var Obj3 = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            var obj_Safe = (await connection.QueryAsync<M_Return_Message>(procedure5, parameters5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (obj_Safe != null)
                            {
                                Safe_Id = obj_Safe.Return_2;
                            }

                            var parameters7 = new
                            {
                                Insp_Request_Id = obj.Return_1,
                                Insp_Finding_Id = entity.Insp_Spot_Finding_List.Insp_Finding_Id,
                                CreatedBy = entity.CreatedBy,
                            };
                            var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure7, parameters7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_1 = obj!.Return_1,
                        Return_2 = Safe_Id,
                    };
                    return rETURN_MESSAGE;

                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Add_Insp_Spot_Walk_In_Finding";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        #endregion

        #region [Insp Spot Corrective Action]
        public async Task<IReadOnlyList<M_Insp_Request>> Insp_Spot_Corrective_Action_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Spot_Corrective_Action_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Spot_Corrective_Action_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Request> Insp_Spot_CA_GetById(M_Insp_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Request_Reject_GetbyId";
                string procedure11 = "sp_Insp_Spot_Finding_GetbyId";
                string procedure12 = "sp_Insp_Spot_Sub_Finding_GetbyId";
                string procedure13 = "sp_Insp_Spot_Sub_Category_GetbyId";
                string procedure14 = "sp_Insp_Spot_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure17 = "sp_Insp_Sub_Category_Master_GetbyId";
                string procedure18 = "sp_Insp_Spot_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Spot_Action_Closure_GetbyId";
                string procedure20 = "sp_Insp_Spot_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Spot_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Spot_CA_ReAssign_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                    Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                    Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                    Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                    Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                    Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                    Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                    Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                    if (entity.Insp_Request_Id == "0")
                    {
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                        if (Business_Unit_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Type_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                        }
                    }
                    else
                    {
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                        var parameters_Zone = new
                        {
                            Zone_Id = Obj.Zone_Id,
                            Community_Id = Obj.Community_Id,
                        };
                        var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                        var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Business_Unit_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                        }
                        if (Type_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                        }
                        if (Community_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                        }
                        if (Building_Master != null)
                        {
                            Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                        }
                        if (Request_Reject != null)
                        {
                            Obj!.Insp_Request_Reject_List = Request_Reject;
                        }
                    }
                    //if (Obj.Status == "Inspection Finding Pending" || Obj.Status == "Inspection Finding Approval Pending" || Obj.Status == "Inspection Finding Approved")
                    //{
                    var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj_Finding != null)
                    {
                        Obj_Finding.Main_Status = Obj.Status;
                        Obj_Finding.Req_Createdby = Obj.CreatedBy;
                        Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                        Obj_Finding.Zone_Name = Obj.Zone_Name;
                        Obj_Finding.Community_Name = Obj.Community_Name;
                        Obj_Finding.Building_Name = Obj.Building_Name;
                        Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                        Obj_Finding.Req_Description = Obj.Req_Description;
                        Obj_Finding.Insp_Category_Name = Obj.Insp_Category_Name;
                        DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                        Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                        Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                        var parameters_Emp = new
                        {
                            Zone_Id = Obj.Zone_Id,
                            Community_Id = Obj.Community_Id,
                        };
                        var parameters_Rej = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                        };
                        var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                        {
                            Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                        }
                        var Obj_Cat_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_Cat_List != null && Obj_Cat_List.Count > 0)
                        {
                            Obj_Finding.Insp_Spot_Category_Master_List = Obj_Cat_List;
                        }
                        var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                        {
                            Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                        }
                        var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                        {
                            Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                            foreach (var item in Obj_Sub_Finding)
                            {
                                var parameters_Sub = new
                                {
                                    Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                };
                                var parameters_Sub1 = new
                                {
                                    Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    CreatedBy = entity.CreatedBy,
                                };

                                var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure13, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();

                                if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                                {
                                    item.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                                }
                                if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                {
                                    item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                }
                                if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                {
                                    foreach (var itemss in Obj_Sub_Finding_CA)
                                    {
                                        var parameters_Cass = new
                                        {
                                            Corrective_Action_Id = itemss.Corrective_Action_Id,
                                        };
                                        var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                        var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                        var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                        if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                        {
                                            itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                        }
                                        if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                        {
                                            itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                        }
                                        if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                        {
                                            itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                        }
                                    }
                                    item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                }
                            }
                        }
                        Obj.Insp_Spot_Finding_List = Obj_Finding;
                    }
                    //}


                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Spot_CA_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Spot_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Corrective_Action_Add";
                string procedure1 = "sp_Insp_Spot_Corrective_Action_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Insp_Request_Id = entity[0].Insp_Request_Id,
                        CreatedBy = entity[0].CreatedBy,
                    };
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = item.Corrective_Action_Id,
                            Insp_Finding_Id = item.Insp_Finding_Id,
                            Insp_Request_Id = item.Insp_Request_Id,
                            Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                            Assignee_Type = item.Assignee_Type,
                            Responsibility_To = item.Responsibility_To,
                            Target_Date = item.Target_Date,
                            Action_Description = item.Action_Description,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure);

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Spot_Corrective_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Spot_CA_ReAssign(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_CA_ReAssign_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Responsibility_To = entity.Responsibility_To,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Spot_CA_ReAssign";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Spot_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_CA_Action_Closure_Add";
                string procedure1 = "sp_Insp_Spot_CA_Action_Closure_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Closure_Action_Description = entity.Closure_Action_Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        if (entity.Insp_Spot_CA_Photo_List != null)
                        {
                            foreach (var item in entity.Insp_Spot_CA_Photo_List)
                            {
                                var parameters1 = new
                                {
                                    Corrective_Action_Id = item.Corrective_Action_Id,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Spot_CA_Closure_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Spot_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_CA_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_CA_Photo_Id = entity.Insp_CA_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Spot_CA_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Spot_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_CA_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Status = entity.Status,
                        Reject_Reason = entity.Description,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Spot_CA_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion


        #endregion

        #region [INSP SAFETY VIOLATION]

        #region [Safety Violation]
        public async Task<IReadOnlyList<M_Insp_Request>> Insp_Safety_Violation_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                    Card_Id = entity.Card_Id,
                };
                string procedure = "sp_Insp_Safety_Violation_GetAll_Filter";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Safety_Violation> Insp_Safety_Violation_Add_GetById(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Spot_Safety_Violation_GetbyId";
                string procedure2 = "sp_Insp_Category_Master_GetAll";
                string procedure3 = "sp_Business_Unit_Master_GetAll";
                string procedure4 = "sp_Zone_Master_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Safety_Violation>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Emp_Service_Provider_List = new List<M_Emp_Service_Provider>();
                        Obj!.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Zone_Master_List = new List<Dropdown_Values>();
                        var Obj_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                        var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_Cat_Mas_List != null && Obj_Cat_Mas_List.Count > 0)
                        {
                            Obj.Insp_Spot_Category_Master_List = Obj_Cat_Mas_List;
                        }
                        if (Business_Unit_Master != null && Business_Unit_Master.Count > 0)
                        {
                            Obj.Business_Master_List = Business_Unit_Master;
                        }
                        if (Zone_Master != null && Zone_Master.Count > 0)
                        {
                            Obj.Zone_Master_List = Zone_Master;
                        }
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_Add_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Safety_Violation> Insp_Safety_Violation_GetById(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Spot_Safety_Violation_GetbyId";
                string procedure2 = "sp_Insp_Category_Master_GetAll";
                string procedure3 = "sp_Insp_Spot_Safety_Violation_Sub_Type_GetbyId";
                string procedure4 = "sp_Insp_Spot_Safety_Violation_Reject_GetbyId";
                string procedure5 = "sp_Insp_Safety_Vio_Corrective_Action_GetbyId";
                string procedure20 = "sp_Insp_SV_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_SV_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_SV_CA_ReAssign_GetbyId";
                string procedure23 = "SP_GET_EMPLOYESS_BY_ROLE";
                string procedure24 = "sp_Insp_Spot_Safe_Vio_History_Approval_GetbyId";
                string procedure25 = "sp_Insp_Spot_Safety_Violation_Photos_GetbyId";


                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id
                    };
                    var parameters1 = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Safety_Violation>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Emp_Service_Provider_List = new List<M_Emp_Service_Provider>();
                        Obj!.Insp_Safe_Vio_Photos_List = new List<M_Insp_Safety_Photos>();
                        var parameters23 = new
                        {
                            Zone_Id = Obj.Zone_Id,
                            Emp_Community_Id = Obj.Community_Id,
                            Role_Name = "Service_Provider",
                        };
                        var Obj_App_His = (await connection.QueryAsync<Insp_Req_Approval_History>(procedure24, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (Obj_App_His != null)
                        {
                            Obj.Insp_Safe_Vio_Approval_History_List = Obj_App_His;
                        }
                        var Obj_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_Sub_Type_List = (await connection.QueryAsync<M_Insp_Safety_Violation_Sub_Type>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_Reject_List = (await connection.QueryAsync<M_Insp_Safety_ViolationReject>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_CA_List = (await connection.QueryAsync<M_Safety_Vio_Corrective_Action>(procedure5, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Service_Pro_Emp_List = (await connection.QueryAsync<M_Emp_Service_Provider>(procedure23, parameters23, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Safe_Photos_List = (await connection.QueryAsync<M_Insp_Safety_Photos>(procedure25, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Cat_Mas_List != null && Obj_Cat_Mas_List.Count > 0)
                        {
                            Obj.Insp_Spot_Category_Master_List = Obj_Cat_Mas_List;
                        }
                        if (Obj_Violation_Sub_Type_List != null && Obj_Violation_Sub_Type_List.Count > 0)
                        {
                            Obj.Safety_Violation_Sub_Type_List = Obj_Violation_Sub_Type_List;
                        }
                        if (Obj_Violation_Reject_List != null && Obj_Violation_Reject_List.Count > 0)
                        {
                            Obj.Safety_Violation_Reject_List = Obj_Violation_Reject_List;
                        }
                        if (Obj_Safe_Photos_List != null && Obj_Safe_Photos_List.Count > 0)
                        {
                            Obj.Insp_Safe_Vio_Photos_List = Obj_Safe_Photos_List;
                        }
                        if (Obj_Service_Pro_Emp_List != null && Obj_Service_Pro_Emp_List.Count > 0)
                        {
                            foreach (var item in Obj_Service_Pro_Emp_List)
                            {
                                item.First_Name = item.First_Name;
                            }
                            Obj.Emp_Service_Provider_List = Obj_Service_Pro_Emp_List;
                        }
                        if (Obj_Violation_CA_List != null && Obj_Violation_CA_List.Count > 0)
                        {
                            foreach (var itemss in Obj_Violation_CA_List)
                            {
                                var parameters_Cass = new
                                {
                                    SV_Corrective_Action_Id = itemss.SV_Corrective_Action_Id,
                                };
                                var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_SV_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_SV_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_SV_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                {
                                    itemss.Insp_SV_CA_Photo_List = Obj_CA_Photos;
                                }
                                if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                {
                                    itemss.Insp_SV_CA_Reject_List = Obj_CA_Rej;
                                }
                                if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                {
                                    itemss.Insp_SV_CA_ReAssign_List = Obj_CA_ReAsign;
                                }
                            }

                            Obj.Safety_Violation_CA_List = Obj_Violation_CA_List;
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Safety_Violation_Create(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Safety_Violation_Create";
                string procedure1 = "sp_Insp_Spot_Safety_Violation_Sub_Type_Add";
                string procedure3 = "sp_Insp_Spot_Safety_Violation_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Inspection_Date = entity.Inspection_Date,
                        Responsible_Dept = entity.Responsible_Dept,
                        Description_Violation = entity.Description_Violation,
                        Requirement = entity.Requirement,
                        CreatedBy = entity.CreatedBy,
                        Emp_Service_provider = entity.Emp_Service_provider,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Safety_Violation_Sub_Type_List != null && entity.Safety_Violation_Sub_Type_List.Count > 0)
                        {
                            foreach (var item in entity.Safety_Violation_Sub_Type_List)
                            {
                                var parameters1 = new
                                {
                                    Type_of_Violation_Id = item.Type_of_Violation_Id,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Safety_Violation_Id = obj.Status_Code,
                                    Type_Master_Id = item.Type_Master_Id,
                                    Others_Name = item.Others_Name,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }

                        }

                        if (entity.Insp_Safe_Vio_Photos_List != null && entity.Insp_Safe_Vio_Photos_List.Count > 0)
                        {
                            foreach (var items in entity.Insp_Safe_Vio_Photos_List)
                            {
                                var parameters3 = new
                                {
                                    Insp_Request_Id = "0",
                                    Safety_Violation_Id = obj.Status_Code,
                                    File_Path = items.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        obj.Status_Code = "200";
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_Create";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Safety_Violation_Add(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Safety_Violation_Add";
                string procedure1 = "sp_Insp_Spot_Safety_Violation_Sub_Type_Add";
                string procedure2 = "sp_Insp_Spot_Safety_Violation_Sub_Type_Delete";
                string procedure3 = "sp_Insp_Spot_Safety_Violation_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Responsible_Dept = entity.Responsible_Dept,
                        Description_Violation = entity.Description_Violation,
                        Requirement = entity.Requirement,
                        CreatedBy = entity.CreatedBy,
                        Emp_Service_provider = entity.Emp_Service_provider,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Safety_Violation_Sub_Type_List != null && entity.Safety_Violation_Sub_Type_List.Count > 0)
                        {
                            if (entity.Safety_Violation_Id != "0")
                            {
                                var parameters2 = new
                                {
                                    Safety_Violation_Id = entity.Safety_Violation_Id,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure);
                            }
                            foreach (var item in entity.Safety_Violation_Sub_Type_List)
                            {
                                var parameters1 = new
                                {
                                    Type_of_Violation_Id = item.Type_of_Violation_Id,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Safety_Violation_Id = entity.Safety_Violation_Id,
                                    Type_Master_Id = item.Type_Master_Id,
                                    Others_Name = item.Others_Name,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }

                        }
                        if (entity.Insp_Safe_Vio_Photos_List != null && entity.Insp_Safe_Vio_Photos_List.Count > 0)
                        {
                            foreach (var items in entity.Insp_Safe_Vio_Photos_List)
                            {
                                var parameters3 = new
                                {
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Safety_Violation_Id = entity.Safety_Violation_Id,
                                    File_Path = items.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure);
                            }
                        }
                        obj.Status_Code = "200";
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Safe_Vio_ApprovalReject(M_Insp_Safety_ViolationReject entity)
        {
            try
            {
                string procedure = "sp_Insp_Safety_Violation_Reject_ApprovalReject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Safe_Violation_Reject_Id = entity.Insp_Safe_Violation_Reject_Id,
                        Safety_Violation_Id = entity.Safety_Violation_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        Reject_Reason = entity.Reject_Reason,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safe_Vio_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Safe_Vio_Corrective_Action_Add(List<M_Safety_Vio_Corrective_Action> entity)
        {
            try
            {
                string procedure = "sp_Insp_Spot_Safety_Vio_Corrective_Action_Add";
                string procedure1 = "sp_Insp_Safety_Vio_Corrective_Action_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Safety_Violation_Id = entity[0].Safety_Violation_Id,
                        CreatedBy = entity[0].CreatedBy,
                    };
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            SV_Corrective_Action_Id = item.SV_Corrective_Action_Id,
                            Safety_Violation_Id = item.Safety_Violation_Id,
                            Assignee_Type = item.Assignee_Type,
                            Responsibility_To = item.Responsibility_To,
                            Target_Date = item.Target_Date,
                            Action_Description = item.Action_Description,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure);

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Safe_Vio_Corrective_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Safe_Vio_Spot_CA_ApprovalReject(M_Safety_Vio_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_SV_CA_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SV_Corrective_Action_Id = entity.SV_Corrective_Action_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Status = entity.Status,
                        Reject_Reason = entity.Description,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safe_Vio_Spot_CA_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Emp_Service_Provider>> Insp_Safety_Vio_Ser_Pro_GetAll(M_Insp_Safety_Violation entity)
        {
            try
            {
                String procedure = "SP_GET_EMPLOYESS_BY_ROLE";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Emp_Community_Id = entity.Community_Id,
                        Role_Name = "Service_Provider",
                    };
                    return (await connection.QueryAsync<M_Emp_Service_Provider>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Vio_Ser_Pro_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public List<string> UploadImage_Safe(List<IFormFile> file)
        {
            try
            {
                var connection = "";

                connection = configuration.GetConnectionString("FilePath");
                string path = "";
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;
                path = Path.GetFullPath(Path.Combine(contentPath, "FileUpload/InspImages"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                List<string> uploadedFiles = new List<string>();

                // Allowed File Count = '5'
                if (file.Count < 6)
                {
                    foreach (IFormFile postedFile in file)
                    {
                        // Allowed File Format = '.jpeg', '.jpg', '.png'
                        if (postedFile.ContentType == "image/jpeg" || postedFile.ContentType == "image/jpg" || postedFile.ContentType == "image/png" || postedFile.ContentType == "image/bmp")
                        {
                            // Allowed File Size = '50 MB'
                            if (postedFile.Length < 52428800)
                            {
                                Guid FileName = Guid.NewGuid();
                                var extension = Path.GetExtension(postedFile.FileName);
                                string fileupload = FileName.ToString() + extension;

                                //string fileName = Path.GetFileName(postedFile.FileName);
                                using (FileStream stream = new FileStream(Path.Combine(path, fileupload), FileMode.Create))
                                {
                                    postedFile.CopyTo(stream);
                                }
                                uploadedFiles.Add(connection + fileupload);
                            }
                            else
                            {
                                uploadedFiles.Add("File to large");
                            }
                        }
                        else
                        {
                            uploadedFiles.Add("Invalid Format");
                        }
                    }
                }
                else
                {
                    uploadedFiles.Add("Maximum Allowed 5 Images");
                }

                return uploadedFiles;
            }
            catch (Exception ex)
            {
                string Repo = "UploadImage";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public async Task<M_Return_Message> Insp_Safe_Photo_Delete(M_Insp_Safety_Photos entity)
        {
            try
            {
                string procedure = "sp_Insp_Safe_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Photo_Id = entity.Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safe_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Safety Violation Corrective Action]
        public async Task<IReadOnlyList<M_Insp_Request>> Insp_Safety_Vio_CA_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Safety_Violation_CA_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Vio_CA_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Safety_Violation> Insp_Safety_Violation_CA_GetById(M_Insp_Safety_Violation entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Spot_Safety_Violation_GetbyId";
                string procedure2 = "sp_Insp_Category_Master_GetAll";
                string procedure3 = "sp_Insp_Spot_Safety_Violation_Sub_Type_GetbyId";
                string procedure4 = "sp_Insp_Spot_Safety_Violation_Reject_GetbyId";
                string procedure5 = "sp_Insp_Safety_Vio_Corrective_Action_Emp_GetbyId";
                string procedure20 = "sp_Insp_SV_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_SV_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_SV_CA_ReAssign_GetbyId";
                string procedure25 = "sp_Insp_Spot_Safety_Violation_Photos_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id
                    };
                    var parameters1 = new
                    {
                        Safety_Violation_Id = entity.Safety_Violation_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Safety_Violation>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var Obj_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_Sub_Type_List = (await connection.QueryAsync<M_Insp_Safety_Violation_Sub_Type>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_Reject_List = (await connection.QueryAsync<M_Insp_Safety_ViolationReject>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Violation_CA_List = (await connection.QueryAsync<M_Safety_Vio_Corrective_Action>(procedure5, parameters1, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Safe_Photos_List = (await connection.QueryAsync<M_Insp_Safety_Photos>(procedure25, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Cat_Mas_List != null && Obj_Cat_Mas_List.Count > 0)
                        {
                            Obj.Insp_Spot_Category_Master_List = Obj_Cat_Mas_List;
                        }
                        if (Obj_Violation_Sub_Type_List != null && Obj_Violation_Sub_Type_List.Count > 0)
                        {
                            Obj.Safety_Violation_Sub_Type_List = Obj_Violation_Sub_Type_List;
                        }
                        if (Obj_Violation_Reject_List != null && Obj_Violation_Reject_List.Count > 0)
                        {
                            Obj.Safety_Violation_Reject_List = Obj_Violation_Reject_List;
                        }
                        if (Obj_Safe_Photos_List != null && Obj_Safe_Photos_List.Count > 0)
                        {
                            Obj.Insp_Safe_Vio_Photos_List = Obj_Safe_Photos_List;
                        }
                        if (Obj_Violation_CA_List != null && Obj_Violation_CA_List.Count > 0)
                        {

                            foreach (var itemss in Obj_Violation_CA_List)
                            {
                                var parameters_Cass = new
                                {
                                    SV_Corrective_Action_Id = itemss.SV_Corrective_Action_Id,
                                };
                                var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_SV_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_SV_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_SV_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                {
                                    itemss.Insp_SV_CA_Photo_List = Obj_CA_Photos;
                                }
                                if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                {
                                    itemss.Insp_SV_CA_Reject_List = Obj_CA_Rej;
                                }
                                if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                {
                                    itemss.Insp_SV_CA_ReAssign_List = Obj_CA_ReAsign;
                                }
                            }

                            Obj.Safety_Violation_CA_List = Obj_Violation_CA_List;
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Safety_Violation_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SV_CA_Action_Closure_Add(M_Safety_Vio_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_SV_CA_Action_Closure_Add";
                string procedure1 = "sp_Insp_SV_CA_Action_Closure_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SV_Corrective_Action_Id = entity.SV_Corrective_Action_Id,
                        Closure_Action_Description = entity.Closure_Action_Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        if (entity.Insp_SV_CA_Photo_List != null)
                        {
                            foreach (var item in entity.Insp_SV_CA_Photo_List)
                            {
                                var parameters1 = new
                                {
                                    SV_Corrective_Action_Id = item.SV_Corrective_Action_Id,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SV_CA_Action_Closure_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SV_CA_ReAssign(M_Safety_Vio_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_SV_CA_ReAssign_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        SV_Corrective_Action_Id = entity.SV_Corrective_Action_Id,
                        Responsibility_To = entity.Responsibility_To,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SV_CA_ReAssign";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SV_CA_Photo_Delete(M_Insp_SV_CA_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_SV_CA_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_SV_CA_Photo_Id = entity.Insp_SV_CA_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SV_CA_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #endregion

        #region [Joint Insp]

        #region [Insp Joint Request]
        public async Task<IReadOnlyList<M_Insp_Joint_Request>> Insp_Joint_Request_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Joint_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Joint_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Request_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Request_Add(M_Insp_Joint_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Request_Add";
                //string procedure1 = "sp_Insp_Joint_Req_Doc_Review_Add";
                string procedure2 = "sp_Insp_Joint_History_Approval_Add";
                //string procedure8 = "sp_Upcoming_Activity_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    //if (entity.Insp_Type_Id == "Document_Review")
                    //{
                    //    entity.Category_Id = "0";
                    //}
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        //Business_Unit_Id = entity.Business_Unit_Id,
                        //Zone_Id = entity.Zone_Id,
                        //Community_Id = entity.Community_Id,
                        //Building_Id = entity.Building_Id,
                        Supervisor_Id = entity.Supervisor_Id,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        HSE_Representative_Id = entity.HSE_Representative_Id,
                        //Insp_Type_Id = entity.Insp_Type_Id,
                        //Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        //Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                        //Schedule_Type = entity.Schedule_Type,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        var parameters2 = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        //var parameters_8 = new
                        //{
                        //    Schedule_Type_Id = entity.Insp_Request_Id,
                        //    Zone_Id = "0",
                        //    Community_Id = "0",
                        //    Building_Id = "0",
                        //    Module_Name = "Joint Inspection",
                        //    Hyper_Link = "/Inspection/Joint_Insp_Request",
                        //    CreatedBy = entity.CreatedBy
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Request_Form : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Request_Update(M_Insp_Joint_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Request_Update";
                string procedure1 = "sp_Insp_Joint_Req_Doc_Review_Add";
                string procedure2 = "sp_Insp_Joint_History_Approval_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Supervisor_Id = entity.Supervisor_Id,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        HSE_Representative_Id = entity.HSE_Representative_Id,
                        Insp_Type_Id = entity.Insp_Type_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Req_Description = entity.Req_Description,
                        Schedule_Type = entity.Schedule_Type,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_Req_Doc_Review_List != null && entity.Insp_Req_Doc_Review_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_Req_Doc_Review_List)
                            {
                                var parameters1 = new
                                {
                                    Req_Document_Review_Id = item.Req_Document_Review_Id,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Req_Document_Name = item.Req_Document_Name,
                                    Req_Document_Description = item.Req_Document_Description,
                                    File_Path = item.File_Path,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                        var parameters2 = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Joint_Request> Insp_Joint_Request_GetById(M_Insp_Joint_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Joint_Req_Reject_GetbyId";
                string procedure11 = "sp_Insp_Joint_Finding_GetbyId";
                string procedure12 = "sp_Insp_Joint_Sub_Finding_GetbyId";
                string procedure13 = "sp_Insp_Joint_Sub_Category_GetbyId";
                string procedure14 = "sp_Insp_Joint_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure17 = "sp_Insp_Sub_Category_Master_GetbyId";
                string procedure18 = "sp_Insp_Joint_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Joint_Corrective_Action_GetbyId";
                string procedure20 = "sp_Insp_Joint_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Joint_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Joint_CA_ReAssign_GetbyId";
                string procedure23 = "sp_Insp_Joint_Req_Document_Review_GetbyId";
                string procedure24 = "sp_Insp_Joint_Supervisor_Finding_GetbyId";
                string procedure25 = "sp_Insp_Joint_History_Approval_GetbyId";
                string procedure26 = "sp_Insp_Joint_Req_Supervisor_GetbyId";
                string procedure27 = "sp_Insp_Joint_Req_Service_Provider_GetbyId";
                string procedure28 = "sp_Insp_Joint_Req_HSE_Team_GetbyId";
                string procedure29 = "sp_Insp_Joint_Req_Service_Provider_Scope_GetbyId";


                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Joint_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var Obj_Doc = (await connection.QueryAsync<Insp_Req_Doc_Review>(procedure23, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_App_His = (await connection.QueryAsync<Insp_Req_Approval_History>(procedure25, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Doc != null)
                        {
                            Obj.Insp_Req_Doc_Review_List = Obj_Doc;
                        }
                        if (Obj_App_His != null)
                        {
                            Obj.Insp_Req_Approval_History_List = Obj_App_His;
                        }
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = new List<M_Insp_Value_Text>();
                        Obj!.Inc_Comman_Master_List.Supervisor_Req_List = new List<Dropdown_Values>();

                        Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                        Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var parameters_Super_Reqs = new
                            {
                                Zone_Id = entity.Zone_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            var Super_Req_Emps = (await connection.QueryAsync<Dropdown_Values>(procedure26, parameters_Super_Reqs, commandType: CommandType.StoredProcedure)).ToList();
                            var Service_P_Req_Emps = (await connection.QueryAsync<Dropdown_Values>(procedure27, parameters_Super_Reqs, commandType: CommandType.StoredProcedure)).ToList();
                            var HSE_Team_Req_Emps = (await connection.QueryAsync<Dropdown_Values>(procedure28, parameters_Super_Reqs, commandType: CommandType.StoredProcedure)).ToList();

                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Super_Req_Emps != null)
                            {
                                Obj!.Inc_Comman_Master_List.Supervisor_Req_List = Super_Req_Emps;
                            }
                            if (Service_P_Req_Emps != null)
                            {
                                Obj!.Inc_Comman_Master_List.Service_Provider_Req_List = Service_P_Req_Emps;
                            }
                            if (HSE_Team_Req_Emps != null)
                            {
                                Obj!.Inc_Comman_Master_List.HSE_Team_Req_Emp_List = HSE_Team_Req_Emps;
                            }
                        }
                        else
                        {
                            var parameters_Super_Req = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };
                            var parameters_Super_Req1 = new
                            {
                                Scope_Of_Work = Obj.Scope_Of_Work,
                            };

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            var Super_Req_Emp = (await connection.QueryAsync<Dropdown_Values>(procedure26, parameters_Super_Req, commandType: CommandType.StoredProcedure)).ToList();
                            var Service_P_Req_Emp = (await connection.QueryAsync<Dropdown_Values>(procedure29, parameters_Super_Req1, commandType: CommandType.StoredProcedure)).ToList();
                            var HSE_Team_Req_Emps = (await connection.QueryAsync<Dropdown_Values>(procedure28, parameters_Super_Req, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Request_Reject != null)
                            {
                                Obj!.Insp_Request_Reject_List = Request_Reject;
                            }
                            if (Super_Req_Emp != null)
                            {
                                Obj!.Inc_Comman_Master_List.Supervisor_Req_List = Super_Req_Emp;
                            }
                            if (Service_P_Req_Emp != null)
                            {
                                Obj!.Inc_Comman_Master_List.Service_Provider_Req_List = Service_P_Req_Emp;
                            }
                            if (HSE_Team_Req_Emps != null)
                            {
                                Obj!.Inc_Comman_Master_List.HSE_Team_Req_Emp_List = HSE_Team_Req_Emps;
                            }
                        }
                        var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj_Finding != null)
                        {
                            Obj_Finding.Main_Status = Obj.Status;
                            Obj_Finding.Req_Createdby = Obj.CreatedBy;
                            Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                            Obj_Finding.Zone_Name = Obj.Zone_Name;
                            Obj_Finding.Community_Name = Obj.Community_Name;
                            Obj_Finding.Building_Name = Obj.Building_Name;
                            Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                            Obj_Finding.Req_Description = Obj.Req_Description;
                            DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                            Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                            Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                            Obj_Finding.HSE_Representative_Name = Obj.HSE_Representative_Name;
                            Obj_Finding.Schedule_Type = Obj.Schedule_Type;
                            var parameters_Emp = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Rej = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                            };
                            if (Obj_App_His != null)
                            {
                                Obj_Finding.Insp_Req_Approval_History_List = Obj_App_His;
                            }
                            var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                            }
                            var Obj_Supervisor_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure24, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Supervisor_List != null && Obj_Supervisor_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Supervisor_Master_List = Obj_Supervisor_List;
                            }
                            var Obj_Cat_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();

                            if (Obj_Cat_List != null && Obj_Cat_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Category_Master_List = Obj_Cat_List;
                            }
                            var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                            {
                                Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                            }
                            var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                                foreach (var item in Obj_Sub_Finding)
                                {
                                    var parameters_Sub = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    };
                                    var parameters_Ca = new
                                    {
                                        Insp_Category_Id = item.Category,
                                    };
                                    var parameters_Sub1 = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                        CreatedBy = entity.CreatedBy,
                                    };
                                    var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                                    if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                                    {
                                        item.Insp_Spot_Category_Master_List = Obj_Cat_List_Mas;
                                    }
                                    var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure13, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure17, parameters_Ca, commandType: CommandType.StoredProcedure)).ToList();

                                    if (Obj_Sub_Cat_Mas_List != null && Obj_Sub_Cat_Mas_List.Count > 0)
                                    {
                                        item.Insp_Spot_Sub_Category_Master_List = Obj_Sub_Cat_Mas_List;
                                    }

                                    if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                                    }
                                    if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                    }
                                    if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                    {
                                        foreach (var itemss in Obj_Sub_Finding_CA)
                                        {
                                            var parameters_Cass = new
                                            {
                                                Corrective_Action_Id = itemss.Corrective_Action_Id,
                                            };
                                            var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                            }
                                            if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                            }
                                            if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                            }
                                        }
                                        item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                    }
                                }
                            }
                            Obj.Insp_Spot_Finding_List = Obj_Finding;
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Request_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Dropdown_Values>> Insp_Joint_Req_Supervisor_GetbyId(Dropdown_Values entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Req_Supervisor_GetbyId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Value,
                    };
                    return (await connection.QueryAsync<Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Req_Supervisor_GetbyId";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Req_ApprovalReject(M_Insp_Joint_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Req_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Inspection_Date = entity.Inspection_Date,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Req_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Dropdown_Values>> Insp_Joint_Zone_based_HSE_Team_Emp(M_Insp_Joint_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Req_HSE_Team_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id
                    };
                    return (await connection.QueryAsync<Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Zone_based_HSE_Team_Emp";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Insp Joint Finding]
        public async Task<M_Return_Message> Add_Insp_Joint_Finding(M_Insp_Spot_Finding entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Joint_Finding_Add";
                string procedure2 = "sp_Insp_Joint_Sub_Finding_Add";
                string procedure3 = "sp_Insp_Joint_Sub_Category_Add";
                string procedure4 = "sp_Insp_Joint_Sub_Photos_Add";
                string procedure5 = "sp_Insp_Joint_Req_Find_Status_Update_GetbyId";
                string procedure6 = "sp_Insp_Joint_Sub_Category_Delete";
                string procedure7 = "sp_Insp_Joint_History_Approval_Find_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters1 = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        NCM_Supervisor = entity.NCM_Supervisor,
                        NCM_Community_Manager = entity.NCM_Community_Manager,
                        Zone_Rep_Attended = entity.Zone_Rep_Attended,
                        Service_Provider_Attended = entity.Service_Provider_Attended,
                        Zone_Rep_Id = entity.Zone_Rep_Id,
                        Service_Provider_ID = entity.Service_Provider_ID,
                        CreatedBy = entity.CreatedBy,
                        Safety_Violation = entity.Safety_Violation,
                    };
                    var parameters5 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Safe_Id = "0";
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.Insp_Spot_Sub_Finding_List != null && entity.Insp_Spot_Sub_Finding_List.Count > 0)
                        {
                            foreach (var item1 in entity.Insp_Spot_Sub_Finding_List!)
                            {
                                var parameters2 = new
                                {
                                    Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                    Insp_Finding_Id = Obj.Status_Code,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Observations = item1.Observations,
                                    Latitude = item1.Latitude,
                                    Longitude = item1.Longitude,
                                    Hazard_Risk = item1.Hazard_Risk,
                                    Requirements = item1.Requirements,
                                    Action_Required = item1.Action_Required,
                                    Category = item1.Category,
                                    Risk_Level = item1.Risk_Level,
                                    CreatedBy = entity.CreatedBy,
                                    Location_Address = item1.Location_Address,
                                    Exact_Location_Address = item1.Exact_Location_Address,
                                };
                                var Obj1 = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                if (Obj1 != null)
                                {
                                    if (item1.Insp_Spot_Find_Sub_Category_List != null && item1.Insp_Spot_Find_Sub_Category_List.Count > 0)
                                    {
                                        if (item1.Insp_Sub_Finding_Id != "0")
                                        {
                                            var parameters6 = new
                                            {
                                                Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                            };
                                            var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure6, parameters6, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                        foreach (var item2 in item1.Insp_Spot_Find_Sub_Category_List!)
                                        {
                                            var parameters3 = new
                                            {
                                                Insp_Sub_Finding_Sub_Cat_Id = item2.Insp_Sub_Finding_Sub_Cat_Id,
                                                Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                Insp_Finding_Id = Obj.Status_Code,
                                                Insp_Request_Id = entity.Insp_Request_Id,
                                                Insp_Sub_Category_Id = item2.Insp_Sub_Category_Id,
                                                CreatedBy = entity.CreatedBy,
                                            };
                                            var Obj2 = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                    }

                                    if (item1.Insp_Spot_Find_Sub_Photo_List != null && item1.Insp_Spot_Find_Sub_Photo_List.Count > 0)
                                    {
                                        foreach (var item3 in item1.Insp_Spot_Find_Sub_Photo_List!)
                                        {
                                            var parameters4 = new
                                            {
                                                Insp_Sub_Photo_Id = item3.Insp_Sub_Photo_Id,
                                                Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                Insp_Finding_Id = Obj.Status_Code,
                                                Insp_Request_Id = entity.Insp_Request_Id,
                                                File_Path = item3.File_Path,
                                                CreatedBy = entity.CreatedBy,
                                            };
                                            var Obj3 = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                    }
                                }
                            }
                        }
                    }
                    var parameters7 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure7, parameters7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    var obj_Safe = (await connection.QueryAsync<M_Return_Message>(procedure5, parameters5, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj_Safe != null)
                    {
                        Safe_Id = obj_Safe.Return_2;
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK,
                        Return_1 = entity.Insp_Request_Id,
                        Return_2 = Safe_Id,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Add_Insp_Joint_Finding";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Find_ApprovalReject(M_Insp_Finding_Approval entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Finding_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Find_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Spot_Sub_Finding> Insp_Joint_Sub_Find_List_GetById(M_Insp_Spot_Sub_Finding entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Joint_Sub_Finding_Rej_GetbyId";
                string procedure2 = "sp_Insp_Joint_Sub_Category_GetbyId";
                string procedure3 = "sp_Insp_Joint_Sub_Photos_GetbyId";
                string procedure4 = "sp_Insp_Category_Master_GetAll";
                string procedure5 = "sp_Insp_Sub_Category_Master_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Finding_Id = entity.Insp_Sub_Finding_Id
                    };

                    var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure1, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj_Sub_Finding != null)
                    {
                        var parameters1 = new
                        {
                            Insp_Category_Id = Obj_Sub_Finding.Category,
                        };
                        var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure2, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure4, commandType: CommandType.StoredProcedure)).ToList();
                        var Obj_Sub_Cat_Mas_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure5, parameters1, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                        }
                        if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                        }
                        if (Obj_Cat_Mas_List != null && Obj_Cat_Mas_List.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Category_Master_List = Obj_Cat_Mas_List;
                        }
                        if (Obj_Sub_Cat_Mas_List != null && Obj_Sub_Cat_Mas_List.Count > 0)
                        {
                            Obj_Sub_Finding!.Insp_Spot_Sub_Category_Master_List = Obj_Sub_Cat_Mas_List;
                        }
                    }
                    return Obj_Sub_Finding;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Sub_Find_List_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Sub_Photos_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Photo_Id = entity.Insp_Sub_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Sub_Find_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_Sub_Finding_Delete(M_Insp_Spot_Sub_Finding entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Sub_Finding_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Finding_Id = entity.Insp_Sub_Finding_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Sub_Finding_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Insp Joint Corrective Action]
        public async Task<M_Return_Message> Insp_Joint_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_Corrective_Action_Add";
                string procedure1 = "sp_Insp_Joint_Corrective_Action_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Insp_Request_Id = entity[0].Insp_Request_Id,
                        CreatedBy = entity[0].CreatedBy,
                    };
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = item.Corrective_Action_Id,
                            Insp_Finding_Id = item.Insp_Finding_Id,
                            Insp_Request_Id = item.Insp_Request_Id,
                            Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                            Assignee_Type = item.Assignee_Type,
                            Responsibility_To = item.Responsibility_To,
                            Target_Date = item.Target_Date,
                            Action_Description = item.Action_Description,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure);

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Joint_Corrective_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Joint_Request>> Insp_Joint_Corrective_Action_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Joint_Corrective_Action_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Joint_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Corrective_Action_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Joint_Request> Insp_Joint_CA_GetById(M_Insp_Joint_Request entity)
        {
            try
            {

                string procedure = "sp_Insp_Joint_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Joint_Req_Reject_GetbyId";
                string procedure11 = "sp_Insp_Joint_Finding_GetbyId";
                string procedure12 = "sp_Insp_Joint_Sub_Finding_GetbyId";
                string procedure13 = "sp_Insp_Joint_Sub_Category_GetbyId";
                string procedure14 = "sp_Insp_Joint_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure17 = "sp_Insp_Sub_Category_Master_GetbyId";
                string procedure18 = "sp_Insp_Joint_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Joint_Action_Closure_GetbyId";
                string procedure20 = "sp_Insp_Joint_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Joint_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Joint_CA_ReAssign_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Joint_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                        Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                        Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                        }
                        else
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Request_Reject != null)
                            {
                                Obj!.Insp_Request_Reject_List = Request_Reject;
                            }
                        }

                        var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj_Finding != null)
                        {
                            Obj_Finding.Main_Status = Obj.Status;
                            Obj_Finding.Req_Createdby = Obj.CreatedBy;
                            Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                            Obj_Finding.Zone_Name = Obj.Zone_Name;
                            Obj_Finding.Community_Name = Obj.Community_Name;
                            Obj_Finding.Building_Name = Obj.Building_Name;
                            Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                            Obj_Finding.Req_Description = Obj.Req_Description;
                            DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                            Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                            Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                            Obj_Finding.HSE_Representative_Name = Obj.HSE_Representative_Name;
                            Obj_Finding.Schedule_Type = Obj.Schedule_Type;
                            var parameters_Emp = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Rej = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                            };
                            var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                            }
                            var Obj_Cat_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List != null && Obj_Cat_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Category_Master_List = Obj_Cat_List;
                            }
                            var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                            {
                                Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                            }
                            var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                                foreach (var item in Obj_Sub_Finding)
                                {
                                    var parameters_Sub = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    };
                                    var parameters_Sub1 = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                        CreatedBy = entity.CreatedBy,
                                    };

                                    var Obj_Sub_Finding_Cat = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Category>(procedure13, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();

                                    if (Obj_Sub_Finding_Cat != null && Obj_Sub_Finding_Cat.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Category_List = Obj_Sub_Finding_Cat;
                                    }
                                    if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                    }
                                    if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                    {
                                        foreach (var itemss in Obj_Sub_Finding_CA)
                                        {
                                            var parameters_Cass = new
                                            {
                                                Corrective_Action_Id = itemss.Corrective_Action_Id,
                                            };
                                            var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                            }
                                            if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                            }
                                            if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                            }
                                        }
                                        item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                    }
                                }
                            }
                            Obj.Insp_Spot_Finding_List = Obj_Finding;
                        }
                    }


                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_CA_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_CA_ReAssign(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_CA_ReAssign_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Responsibility_To = entity.Responsibility_To,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_CA_ReAssign";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_CA_Action_Closure_Add";
                string procedure1 = "sp_Insp_Joint_CA_Action_Closure_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Closure_Action_Description = entity.Closure_Action_Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        if (entity.Insp_Spot_CA_Photo_List != null)
                        {
                            foreach (var item in entity.Insp_Spot_CA_Photo_List)
                            {
                                var parameters1 = new
                                {
                                    Corrective_Action_Id = item.Corrective_Action_Id,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Joint_CA_Action_Closure_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_CA_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_CA_Photo_Id = entity.Insp_CA_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_CA_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Joint_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Joint_CA_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Status = entity.Status,
                        Reject_Reason = entity.Description,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_CA_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #endregion

        #region [Leadership Tour Insp]
        public async Task<IReadOnlyList<M_Insp_Leader_Request>> Insp_Leader_Request_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Leader_Request_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Leader_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Request_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Leader_Request> Insp_Leader_Request_GetById(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Leader_Req_Reject_GetbyId";
                string procedure11 = "sp_Insp_Leader_Finding_GetbyId";
                string procedure12 = "sp_Insp_Leader_Sub_Finding_GetbyId";
                string procedure14 = "sp_Insp_Leader_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure18 = "sp_Insp_Leader_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Leader_Corrective_Action_GetbyId";
                string procedure20 = "sp_Insp_Leader_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Leader_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Leader_CA_ReAssign_GetbyId";
                string procedure25 = "sp_Insp_Leader_History_Approval_GetbyId";
                string procedure26 = "sp_Insp_Leader_Find_Sub_Photos_GetById";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var parameters_New = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Zone_Id = entity.Zone_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Leader_Request>(procedure, parameters_New, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var Obj_App_His = (await connection.QueryAsync<Insp_Req_Approval_History>(procedure25, parameters, commandType: CommandType.StoredProcedure)).ToList();

                        if (Obj_App_His != null)
                        {
                            Obj.Insp_Req_Approval_History_List = Obj_App_His;
                        }
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = new List<M_Insp_Value_Text>();
                        Obj!.Inc_Comman_Master_List.Supervisor_Req_List = new List<Dropdown_Values>();

                        Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                        Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var parameters_Super_Reqs = new
                            {
                                Zone_Id = entity.Zone_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                        }
                        else
                        {
                            var parameters_Super_Req = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Cat_List_Mas = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List_Mas != null && Obj_Cat_List_Mas.Count > 0)
                            {
                                Obj!.Inc_Comman_Master_List.Insp_Category_Master_List = Obj_Cat_List_Mas;
                            }
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Request_Reject != null)
                            {
                                Obj!.Insp_Request_Reject_List = Request_Reject;
                            }
                        }
                        var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj_Finding != null)
                        {
                            Obj_Finding.Insp_Leader_Finding_Sub_Photo_List = new List<M_Insp_Leader_Finding_Sub_Photo>();

                            Obj_Finding.Main_Status = Obj.Status;
                            Obj_Finding.Req_Createdby = Obj.CreatedBy;
                            Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                            Obj_Finding.Zone_Name = Obj.Zone_Name;
                            Obj_Finding.Community_Name = Obj.Community_Name;
                            Obj_Finding.Building_Name = Obj.Building_Name;
                            Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                            Obj_Finding.Req_Description = Obj.Req_Description;
                            DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                            Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                            Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                            var parameters_Emp = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Rej = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                            };
                            if (Obj_App_His != null)
                            {
                                Obj_Finding.Insp_Req_Approval_History_List = Obj_App_His;
                            }

                            var Obj_Finding_Sub_Photo = (await connection.QueryAsync<M_Insp_Leader_Finding_Sub_Photo>(procedure26, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Finding_Sub_Photo != null && Obj_Finding_Sub_Photo.Count > 0)
                            {
                                Obj_Finding.Insp_Leader_Finding_Sub_Photo_List = Obj_Finding_Sub_Photo;
                            }

                            var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                            }
                            var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                            {
                                Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                            }
                            var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                                foreach (var item in Obj_Sub_Finding)
                                {
                                    var parameters_Sub = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    };
                                    var parameters_Ca = new
                                    {
                                        Insp_Category_Id = item.Category,
                                    };
                                    var parameters_Sub1 = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                        CreatedBy = entity.CreatedBy,
                                    };
                                    var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();
                                    if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                    }
                                    if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                    {
                                        foreach (var itemss in Obj_Sub_Finding_CA)
                                        {
                                            var parameters_Cass = new
                                            {
                                                Corrective_Action_Id = itemss.Corrective_Action_Id,
                                            };
                                            var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                            }
                                            if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                            }
                                            if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                            }
                                        }
                                        item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                    }
                                }
                            }
                            Obj.Insp_Spot_Finding_List = Obj_Finding;
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Joint_Request_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Leader_Request> Insp_Leader_Zone_based_Dir_Hsse(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Zone_based_Dir_Hsse_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Leader_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Zone_based_Dir_Hsse";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Request_Add(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Request_Add";
                string procedure2 = "sp_Insp_Leader_History_Approval_Add";
                //string procedure8 = "sp_Upcoming_Activity_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Zone_Director_Id = entity.Zone_Director_Id,
                        HSSE_Director_Id = entity.HSSE_Director_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                        Other_Attendees = entity.Other_Attendees,
                        Schedule_Type = entity.Schedule_Type,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        var parameters2 = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        //var parameters_8 = new
                        //{
                        //    Schedule_Type_Id = entity.Insp_Request_Id,
                        //    Zone_Id = "0",
                        //    Community_Id = "0",
                        //    Building_Id = "0",
                        //    Module_Name = "Leadership Tour Inspection",
                        //    Hyper_Link = "/Inspection/Leader_Insp_Request",
                        //    CreatedBy = entity.CreatedBy
                        //};
                        //var objActivity = (await connection.QueryAsync<M_Return_Message>(procedure8, parameters_8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Leader_Request_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Request_Update(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Request_Update";
                string procedure2 = "sp_Insp_Leader_History_Approval_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Zone_Director_Id = entity.Zone_Director_Id,
                        HSSE_Director_Id = entity.HSSE_Director_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                        Other_Attendees = entity.Other_Attendees,
                        Schedule_Type = entity.Schedule_Type,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        var parameters2 = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Joint_Request_Update";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Req_ApprovalReject(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Req_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Inspection_Date = entity.Inspection_Date,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Req_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Insp_Leader_Finding(M_Insp_Spot_Finding entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Leader_Finding_Add";
                string procedure2 = "sp_Insp_Leader_Sub_Finding_Add";
                string procedure4 = "sp_Insp_Leader_Sub_Photos_Add";
                string procedure5 = "sp_Insp_Leader_Req_Find_Status_Update_GetbyId";
                string procedure7 = "sp_Insp_Leader_History_Approval_Find_Update";
                string procedure8 = "sp_Insp_Leader_Finding_Sub_Photo_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters1 = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Summary = entity.Summary,
                        Highlights = entity.Highlights,
                        Lowlights = entity.Lowlights,
                        CreatedBy = entity.CreatedBy,
                    };
                    var parameters5 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.Insp_Spot_Sub_Finding_List != null && entity.Insp_Spot_Sub_Finding_List.Count > 0)
                        {
                            foreach (var item1 in entity.Insp_Spot_Sub_Finding_List!)
                            {
                                var parameters2 = new
                                {
                                    Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                    Insp_Finding_Id = Obj.Status_Code,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    Observations = item1.Observations,
                                    Latitude = item1.Latitude,
                                    Longitude = item1.Longitude,
                                    Action_Required = item1.Action_Required,
                                    Type = item1.Type,
                                    CreatedBy = entity.CreatedBy,
                                    Location_Address = item1.Location_Address,
                                    Exact_Location_Address = item1.Exact_Location_Address,
                                };
                                var Obj1 = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                if (Obj1 != null)
                                {
                                    if (item1.Insp_Spot_Find_Sub_Photo_List != null && item1.Insp_Spot_Find_Sub_Photo_List.Count > 0)
                                    {
                                        foreach (var item3 in item1.Insp_Spot_Find_Sub_Photo_List!)
                                        {
                                            var parameters4 = new
                                            {
                                                Insp_Sub_Photo_Id = item3.Insp_Sub_Photo_Id,
                                                Insp_Sub_Finding_Id = Obj1.Status_Code,
                                                Insp_Finding_Id = Obj.Status_Code,
                                                Insp_Request_Id = entity.Insp_Request_Id,
                                                File_Path = item3.File_Path,
                                                CreatedBy = entity.CreatedBy,
                                            };
                                            var Obj3 = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        }
                                    }
                                }
                            }
                        }
                        if (entity.Insp_Leader_Finding_Sub_Photo_List != null && entity.Insp_Leader_Finding_Sub_Photo_List.Count > 0)
                        {
                            foreach (var item1 in entity.Insp_Leader_Finding_Sub_Photo_List)
                            {
                                var parameters8 = new
                                {
                                    Insp_Leader_Sub_Photo_Id = item1.Insp_Leader_Sub_Photo_Id,
                                    Insp_Finding_Id = Obj.Status_Code,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                    File_Path = item1.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                var Obj_Finding_Sub_Photo = (await connection.QueryAsync<M_Return_Message>(procedure8, parameters8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }

                    }
                    await connection.QueryAsync<M_Return_Message>(procedure5, parameters5, commandType: CommandType.StoredProcedure);
                    var parameters7 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure7, parameters7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Add_Insp_Leader_Finding";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Find_ApprovalReject(M_Insp_Finding_Approval entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Finding_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Finding_Id = entity.Insp_Finding_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Find_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Sub_Photos_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Sub_Photo_Id = entity.Insp_Sub_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Sub_Find_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Corrective_Action_Add";
                string procedure1 = "sp_Insp_Leader_Corrective_Action_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Insp_Request_Id = entity[0].Insp_Request_Id,
                        CreatedBy = entity[0].CreatedBy,
                    };
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Corrective_Action_Id = item.Corrective_Action_Id,
                            Insp_Finding_Id = item.Insp_Finding_Id,
                            Insp_Request_Id = item.Insp_Request_Id,
                            Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                            Assignee_Type = item.Assignee_Type,
                            Responsibility_To = item.Responsibility_To,
                            Target_Date = item.Target_Date,
                            Action_Description = item.Action_Description,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                    }
                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure);

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Leader_Corrective_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Insp_Leader_Request>> Insp_Leader_Corrective_Action_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Leader_Corrective_Action_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Leader_Request>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Corrective_Action_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Leader_Request> Insp_Leader_CA_GetById(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Request_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure7 = "sp_Insp_Leader_Req_Reject_GetbyId";
                string procedure11 = "sp_Insp_Leader_Finding_GetbyId";
                string procedure12 = "sp_Insp_Leader_Sub_Finding_GetbyId";
                string procedure14 = "sp_Insp_Leader_Sub_Photos_GetbyId";
                string procedure15 = "sp_Insp_Employee_Based_Zone_Com";
                string procedure16 = "sp_Insp_Category_Master_GetAll";
                string procedure18 = "sp_Insp_Leader_Finding_Reject_GetbyId";
                string procedure19 = "sp_Insp_Leader_Action_Closure_GetbyId";
                string procedure20 = "sp_Insp_Leader_Action_Closure_Photos_GetbyId";
                string procedure21 = "sp_Insp_Leader_CA_Reject_GetbyId";
                string procedure22 = "sp_Insp_Leader_CA_ReAssign_GetbyId";
                string procedure26 = "sp_Insp_Leader_Find_Sub_Photos_GetById";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Leader_Request>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = new List<Dropdown_Values>();
                        Obj!.Insp_Request_Reject_List = new List<Insp_Request_Reject>();
                        Obj!.Insp_Spot_Finding_List = new M_Insp_Spot_Finding();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                        }
                        else
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Request_Reject = (await connection.QueryAsync<Insp_Request_Reject>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Type_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Inspection_Type_Master_List = Type_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Request_Reject != null)
                            {
                                Obj!.Insp_Request_Reject_List = Request_Reject;
                            }
                        }

                        var Obj_Finding = (await connection.QueryAsync<M_Insp_Spot_Finding>(procedure11, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                        if (Obj_Finding != null)
                        {
                            Obj_Finding.Main_Status = Obj.Status;
                            Obj_Finding.Req_Createdby = Obj.CreatedBy;
                            Obj_Finding.Business_Unit_Name = Obj.Business_Unit_Name;
                            Obj_Finding.Zone_Name = Obj.Zone_Name;
                            Obj_Finding.Community_Name = Obj.Community_Name;
                            Obj_Finding.Building_Name = Obj.Building_Name;
                            Obj_Finding.Insp_Type_Name = Obj.Insp_Type_Name;
                            Obj_Finding.Req_Description = Obj.Req_Description;
                            DateTime StartDate = Convert.ToDateTime(Obj.Inspection_Date);
                            Obj.Inspection_Date = StartDate.ToString("dd-MMM-yyyy");
                            Obj_Finding.Inspection_Date = Obj.Inspection_Date;
                            var parameters_Emp = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Rej = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                                Insp_Finding_Id = Obj_Finding.Insp_Finding_Id,
                            };
                            var Obj_Finding_Sub_Photo = (await connection.QueryAsync<M_Insp_Leader_Finding_Sub_Photo>(procedure26, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Finding_Sub_Photo != null && Obj_Finding_Sub_Photo.Count > 0)
                            {
                                Obj_Finding.Insp_Leader_Finding_Sub_Photo_List = Obj_Finding_Sub_Photo;
                            }

                            var Obj_Emp_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure15, parameters_Emp, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Emp_List != null && Obj_Emp_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Emp_Master_List = Obj_Emp_List;
                            }
                            var Obj_Cat_List = (await connection.QueryAsync<M_Insp_Value_Text>(procedure16, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Cat_List != null && Obj_Cat_List.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Category_Master_List = Obj_Cat_List;
                            }
                            var Obj_Sub_Finding_Rej = (await connection.QueryAsync<Insp_Finding_Reject>(procedure18, parameters_Rej, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding_Rej != null && Obj_Sub_Finding_Rej.Count > 0)
                            {
                                Obj_Finding.Insp_Finding_Reject_List = Obj_Sub_Finding_Rej;
                            }
                            var Obj_Sub_Finding = (await connection.QueryAsync<M_Insp_Spot_Sub_Finding>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_Sub_Finding != null && Obj_Sub_Finding.Count > 0)
                            {
                                Obj_Finding.Insp_Spot_Sub_Finding_List = Obj_Sub_Finding;
                                foreach (var item in Obj_Sub_Finding)
                                {
                                    var parameters_Sub = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                    };
                                    var parameters_Sub1 = new
                                    {
                                        Insp_Sub_Finding_Id = item.Insp_Sub_Finding_Id,
                                        CreatedBy = entity.CreatedBy,
                                    };

                                    var Obj_Sub_Finding_Photo = (await connection.QueryAsync<M_Insp_Spot_Find_Sub_Photo>(procedure14, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                    var Obj_Sub_Finding_CA = (await connection.QueryAsync<M_Insp_Spot_Corrective_Action>(procedure19, parameters_Sub1, commandType: CommandType.StoredProcedure)).ToList();

                                    if (Obj_Sub_Finding_Photo != null && Obj_Sub_Finding_Photo.Count > 0)
                                    {
                                        item.Insp_Spot_Find_Sub_Photo_List = Obj_Sub_Finding_Photo;
                                    }
                                    if (Obj_Sub_Finding_CA != null && Obj_Sub_Finding_CA.Count > 0)
                                    {
                                        foreach (var itemss in Obj_Sub_Finding_CA)
                                        {
                                            var parameters_Cass = new
                                            {
                                                Corrective_Action_Id = itemss.Corrective_Action_Id,
                                            };
                                            var Obj_CA_Photos = (await connection.QueryAsync<M_Insp_Spot_CA_Photo>(procedure20, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Spot_CA_Reject>(procedure21, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            var Obj_CA_ReAsign = (await connection.QueryAsync<M_Insp_Spot_CA_Re_Assign>(procedure22, parameters_Cass, commandType: CommandType.StoredProcedure)).ToList();
                                            if (Obj_CA_Photos != null && Obj_CA_Photos.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Photo_List = Obj_CA_Photos;
                                            }
                                            if (Obj_CA_Rej != null && Obj_CA_Rej.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_Reject_List = Obj_CA_Rej;
                                            }
                                            if (Obj_CA_ReAsign != null && Obj_CA_ReAsign.Count > 0)
                                            {
                                                itemss.Insp_Spot_CA_ReAssign_List = Obj_CA_ReAsign;
                                            }
                                        }
                                        item.Insp_Spot_Find_Corrective_Action_List = Obj_Sub_Finding_CA;
                                    }
                                }
                            }
                            Obj.Insp_Spot_Finding_List = Obj_Finding;
                        }
                    }


                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_CA_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_CA_Action_Closure_Add";
                string procedure1 = "sp_Insp_Leader_CA_Action_Closure_Photos_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Closure_Action_Description = entity.Closure_Action_Description,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        if (entity.Insp_Spot_CA_Photo_List != null)
                        {
                            foreach (var item in entity.Insp_Spot_CA_Photo_List)
                            {
                                var parameters1 = new
                                {
                                    Corrective_Action_Id = item.Corrective_Action_Id,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Leader_CA_Action_Closure_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_CA_ReAssign(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_CA_ReAssign_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Responsibility_To = entity.Responsibility_To,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_CA_ReAssign";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_CA_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_CA_Photo_Id = entity.Insp_CA_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_CA_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_CA_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Corrective_Action_Id = entity.Corrective_Action_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Status = entity.Status,
                        Reject_Reason = entity.Description,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_CA_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Insp_Leader_WalkIn_Finding(M_Insp_Leader_Request entity)
        {
            try
            {
                string procedure1 = "sp_Insp_Leader_Request_Add";
                string procedure2 = "sp_Insp_Leader_Finding_Add";
                string procedure3 = "sp_Insp_Leader_Sub_Finding_Add";
                string procedure4 = "sp_Insp_Leader_Sub_Photos_Add";
                string procedure5 = "sp_Insp_Leader_Req_Find_Status_Update_GetbyId";
                string procedure7 = "sp_Insp_Leader_History_Approval_Walkin_Find_Update";
                string procedure8 = "sp_Insp_Leader_Finding_Sub_Photo_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters1 = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Zone_Director_Id = entity.Zone_Director_Id,
                        HSSE_Director_Id = entity.HSSE_Director_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                        Req_Description = entity.Req_Description,
                        Category_Id = entity.Category_Id,
                        Other_Attendees = entity.Other_Attendees,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_Spot_Finding_List != null)
                        {
                            var parameters2 = new
                            {
                                Insp_Finding_Id = entity.Insp_Spot_Finding_List.Insp_Finding_Id,
                                Insp_Request_Id = obj.Return_1,
                                Summary = entity.Insp_Spot_Finding_List.Summary,
                                Highlights = entity.Insp_Spot_Finding_List.Highlights,
                                Lowlights = entity.Insp_Spot_Finding_List.Lowlights,
                                CreatedBy = entity.CreatedBy,
                            };
                            var Obj_Find = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            if (Obj_Find != null)
                            {
                                if (entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List != null && entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List.Count > 0)
                                {
                                    foreach (var item1 in entity.Insp_Spot_Finding_List.Insp_Spot_Sub_Finding_List)
                                    {
                                        var parameters3 = new
                                        {
                                            Insp_Sub_Finding_Id = item1.Insp_Sub_Finding_Id,
                                            Insp_Finding_Id = Obj_Find.Status_Code,
                                            Insp_Request_Id = obj.Return_1,
                                            Observations = item1.Observations,
                                            Latitude = item1.Latitude,
                                            Longitude = item1.Longitude,
                                            Action_Required = item1.Action_Required,
                                            Type = item1.Type,
                                            CreatedBy = entity.CreatedBy,
                                            Location_Address = item1.Location_Address,
                                            Exact_Location_Address = item1.Exact_Location_Address,
                                        };
                                        var Obj_Sub_Find = (await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                        if (Obj_Sub_Find != null)
                                        {
                                            if (item1.Insp_Spot_Find_Sub_Photo_List != null && item1.Insp_Spot_Find_Sub_Photo_List.Count > 0)
                                            {
                                                foreach (var item3 in item1.Insp_Spot_Find_Sub_Photo_List!)
                                                {
                                                    var parameters4 = new
                                                    {
                                                        Insp_Sub_Photo_Id = item3.Insp_Sub_Photo_Id,
                                                        Insp_Sub_Finding_Id = Obj_Sub_Find.Status_Code,
                                                        Insp_Finding_Id = Obj_Find.Status_Code,
                                                        Insp_Request_Id = obj.Return_1,
                                                        File_Path = item3.File_Path,
                                                        CreatedBy = entity.CreatedBy,
                                                    };
                                                    var Obj3 = (await connection.QueryAsync<M_Return_Message>(procedure4, parameters4, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                                }
                                            }
                                        }
                                    }
                                }
                                if (entity.Insp_Spot_Finding_List.Insp_Leader_Finding_Sub_Photo_List != null && entity.Insp_Spot_Finding_List.Insp_Leader_Finding_Sub_Photo_List.Count > 0)
                                {
                                    foreach (var item1 in entity.Insp_Spot_Finding_List.Insp_Leader_Finding_Sub_Photo_List)
                                    {
                                        var parameters8 = new
                                        {
                                            Insp_Leader_Sub_Photo_Id = item1.Insp_Leader_Sub_Photo_Id,
                                            Insp_Finding_Id = Obj_Find.Status_Code,
                                            Insp_Request_Id = obj.Return_1,
                                            File_Path = item1.File_Path,
                                            CreatedBy = entity.CreatedBy,
                                        };
                                        var Obj_Finding_Sub_Photo = (await connection.QueryAsync<M_Return_Message>(procedure8, parameters8, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                    }
                                }
                            }
                            var parameters5 = new
                            {
                                Insp_Request_Id = obj.Return_1,
                            };
                            var parameters7 = new
                            {
                                Insp_Request_Id = obj.Return_1,
                                Insp_Finding_Id = entity.Insp_Spot_Finding_List.Insp_Finding_Id,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure5, parameters5, commandType: CommandType.StoredProcedure);
                            var obj_His = (await connection.QueryAsync<M_Return_Message>(procedure7, parameters7, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                        }
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = M_Return_Status_Text.SUCCESS,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = M_Return_Status_Code.OK
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Add_Insp_Leader_WalkIn_Finding";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }
        public async Task<M_Return_Message> Insp_Leader_Find_Photo_Delete(M_Insp_Leader_Finding_Sub_Photo entity)
        {
            try
            {
                string procedure = "sp_Insp_Leader_Find_Photo_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Leader_Sub_Photo_Id = entity.Insp_Leader_Sub_Photo_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Leader_Find_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Advisory Notice Insp]
        public async Task<IReadOnlyList<M_Complaint_Register>> Insp_Complaint_Register_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Complaint_Register_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Complaint_Register>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Request_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Complaint_Register> Insp_Complaint_Register_GetById(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Complaint_Register_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure3 = "sp_Insp_Type_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_Building_Master_GetbyId_Zone_Com";
                string procedure6 = "sp_Insp_Joint_Req_Service_Provider_GetbyId";
                string procedure7 = "sp_Insp_Advisory_Notice_History_Approval_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Complaint_Register>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Insp_AN_Approval_History_List = new List<Insp_AN_Approval_History>();
                        if (entity.Complaint_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Type_Master = (await connection.QueryAsync<Dropdown_Values>(procedure3, commandType: CommandType.StoredProcedure)).ToList();
                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                        }
                        else
                        {
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();

                            var parameters_Zone = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };
                            var parameters_Super_Reqs = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Building_Master = (await connection.QueryAsync<Dropdown_Values>(procedure5, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            var Super_Req_Emps = (await connection.QueryAsync<Dropdown_Values>(procedure6, parameters_Super_Reqs, commandType: CommandType.StoredProcedure)).ToList();
                            var AN_History = (await connection.QueryAsync<Insp_AN_Approval_History>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Building_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Building_Master_List = Building_Master;
                            }
                            if (Super_Req_Emps != null)
                            {
                                Obj!.Inc_Comman_Master_List.Supervisor_Req_List = Super_Req_Emps;
                            }
                            if (AN_History != null)
                            {
                                Obj!.Insp_AN_Approval_History_List = AN_History;
                            }
                        }
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Complaint_Register_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Complaint_Register_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Complaint_Register_Add";
                string procedure1 = "sp_Insp_Complaint_Register_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Customer_Name = entity.Customer_Name,
                        Customer_Address = entity.Customer_Address,
                        Customer_Email = entity.Customer_Email,
                        Customer_Number = entity.Customer_Number,
                        Date_Complaint = entity.Date_Complaint,
                        Received_Via = entity.Received_Via,
                        Name_Complaint = entity.Name_Complaint,
                        Description_Complaint = entity.Description_Complaint,
                        CreatedBy = entity.CreatedBy,
                        Walk_In_Insp_Name = entity.Walk_In_Insp_Name,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        var parameters1 = new
                        {
                            Complaint_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Complaint_Register_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Complaint_Service_Request_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Complaint_Service_Request_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        Target_Date = entity.Target_Date,
                        Service_Provider_Id = entity.Service_Provider_Id,
                        Action_Details = entity.Action_Details,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Complaint_Service_Request_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Complaint_Assessment_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Complaint_Assessment_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        Closure_Action_Details = entity.Closure_Action_Details,
                        Closure_File_Path = entity.Closure_File_Path,
                        If_Observation = entity.If_Observation,
                        Observation_Action_Details = entity.Observation_Action_Details,
                        Ob_Recommended_Action_Details = entity.Ob_Recommended_Action_Details,
                        Ob_File_Path = entity.Ob_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Complaint_Service_Request_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Complaint_Register> Insp_Pre_Advisory_Notice_GetById(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Pre_Advisory_Notice_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Complaint_Register>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Pre_Advisory_Notice_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Pre_Sub_Advisory_Notice_Report_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Pre_Sub_Advisory_Notice_Report_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        Date_Complaint = entity.Date_Complaint,
                        Customer_Name = entity.Customer_Name,
                        Customer_Address = entity.Customer_Address,
                        Name_Complaint = entity.Name_Complaint,
                        Description_Complaint = entity.Description_Complaint,
                        Observation_Action_Details = entity.Observation_Action_Details,
                        Ob_Recommended_Action_Details = entity.Ob_Recommended_Action_Details,
                        Ob_File_Path = entity.Ob_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1,
                        Return_2 = obj!.Return_2,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Pre_Sub_Advisory_Notice_Report_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Pre_Advisory_Notice_Report_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Pre_Advisory_Notice_Report_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        Date_Complaint = entity.Date_Complaint,
                        Customer_Name = entity.Customer_Name,
                        Customer_Address = entity.Customer_Address,
                        Name_Complaint = entity.Name_Complaint,
                        Description_Complaint = entity.Description_Complaint,
                        Observation_Action_Details = entity.Observation_Action_Details,
                        Ob_Recommended_Action_Details = entity.Ob_Recommended_Action_Details,
                        Ob_File_Path = entity.Ob_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1,
                        Return_2 = obj!.Return_2,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Pre_Sub_Advisory_Notice_Report_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Pre_Sub_Advisory_Notice_No_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Pre_Sub_Advisory_Notice_No_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Complaint_Service_Request_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Advisory_Notice_Final_Add(M_Complaint_Register entity)
        {
            try
            {
                string procedure = "sp_Insp_Advisory_Notice_Final_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Complaint_Id = entity.Complaint_Id,
                        AN_Closure_Action_Details = entity.AN_Closure_Action_Details,
                        AN_Closure_Remarks = entity.AN_Closure_Remarks,
                        AN_File_Path = entity.AN_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Advisory_Notice_Final_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Create Schedule]
        public async Task<IReadOnlyList<Insp_Audit_Building_Model>> Get_All_Building_Load(Insp_Audit_Building_Model entity)
        {
            try
            {
                string procedure = "sp_Get_All_Building_byZone";
                string Procedure_Type = "sp_Get_All_Audit_Insp_Sch_Load";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id
                    };
                    var building_List = (await connection.QueryAsync<Insp_Audit_Building_Model>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                    if (building_List != null && building_List.Count > 0)
                    {
                        foreach (var item in building_List)
                        {
                            var param = new
                            {
                                Sub_Building_Id = item.Sub_Building_Id
                            };
                            var _list = (await connection.QueryAsync<Audit_Insp_Schd_List>(Procedure_Type, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                            item._Scheduled_List = _list;
                        }

                    }

                    return building_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Building_Load";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Audit_Insp_Emp_List>> Get_All_Audit_Insp_Emp()
        {
            try
            {
                string procedure = "sp_Get_All_Audit_Insp_Sch_Emp";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Audit_Insp_Emp_List>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Audit_Insp_Emp";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Insp_Audit_Building_Model>> Get_Building_Base_Sch_Load(Insp_Audit_Building_Model entity)
        {
            try
            {
                string procedure = "sp_Get_Insp_Audit_Onclick_Building";
                string Procedure_Type = "sp_Get_All_Audit_Insp_Sch_Load";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Sub_Building_Id = entity.Sub_Building_Id
                    };
                    var building_List = (await connection.QueryAsync<Insp_Audit_Building_Model>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                    if (building_List != null && building_List.Count > 0)
                    {
                        foreach (var item in building_List)
                        {
                            var param = new
                            {
                                Sub_Building_Id = item.Sub_Building_Id
                            };
                            var _list = (await connection.QueryAsync<Audit_Insp_Schd_List>(Procedure_Type, param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                            item._Scheduled_List = _list;
                        }

                    }

                    return building_List;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_Building_Base_Sch_Load";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Audit_Insp_Sch_Row_Submit(Audit_Insp_Row_Submit entity)
        {
            try
            {
                string procedure = "sp_Audit_Insp_Add_Sch_Row";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Type_Id == "HealthSafetyBuilding" || entity.Type_Id == "HealthSafetyCommunity")
                    {
                        var param_Build = new
                        {
                            Insp_HealthSafety_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Date_of_Inspection = entity.Inspection_Date,
                            Status = entity.Status,
                            Health_Safety_Type = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,

                        };
                        var List = (await connection.QueryAsync<Audit_Insp_Row_Submit>(procedure, param_Build, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }
                    else if (entity.Type_Id == "ServiceProviderMaster" || entity.Type_Id == "ServiceProviderBuilding")
                    {
                        var param_Build = new
                        {
                            Insp_Service_Provider_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Status = entity.Status,
                            Service_Provider_Type = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                            Service_Provider_Id = entity.Service_Provider_Id,

                        };
                        var List = (await connection.QueryAsync<Audit_Insp_Row_Submit>(procedure, param_Build, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "InternalAudit")
                    {
                        var parameters = new
                        {
                            Internal_Audit_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Remarks_1 = entity.Building_Id,
                            Remarks_3 = entity.Schedule_Type,
                            Remarks_4 = entity.Access_Schedule,
                            Date_Time = entity.Inspection_Date,
                            Status = entity.Status,
                            Remarks_2 = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "FireSafety")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Status = entity.Status,
                            Type_Id = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "SpotInspection")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Status = entity.Status,
                            Type_Id = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                            Category_Id = entity.Category_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "ServiceProviderAudit")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Status = entity.Status,
                            Type_Id = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                            Category_Id = entity.Category_Id,
                            Service_Provider_Id = entity.Service_Provider_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "JointInspection")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Zone_Id = entity.Zone_Id,
                            Community_Id = entity.Community_Id,
                            Building_Id = entity.Building_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Status = entity.Status,
                            Type_Id = entity.Type_Id,
                            Business_Unit_Id = entity.Business_Unit_Id,
                            CreatedBy = entity.CreatedBy,
                            Scope_Of_Work = entity.Scope_Of_Work,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }


                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }

        }
        //public async Task<M_Return_Message> Add_Audit_Insp_Sch_Table_Submit(Audit_Insp_Table_List entity)
        //{
        //    try
        //    {
        //        string procedure = "sp_Audit_Insp_Add_Sch_Row";
        //        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        //        {
        //            if (entity._Sch_List != null && entity._Sch_List.Count > 0)
        //            {
        //                if (entity._Sch_List[0].Type_Id == "HealthSafetyBuilding" || entity._Sch_List[0].Type_Id == "HealthSafetyCommunity")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_HealthSafety_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Date_of_Inspection = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Health_Safety_Type = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }

        //                }
        //                else if (entity._Sch_List[0].Type_Id == "ServiceProviderMaster" || entity._Sch_List[0].Type_Id == "ServiceProviderBuilding")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Service_Provider_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Inspection_Date = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Service_Provider_Type = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Service_Provider_Id = item.Service_Provider_Id,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }
        //                }
        //                else if (entity._Sch_List[0].Type_Id == "InternalAudit")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Internal_Audit_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Date_Time = item.Inspection_Date,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,

        //                            //Internal_Audit_Id = item.Insp_Request_Id,
        //                            //Zone_Id = item.Zone_Id,
        //                            //Community_Id = item.Community_Id,
        //                            //Remarks_1 = item.Building_Id,
        //                            //Remarks_3 = item.Schedule_Type,
        //                            //Remarks_4 = item.Access_Schedule,
        //                            //Date_Time = item.Inspection_Date,
        //                            //Status = item.Status,
        //                            //Remarks_2 = item.Type_Id,
        //                            //Business_Unit_Id = item.Business_Unit_Id,
        //                            //CreatedBy = item.CreatedBy,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }
        //                }
        //                else if (entity._Sch_List[0].Type_Id == "FireSafety")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Request_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Inspection_Date = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }
        //                }
        //                else if (entity._Sch_List[0].Type_Id == "SpotInspection")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Request_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Inspection_Date = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Category_Id = item.Category_Id,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }
        //                }
        //                else if (entity._Sch_List[0].Type_Id == "EnvironmentalAudit")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Env_Audit_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Date_Time = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Service_Provider_Id = item.Service_Provider_Id,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }

        //                }
        //                else if (entity._Sch_List[0].Type_Id == "ServiceProviderAudit")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Request_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Inspection_Date = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Category_Id = item.Category_Id,
        //                            Service_Provider_Id = item.Service_Provider_Id,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }
        //                }
        //                else if (entity._Sch_List[0].Type_Id == "WelfareAudit")
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Request_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Date_Time = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Service_Provider_Id = item.Service_Provider_Id,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }

        //                }
        //                else
        //                {
        //                    foreach (var item in entity._Sch_List)
        //                    {
        //                        var parameters = new
        //                        {
        //                            Insp_Request_Id = item.Insp_Request_Id,
        //                            Zone_Id = item.Zone_Id,
        //                            Community_Id = item.Community_Id,
        //                            Building_Id = item.Building_Id,
        //                            Schedule_Type = item.Schedule_Type,
        //                            Access_Schedule = item.Access_Schedule,
        //                            Inspection_Date = item.Inspection_Date,
        //                            Status = item.Status,
        //                            Type_Id = item.Type_Id,
        //                            Business_Unit_Id = item.Business_Unit_Id,
        //                            CreatedBy = item.CreatedBy,
        //                            Scope_Of_Work = item.Scope_Of_Work,
        //                        };
        //                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
        //                    }

        //                }
        //            }
        //            M_Return_Message rETURN_MESSAGE = new M_Return_Message
        //            {
        //                Status_Code = "200",
        //                Status = true,
        //                Message = "Success"
        //            };
        //            return rETURN_MESSAGE;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        M_Return_Message rETURN_MESSAGE = new M_Return_Message
        //        {
        //            Status_Code = "500",
        //            Status = false,
        //            Message = "Failed"
        //        };
        //        string Repo = "Add_Zone_Confined_Space";
        //        ErrorLog.ErrorLogs(ex, Repo);
        //        return rETURN_MESSAGE;
        //    }
        //}

        public async Task<M_Return_Message> Add_Audit_Insp_Sch_Table_Submit(Insp_Sch_Calendar_List entity)
        {
            try
            {
                string procedure = "Sp_Insp_Sch_Calendar_Add";
                string procedure_Aud = "sp_Audit_Insp_Add_Sch_Row";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity._Sch_Calendar_List != null && entity._Sch_Calendar_List.Count > 0)
                    {
                        if (entity._Sch_Calendar_List[0].Insp_Type == "InternalAudit")
                        {
                            foreach (var item in entity._Sch_Calendar_List)
                            {
                                var parameters = new
                                {
                                    Internal_Audit_Id = item.Insp_Sch_Calendar_Id,
                                    Business_Unit_Id = item.Business_Unit_Id,
                                    Zone_Id = item.Zone_Id,
                                    Community_Id = item.Community_Id,
                                    Building_Id = item.Building_Id,
                                    Date_Time = item.Initial_Date,
                                    Access_Schedule = item.Access_Schedule,
                                    Type_Id = item.Insp_Type,
                                    Schedule_Type = item.Frequency,
                                    CreatedBy = item.Created_by,
                                };
                                var List = (await connection.QueryAsync<M_Return_Message>(procedure_Aud, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        else if (entity._Sch_Calendar_List[0].Insp_Type == "EnvironmentalAudit")
                        {
                            foreach (var item in entity._Sch_Calendar_List)
                            {
                                var parameters = new
                                {
                                    Env_Audit_Id = item.Insp_Sch_Calendar_Id,
                                    Business_Unit_Id = item.Business_Unit_Id,
                                    Zone_Id = item.Zone_Id,
                                    Community_Id = item.Community_Id,
                                    Building_Id = item.Building_Id,
                                    Date_Time = item.Initial_Date,
                                    Access_Schedule = item.Access_Schedule,
                                    Type_Id = item.Insp_Type,
                                    Schedule_Type = item.Frequency,
                                    CreatedBy = item.Created_by,
                                    Service_Provider_Id = item.Service_Provider_Id,
                                };
                                var List = (await connection.QueryAsync<M_Return_Message>(procedure_Aud, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        else if (entity._Sch_Calendar_List[0].Insp_Type == "ServiceProviderAudit")
                        {
                            foreach (var item in entity._Sch_Calendar_List)
                            {
                                var parameters = new
                                {
                                    Insp_Request_Id = item.Insp_Sch_Calendar_Id,
                                    Business_Unit_Id = item.Business_Unit_Id,
                                    Zone_Id = item.Zone_Id,
                                    Community_Id = item.Community_Id,
                                    Building_Id = item.Building_Id,
                                    Inspection_Date = item.Initial_Date,
                                    Access_Schedule = item.Access_Schedule,
                                    Type_Id = item.Insp_Type,
                                    Schedule_Type = item.Frequency,
                                    CreatedBy = item.Created_by,
                                    Service_Provider_Id = item.Service_Provider_Id,
                                };
                                var List = (await connection.QueryAsync<M_Return_Message>(procedure_Aud, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        else if (entity._Sch_Calendar_List[0].Insp_Type == "WelfareAudit")
                        {
                            foreach (var item in entity._Sch_Calendar_List)
                            {
                                var parameters = new
                                {
                                    Insp_Request_Id = item.Insp_Sch_Calendar_Id,
                                    Business_Unit_Id = item.Business_Unit_Id,
                                    Zone_Id = item.Zone_Id,
                                    Community_Id = item.Community_Id,
                                    Building_Id = item.Building_Id,
                                    Date_Time = item.Initial_Date,
                                    Access_Schedule = item.Access_Schedule,
                                    Type_Id = item.Insp_Type,
                                    Schedule_Type = item.Frequency,
                                    CreatedBy = item.Created_by,
                                    Service_Provider_Id = item.Service_Provider_Id,
                                };
                                var List = (await connection.QueryAsync<M_Return_Message>(procedure_Aud, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        else
                        {
                            foreach (var item in entity._Sch_Calendar_List)
                            {
                                var parameters = new
                                {
                                    Insp_Sch_Calendar_Id = item.Insp_Sch_Calendar_Id,
                                    Business_Unit_Id = item.Business_Unit_Id,
                                    Zone_Id = item.Zone_Id,
                                    Community_Id = item.Community_Id,
                                    Building_Id = item.Building_Id,
                                    Initial_Date = item.Initial_Date,
                                    Access_Schedule = item.Access_Schedule,
                                    Insp_Type = item.Insp_Type,
                                    Frequency = item.Frequency,
                                    Created_by = item.Created_by,
                                    Service_Provider_Id = item.Service_Provider_Id,
                                    Scope_Work_Id = item.Scope_Work_Id,
                                    Category_Id = item.Category_Id,
                                };
                                var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                                     
                    }
                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Add_Zone_Confined_Space";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }
        }

        public async Task<Audit_Insp_Row_Submit> Insp_Audit_Edit_Row(Audit_Insp_Row_Submit entity)
        {
            try
            {
                string procedure = "sp_Insp_Audit_Sch_Edit_Row";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Insp_Type = entity.Type_Id,
                    };

                    var Sch = (await connection.QueryAsync<Audit_Insp_Row_Submit>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    return Sch;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Audit_Edit_Row";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Insp_Sch_Row_Submit(Update_Audit_Insp_Row_Submit entity)
        {
            try
            {
                string procedure = "sp_Audit_Insp_Update_Sch_Row";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    if (entity.Type_Id == "JointInspection")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Scope_Work_Id = entity.Scope_Work_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "HealthSafetyBuilding" || entity.Type_Id == "HealthSafetyCommunity")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    else if (entity.Type_Id == "ServiceProviderMaster" || entity.Type_Id == "ServiceProviderBuilding")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Service_Provider_Id =entity.Service_Provider_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }              

                    else if (entity.Type_Id == "FireSafety")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "SpotInspection")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Category_Id = entity.Category_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "LeadershipTour")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Insp_Sch_Calendar_Id = entity.Insp_Sch_Calendar_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if(entity.Type_Id == "InternalAudit")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "Service Provider Audit")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Service_Provider_Id = entity.Service_Provider_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "EnvironmentalAudit")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Service_Provider_Id = entity.Service_Provider_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    else if (entity.Type_Id == "WelfareAudit")
                    {
                        var parameters = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            Schedule_Type = entity.Schedule_Type,
                            Access_Schedule = entity.Access_Schedule,
                            Inspection_Date = entity.Inspection_Date,
                            Type_Id = entity.Type_Id,
                            Service_Provider_Id = entity.Service_Provider_Id,
                        };
                        var List = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Status_Code = "200",
                        Status = true,
                        Message = "Success"
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Status_Code = "500",
                    Status = false,
                    Message = "Failed"
                };
                string Repo = "Update_Insp_Sch_Row_Submit";
                ErrorLog.ErrorLogs(ex, Repo);
                return rETURN_MESSAGE;
            }

        }

        public async Task<IReadOnlyList<Audit_Insp_Emp_List>> LoadAll_Service_Provider(Insp_Audit_Building_Model entity)
        {
            try
            {
                string procedure = "sp_Get_Audit_Insp_Sch_SP";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Community_Id = entity.Community_Id
                    };
                    return (await connection.QueryAsync<Audit_Insp_Emp_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Audit_Insp_Emp";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Landscape Inspection]
        public async Task<IReadOnlyList<M_Insp_Landscape>> Insp_Landscape_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Landscape_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Landscape_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Landscape> Insp_Landscape_GetById(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_tbl_Insp_landscap_Check_Master_GetAll";
                string procedure6 = "sp_tbl_Insp_landscap_Check_Sub_Master_GetAll";
                string procedure7 = "sp_Insp_Landscape_Qns_Cat_GetbyId";
                string procedure8 = "sp_Insp_Landscape_Qns_Sub_Cat_GetbyId";
                string procedure9 = "sp_Insp_Land_Service_Provider_Company_GetbyId_Building";
                string procedure10 = "sp_Insp_Land_ZoneWise_All_Emp_GetbyId";
                string procedure11 = "sp_Insp_Landscape_Closure_Access_GetbyId";
                string procedure12 = "sp_Insp_Landscape_CA_Reject_GetbyId";
                string procedure13 = "sp_Insp_Landscape_History_Approval_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Insp_landscap_SP_Company_List = new List<M_Insp_Master_List>();
                        Obj!.Insp_landscap_Zone_Emp_List = new List<M_Insp_Master_List>();
                        Obj!.Insp_landscap_History_List = new List<Insp_landscap_History>();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var parameters_Zone = new
                            {
                                Zone_Id = entity.Zone_Id
                            };
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();
                            var Insp_landscap_Check_Master_List = (await connection.QueryAsync<M_Insp_Landscap_Master_List>(procedure5, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Zone_Emp = (await connection.QueryAsync<M_Insp_Master_List>(procedure10, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Obj_Zone_Emp != null)
                            {
                                Obj.Insp_landscap_Zone_Emp_List = Obj_Zone_Emp;
                            }

                            foreach (var item in Insp_landscap_Check_Master_List)
                            {
                                var parameters_Cat = new
                                {
                                    Insp_Landscap_Mas_Id = item.Value,
                                };
                                var Sub_Cat_List = (await connection.QueryAsync<M_Insp_Master_List>(procedure6, parameters_Cat, commandType: CommandType.StoredProcedure)).ToList();
                                item.Insp_landscap_Check_Sub_Master_List = Sub_Cat_List;
                            }
                            Obj!.Insp_landscap_Check_Master_List = Insp_landscap_Check_Master_List;
                        }
                        else
                        {
                            var parameters_Build = new
                            {
                                Building_Id = Obj.Building_Id
                            };
                            //var parameters_Zone = new
                            //{
                            //    Zone_Id = Obj.Zone_Id
                            //};
                            var Obj_Cat = (await connection.QueryAsync<Insp_Edit_Landscape>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_SP_Company = (await connection.QueryAsync<M_Insp_Master_List>(procedure9, parameters_Build, commandType: CommandType.StoredProcedure)).ToList();
                            //var Obj_Zone_Emp = (await connection.QueryAsync<M_Insp_Master_List>(procedure10, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_SP_Company != null)
                            {
                                Obj.Insp_landscap_SP_Company_List = Obj_SP_Company;
                            }
                            //if (Obj_Zone_Emp != null)
                            //{
                            //    Obj.Insp_landscap_Zone_Emp_List = Obj_Zone_Emp;
                            //}
                            if (Obj_Cat != null)
                            {
                                foreach (var item in Obj_Cat)
                                {
                                    var parameters1 = new
                                    {
                                        Insp_Request_Id = item.Insp_Request_Id,
                                        Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                                    };
                                    var Obj_Sub_Cat = (await connection.QueryAsync<Insp_Landscape_Qns>(procedure8, parameters1, commandType: CommandType.StoredProcedure)).ToList();
                                    if (Obj_Sub_Cat != null)
                                    {
                                        foreach (var item_sub in Obj_Sub_Cat)
                                        {
                                            if (item_sub.Status == "2")
                                            {
                                                var parameters_Sub = new
                                                {
                                                    Landscape_Qns_Id = item_sub.Landscape_Qns_Id,
                                                };
                                                var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Land_CA_Reject>(procedure12, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                                if (Obj_CA_Rej != null)
                                                {
                                                    item_sub.Insp_Land_CA_Reject_List = Obj_CA_Rej;
                                                }
                                            }
                                        }
                                        item.Edit_Insp_landscap_Sub_List = Obj_Sub_Cat;
                                    }
                                }
                            }
                            Obj.Edit_Insp_landscap_List = Obj_Cat;

                            if (Obj.Status == "Action Closure Pending")
                            {
                                var parameters_Access = new
                                {
                                    CreatedBy = entity.CreatedBy,
                                    Company_Id = Obj.Company_Id,
                                    Responsible_Dept = Obj.Responsible_Dept,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                };
                                var CA_Access = (await connection.QueryAsync<M_Insp_Landscape>(procedure11, parameters_Access, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                                if (CA_Access != null)
                                {
                                    Obj.If_Closure_Access = CA_Access.If_Closure_Access;
                                }

                            }

                            var parameters_His = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                            };
                            var Obj_History = (await connection.QueryAsync<Insp_landscap_History>(procedure13, parameters_His, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_History != null)
                            {
                                Obj.Insp_landscap_History_List = Obj_History;
                            }
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Landscape_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_Add(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_Add";
                string procedure1 = "sp_Insp_Landscape_Qns_Add";
                string procedure2 = "sp_Insp_Landscape_Qns_Status_Update";
                string procedure3 = "sp_Insp_Land_Zone_CA_Employee_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Company_Id = entity.Company_Id,
                        Responsible_Dept = entity.Responsible_Dept,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_landscap_Qns_List != null && entity.Insp_landscap_Qns_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_landscap_Qns_List)
                            {
                                var parameters1 = new
                                {
                                    Landscape_Qns_Id = item.Landscape_Qns_Id,
                                    Insp_Request_Id = obj.Return_1,
                                    Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                                    Insp_Landscap_Sub_Mas_Id = item.Insp_Landscap_Sub_Mas_Id,
                                    Qns_Action = item.Qns_Action,
                                    Qns_Remarks = item.Qns_Remarks,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }
                        if (entity.Insp_landscap_Zone_Emp_List != null && entity.Insp_landscap_Zone_Emp_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_landscap_Zone_Emp_List)
                            {
                                var parameters3 = new
                                {
                                    Insp_Request_Id = obj.Return_1,
                                    Employee_Id = item.Value,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_Status = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_CA_Add(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_CA_Update";
                string procedure1 = "sp_Insp_Land_Zone_CA_Employee_Add";
                string procedure2 = "sp_Insp_Landscape_CA_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Company_Id = entity.Company_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (obj.Status_Code == "200")
                        {
                            if (entity.Insp_landscap_Zone_Emp_List != null && entity.Insp_landscap_Zone_Emp_List.Count > 0)
                            {
                                foreach (var item in entity.Insp_landscap_Zone_Emp_List)
                                {
                                    var parameters1 = new
                                    {
                                        Insp_Request_Id = entity.Insp_Request_Id,
                                        Employee_Id = item.Value,
                                        CreatedBy = entity.CreatedBy,
                                    };
                                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                                }
                            }
                        }

                        var parameters_Status = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_CA_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_CA_Closue_Add(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_CA_Closue_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Landscape_Qns_Id = entity.Landscape_Qns_Id,
                        Closure_Description = entity.Closure_Description,
                        Closure_File_Path = entity.Closure_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_CA_Closue_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Landscape>> Insp_Landscape_CA_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_Landscape_CA_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Landscape_CA_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_CA_Approval(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_CA_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Landscape_Qns_Id = entity.Landscape_Qns_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Reject_Reason = entity.Reject_Reason,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_CA_Multi_Reject(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_CA_Multi_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Insp_Land_CA_Reject_List != null)
                    {


                        foreach (var item in entity.Insp_Land_CA_Reject_List)
                        {
                            var parameters = new
                            {
                                Landscape_Qns_Id = item.Landscape_Qns_Id,
                                Remarks = item.Remarks,
                                CreatedBy = entity.CreatedBy,
                                Reject_Reason = item.Reject_Reason,
                            };
                            var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = "Rejected Successfully",
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = "200",
                            Return_1 = "0"
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = "Failed",
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = "500",
                            Return_1 = "0"
                        };
                        return rETURN_MESSAGE;
                    }

                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_Landscape_CA_Final_Approve(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_Landscape_CA_Final_Approve";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Final_Approve_Comments = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_Landscape_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Master_List>> Insp_Land_ZoneWise_All_Emp_GetbyId(M_Insp_Master_List entity)
        {
            try
            {
                var parameters = new
                {
                    Zone_Id = entity.Value,
                };
                string procedure = "sp_Insp_Land_ZoneWise_All_Emp_GetbyId";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Master_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Landscape_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Master_List>> Insp_Land_Service_Provider_Company_GetbyId(M_Insp_Master_List entity)
        {
            try
            {
                var parameters = new
                {
                    Building_Id = entity.Value,
                };
                string procedure = "sp_Insp_Land_Service_Provider_Company_GetbyId_Building";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Master_List>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_Land_Service_Provider_Company_GetbyId";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [SoftService Inspection]
        public async Task<IReadOnlyList<M_Insp_Landscape>> Insp_SoftService_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_SoftService_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Insp_Landscape> Insp_SoftService_GetById(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_GetbyId";
                string procedure1 = "sp_Business_Unit_Master_GetAll";
                string procedure2 = "sp_Zone_Master_GetAll";
                string procedure4 = "sp_Community_Master_GetbyId_Zone";
                string procedure5 = "sp_tbl_Insp_SoftService_Check_Master_GetAll";
                string procedure6 = "sp_tbl_Insp_SoftService_Check_Sub_Master_GetAll";
                string procedure7 = "sp_Insp_SoftService_Qns_Cat_GetbyId";
                string procedure8 = "sp_Insp_SoftService_Qns_Sub_Cat_GetbyId";
                string procedure9 = "sp_Insp_SoftService_Service_Provider_Company_GetbyId_Building";
                string procedure10 = "sp_Insp_Land_ZoneWise_All_Emp_GetbyId";
                string procedure11 = "sp_Insp_SoftService_Closure_Access_GetbyId";
                string procedure12 = "sp_Insp_SoftService_CA_Reject_GetbyId";
                string procedure13 = "sp_Insp_SoftService_History_Approval_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj!.Inc_Comman_Master_List = new Basic_Master_Data();
                        Obj!.Inc_Comman_Master_List.Business_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Zone_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Community_Master_List = new List<Dropdown_Values>();
                        Obj!.Inc_Comman_Master_List.Building_Master_List = new List<Dropdown_Values>();
                        Obj!.Insp_landscap_SP_Company_List = new List<M_Insp_Master_List>();
                        Obj!.Insp_landscap_Zone_Emp_List = new List<M_Insp_Master_List>();
                        Obj!.Insp_landscap_History_List = new List<Insp_landscap_History>();
                        if (entity.Insp_Request_Id == "0")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = entity.Zone_Id,
                                Community_Id = 0,
                            };
                            var parameters_Zone = new
                            {
                                Zone_Id = entity.Zone_Id
                            };
                            var Business_Unit_Master = (await connection.QueryAsync<Dropdown_Values>(procedure1, commandType: CommandType.StoredProcedure)).ToList();
                            var Zone_Master = (await connection.QueryAsync<Dropdown_Values>(procedure2, commandType: CommandType.StoredProcedure)).ToList();
                            var Community_Master = (await connection.QueryAsync<Dropdown_Values>(procedure4, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();
                            var Insp_landscap_Check_Master_List = (await connection.QueryAsync<M_Insp_Landscap_Master_List>(procedure5, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_Zone_Emp = (await connection.QueryAsync<M_Insp_Master_List>(procedure10, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();

                            if (Business_Unit_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Business_Master_List = Business_Unit_Master;
                            }
                            if (Zone_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Zone_Master_List = Zone_Master;
                            }
                            if (Community_Master != null)
                            {
                                Obj!.Inc_Comman_Master_List.Community_Master_List = Community_Master;
                            }
                            if (Obj_Zone_Emp != null)
                            {
                                Obj.Insp_landscap_Zone_Emp_List = Obj_Zone_Emp;
                            }
                            foreach (var item in Insp_landscap_Check_Master_List)
                            {
                                var parameters_Cat = new
                                {
                                    Insp_Landscap_Mas_Id = item.Value,
                                };
                                var Sub_Cat_List = (await connection.QueryAsync<M_Insp_Master_List>(procedure6, parameters_Cat, commandType: CommandType.StoredProcedure)).ToList();
                                item.Insp_landscap_Check_Sub_Master_List = Sub_Cat_List;
                            }
                            Obj!.Insp_landscap_Check_Master_List = Insp_landscap_Check_Master_List;
                        }
                        else
                        {
                            var parameters_Build = new
                            {
                                Building_Id = Obj.Building_Id
                            };
                            //var parameters_Zone = new
                            //{
                            //    Zone_Id = Obj.Zone_Id
                            //};
                            var Obj_Cat = (await connection.QueryAsync<Insp_Edit_Landscape>(procedure7, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var Obj_SP_Company = (await connection.QueryAsync<M_Insp_Master_List>(procedure9, parameters_Build, commandType: CommandType.StoredProcedure)).ToList();
                            //var Obj_Zone_Emp = (await connection.QueryAsync<M_Insp_Master_List>(procedure10, parameters_Zone, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_SP_Company != null)
                            {
                                Obj.Insp_landscap_SP_Company_List = Obj_SP_Company;
                            }
                            //if (Obj_Zone_Emp != null)
                            //{
                            //    Obj.Insp_landscap_Zone_Emp_List = Obj_Zone_Emp;
                            //}
                            if (Obj_Cat != null)
                            {
                                foreach (var item in Obj_Cat)
                                {
                                    var parameters1 = new
                                    {
                                        Insp_Request_Id = item.Insp_Request_Id,
                                        Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                                    };
                                    var Obj_Sub_Cat = (await connection.QueryAsync<Insp_Landscape_Qns>(procedure8, parameters1, commandType: CommandType.StoredProcedure)).ToList();
                                    if (Obj_Sub_Cat != null)
                                    {
                                        foreach (var item_sub in Obj_Sub_Cat)
                                        {
                                            if (item_sub.Status == "2")
                                            {
                                                var parameters_Sub = new
                                                {
                                                    Landscape_Qns_Id = item_sub.Landscape_Qns_Id,
                                                };
                                                var Obj_CA_Rej = (await connection.QueryAsync<M_Insp_Land_CA_Reject>(procedure12, parameters_Sub, commandType: CommandType.StoredProcedure)).ToList();
                                                if (Obj_CA_Rej != null)
                                                {
                                                    item_sub.Insp_Land_CA_Reject_List = Obj_CA_Rej;
                                                }
                                            }
                                        }
                                        item.Edit_Insp_landscap_Sub_List = Obj_Sub_Cat;
                                    }
                                }
                            }
                            Obj.Edit_Insp_landscap_List = Obj_Cat;

                            if (Obj.Status == "Action Closure Pending")
                            {
                                var parameters_Access = new
                                {
                                    CreatedBy = entity.CreatedBy,
                                    Company_Id = Obj.Company_Id,
                                    Responsible_Dept = Obj.Responsible_Dept,
                                    Insp_Request_Id = entity.Insp_Request_Id,
                                };
                                var CA_Access = (await connection.QueryAsync<M_Insp_Landscape>(procedure11, parameters_Access, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                                if (CA_Access != null)
                                {
                                    Obj.If_Closure_Access = CA_Access.If_Closure_Access;
                                }

                            }

                            var parameters_His = new
                            {
                                Insp_Request_Id = entity.Insp_Request_Id,
                            };
                            var Obj_History = (await connection.QueryAsync<Insp_landscap_History>(procedure13, parameters_His, commandType: CommandType.StoredProcedure)).ToList();
                            if (Obj_History != null)
                            {
                                Obj.Insp_landscap_History_List = Obj_History;
                            }
                        }
                    }

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_Add(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_Add";
                string procedure1 = "sp_Insp_SoftService_Qns_Add";
                string procedure2 = "sp_Insp_SoftService_Qns_Status_Update";
                string procedure3 = "sp_Insp_SoftService_Zone_CA_Employee_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Building_Id = entity.Building_Id,
                        Inspection_Date = entity.Inspection_Date,
                        CreatedBy = entity.CreatedBy,
                        Company_Id = entity.Company_Id,
                        Responsible_Dept = entity.Responsible_Dept,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (entity.Insp_landscap_Qns_List != null && entity.Insp_landscap_Qns_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_landscap_Qns_List)
                            {
                                var parameters1 = new
                                {
                                    Landscape_Qns_Id = item.Landscape_Qns_Id,
                                    Insp_Request_Id = obj.Return_1,
                                    Insp_Landscap_Mas_Id = item.Insp_Landscap_Mas_Id,
                                    Insp_Landscap_Sub_Mas_Id = item.Insp_Landscap_Sub_Mas_Id,
                                    Qns_Action = item.Qns_Action,
                                    Qns_Remarks = item.Qns_Remarks,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.Insp_landscap_Zone_Emp_List != null && entity.Insp_landscap_Zone_Emp_List.Count > 0)
                        {
                            foreach (var item in entity.Insp_landscap_Zone_Emp_List)
                            {
                                var parameters3 = new
                                {
                                    Insp_Request_Id = obj.Return_1,
                                    Employee_Id = item.Value,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure3, parameters3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_Status = new
                        {
                            Insp_Request_Id = obj.Return_1,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                        Return_1 = obj!.Return_1
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_CA_Add(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_CA_Update";
                string procedure1 = "sp_Insp_SoftService_Zone_CA_Employee_Add";
                string procedure2 = "sp_Insp_SoftService_CA_Status_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Company_Id = entity.Company_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj != null)
                    {
                        if (obj.Status_Code == "200")
                        {
                            if (entity.Insp_landscap_Zone_Emp_List != null && entity.Insp_landscap_Zone_Emp_List.Count > 0)
                            {
                                foreach (var item in entity.Insp_landscap_Zone_Emp_List)
                                {
                                    var parameters1 = new
                                    {
                                        Insp_Request_Id = entity.Insp_Request_Id,
                                        Employee_Id = item.Value,
                                        CreatedBy = entity.CreatedBy,
                                    };
                                    await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                                }
                            }
                        }

                        var parameters_Status = new
                        {
                            Insp_Request_Id = entity.Insp_Request_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = obj!.Message,
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = obj!.Status_Code,
                    };
                    return rETURN_MESSAGE;
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_CA_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_CA_Closue_Add(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_CA_Closue_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Landscape_Qns_Id = entity.Landscape_Qns_Id,
                        Closure_Description = entity.Closure_Description,
                        Closure_File_Path = entity.Closure_File_Path,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_CA_Closue_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Insp_Landscape>> Insp_SoftService_CA_GetAll(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Business_Unit_Name = "";
                var Zone_Name = "";
                var Insp_Type_Name = "";
                var CreatedBy = "";
                var CreatedDate = "";
                var Status = "";
                if (entity.Columns! != null && entity.Columns!.Count > 0)
                {
                    foreach (var item in entity.Columns!)
                    {
                        int index = entity.Columns.IndexOf(item);
                        switch (index)
                        {
                            case 0:
                                UniqueID_Value = item.Search!.Value;
                                break;
                            case 1:
                                Business_Unit_Name = item.Search!.Value;
                                break;
                            case 2:
                                Zone_Name = item.Search!.Value;
                                break;
                            case 3:
                                Insp_Type_Name = item.Search!.Value;
                                break;
                            case 4:
                                CreatedBy = item.Search!.Value;
                                break;
                            case 5:
                                CreatedDate = item.Search!.Value;
                                break;
                            case 6:
                                Status = item.Search!.Value;
                                break;
                            default:
                                break;
                        }
                    }
                }
                var VarOrder = entity.Order![0].Column;
                var VarDir = entity.Order![0].Dir;
                var VarTopSearch = entity.Search!.Value;

                var parameters = new
                {
                    SearchValue = VarTopSearch,
                    PageNo = entity.page,
                    PageSize = entity.Length,
                    SortColumn = VarOrder,
                    SortDirection = VarDir,
                    CreatedBy = entity.CreatedBy,
                };
                string procedure = "sp_Insp_SoftService_CA_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Insp_Landscape>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Insp_SoftService_CA_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_CA_Approval(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_CA_Approval";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Landscape_Qns_Id = entity.Landscape_Qns_Id,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                        Reject_Reason = entity.Reject_Reason,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_CA_Multi_Reject(Insp_Landscape_Qns entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_CA_Multi_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Insp_Land_CA_Reject_List != null)
                    {


                        foreach (var item in entity.Insp_Land_CA_Reject_List)
                        {
                            var parameters = new
                            {
                                Landscape_Qns_Id = item.Landscape_Qns_Id,
                                Remarks = item.Remarks,
                                CreatedBy = entity.CreatedBy,
                                Reject_Reason = item.Reject_Reason,
                            };
                            var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = "Rejected Successfully",
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = "200",
                            Return_1 = "0"
                        };
                        return rETURN_MESSAGE;
                    }
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = "Failed",
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = "500",
                            Return_1 = "0"
                        };
                        return rETURN_MESSAGE;
                    }

                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Insp_SoftService_CA_Final_Approve(M_Insp_Landscape entity)
        {
            try
            {
                string procedure = "sp_Insp_SoftService_CA_Final_Approve";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Insp_Request_Id = entity.Insp_Request_Id,
                        Final_Approve_Comments = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj = (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (obj!.Status_Code == "200")
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = obj!.Message,
                            Status = M_Return_Status_Code.TRUE,
                            Status_Code = obj!.Status_Code,
                            Return_1 = obj!.Return_1,
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Message = M_Return_Status_Text.FAILED,
                            Status = M_Return_Status_Code.FALSE,
                            Status_Code = M_Return_Status_Code.FAILED,
                            Return_1 = "0",
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                string Repo = "Insp_SoftService_CA_Approval";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

#pragma warning restore CS8603 // Possible null reference return.

    }
}
