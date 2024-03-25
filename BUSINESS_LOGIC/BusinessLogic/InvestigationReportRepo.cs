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

namespace BUSINESS_LOGIC.BusinessLogic
{
    public class InvestigationReportRepo : IInvestigationReportRepo
    {
        private readonly IConfiguration configuration;

        public InvestigationReportRepo(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<M_Return_Message> AddAsync(M_Investigation_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Inves_Investigation_Details_Add";
                string procedure_2 = "sp_Inves_Other_Parties_Involved_Add";
                string procedure_3 = "sp_Inves_Immediate_Cause_Unsafe_Act_Add";
                string procedure_4 = "sp_Inves_Immediate_Cause_Unsafe_Cond_Add";
                string procedure_5 = "sp_Inves_Root_Cause_PF_Add";
                string procedure_6 = "sp_Inves_Root_Cause_SF_Add";
                string procedure_7 = "sp_Inves_Mechanism_InjuryIllness_Add";
                string procedure_8 = "sp_Inves_AgencySource_InjuryIllness_Add";
                string procedure_9 = "sp_Inves_Environmental_Impact_Details_Add";
                string procedure_10 = "sp_Inves_Security_Impact_Details_Add";
                string procedure_11 = "sp_Inves_Actions_Taken_Immediately_Add";
                string procedure_12 = "sp_Inves_Incident_Root_Cause_Add";
                string procedure_13 = "sp_Inves_Corrective_Actions_Add";
                string procedure_14 = "sp_Inves_Declarations_Approvals_Add";
                string procedure_15 = "sp_Inves_Attachements_Add";
                string procedure_16 = "sp_Incident_Status_Update";

                string procedure_18 = "sp_Inc_Inve_InjuredPerson_Delete";
                string procedure_17 = "sp_Inc_Inve_InjuredPerson_Add";
                string procedure_19 = "sp_Inc_Inve_TeamPersonUpdate";

                string procedure_20 = "sp_Send_Email_and_Noti_Zone_Supervisor_Team";

                string procedure_22 = "sp_Inc_Inve_Injury_Type_Add";
                string procedure_32 = "sp_Inc_Inve_Nature_Injury_Add";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters_1 = new
                    {
                        Investigation_Id = entity.Investigation_Id,
                        Inc_Id = entity.Inc_Id,
                        Total_Man_Days = entity.Total_Man_Days,
                        Involved_Department_Contractor = entity.Involved_Department_Contractor,
                        Description_circumstances = entity.Description_circumstances,
                        Applicable_Reports = entity.Applicable_Reports,
                        Justification_Comments = entity.Justification_Comments,
                        Additional_Information = entity.Additional_Information,
                        Risk_Assessment_Environmental_Impact = entity.Risk_Assessment_Environmental_Impact,
                        Is_Ref = entity.Is_Ref,
                        CreatedBy = entity.CreatedBy,
                        Invs_File_Path = entity.Invs_File_Path,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();

                    if (Obj != null)
                    {
                        if (entity.L_Inves_Other_Parties_Involved != null && entity.L_Inves_Other_Parties_Involved.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Other_Parties_Involved)
                            {
                                var parameters_2 = new
                                {
                                    Inves_Other_Parties_Id = item.Inves_Other_Parties_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Role_Position = item.Role_Position,
                                    Other_Name = item.Other_Name,
                                    Other_Contact_no = item.Other_Contact_no,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Act != null && entity.L_Inves_Immediate_Cause_Unsafe_Act.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Act)
                            {
                                var parameters_3 = new
                                {
                                    Inves_Unsafe_Act_Id = item.Inves_Unsafe_Act_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Unsafe_Act_Id = item.M_Unsafe_Act_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Cond != null && entity.L_Inves_Immediate_Cause_Unsafe_Cond.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Cond)
                            {
                                var parameters_4 = new
                                {
                                    Inves_Unsafe_Cond_Id = item.Inves_Unsafe_Cond_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Unsafe_Cond_Id = item.M_Unsafe_Cond_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_PF != null && entity.L_Inves_Root_Cause_PF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_PF)
                            {
                                var parameters_5 = new
                                {
                                    Inves_RootCause_PF_Id = item.Inves_RootCause_PF_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_RootCause_PF_Id = item.M_RootCause_PF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_SF != null && entity.L_Inves_Root_Cause_SF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_SF)
                            {
                                var parameters_6 = new
                                {
                                    Inves_RootCause_SF_Id = item.Inves_RootCause_SF_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_RootCause_SF_Id = item.M_RootCause_SF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_6, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Mechanism_InjuryIllness != null && entity.L_Inves_Mechanism_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Mechanism_InjuryIllness)
                            {
                                var parameters_7 = new
                                {
                                    Inves_Mechanism_Injury_Id = item.Inves_Mechanism_Injury_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Mechanism_InjuryIllness_Id = item.M_Mechanism_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_AgencySource_InjuryIllness != null && entity.L_Inves_AgencySource_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_AgencySource_InjuryIllness)
                            {
                                var parameters_8 = new
                                {
                                    Inves_AgencySource_Injury_Id = item.Inves_AgencySource_Injury_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_AgencySource_InjuryIllness_Id = item.M_AgencySource_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_8, parameters_8, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Environmental_Impact_Details != null && entity.L_Inves_Environmental_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Environmental_Impact_Details)
                            {
                                var parameters_9 = new
                                {
                                    Inves_Environmental_Id = item.Inves_Environmental_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Environmental_Incident = item.Environmental_Incident,
                                    Cause_Of_Release = item.Cause_Of_Release,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_9, parameters_9, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Security_Impact_Details != null && entity.L_Inves_Security_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Security_Impact_Details)
                            {
                                var parameters_10 = new
                                {
                                    Inves_Security_Id = item.Inves_Security_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Classification_Id = item.Classification_Id,
                                    Type_of_Security_Incident_Id = item.Type_of_Security_Incident_Id,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_10, parameters_10, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Actions_Taken_Immediately != null && entity.L_Inves_Actions_Taken_Immediately.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Actions_Taken_Immediately)
                            {
                                var parameters_11 = new
                                {
                                    Inves_Action_Taken_Id = item.Inves_Action_Taken_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Description_of_Actions = item.Description_of_Actions,
                                    Action_Taken_By = item.Action_Taken_By,
                                    Date_Completed = item.Date_Completed,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_11, parameters_11, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Incident_Root_Cause != null && entity.L_Inves_Incident_Root_Cause.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Incident_Root_Cause)
                            {
                                var parameters_12 = new
                                {
                                    Inves_Root_Cause_Id = item.Inves_Root_Cause_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Root_Cause_Description = item.Root_Cause_Description,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_12, parameters_12, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Corrective_Actions != null && entity.L_Inves_Corrective_Actions.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Corrective_Actions)
                            {
                                var parameters_13 = new
                                {
                                    Inves_Corrective_Action_Id = item.Inves_Corrective_Action_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Description_Actions = item.Description_Actions,
                                    Person_Responsible = item.Person_Responsible,
                                    Priority = item.Priority,
                                    Target_Date = item.Target_Date,
                                    CreatedBy = entity.CreatedBy,
                                    Action_Taken = item.Action_Taken,
                                    Upload_Evidence = item.Upload_Evidence

                                };
                                await connection.ExecuteAsync(procedure_13, parameters_13, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Declarations_Approvals != null && entity.L_Inves_Declarations_Approvals.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Declarations_Approvals)
                            {
                                var parameters_14 = new
                                {
                                    Inves_Declarations_Approvals_Id = item.Inves_Declarations_Approvals_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Report_Status = item.Report_Status,
                                    HSSE_Representative_Id = item.HSSE_Representative_Id,
                                    Department_Representative_Id = item.Department_Representative_Id,
                                    Other_Representative_Id = item.Other_Representative_Id,
                                    Date = item.Date,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_14, parameters_14, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Attachements != null && entity.L_Inves_Attachements.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Attachements)
                            {
                                var parameters_15 = new
                                {
                                    Inves_Attachements_Id = item.Inves_Attachements_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Title = item.Title,
                                    Is_Attachements = item.Is_Attachements,
                                    Attachements_Description = item.Attachements_Description,
                                    CreatedBy = entity.CreatedBy,
                                    File_Path = item.File_Path,

                                };
                                await connection.ExecuteAsync(procedure_15, parameters_15, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Inc_Persons_Injured != null && entity.L_M_Inc_Persons_Injured.Count > 0)
                        {
                            var parameters_18 = new
                            {
                                Inc_Id = entity.Inc_Id,
                            };
                            await connection.ExecuteAsync(procedure_18, parameters_18, commandType: CommandType.StoredProcedure);

                            foreach (var item in entity.L_M_Inc_Persons_Injured)
                            {
                                var parameters_17 = new
                                {
                                    Inc_Persons_Injured_Id = item.Inc_Persons_Injured_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Persons_Name = item.Persons_Name,
                                    Persons_ContactNo = item.Persons_ContactNo,
                                    Injured_Type = item.Injured_Type,
                                    BodyParts_List = item.BodyParts_List,
                                    Persons_Id = item.Persons_Id,
                                    Total_man_days = item.Total_man_days,
                                    Company_Name = item.Company_Name,
                                };
                                await connection.ExecuteAsync(procedure_17, parameters_17, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inc_Inve_Injury_Type != null && entity.L_Inc_Inve_Injury_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Injury_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Injury_Type_Id = item.Inc_Injury_Type_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Injury_Type_Id = item.Injury_Type_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_22, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inc_Inve_Nature_Injury != null && entity.L_Inc_Inve_Nature_Injury.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Nature_Injury)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Nature_Injury_Id = item.Inc_Nature_Injury_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Nature_Injury_Id = item.Nature_Injury_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_32, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.Role_Id == "15" || entity.Role_Id == "16" || entity.Role_Id == "17")
                        {
                            var parameters_16 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                Status = '6',
                            };
                            await connection.ExecuteAsync(procedure_16, parameters_16, commandType: CommandType.StoredProcedure);

                            var parameters_22 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                CreatedBy = entity.CreatedBy,
                                Role_Id = entity.Role_Id,
                            };
                            await connection.ExecuteAsync("sp_Incident_Status_Update_Service_Provider", parameters_22, commandType: CommandType.StoredProcedure);
                        }
                        else
                        {
                            var parameters_16 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                Status = "13",
                            };
                            await connection.ExecuteAsync(procedure_16, parameters_16, commandType: CommandType.StoredProcedure);

                            var parameters_23 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                CreatedBy = entity.CreatedBy,
                                Role_Id = entity.Role_Id,
                            };
                            await connection.ExecuteAsync("sp_Incident_Status_Update_Supervisor", parameters_23, commandType: CommandType.StoredProcedure);
                        }
                        var parameters_19 = new
                        {
                            Inc_Id = entity.Inc_Id,
                            Status = '2',
                        };
                        await connection.ExecuteAsync(procedure_19, parameters_19, commandType: CommandType.StoredProcedure);

                        var parameters_20 = new
                        {
                            Inc_Notification_Id = entity.Inc_Id,
                        };
                        var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_20, parameters_20, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
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
                string Repo = "Investigation Add Report";
                ErrorLog.ErrorLogs(ex, Repo);
                M_Return_Message rETURN_MESSAGE = new M_Return_Message
                {
                    Message = M_Return_Status_Text.FAILED,
                    Status = M_Return_Status_Code.FALSE,
                    Status_Code = M_Return_Status_Code.FAILED
                };
                return rETURN_MESSAGE;
            }
        }

        public Task<M_Return_Message> DeleteAsync(M_Investigation_Report entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<M_Investigation_Report>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<M_Investigation_Report> GetByIdAsync(M_Investigation_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Inves_Investigation_Details_by_Id";
                string procedure_2 = "sp_Inves_Other_Parties_Involved_by_Id";
                string procedure_3 = "sp_Inves_Immediate_Cause_Unsafe_Act_by_Id";
                string procedure_4 = "sp_Inves_Immediate_Cause_Unsafe_Cond_by_Id";
                string procedure_5 = "sp_Inves_Root_Cause_PF_by_Id";
                string procedure_6 = "sp_Inves_Root_Cause_SF_by_Id";
                string procedure_7 = "sp_Inves_Mechanism_InjuryIllness_by_Id";
                string procedure_8 = "sp_Inves_AgencySource_InjuryIllness_by_Id";
                string procedure_9 = "sp_Inves_Environmental_Impact_Details_by_Id";
                string procedure_10 = "sp_Inves_Security_Impact_Details_by_Id";
                string procedure_11 = "sp_Inves_Actions_Taken_Immediately_by_Id";
                string procedure_12 = "sp_Inves_Incident_Root_Cause_by_Id";
                string procedure_13 = "sp_Inves_Corrective_Actions_by_Id";
                string procedure_14 = "sp_Inves_Declarations_Approvals_by_Id";
                string procedure_15 = "sp_Inves_Attachements_by_Id";
                string procedure_16 = "sp_Inc_Incident_Closure_Evidence_Final";
                string procedure_17 = "sp_Inc_Incident_Notification_Reject_List";
                string procedure_18 = "sp_Inc_Knowledge_Share_List";
                string procedure_19 = "sp_Inc_Inc_Knowledge_Share_Key_Points_List";
                string procedure_20 = "sp_Inc_Knowledge_Share_Recommendations_List";
                string procedure_21 = "sp_Inves_Corrective_Actions_List_by_Id";
                string procedure22 = "sp_Incident_History_by_inc_Id";

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    var parameters = new
                    {
                        Inc_Id = entity.Inc_Id
                    };
                    var Obj = (await connection.QueryAsync<M_Investigation_Report>(procedure_1, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    if (Obj != null)
                    {
                        var ObjOther_Parties = (await connection.QueryAsync<Inves_Other_Parties_Involved>(procedure_2, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Other_Parties_Involved = ObjOther_Parties;
                    }
                    if (Obj != null)
                    {
                        var ObjUnsafe_Act = (await connection.QueryAsync<Inves_Immediate_Cause_Unsafe_Act>(procedure_3, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Immediate_Cause_Unsafe_Act = ObjUnsafe_Act;
                    }
                    if (Obj != null)
                    {
                        var ObjUnsafe_Cond = (await connection.QueryAsync<Inves_Immediate_Cause_Unsafe_Cond>(procedure_4, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Immediate_Cause_Unsafe_Cond = ObjUnsafe_Cond;
                    }
                    if (Obj != null)
                    {
                        var ObjRoot_Cause_PF_ = (await connection.QueryAsync<Inves_Root_Cause_PF>(procedure_5, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Root_Cause_PF = ObjRoot_Cause_PF_;
                    }

                    if (Obj != null)
                    {
                        var ObjRoot_Cause_SF = (await connection.QueryAsync<Inves_Root_Cause_SF>(procedure_6, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Root_Cause_SF = ObjRoot_Cause_SF;
                    }
                    if (Obj != null)
                    {
                        var ObjInves_Mechanism = (await connection.QueryAsync<Inves_Mechanism_InjuryIllness>(procedure_7, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Mechanism_InjuryIllness = ObjInves_Mechanism;
                    }
                    if (Obj != null)
                    {
                        var ObjAgencySource = (await connection.QueryAsync<Inves_AgencySource_InjuryIllness>(procedure_8, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_AgencySource_InjuryIllness = ObjAgencySource;
                    }
                    if (Obj != null)
                    {
                        var ObjEnvironmental_Impact = (await connection.QueryAsync<Inves_Environmental_Impact_Details>(procedure_9, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Environmental_Impact_Details = ObjEnvironmental_Impact;
                    }
                    if (Obj != null)
                    {
                        var ObjSecurity_Impact = (await connection.QueryAsync<Inves_Security_Impact_Details>(procedure_10, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Security_Impact_Details = ObjSecurity_Impact;
                    }
                    if (Obj != null)
                    {
                        var ObjActions_Taken = (await connection.QueryAsync<Inves_Actions_Taken_Immediately>(procedure_11, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Actions_Taken_Immediately = ObjActions_Taken;
                    }
                    if (Obj != null)
                    {
                        var ObjIncident_Root = (await connection.QueryAsync<Inves_Incident_Root_Cause>(procedure_12, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Incident_Root_Cause = ObjIncident_Root;
                    }
                    if (Obj != null)
                    {
                        var ObjCorrective_Actions = (await connection.QueryAsync<Inves_Corrective_Actions>(procedure_21, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Corrective_Actions = ObjCorrective_Actions;
                    }
                    if (Obj != null)
                    {
                        var ObjDeclarations_Approvals = (await connection.QueryAsync<Inves_Declarations_Approvals>(procedure_14, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Declarations_Approvals = ObjDeclarations_Approvals;
                    }
                    if (Obj != null)
                    {
                        var ObjInves_Attachements = (await connection.QueryAsync<Inves_Attachements>(procedure_15, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Inves_Attachements = ObjInves_Attachements;
                    }

                    if (Obj != null)
                    {
                        var ObjIncident_Notification_Reject = (await connection.QueryAsync<M_Incident_Notification_Reject>(procedure_17, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_M_Incident_Notification_Reject = ObjIncident_Notification_Reject;
                    }
                    if (Obj != null)
                    {
                        List<Inves_Complete_Corrective_Actions> List_Add_Corrective_Action = new List<Inves_Complete_Corrective_Actions>();
                        if (Obj!.Status == "11")
                        {
                            var ObjCorrective_Actions = (await connection.QueryAsync<Inves_Complete_Corrective_Actions>(procedure_13, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            List_Add_Corrective_Action = ObjCorrective_Actions;

                            foreach (var item in List_Add_Corrective_Action)
                            {
                                var parameters11 = new
                                {
                                    Inc_Id = item.Inc_Id,
                                    Inves_Corrective_Action_Id = item.Inves_Corrective_Action_Id
                                };
                                var ObjEvidence_Upload_Photos = (await connection.QueryAsync<Evidence_Upload_Photos>(procedure_16, parameters11, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                                item.Evidence_Upload_Photos = ObjEvidence_Upload_Photos;
                            }
                            Obj.L_Inves_Complete_Corrective_Actions = List_Add_Corrective_Action;
                        }
                    }


                    if (Obj != null)
                    {
                        var ObjIncident_Knowledge_Share_1 = (await connection.QueryAsync<Inc_Knowledge_Share>(procedure_18, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();

                        if (ObjIncident_Knowledge_Share_1.Count > 0)
                        {
                            Inc_Knowledge_Share List_Add_Inc_Knowledge_Share = new Inc_Knowledge_Share();

                            Inc_Knowledge_Share ObjIncident_Knowledge_Share = (await connection.QueryAsync<Inc_Knowledge_Share>(procedure_18, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).Single();

                            List_Add_Inc_Knowledge_Share.Knowledge_Share_Id = ObjIncident_Knowledge_Share.Knowledge_Share_Id;
                            List_Add_Inc_Knowledge_Share.Inc_Id = ObjIncident_Knowledge_Share.Inc_Id;
                            List_Add_Inc_Knowledge_Share.File_Path = ObjIncident_Knowledge_Share.File_Path;
                            List_Add_Inc_Knowledge_Share.Knowledge_Description = ObjIncident_Knowledge_Share.Knowledge_Description;
                            List_Add_Inc_Knowledge_Share.KnowledgeInc_Category = ObjIncident_Knowledge_Share.KnowledgeInc_Category;
                            List_Add_Inc_Knowledge_Share.KnowledgeInc_Type = ObjIncident_Knowledge_Share.KnowledgeInc_Type;

                            List<Inc_Knowledge_Share_Key_Points> ObjIncident_Knowledge_Share_Key_Points = (await connection.QueryAsync<Inc_Knowledge_Share_Key_Points>(procedure_19, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            List_Add_Inc_Knowledge_Share.L_Inc_Knowledge_Share_Key_Points = ObjIncident_Knowledge_Share_Key_Points;

                            List<Inc_Knowledge_Share_Recommendations> ObjIncident_Knowledge_Share_Recommendations = (await connection.QueryAsync<Inc_Knowledge_Share_Recommendations>(procedure_20, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                            List_Add_Inc_Knowledge_Share.L_Inc_Knowledge_Share_Recommendations = ObjIncident_Knowledge_Share_Recommendations;

                            Obj.L_M_Incident_Knowledge_Share = List_Add_Inc_Knowledge_Share;
                        }
                    }

                    if (Obj != null)
                    {
                        var ObjUpdate_History = (await connection.QueryAsync<Incident_Update_History>(procedure22, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).ToList();
                        Obj.L_Incident_Update_History = ObjUpdate_History;
                    }
                    return Obj!;
                }
            }
            catch (Exception ex)
            {
                string Repo = "Investigation Report GetByIdAsync";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<IReadOnlyList<M_Incident_Report>> IncNotificationGetAll(DataTableAjaxPostModel entity)
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
                    Created_By = entity.CreatedBy,
                    Zone_Id = entity.Zone_Id
                };
                string procedure = "sp_Get_Incident_Inve_Notification";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    return (await connection.QueryAsync<M_Incident_Report>(procedure, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).AsList();
                }
            }
            catch (Exception ex)
            {
                string Repo = "IncNotificationGetAll";
                ErrorLog.ErrorLogs(ex, Repo);
                throw;
            }
        }

        public async Task<M_Return_Message> UpdateAsync(M_Investigation_Report entity)
        {
            try
            {
                string procedure_1 = "sp_Inves_Investigation_Details_Update";
                string procedure_2 = "sp_Inves_Other_Parties_Involved_Add";
                string procedure_3 = "sp_Inves_Immediate_Cause_Unsafe_Act_Add";
                string procedure_4 = "sp_Inves_Immediate_Cause_Unsafe_Cond_Add";
                string procedure_5 = "sp_Inves_Root_Cause_PF_Add";
                string procedure_6 = "sp_Inves_Root_Cause_SF_Add";
                string procedure_7 = "sp_Inves_Mechanism_InjuryIllness_Add";
                string procedure_8 = "sp_Inves_AgencySource_InjuryIllness_Add";
                string procedure_9 = "sp_Inves_Environmental_Impact_Details_Add";
                string procedure_10 = "sp_Inves_Security_Impact_Details_Add";
                string procedure_11 = "sp_Inves_Actions_Taken_Immediately_Add";
                string procedure_12 = "sp_Inves_Incident_Root_Cause_Add";
                string procedure_13 = "sp_Inves_Corrective_Actions_Add";
                string procedure_14 = "sp_Inves_Declarations_Approvals_Add";
                string procedure_15 = "sp_Inves_Attachements_Add";
                string procedure_16 = "sp_Incident_Status_Update";

                string procedure_18 = "sp_Inc_Inve_InjuredPerson_Delete";
                string procedure_17 = "sp_Inc_Inve_InjuredPerson_Add";
                string procedure_19 = "sp_Inc_Inve_TeamPersonUpdate";

                string procedure_20 = "sp_Send_Email_and_Noti_Zone_Supervisor_Team";

                string procedure_22 = "sp_Inc_Inve_Injury_Type_Add";
                string procedure_32 = "sp_Inc_Inve_Nature_Injury_Add";

                string procedure_24 = "sp_Send_Email_and_Noti_Lead_Invs_Team";

                string deleteProcedure = "sp_Investigation_Delete_All";



                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {

                    var deleteParameters = new
                    {
                        Inc_Id = entity.Inc_Id
                    };

                    var DeleteValue = (await connection.QueryAsync<M_Return_Message>(deleteProcedure, deleteParameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();

                    var parameters_1 = new
                    {
                        Investigation_Id = entity.Investigation_Id,
                        //Inc_Id = entity.Inc_Id,
                        Total_Man_Days = entity.Total_Man_Days,
                        Involved_Department_Contractor = entity.Involved_Department_Contractor,
                        Description_circumstances = entity.Description_circumstances,
                        Applicable_Reports = entity.Applicable_Reports,
                        Justification_Comments = entity.Justification_Comments,
                        Additional_Information = entity.Additional_Information,
                        Risk_Assessment_Environmental_Impact = entity.Risk_Assessment_Environmental_Impact,
                        Is_Ref = entity.Is_Ref,
                        CreatedBy = entity.CreatedBy,
                        Invs_File_Path = entity.Invs_File_Path,
                    };
                    var Obj = (await connection.QueryAsync<M_Return_Message>(procedure_1, parameters_1, commandType: CommandType.StoredProcedure)).SingleOrDefault();
                    if (Obj != null)
                    {
                        if (entity.L_Inves_Other_Parties_Involved != null && entity.L_Inves_Other_Parties_Involved.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Other_Parties_Involved)
                            {
                                var parameters_2 = new
                                {
                                    Inves_Other_Parties_Id = item.Inves_Other_Parties_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Role_Position = item.Role_Position,
                                    Other_Name = item.Other_Name,
                                    Other_Contact_no = item.Other_Contact_no,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_2, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Act != null && entity.L_Inves_Immediate_Cause_Unsafe_Act.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Act)
                            {
                                var parameters_3 = new
                                {
                                    Inves_Unsafe_Act_Id = item.Inves_Unsafe_Act_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Unsafe_Act_Id = item.M_Unsafe_Act_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_3, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Immediate_Cause_Unsafe_Cond != null && entity.L_Inves_Immediate_Cause_Unsafe_Cond.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Immediate_Cause_Unsafe_Cond)
                            {
                                var parameters_4 = new
                                {
                                    Inves_Unsafe_Cond_Id = item.Inves_Unsafe_Cond_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Unsafe_Cond_Id = item.M_Unsafe_Cond_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_4, parameters_4, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_PF != null && entity.L_Inves_Root_Cause_PF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_PF)
                            {
                                var parameters_5 = new
                                {
                                    Inves_RootCause_PF_Id = item.Inves_RootCause_PF_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_RootCause_PF_Id = item.M_RootCause_PF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_5, parameters_5, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Root_Cause_SF != null && entity.L_Inves_Root_Cause_SF.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Root_Cause_SF)
                            {
                                var parameters_6 = new
                                {
                                    Inves_RootCause_SF_Id = item.Inves_RootCause_SF_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_RootCause_SF_Id = item.M_RootCause_SF_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_6, parameters_6, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Mechanism_InjuryIllness != null && entity.L_Inves_Mechanism_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Mechanism_InjuryIllness)
                            {
                                var parameters_7 = new
                                {
                                    Inves_Mechanism_Injury_Id = item.Inves_Mechanism_Injury_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_Mechanism_InjuryIllness_Id = item.M_Mechanism_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_7, parameters_7, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_AgencySource_InjuryIllness != null && entity.L_Inves_AgencySource_InjuryIllness.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_AgencySource_InjuryIllness)
                            {
                                var parameters_8 = new
                                {
                                    Inves_AgencySource_Injury_Id = item.Inves_AgencySource_Injury_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    M_AgencySource_InjuryIllness_Id = item.M_AgencySource_InjuryIllness_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_8, parameters_8, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Environmental_Impact_Details != null && entity.L_Inves_Environmental_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Environmental_Impact_Details)
                            {
                                var parameters_9 = new
                                {
                                    Inves_Environmental_Id = item.Inves_Environmental_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Environmental_Incident = item.Environmental_Incident,
                                    Cause_Of_Release = item.Cause_Of_Release,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_9, parameters_9, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Security_Impact_Details != null && entity.L_Inves_Security_Impact_Details.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Security_Impact_Details)
                            {
                                var parameters_10 = new
                                {
                                    Inves_Security_Id = item.Inves_Security_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Classification_Id = item.Classification_Id,
                                    Type_of_Security_Incident_Id = item.Type_of_Security_Incident_Id,
                                    Impact_Details = item.Impact_Details,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_10, parameters_10, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Actions_Taken_Immediately != null && entity.L_Inves_Actions_Taken_Immediately.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Actions_Taken_Immediately)
                            {
                                var parameters_11 = new
                                {
                                    Inves_Action_Taken_Id = item.Inves_Action_Taken_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Description_of_Actions = item.Description_of_Actions,
                                    Action_Taken_By = item.Action_Taken_By,
                                    Date_Completed = item.Date_Completed,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_11, parameters_11, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Incident_Root_Cause != null && entity.L_Inves_Incident_Root_Cause.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Incident_Root_Cause)
                            {
                                var parameters_12 = new
                                {
                                    Inves_Root_Cause_Id = item.Inves_Root_Cause_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Root_Cause_Description = item.Root_Cause_Description,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_12, parameters_12, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Corrective_Actions != null && entity.L_Inves_Corrective_Actions.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Corrective_Actions)
                            {
                                var parameters_13 = new
                                {
                                    Inves_Corrective_Action_Id = item.Inves_Corrective_Action_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Description_Actions = item.Description_Actions,
                                    Person_Responsible = item.Person_Responsible,
                                    Priority = item.Priority,
                                    Target_Date = item.Target_Date,
                                    CreatedBy = entity.CreatedBy,
                                    Action_Taken = item.Action_Taken,
                                    Upload_Evidence = item.Upload_Evidence

                                };
                                await connection.ExecuteAsync(procedure_13, parameters_13, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Declarations_Approvals != null && entity.L_Inves_Declarations_Approvals.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Declarations_Approvals)
                            {
                                var parameters_14 = new
                                {
                                    Inves_Declarations_Approvals_Id = item.Inves_Declarations_Approvals_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Report_Status = item.Report_Status,
                                    HSSE_Representative_Id = item.HSSE_Representative_Id,
                                    Department_Representative_Id = item.Department_Representative_Id,
                                    Other_Representative_Id = item.Other_Representative_Id,
                                    Date = item.Date,
                                    CreatedBy = entity.CreatedBy,
                                };
                                await connection.ExecuteAsync(procedure_14, parameters_14, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inves_Attachements != null && entity.L_Inves_Attachements.Count > 0)
                        {
                            foreach (var item in entity.L_Inves_Attachements)
                            {
                                var parameters_15 = new
                                {
                                    Inves_Attachements_Id = item.Inves_Attachements_Id,
                                    Investigation_Id = Obj.Status_Code,
                                    Inc_Id = item.Inc_Id,
                                    Title = item.Title,
                                    Is_Attachements = item.Is_Attachements,
                                    Attachements_Description = item.Attachements_Description,
                                    CreatedBy = entity.CreatedBy,
                                    File_Path = item.File_Path,

                                };
                                await connection.ExecuteAsync(procedure_15, parameters_15, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_M_Inc_Persons_Injured != null && entity.L_M_Inc_Persons_Injured.Count > 0)
                        {
                            var parameters_18 = new
                            {
                                Inc_Id = entity.Inc_Id,
                            };
                            await connection.ExecuteAsync(procedure_18, parameters_18, commandType: CommandType.StoredProcedure);

                            foreach (var item in entity.L_M_Inc_Persons_Injured)
                            {
                                var parameters_17 = new
                                {
                                    Inc_Persons_Injured_Id = item.Inc_Persons_Injured_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Persons_Name = item.Persons_Name,
                                    Persons_ContactNo = item.Persons_ContactNo,
                                    Injured_Type = item.Injured_Type,
                                    BodyParts_List = item.BodyParts_List,
                                    Persons_Id = item.Persons_Id,
                                    Total_man_days = item.Total_man_days,
                                    Company_Name = item.Company_Name,
                                };
                                await connection.ExecuteAsync(procedure_17, parameters_17, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inc_Inve_Injury_Type != null && entity.L_Inc_Inve_Injury_Type.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Injury_Type)
                            {
                                var parameters_2 = new
                                {
                                    Inc_Injury_Type_Id = item.Inc_Injury_Type_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Injury_Type_Id = item.Injury_Type_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_22, parameters_2, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.L_Inc_Inve_Nature_Injury != null && entity.L_Inc_Inve_Nature_Injury.Count > 0)
                        {
                            foreach (var item in entity.L_Inc_Inve_Nature_Injury)
                            {
                                var parameters_3 = new
                                {
                                    Inc_Nature_Injury_Id = item.Inc_Nature_Injury_Id,
                                    Inc_Id = entity.Inc_Id,
                                    Nature_Injury_Id = item.Nature_Injury_Id,
                                    CreatedBy = entity.CreatedBy,
                                    Remarks = item.Remarks
                                };
                                await connection.ExecuteAsync(procedure_32, parameters_3, commandType: CommandType.StoredProcedure);
                            }
                        }

                        if (entity.Role_Id == "15" || entity.Role_Id == "16" || entity.Role_Id == "17")
                        {
                            var parameters_16 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                Status = '6',
                            };
                            await connection.ExecuteAsync(procedure_16, parameters_16, commandType: CommandType.StoredProcedure);

                            var parameters_22 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                CreatedBy = entity.CreatedBy,
                                Role_Id = entity.Role_Id,
                            };
                            await connection.ExecuteAsync("sp_Incident_Status_Update_Service_Provider", parameters_22, commandType: CommandType.StoredProcedure);

                            var parameters_20 = new
                            {
                                Inc_Notification_Id = entity.Inc_Id,
                            };
                            var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_20, parameters_20, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                        else
                        {
                            var parameters_16 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                Status = "13",
                            };
                            await connection.ExecuteAsync(procedure_16, parameters_16, commandType: CommandType.StoredProcedure);

                            var parameters_23 = new
                            {
                                Inc_Id = entity.Inc_Id,
                                CreatedBy = entity.CreatedBy,
                                Role_Id = entity.Role_Id,
                            };
                            await connection.ExecuteAsync("sp_Incident_Status_Update_Supervisor", parameters_23, commandType: CommandType.StoredProcedure);

                            var parameters_24 = new
                            {
                                Inc_Notification_Id = entity.Inc_Id,
                            };
                            var Objre2 = (await connection.QueryAsync<M_Return_Message>(procedure_24, parameters_24, commandType: CommandType.StoredProcedure).ConfigureAwait(false)).SingleOrDefault();
                        }
                        var parameters_19 = new
                        {
                            Inc_Id = entity.Inc_Id,
                            Status = '2',
                        };
                        await connection.ExecuteAsync(procedure_19, parameters_19, commandType: CommandType.StoredProcedure);

                        
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}
