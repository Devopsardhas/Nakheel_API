using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AuditSpRepo : IAuditSpRepo
    {
        private readonly IConfiguration configuration;
        private IHostingEnvironment Environment;

        public AuditSpRepo(IConfiguration configuration, IHostingEnvironment _environment)
        {
            this.configuration = configuration;
            Environment = _environment;
        }
#pragma warning disable CS8603 // Possible null reference return.
        #region [Basic Method]
        public Task<M_Return_Message> AddAsync(M_AuditSp entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> DeleteAsync(M_AuditSp entity)
        {
            throw new NotImplementedException();
        }
        public Task<IReadOnlyList<M_AuditSp>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<M_AuditSp> GetByIdAsync(M_AuditSp entity)
        {
            throw new NotImplementedException();
        }
        public Task<M_Return_Message> UpdateAsync(M_AuditSp entity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region [Audit Service Provider]
        public async Task<IReadOnlyList<M_AuditSp>> Audit_Sp_GetAll(DataTableAjaxPostModel entity)
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
                string procedure = "sp_Am_Sp_Service_Provider_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_AuditSp>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Sp_GetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_AuditSp> Audit_Sp_GetById(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Service_Provider_GetbyId";
                string procedure1 = "sp_Am_Sp_Audit_Team_GetBy_Id_Filter";
                //string procedure2 = "sp_Am_Sp_Representative_GetBy_Id_Filter";

                string procedure3 = "sp_Am_Sp_Audit_Team_Member_GetBy_Id";
                string procedure4 = "sp_Am_Sp_Representative_Member_GetBy_Id";

                string procedure5 = "sp_Am_Sp_Audit_Topics_Master_GetBy_Id";
                //string procedure6 = "sp_Am_Sp_Sub_Topics_Master_GetBy_Id";
                string procedure7 = "sp_Am_Sp_Questionnaires_Master_GetBy_Id";

                string procedure8 = "sp_Am_Sp_Audit_Topics_Qus_GetBy_Id";
                string procedure9 = "sp_Am_Sp_Audit_Sub_Topics_Qus_GetBy_Id";
                string procedure10 = "sp_Am_Sp_Audit_Questionnaires_Qus_GetBy_Id";

                string procedure11 = "sp_Am_Sp_Questionnaires_Master_Rej_GetBy_Id";
                string procedure12 = "sp_Am_Sp_Questions_Finding_Reject_GetBy_Id";
                string procedure13 = "sp_Am_Sp_CA_Service_Provider_Zone_GetBy_Id";
                string procedure14 = "sp_Am_Sp_Corrective_Action_Details_GetBy_Id";
                string procedure18 = "sp_Am_Sp_Questions_Action_Reject_GetbyId";
                string procedure19 = "sp_Am_Sp_History_Approval_GetbyId";

                string procedure20 = "sp_Am_Sp_Qus_Photos_Getby_Id";

                //string procedure15 = "sp_Am_Sp_NCR_Action_Details_GetbyId";
                //string procedure16 = "sp_Am_Sp_NCR_Root_Cause_Analysis_GetbyId";
                //string procedure17 = "sp_Am_Sp_NCR_Desc_Root_Cause_GetbyId";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id
                    };
                    var parameters0 = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        CreatedBy = entity.CreatedBy,
                    };
                    var Obj = (await connection.QueryAsync<M_AuditSp>(procedure, parameters0, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        Obj.AM_SP_Comman_Master_List = new AM_SP_Basic_Master_Data();
                        Obj.AM_SP_Comman_Master_List.Audit_Team_List = new List<AM_SP_Dropdown_Values>();
                        Obj.AM_SP_Comman_Master_List.SP_Rep_List = new List<AM_SP_Dropdown_Values>();
                        Obj.Am_Sp_Audit_Team_Member_List = new List<Am_Sp_Audit_Team_Member>();
                        Obj.Am_Sp_Representative_Member_List = new List<Am_Sp_Representative_Member>();
                        Obj.Am_Sp_Ques_Finding_Reject_List = new List<Am_Sp_Ques_Finding_Reject>();
                        Obj.Am_Sp_CA_Service_Provider_List = new List<AM_SP_Dropdown_Values>();
                        Obj.Am_Sp_Topics_Master_List = new List<Am_Sp_Topics_Master>();
                        Obj.Am_Sp_NCR_Action_List = new List<Am_Sp_NCR_Action>();
                        Obj.Am_Sp_NCR_Root_Cause_Analysis_List = new List<Am_Sp_NCR_Root_Cause_Analysis>();
                        Obj.Am_Sp_NCR_Desc_Root_Cause_List = new List<Am_Sp_NCR_Desc_Root_Cause>();
                        Obj.Am_Sp_Ques_Action_Reject_List = new List<Am_Sp_Ques_Action_Reject_Reject>();
                        Obj.Am_Sp_History_Approval_List = new List<Am_Sp_History_Approval>();
                        Obj.Qus_Evidence_List = new List<Am_Sp_Qus_Evidence>();
                        var var_HA_List = (await connection.QueryAsync<Am_Sp_History_Approval>(procedure19, parameters, commandType: CommandType.StoredProcedure)).ToList();
                        if (var_HA_List != null)
                        {
                            Obj.Am_Sp_History_Approval_List = var_HA_List;
                        }

                        if (Obj.Status == "Schedule Initiated")
                        {
                            var parameters_Comm = new
                            {
                                Zone_Id = Obj.Zone_Id,
                                Community_Id = Obj.Community_Id,
                            };

                            var var_Audit_Team_List = (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure1, parameters_Comm, commandType: CommandType.StoredProcedure)).ToList();

                            if (var_Audit_Team_List != null)
                            {
                                Obj.AM_SP_Comman_Master_List.Audit_Team_List = var_Audit_Team_List;
                            }
                        }
                        else if (Obj.Status == "Audit Scheduled")
                        {
                            //var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Sp_Audit_Team_Member>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            //var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Sp_Representative_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure5, commandType: CommandType.StoredProcedure)).ToList();

                            //if (var_Audit_Team_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Audit_Team_Member_List = var_Audit_Team_Member_List;
                            //}
                            //if (var_SP_Rep_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Representative_Member_List = var_SP_Rep_Member_List;
                            //}

                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters1 = new
                                    {
                                        Value = item.Value
                                    };
                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure7, parameters1, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }
                                }
                            }
                        }
                        else if (Obj.Status == "Line Manager Approval Pending" || Obj.Status == "HSSE Director Approval Pending")
                        {
                            var parameters10 = new
                            {
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            };
                            //var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Sp_Audit_Team_Member>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            //var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Sp_Representative_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure8, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Find_Rej_List = (await connection.QueryAsync<Am_Sp_Ques_Finding_Reject>(procedure12, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Photo_List = (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (var_Ques_Photo_List != null)
                            {
                                Obj.Qus_Evidence_List = var_Ques_Photo_List;
                            }
                            if (var_Ques_Find_Rej_List != null)
                            {
                                Obj.Am_Sp_Ques_Finding_Reject_List = var_Ques_Find_Rej_List;
                            }

                            //if (var_Audit_Team_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Audit_Team_Member_List = var_Audit_Team_Member_List;
                            //}
                            //if (var_SP_Rep_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Representative_Member_List = var_SP_Rep_Member_List;
                            //}

                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters12 = new
                                    {
                                        Value = item.Value,
                                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                    };
                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure10, parameters12, commandType: CommandType.StoredProcedure)).ToList();

                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }
                                }
                            }

                        }
                        else if (Obj.Status == "Line Manager Rejected" || Obj.Status == "HSSE Director Rejected")
                        {
                            //var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Sp_Audit_Team_Member>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            //var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Sp_Representative_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure5, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Find_Rej_List = (await connection.QueryAsync<Am_Sp_Ques_Finding_Reject>(procedure12, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Photo_List = (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (var_Ques_Photo_List != null)
                            {
                                Obj.Qus_Evidence_List = var_Ques_Photo_List;
                            }
                            if (var_Ques_Find_Rej_List != null)
                            {
                                Obj.Am_Sp_Ques_Finding_Reject_List = var_Ques_Find_Rej_List;
                            }

                            //if (var_Audit_Team_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Audit_Team_Member_List = var_Audit_Team_Member_List;
                            //}
                            //if (var_SP_Rep_Member_List != null)
                            //{
                            //    Obj.Am_Sp_Representative_Member_List = var_SP_Rep_Member_List;
                            //}

                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters2 = new
                                    {
                                        Value = item.Value,
                                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                    };

                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure11, parameters2, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }
                                }
                            }

                        }
                        else if (Obj.Status == "NCR Form Pending")
                        {
                            var parameters10 = new
                            {
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            };
                            var parameters15 = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };
                            var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Sp_Audit_Team_Member>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Sp_Representative_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure8, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_CA_Service_Provider_List = (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure13, parameters15, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Photo_List = (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (var_Ques_Photo_List != null)
                            {
                                Obj.Qus_Evidence_List = var_Ques_Photo_List;
                            }
                            if (var_CA_Service_Provider_List != null)
                            {
                                Obj.Am_Sp_CA_Service_Provider_List = var_CA_Service_Provider_List;
                            }
                            if (var_Audit_Team_Member_List != null)
                            {
                                Obj.Am_Sp_Audit_Team_Member_List = var_Audit_Team_Member_List;
                            }
                            if (var_SP_Rep_Member_List != null)
                            {
                                Obj.Am_Sp_Representative_Member_List = var_SP_Rep_Member_List;
                            }

                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters11 = new
                                    {
                                        Value = item.Value
                                    };
                                    var var_Sub_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Sub_Topics_Master>(procedure9, parameters11, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Sub_Topic_Mas_List != null)
                                    {
                                        foreach (var item1 in var_Sub_Topic_Mas_List)
                                        {
                                            var parameters12 = new
                                            {
                                                Value = item1.Value,
                                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                            };

                                            var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure10, parameters12, commandType: CommandType.StoredProcedure)).ToList();
                                            if (var_Questionnaires_Mas_List != null)
                                            {
                                                item1.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                            }
                                        }
                                    }
                                    item.Am_Sp_Sub_Topics_Master_List = var_Sub_Topic_Mas_List;
                                }
                            }

                        }
                        else if (Obj.Status == "Corrective Action Pending")
                        {
                            var parameters10 = new
                            {
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            };
                            var parameters15 = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };
                            var var_Audit_Team_Member_List = (await connection.QueryAsync<Am_Sp_Audit_Team_Member>(procedure3, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_SP_Rep_Member_List = (await connection.QueryAsync<Am_Sp_Representative_Member>(procedure4, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure8, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_CA_Service_Provider_List = (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure13, parameters15, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Photo_List = (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (var_Ques_Photo_List != null)
                            {
                                Obj.Qus_Evidence_List = var_Ques_Photo_List;
                            }
                            if (var_CA_Service_Provider_List != null)
                            {
                                Obj.Am_Sp_CA_Service_Provider_List = var_CA_Service_Provider_List;
                            }
                            if (var_Audit_Team_Member_List != null)
                            {
                                Obj.Am_Sp_Audit_Team_Member_List = var_Audit_Team_Member_List;
                            }
                            if (var_SP_Rep_Member_List != null)
                            {
                                Obj.Am_Sp_Representative_Member_List = var_SP_Rep_Member_List;
                            }

                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters12 = new
                                    {
                                        Value = item.Value,
                                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                    };

                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure10, parameters12, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }

                                    var parameters16 = new
                                    {
                                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                        Audit_Topics_Id = item.Value,
                                    };
                                    var var_CA_Details_List = (await connection.QueryAsync<Am_Sp_Corrective_Action>(procedure14, parameters16, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_CA_Details_List != null)
                                    {
                                        item.Am_Sp_Corrective_Action_List = var_CA_Details_List;
                                    }
                                }
                            }

                        }
                        else if (Obj.Status == "HSE Manager Approval Pending" || Obj.Status == "Lead Auditor Approval Pending" || Obj.Status == "HSE Manager Rejected" || Obj.Status == "Lead Auditor Rejected" || Obj.Status == "Audit Closed")
                        {
                            var parameters10 = new
                            {
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            };
                            var parameters15 = new
                            {
                                Zone_Id = Obj.Zone_Id,
                            };
                            var var_Topic_Mas_List = (await connection.QueryAsync<Am_Sp_Topics_Master>(procedure8, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Action_Reject_List = (await connection.QueryAsync<Am_Sp_Ques_Action_Reject_Reject>(procedure18, parameters10, commandType: CommandType.StoredProcedure)).ToList();
                            var var_Ques_Photo_List = (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure20, parameters, commandType: CommandType.StoredProcedure)).ToList();
                            if (var_Ques_Photo_List != null)
                            {
                                Obj.Qus_Evidence_List = var_Ques_Photo_List;
                            }
                            if (var_Ques_Action_Reject_List != null)
                            {
                                Obj.Am_Sp_Ques_Action_Reject_List = var_Ques_Action_Reject_List;
                            }
                            if (var_Topic_Mas_List != null)
                            {
                                Obj.Am_Sp_Topics_Master_List = var_Topic_Mas_List;
                                foreach (var item in Obj.Am_Sp_Topics_Master_List)
                                {
                                    var parameters12 = new
                                    {
                                        Value = item.Value,
                                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                    };

                                    var var_Questionnaires_Mas_List = (await connection.QueryAsync<Am_Sp_Questionnaires_Master>(procedure10, parameters12, commandType: CommandType.StoredProcedure)).ToList();
                                    if (var_Questionnaires_Mas_List != null)
                                    {
                                        item.Am_Sp_Questionnaires_Master_List = var_Questionnaires_Mas_List;
                                    }
                                }
                            }

                        }
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Sp_GetById";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_Audit_Team_GetBy_Id(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_Team_GetBy_Id_Filter";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                    };
                    return (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Audit_Team_GetBy_Id";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_Representative_GetBy_Id(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Representative_GetBy_Id_Filter";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                    };
                    return (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Representative_GetBy_Id";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Audit_Sp_Add(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Audit_Team_Member_Add";
                //string procedure1 = "sp_Am_Sp_Representative_Member_Add";
                string procedure2 = "sp_Am_Sp_Status_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity.Am_Sp_Audit_Team_Member_List != null && entity.Am_Sp_Audit_Team_Member_List.Count > 0)
                    {
                        foreach (var item in entity.Am_Sp_Audit_Team_Member_List)
                        {
                            var parameters = new
                            {
                                Am_Sp_Audit_Team_Id = item.Am_Sp_Audit_Team_Id,
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                Emp_Id = item.Emp_Id,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                        }
                    }

                    //if (entity.Am_Sp_Representative_Member_List != null && entity.Am_Sp_Representative_Member_List.Count > 0)
                    //{
                    //    foreach (var items in entity.Am_Sp_Representative_Member_List)
                    //    {
                    //        var parameters1 = new
                    //        {
                    //            Am_Sp_Representative_Id = items.Am_Sp_Representative_Id,
                    //            Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                    //            Emp_Id = items.Emp_Id,
                    //            CreatedBy = entity.CreatedBy,
                    //        };
                    //        await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                    //    }
                    //}

                    var parameters_Status = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        Building_Area_Name = entity.Building_Area_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Find_Questionnaire_Add(Am_Sp_Add_Finding_Questionnaires_List entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Find_Questionnaire_Add";
                string procedure1 = "sp_Am_Sp_Find_Questionnaire_Status_Update";
                string procedure2 = "sp_Am_Sp_Find_Questionnaire_Rej_Delete";
                string procedure3 = "sp_Am_Sp_Qus_Photos_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    if (entity.Add_Finding_Questionnaires_List != null && entity.Add_Finding_Questionnaires_List.Count > 0)
                    {
                        var parameters_Del = new
                        {
                            Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Del, commandType: CommandType.StoredProcedure);

                        foreach (var item in entity.Add_Finding_Questionnaires_List)
                        {
                            var parameters = new
                            {
                                Am_Sp_Ques_Finding_Id = item.Am_Sp_Ques_Finding_Id,
                                Audit_Sp_Sch_Id = item.Audit_Sp_Sch_Id,
                                Audit_Topics_Id = item.Audit_Topics_Id,
                                Audit_Questionnaires_Id = item.Audit_Questionnaires_Id,
                                Is_Questionnaires_Checked = item.Is_Questionnaires_Checked,
                                Objective_Evidence = item.Objective_Evidence,
                                Find_Comments = item.Find_Comments,
                                Findings_Type_Name = item.Findings_Type_Name,
                                CreatedBy = item.CreatedBy,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
                        }
                        

                        var parameters_Status = new
                        {
                            Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            CreatedBy = entity.CreatedBy,
                            Safety_Violation = entity.Safety_Violation,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }
                    if (entity.Qus_Evidence_List != null && entity.Qus_Evidence_List.Count > 0)
                    {
                        foreach (var items in entity.Qus_Evidence_List)
                        {
                            var parameters = new
                            {
                                Am_SP_Qus_Photo_Id = items.Am_SP_Qus_Photo_Id,
                                Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                                File_Path = items.File_Path,
                                CreatedBy = entity.CreatedBy,
                            };
                            await connection.QueryAsync<M_Return_Message>(procedure3, parameters, commandType: CommandType.StoredProcedure);
                        }
                    }

                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Find_Ques_LM_ApprovalReject(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Find_Ques_LM_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Find_Ques_LM_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Find_Ques_Director_ApprovalReject(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Find_Ques_Director_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Find_Ques_Director_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<AM_SP_Dropdown_Values>> Am_Sp_CA_Service_Provider_Zone_GetBy(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_CA_Service_Provider_Zone_GetBy_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    var parameters = new
                    {
                        Zone_Id = entity.Zone_Id,
                    };
                    return (await connection.QueryAsync<AM_SP_Dropdown_Values>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_CA_Service_Provider_Zone_GetBy";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Corrective_Action_Add(M_AuditSp entity)
        {
            try
            {
                string procedure1 = "sp_Am_Sp_Corrective_Action_Status_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_Status = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        CA_Target_Date = entity.CA_Target_Date,
                        Safety_Violation = entity.Safety_Violation,
                        CreatedBy = entity.CreatedBy,
                    };
                    var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure1, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }


                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = "Added Successful",
                    Status = M_Return_Status_Code.TRUE,
                    Status_Code = "200",
                };
                return rETURN_MESSAGE;
            }

            catch (Exception ex)
            {
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };

                string Repo = "Audit_Sp_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }

        }
        public async Task<M_Return_Message> Am_Sp_NCR_Action_Add(M_AuditSp entity)
        {
            try
            {
                string procedure1 = "sp_Am_Sp_NCR_Questions_Action_Add";
                string procedure2 = "sp_sp_Am_Sp_NCR_Action_Status_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity != null)
                    {
                        if (entity.Add_Finding_Questionnaires_List != null && entity.Add_Finding_Questionnaires_List.Count > 0)
                        {
                            foreach (var item in entity.Add_Finding_Questionnaires_List)
                            {
                                var parameters1 = new
                                {
                                    Am_Sp_Ques_Finding_Id = item.Am_Sp_Ques_Finding_Id,
                                    Audit_Sp_Sch_Id = item.Audit_Sp_Sch_Id,
                                    Closure_Description = item.Closure_Description,
                                    File_Path = item.File_Path,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.QueryAsync<M_Return_Message>(procedure1, parameters1, commandType: CommandType.StoredProcedure);
                            }
                        }

                        var parameters_Status = new
                        {
                            Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                            CreatedBy = entity.CreatedBy,
                        };
                        var obj_Status = (await connection.QueryAsync<M_Return_Message>(procedure2, parameters_Status, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    }



                    M_Return_Message rETURN_MESSAGE = new M_Return_Message
                    {
                        Message = "Added Successful",
                        Status = M_Return_Status_Code.TRUE,
                        Status_Code = "200",
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
                string Repo = "Am_Sp_NCR_Action_Add";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Find_Ques_HSE_ApprovalReject(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Ques_Action_HSE_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Find_Ques_HSE_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Am_Sp_Find_Ques_Lead_Au_ApprovalReject(M_AuditSp entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Ques_Action_Lead_Auditor_Approval_Reject";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sp_Sch_Id = entity.Audit_Sp_Sch_Id,
                        Status = entity.Status,
                        Remarks = entity.Remarks,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Find_Ques_Lead_Au_ApprovalReject";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<Am_Sp_Qus_Evidence> Am_Sp_Ques_Photo_Delete(Am_Sp_Qus_Evidence entity)
        {
            try
            {
                string procedure = "sp_Am_Sp_Qus_Photos_Delete";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Am_SP_Qus_Photo_Id = entity.Am_SP_Qus_Photo_Id
                    };
                    return (await connection.QueryAsync<Am_Sp_Qus_Evidence>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Am_Sp_Ques_Photo_Delete";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

#pragma warning restore CS8603 // Possible null reference return.
    }
}
