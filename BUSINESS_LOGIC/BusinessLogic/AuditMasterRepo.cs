using BUSINESS_LOGIC.ErrorLogs;
using IBUSINESS_LOGIC.IBusinessLogic;
using Microsoft.Extensions.Configuration;
using MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using static Dapper.SqlMapper;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using System.Collections;

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class AuditMasterRepo : IAuditMasterRepo
    {
        private readonly IConfiguration configuration;

        public AuditMasterRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
#pragma warning disable CS8603 // Possible null reference return.

        #region [Audit Category]
        public async Task<IReadOnlyList<M_Audit_Category>> GetAllAsync()
        {
            try
            {
                string procedure = "sp_AM_Audit_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Audit_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Category_Master : GetAllAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> AddAsync(M_Audit_Category entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 2,
                        Audit_Category_Id = entity.Audit_Category_Id,
                        Audit_Category_Name = entity.Audit_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Category_Master : AddAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> UpdateAsync(M_Audit_Category entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Audit_Category_Id = entity.Audit_Category_Id,
                        Audit_Category_Name = entity.Audit_Category_Name,
                        CreatedBy = entity.CreatedBy,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Category_Master : UpdateAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Audit_Category> GetByIdAsync(M_Audit_Category entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Audit_Category_Id = entity.Audit_Category_Id
                    };
                    return (await connection.QueryAsync<M_Audit_Category>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Category_Master : GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> DeleteAsync(M_Audit_Category entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Category_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Audit_Category_Id = entity.Audit_Category_Id
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit_Category_Master : DeleteAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Audit Topics]
        public async Task<IReadOnlyList<M_Audit_Topics>> GetAll_AM_Topics()
        {
            try
            {
                string procedure = "sp_AM_Audit_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Audit_Topics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll_AM_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Audit_Topics>> GetById_AM_Topics(M_Audit_Topics entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Audit_Category_Id = entity.Audit_Category_Id,
                    };
                    return (await connection.QueryAsync<M_Audit_Topics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetById_AM_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_AM_Topics(List<M_Audit_Topics> entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Audit_Category_Id = item.Audit_Category_Id,
                            Audit_Topics_Id = item.Audit_Topics_Id,
                            Audit_Topics_Name = item.Audit_Topics_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
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
                string Repo = "Add_AM_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Delete_AM_Topics(M_Audit_Topics entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Audit_Topics_Id = entity.Audit_Topics_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Delete_AM_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Audit Sub Topics]
        public async Task<IReadOnlyList<M_Audit_Sub_Topics>> GetAll_AM_Sub_Topics()
        {
            try
            {
                string procedure = "sp_AM_Audit_Sub_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Audit_Sub_Topics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll_AM_Sub_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Audit_Sub_Topics>> GetById_AM_Sub_Topics(M_Audit_Sub_Topics entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Sub_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Audit_Category_Id = entity.Audit_Category_Id,

                    };
                    return (await connection.QueryAsync<M_Audit_Sub_Topics>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetById_AM_Sub_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_AM_Sub_Topics(List<M_Audit_Sub_Topics> entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Sub_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Audit_Category_Id = item.Audit_Category_Id,
                            Audit_Sub_Topics_Id = item.Audit_Sub_Topics_Id,
                            Audit_Sub_Topics_Name = item.Audit_Sub_Topics_Name,
                            CreatedBy = item.CreatedBy,
                            Remarks = item.Remarks,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
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
                string Repo = "Add_AM_Sub_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Delete_AM_Sub_Topics(M_Audit_Sub_Topics entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Sub_Topics_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Audit_Sub_Topics_Id = entity.Audit_Sub_Topics_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Delete_AM_Sub_Topics";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        #endregion

        #region [Audit Questionnaires]
        public async Task<IReadOnlyList<M_Audit_Questionnaires>> GetAll_AM_Questionnaires()
        {
            try
            {
                string procedure = "sp_AM_Audit_Questionnaires_Master_Crud";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1,
                    };
                    return (await connection.QueryAsync<M_Audit_Questionnaires>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll_AM_Questionnaires";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<M_Audit_Questionnaires>> GetById_AM_Questionnaires(M_Audit_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,
                        Audit_Category_Id = entity.Audit_Category_Id,
                        Audit_Sub_Topics_Id = entity.Audit_Sub_Topics_Id,
                    };
                    return (await connection.QueryAsync<M_Audit_Questionnaires>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetById_AM_Questionnaires";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Audit_Questionnaires>> Get_Env_Sp_Questionaire(M_Audit_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 6,
                        Audit_Category_Id = entity.Audit_Category_Id,
                        //Audit_Sub_Topics_Id = entity.Audit_Sub_Topics_Id,
                    };
                    return (await connection.QueryAsync<M_Audit_Questionnaires>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetById_AM_Questionnaires";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_AM_Questionnaires(List<M_Audit_Questionnaires> entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Audit_Category_Id = item.Audit_Category_Id,
                            Audit_Sub_Topics_Id = item.Audit_Sub_Topics_Id,
                            Audit_Questionnaires_Id = item.Audit_Questionnaires_Id,
                            Audit_Questionnaires_Name = item.Audit_Questionnaires_Name,
                            CreatedBy = item.CreatedBy,
                        };
                        await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure);
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
                string Repo = "Add_AM_Questionnaires";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Delete_AM_Questionnaires(M_Audit_Questionnaires entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Questionnaires_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Audit_Questionnaires_Id = entity.Audit_Questionnaires_Id,
                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Delete_AM_Questionnaires";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Audit_QuestionnaireDetails>> Get_All_Questionnaire_Chk(M_Audit_QuestionnaireDetails entity)
        {
            try
            {
                string pro_Quest_Topic = "sp_Am_Audit_Sch_Questionnaire_Topics";
                string pro_Quest_SubTopic = "sp_Am_Audit_Sch_Questionnaire_subTopics";
                string procedure = "sp_AM_Audit_LoadAll_Questionnaires";
                string pro_Ins_Detail = "sp_AM_Audit_Inspection_Details";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Audit_Category_Id = entity.Audit_Category_Id,

                    };
                    var Quest = (await connection.QueryAsync<M_Audit_QuestionnaireDetails>(pro_Quest_Topic, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    foreach (var topic in Quest)
                    {
                        var parameters_2 = new
                        {
                            Audit_Topics_Id = topic.Audit_Topics_Id,
                        };
                        var subTopics = (await connection.QueryAsync<M_Audit_Sub_Topics>(pro_Quest_SubTopic, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        topic.Audit_Sub_Topics = subTopics;
                        foreach (var Questionnaire in subTopics)
                        {
                            var parameters_3 = new
                            {
                                Audit_Sub_Topics_Id = Questionnaire.Audit_Sub_Topics_Id
                            };
                            var Question = (await connection.QueryAsync<M_Audit_Questionnaires>(procedure, parameters_3, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                            Questionnaire.Load_All_Quest = Question;
                            foreach (var findings in Question)
                            {
                                var FindingsType = (await connection.QueryAsync<M_Audit_Inspection_Details>(pro_Ins_Detail, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                                findings.Aud_Ins_Details = FindingsType;
                            }
                        }
                    }
                    return Quest;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Questionnaire_Chk";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region[Audit Findings]
        public async Task<IReadOnlyList<M_AuditFindings>> GetAll_Am_AuditFindings()
        {
            try
            {
                string procedure = "sp_AM_Audit_Findings_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 1
                    };
                    return (await connection.QueryAsync<M_AuditFindings>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetAll_Am_AuditFindings";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_AuditFindings>> GetByID_AuditFindings(M_AuditFindings entity)
        {
            try
            {
                string procedureGetByID = "sp_AM_Audit_Findings_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 4,

                        Findings_Type = entity.Findings_Type
                    };
                    return (await connection.QueryAsync<M_AuditFindings>(procedureGetByID, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetByID_AuditFindings";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Delete_AM_Audit_Findings(M_AuditFindings entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Findings_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 5,
                        Findings_Id = entity.Findings_Id,

                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                };
            }
            catch (Exception ex)
            {
                string Repo = "Delete_AM_Audit_Findings";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Am_Audit_Findings(List<M_AuditFindings> entity)
        {
            try
            {
                string procedureAdd = "sp_AM_Audit_Findings_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity)
                    {
                        var parameters = new
                        {
                            Action = 2,
                            Findings_Name = item.Findings_Name,
                            Findings_Id = item.Findings_Id,
                            Findings_Type = item.Findings_Type,
                            Created_By = item.CreatedBy
                        };
                        await connection.QueryAsync<M_Return_Message>(procedureAdd, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
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
                string Repo = "Add_Am_Audit_Findings";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_Am_Audit_Findings(M_AuditFindings entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Findings_Master_Crud";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Action = 3,
                        Findings_Name = entity.Findings_Name,
                        Findings_Type = entity.Findings_Type,
                        Findings_Id = entity.Findings_Id

                    };
                    return (await connection.QueryAsync<M_Return_Message>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Update_Am_Audit_Findings";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Audit_Type]
        public async Task<IReadOnlyList<M_Audit_Type>> Get_All_Audit_Type()
        {
            try
            {
                string procedure = "sp_AM_Audit_Type_GetAll";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Audit_Type>(procedure, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Audit_Type";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Audit Schedule - Service Provider] 

        public async Task<M_Return_Message> Add_Audit_Schedule(Audit_Schedule_Model entity)
        {
            try
            {
                string procedure = "sp_Am_Add_Audit_Schedule";
                string Audit_Team_Proc = "sp_Am_Add_Audit_Team";
                string Service_Prov_Proc = "sp_Am_Add_Service_Provider";
                string History_Procedure = "sp_SAud_ServiceProv_Update_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Schedule_Parameter = new
                    {
                        Audit_Sch_Id = entity.Audit_Sch_Id,
                        DateTime = entity.DateTime,
                        Business_Unit_Id = entity.Business_Unit_Id,
                        Zone_Id = entity.Zone_Id,
                        Community_Id = entity.Community_Id,
                        Lead_Auditor_Id = entity.Lead_Auditor_Id,
                        Business_Unit_Type = entity.Business_Unit_Type,
                        CreatedBy = entity.CreatedBy,
                        Audit_Lati = entity.Audit_Lati,
                        Audit_Long = entity.Audit_Long
                    };
                    var Schd_List = (await connection.QueryAsync<Audit_Schedule_Model>(procedure, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Schd_List != null)
                    {
                        if (entity.Audit_Team_List != null)
                        {
                            foreach (var item in entity.Audit_Team_List)
                            {
                                var Audit_Team_Param = new
                                {
                                    Audit_Sch_Id = Schd_List.Audit_Sch_Id,
                                    Audit_Emp_Id = item.Audit_Emp_Id,
                                    CreatedBy = item.CreatedBy
                                };
                                var Audit_Team_List = (await connection.QueryAsync<Audit_Team>(Audit_Team_Proc, Audit_Team_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        if (entity.Service_Prov_List != null)
                        {
                            foreach (var Obj in entity.Service_Prov_List)
                            {
                                var Service_Prov_Param = new
                                {
                                    Audit_Sch_Id = Schd_List.Audit_Sch_Id,
                                    Service_Prov_Emp_Id = Obj.Service_Prov_Emp_Id,
                                    CreatedBy = Obj.CreatedBy
                                };
                                var Audit_Team_List = (await connection.QueryAsync<Audit_Service_Provider>(Service_Prov_Proc, Service_Prov_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                            }
                        }
                        var parameters_History = new
                        {
                            Audit_Sch_Id = Schd_List.Audit_Sch_Id,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(History_Procedure, parameters_History, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Add_Audit_Schedule";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;

            }
        }

        public async Task<IReadOnlyList<Audit_Schedule_Model>> Get_All_Audit_Schedule(DataTableAjaxPostModel entity)
        {
            try
            {
                var UniqueID_Value = "";
                var Inc_Category_Id_Value = "";
                var Inc_Type_Id_Value = "";
                var Zone_Value = "";
                var Status_Value = "";
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
                                Inc_Category_Id_Value = item.Search!.Value;
                                break;
                            case 2:
                                Inc_Type_Id_Value = item.Search!.Value;
                                break;
                            case 3:
                                Zone_Value = item.Search!.Value;
                                break;
                            case 4:
                                Status_Value = item.Search!.Value;
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
                };
                string procedure = "sp_Am_Get_All_AuditSchedule";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Audit_Schedule_Model>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                };
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Audit_Schedule";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<IReadOnlyList<Audit_Schedule_Model>> GetById_AM_AuditSchedule(Audit_Schedule_Model entity)
        {
            try
            {
                string procedure = "sp_Am_Audit_Schedule_GetById";
                string procedure_AuditTeam = "sp_Am_Audit_Get_Audit_Team";
                string procedure_ServiceProv = "sp_Am_Audit_Get_ServiceProvider";
                string procedure1 = "sp_ServiceProv_Audit_History_by_Aud_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sch_Id = entity.Audit_Sch_Id
                    };
                    var model = (await connection.QueryAsync<Audit_Schedule_Model>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    foreach (var item in model)
                    {
                        var AuditTemParameter = new
                        {
                            Audit_Sch_Id = item.Audit_Sch_Id,
                        };

                        var AuditTeam = (await connection.QueryAsync<Audit_Team>(procedure_AuditTeam, AuditTemParameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        item.Audit_Team_List = AuditTeam;
                        var ServiceProvider = (await connection.QueryAsync<Audit_Service_Provider>(procedure_ServiceProv, AuditTemParameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        item.Service_Prov_List = ServiceProvider;
                        var ObjUpdate_History = (await connection.QueryAsync<Aud_ServiceProv_Update_History>(procedure1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        item.ServicePro_Update_History = ObjUpdate_History;
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetById_AM_AuditSchedule";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Add_Audit_Findings_Chk(Audit_Schedule_Model entity)
        {
            try
            {
                string procedure = "sp_AM_Audit_Add_Service_Prov_Checklist";
                string File_Upl_Procedure = "sp_Am_Audit_Add_Service_Prov_Checklist_Evidence";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    foreach (var item in entity.add_Audit_Chk_List!)
                    {
                        var index = entity.add_Audit_Chk_List.IndexOf(item);
                        var parameters = new
                        {
                            Audit_Clause_Id = item.Audit_Clause_Id,
                            Audit_Sch_Id = item.Audit_Sch_Id,
                            Audit_Topics_Id = item.Audit_Topics_Id,
                            Audit_Quest_Id = item.Audit_Quest_Id,
                            Audit_Verifi_Details = item.Audit_Verifi_Details,
                            Site_Inspection_Details = item.Site_Inspection_Details,
                            Audit_Findings_ID = item.Audit_Findings_ID,
                            CreatedBy = item.CreatedBy,
                        };
                        var Audit_CheckList = (await connection.QueryAsync<Add_Audit_Checklist>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        if (Audit_CheckList != null)
                        {
                            if (item.Checklist_File_Upl != null)
                            {
                                foreach (var Obj in item.Checklist_File_Upl)
                                {
                                    Obj.Audit_Sch_Id = item.Audit_Sch_Id;
                                    Obj.Audit_Clause_Id = Audit_CheckList.Audit_Clause_Id;
                                }
                                await connection.ExecuteAsync(File_Upl_Procedure, item.Checklist_File_Upl, commandType: CommandType.StoredProcedure);
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
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<Audit_Schedule_Model>> GetbyIdAudit_CheckList(Audit_Schedule_Model entity)
        {
            try
            {
                string procedure = "sp_Am_Audit_Schedule_GetById";
                string procedure_AuditTeam = "sp_Am_Audit_Get_Audit_Team";
                string procedure_ServiceProv = "sp_Am_Audit_Get_ServiceProvider";
                string Procedure_Checklist = "sp_Am_Audit_ServiceProvider_Checklst_GetById";
                string Procedure_Checlist_Photos = "Audit_ServiceProvider_Checklst_Photos_GetById";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Audit_Sch_Id = entity.Audit_Sch_Id
                    };
                    var model = (await connection.QueryAsync<Audit_Schedule_Model>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    foreach (var item in model)
                    {
                        var AuditTemParameter = new
                        {
                            Audit_Sch_Id = item.Audit_Sch_Id,
                        };

                        var AuditTeam = (await connection.QueryAsync<Audit_Team>(procedure_AuditTeam, AuditTemParameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        item.Audit_Team_List = AuditTeam;
                        var ServiceProvider = (await connection.QueryAsync<Audit_Service_Provider>(procedure_ServiceProv, AuditTemParameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        item.Service_Prov_List = ServiceProvider;
                        var Audit_Checklist = (await connection.QueryAsync<Add_Audit_Checklist>(Procedure_Checklist, AuditTemParameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                        item.add_Audit_Chk_List = Audit_Checklist;
                        foreach (var photos in item.add_Audit_Chk_List)
                        {
                            var parameters_Photos = new
                            {
                                Audit_Clause_Id = photos.Audit_Clause_Id
                            };
                            var Audit_Chk_Photos = (await connection.QueryAsync<ServiceProv_Checlist_File_Upl>(Procedure_Checlist_Photos, parameters_Photos, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                            photos.Checklist_File_Upl = Audit_Chk_Photos;
                        }
                    }
                    return model;
                }
            }
            catch (Exception ex)
            {
                string Repo = "GetbyIdAudit_CheckList";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

        #region [Audit Schedule - Internal Audit] 

        public async Task<M_Return_Message> Add_Internal_Audit(Aud_Internal_Audit entity)
        {
            try
            {
                DateTime date = Convert.ToDateTime(entity.Date_Time);
                //string procedure = "sp_IAud_Internal_Audit";
                string procedure = "sp_IAud_Internal_Audit_Sed_Update";
                string Audit_Team_Proc = "sp_IAud_Internal_Audit_Audit_Team";
                string Service_Prov_Proc = "sp_IAud_Internal_Audit_Service_Provider";
                string Histor_procedure = "sp_IAud_Internal_Update_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    //var Schedule_Parameter = new
                    //{
                    //    Internal_Audit_Id = entity.Internal_Audit_Id,
                    //    Reported_by = entity.Reported_by,
                    //    Designation = entity.Designation,
                    //    Date_Time = date,
                    //    Business_Unit_Id = entity.Business_Unit_Id,
                    //    Zone_Id = entity.Zone_Id,
                    //    Community_Id = entity.Community_Id,
                    //    Lead_Auditor_Id = entity.Lead_Auditor_Id,
                    //    Business_Unit_Type_Id = entity.Business_Unit_Type_Id,
                    //    Aud_Lat = entity.Aud_Lat,
                    //    Aud_Long = entity.Aud_Long,
                    //    CreatedBy = entity.CreatedBy,
                    //    Status = entity.Status
                    //};
                    //var Schd_List = (await connection.QueryAsync<M_Return_Message>(procedure, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                    var Schedule_Parameter = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id,
                        Reported_by = entity.Reported_by,
                        Designation = entity.Designation,
                        Status = entity.Status
                    };
                    var Schd_List = (await connection.QueryAsync<M_Return_Message>(procedure, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();


                    if (Schd_List != null)
                    {
                        if (entity.L_Aud_Internal_Audit_Team != null)
                        {
                            foreach (var item in entity.L_Aud_Internal_Audit_Team)
                            {
                                var Audit_Team_Param = new
                                {
                                    Internal_Audit_Id = Schd_List.Status_Code,
                                    Auditor_Id = item.Auditor_Id,
                                    Created_by = entity.CreatedBy
                                };
                                var Audit_Team_List = (await connection.QueryAsync<M_Return_Message>(Audit_Team_Proc, Audit_Team_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }
                        if (entity.L_Aud_Internal_Service_Provider_Team != null)
                        {
                            foreach (var Obj in entity.L_Aud_Internal_Service_Provider_Team)
                            {
                                var Service_Prov_Param = new
                                {
                                    Internal_Audit_Id = Schd_List.Status_Code,
                                    Service_Provider_Id = Obj.Service_Provider_Id,
                                    Created_by = entity.CreatedBy
                                };
                                var Audit_Team_List = (await connection.QueryAsync<M_Return_Message>(Service_Prov_Proc, Service_Prov_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                            }
                        }

                        var parameters_9 = new
                        {
                            Int_Audit_Id = Schd_List.Status_Code,
                            CreatedBy = entity.CreatedBy,
                            Role_Id = entity.Role_Id,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(Histor_procedure, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Add_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Aud_Internal_Audit>> Get_All_Internal_Audit(DataTableAjaxPostModel entity)
        {

            try
            {
                var UniqueID_Value = "";
                var Inc_Category_Id_Value = "";
                var Inc_Type_Id_Value = "";
                var Zone_Value = "";
                var Status_Value = "";
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
                                Inc_Category_Id_Value = item.Search!.Value;
                                break;
                            case 2:
                                Inc_Type_Id_Value = item.Search!.Value;
                                break;
                            case 3:
                                Zone_Value = item.Search!.Value;
                                break;
                            case 4:
                                Status_Value = item.Search!.Value;
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
                };
                string procedure = "sp_IAud_Get_Internal_Audit_List";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<Aud_Internal_Audit>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "Get_All_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Aud_Internal_Audit> GetByIdInternalAudit(Aud_Internal_Audit entity)
        {
            try
            {
                string procedure_1 = "sp_IAud_GetById_Internal_Audit";
                string procedure_2 = "sp_IAud_GetById_Internal_Audit_Team";
                string procedure_3 = "sp_IAud_GetById_Service_Provider_Team";
                string procedure_4 = "sp_IAud_Internal_Audit_History_by_Aud_Id";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id
                    };

                    var Obj = (await connection.QueryAsync<Aud_Internal_Audit>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Obj != null)
                    {
                        var ObjAudit_Team = (await connection.QueryAsync<Aud_Internal_Audit_Team>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Aud_Internal_Audit_Team = ObjAudit_Team;
                    }
                    if (Obj != null)
                    {
                        var ObjService_Provider_Team = (await connection.QueryAsync<Aud_Internal_Service_Provider_Team>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Aud_Internal_Service_Provider_Team = ObjService_Provider_Team;
                    }
                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Aud_Internal_Update_History>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Aud_Internal_Update_History = ObjUpdate_History;
                    }
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit Schedule - Internal Audit: GetByIdInternalAudit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<Aud_Internal_Audit> GetByIdInternalAuditSed(Aud_Internal_Audit entity)
        {
            try
            {
                string procedure_1 = "SP_IAUD_GETBYID_INTERNAL_AUDIT_Scd";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id
                    };
                    var Obj = (await connection.QueryAsync<Aud_Internal_Audit>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit Schedule - Internal Audit: GetByIdInternalAudit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_Internal_Aud_CheckList(List<Internal_Aud_CheckList> entity)
        {
            try
            {
                string procedure_1 = "sp_IAud_Internal_Audit_CheckList";
                string procedure_2 = "sp_IAud_Internal_Audit_Evidence_Photos";
                string procedure_3 = "sp_IAud_InternalCheckList_Update_History_Add";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    if (entity != null)
                    {
                        foreach (var item in entity)
                        {
                            var Audit_Team_Param = new
                            {
                                Clause_Id = item.Clause_Id,
                                Questionnaire_Id = item.Questionnaire_Id,
                                Internal_Audit_Id = item.Internal_Audit_Id,
                                Auditor_Verification_Details = item.Auditor_Verification_Details,
                                Site_Inspection_Details = item.Site_Inspection_Details,
                                Findings = item.Findings,
                                Created_by = item.CreatedBy,
                                Internal_Topic = item.Internal_Topic,
                                Internal_Sub_Topic = item.Internal_Sub_Topic
                            };
                            var Audit_Team_List = (await connection.QueryAsync<M_Return_Message>(procedure_1, Audit_Team_Param, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                            if (item.L_Aud_Internal_Evidence_Photos != null)
                            {
                                foreach (var item2 in item.L_Aud_Internal_Evidence_Photos)
                                {
                                    var Audit_Evidence = new
                                    {
                                        Evidence_Id = item2.Evidence_Id,
                                        Clause_Id = Audit_Team_List!.Status_Code,
                                        Internal_Audit_Id = item2.Internal_Audit_Id,
                                        Evidence_Path = item2.Evidence_Path,
                                    };
                                    var Audit_Evidence_List = (await connection.QueryAsync<M_Return_Message>(procedure_2, Audit_Evidence, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                                }
                            }
                        }
                    }

                    var parameters_9 = new
                    {
                        Int_Audit_Id = entity![0].Internal_Audit_Id,
                        CreatedBy = entity![0].CreatedBy,
                        Role_Id = entity![0].Role_Id,
                    };
                    var Objhis = (await connection.QueryAsync<M_Return_Message>(procedure_3, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Add_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<Internal_Aud_CheckList>> Get_Internal_Aud_CheckList(Aud_Internal_Audit entity)
        {
            try
            {
                string procedure_1 = "sp_IAud_GetById_Internal_Audit_CheckList";
                string procedure_2 = "sp_IAud_GetById_Internal_Audit_Evidence_Photos_CheckList";
                //string procedure_3 = "sp_IAud_Internal_Audit_History_by_Aud_Id_CheckList";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id
                    };

                    var Obj = (await connection.QueryAsync<Internal_Aud_CheckList>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                    if (Obj != null)
                    {
                        foreach (var item in Obj)
                        {
                            var parameters_1 = new
                            {
                                Clause_Id = item.Clause_Id
                            };
                            var ObjEvidence_Photos = (await connection.QueryAsync<Aud_Internal_Evidence_Photos>(procedure_2, parameters_1, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            item.L_Aud_Internal_Evidence_Photos = ObjEvidence_Photos;
                        }

                    }
                    //if (Obj!=null)
                    //{
                    //    var ObjUpdate_History = (await connection.QueryAsync<Aud_Internal_Update_History>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                    //    Obj[0].L_Aud_Internal_Update_History = ObjUpdate_History;
                    //}

                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit Schedule - Internal Audit: GetByIdInternalAudit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Add_NCR_Report_Form(Aud_Internal_NCR_Form entity)
        {
            try
            {
                string Procedure_1 = "sp_IAud_Internal_Audit_NCR_Form";
                string Procedure_2 = "sp_IAud_Internal_Audit_NCR_Root_Cause_Analysis";
                string Procedure_3 = "sp_IAud_Internal_Audit_NCR_Corrective_Action";
                string Procedure_4 = "sp_IAud_Internal_Update_Aud_CheckList";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Schedule_Parameter = new
                    {
                        NCR_Report_Id = entity.NCR_Report_Id,
                        Int_Audit_Id = entity.Int_Audit_Id,
                        Questionnaires_Id = entity.Questionnaires_Id,
                        Non_Conformity_Description = entity.Non_Conformity_Description,
                        Applicable_Standard_Procedure = entity.Applicable_Standard_Procedure,
                        Responsibility = entity.Responsibility,
                        Completion_Date = entity.Completion_Date,
                        Target_Date = entity.Target_Date,
                        Authorised_by = entity.Authorised_by,
                        Created_by = entity.CreatedBy
                    };
                    var Schd_List = (await connection.QueryAsync<M_Return_Message>(Procedure_1, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Schd_List != null)
                    {
                        if (entity.L_NCR_Root_Cause_Analysis!.Count > 0)
                        {
                            foreach (var item in entity.L_NCR_Root_Cause_Analysis)
                            {
                                item.NCR_Report_Id = Schd_List.Status_Code;
                                item.Int_Audit_Id = entity.Int_Audit_Id;
                            }
                            connection.Execute(Procedure_2, entity.L_NCR_Root_Cause_Analysis, commandType: CommandType.StoredProcedure);
                        }
                        if (entity.L_NCR_Corrective_Action!.Count > 0)
                        {
                            foreach (var Obj in entity.L_NCR_Corrective_Action)
                            {
                                Obj.NCR_Report_Id = Schd_List.Status_Code;
                                Obj.Int_Audit_Id = entity.Int_Audit_Id;
                            }
                            connection.Execute(Procedure_3, entity.L_NCR_Corrective_Action, commandType: CommandType.StoredProcedure);
                        }
                        var parameters_2 = new
                        {
                            Clause_Id = entity.Remarks_1,
                            Remarks = entity.Responsibility,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(Procedure_4, parameters_2, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Add_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Update_NCR_Report_Form(Aud_Internal_NCR_Form entity)
        {
            try
            {
                string Procedure_1 = "sp_IAud_Internal_Audit_NCR_Form_Update";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Schedule_Parameter = new
                    {
                        NCR_Report_Id = entity.NCR_Report_Id,
                        Applicable_Standard_Procedure = entity.Applicable_Standard_Procedure,
                        Responsibility = entity.Responsibility,
                        Target_Date = entity.Target_Date,
                        Created_by = entity.CreatedBy
                    };
                    var Schd_List = (await connection.QueryAsync<M_Return_Message>(Procedure_1, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

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
                string Repo = "Add_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        public async Task<M_Return_Message> Get_Internal_Audit_Audit_Team(Aud_Internal_Audit entity)
        {
            try
            {
                string procedure_1 = "sp_IAud_GetById_Internal_Audit_Audit_Team";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id,
                        Login_Id = entity.Login_Id,
                    };

                    var Obj = (await connection.QueryAsync<Aud_Internal_Audit_Team>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Status_Code = Obj!.Auditor_Id,
                            Status = true,
                            Message = "Success"
                        };
                        return rETURN_MESSAGE;
                    }
                    else
                    {
                        M_Return_Message rETURN_MESSAGE = new M_Return_Message
                        {
                            Status_Code = "0",
                            Status = true,
                            Message = "Success"
                        };
                        return rETURN_MESSAGE;
                    }
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit Schedule - Internal Audit: GetByIdInternalAudit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> Complete_NCR_Report_Form(Aud_Internal_Audit entity)
        {
            try
            {
                string procedure = "sp_IAud_Internal_Audit_Update";
                string Histor_procedure = "sp_IAud_Internal_Update_History_Update";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var Schedule_Parameter = new
                    {
                        Internal_Audit_Id = entity.Internal_Audit_Id,
                        Status = entity.Status
                    };
                    var Schd_List = (await connection.QueryAsync<M_Return_Message>(procedure, Schedule_Parameter, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    if (Schd_List!.Status_Code == "200")
                    {
                        var parameters_9 = new
                        {
                            Int_Audit_Id = entity.Internal_Audit_Id,
                            CreatedBy = entity.Login_Id,
                            Role_Id = entity.Role_Id,
                            Remarks = entity.Remarks_1,
                            Status = entity.Status,
                        };
                        var Objhis = (await connection.QueryAsync<M_Return_Message>(Histor_procedure, parameters_9, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Add_Internal_Audit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<Aud_Internal_NCR_Form> Get_NCR_Report_Form_Details(Aud_Internal_NCR_Form entity)
        {
            try
            {
                string procedure_1 = "sp_IAud_GetById_Internal_Audit_NCR_Details";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Int_Audit_Id = entity.Int_Audit_Id,
                        Questionnaires_Id = entity.Questionnaires_Id,
                    };
                    var Obj = (await connection.QueryAsync<Aud_Internal_NCR_Form>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                    return Obj;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Audit Schedule - Internal Audit: GetByIdInternalAudit";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }
        #endregion

#pragma warning restore CS8603 // Possible null reference return.
    }
}
