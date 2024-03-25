using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
  public interface IControlofWork_MasterRepo: IGenericRepo<M_ControlofWork_Master>
    {
        public Task<IReadOnlyList<M_MajorQuestion>> Major_Ques_GetAll();
        public Task<IReadOnlyList<M_MajorQuestion>> Major_Ques_GetById(M_MajorQuestion entity);
        public Task<M_Return_Message> Major_Ques_Add(List<M_MajorQuestion> entity);
        public Task<M_Return_Message> Major_Ques_Delete(M_MajorQuestion entity);
        public Task<IReadOnlyList<M_MajorQuestion>> Get_All_Questionnaire_Work();


        #region [Confined Space Permit to Work]
        public Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Confined_Space_Req(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Confined_Space_Req(Ptw_Confined_Space_Add entity);
        public Task<Ptw_Confined_Space_Add> Edit_Confined_Space(Ptw_Confined_Space_Add entity);
        public Task<M_Return_Message> Add_Zone_HSE_Csp_Approve(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Zone_Csp_Reject(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_HSE_Csp_Reject(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Sp_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Edit_Sp_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Add_Sp_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<Ptw_Contractor_Load_Details> Get_Contractor_Load(Ptw_Contractor_Load_Details entity);
        public Task<IReadOnlyList<Ptw_Contractor_Load_Details>> Get_Con_Pur_Drp(Ptw_Contractor_Load_Details entity);
        public Task<Ptw_Competent_Number> Get_Competent_Number(Ptw_Competent_Number entity);
        public Task<M_Return_Message> Add_Zone_Evd_Reject(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Zone_Renewal_Reject(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_HSE_Evd_Reject(Ptw_History_of_Approval entity);
        #endregion

        #region [Electrical Work Permit]
        public Task<IReadOnlyList<M_MajorQuestion>> Get_All_Electrical_Question();
        public Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Electrical_Work(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Electrical_Work_Req(Ptw_Confined_Space_Add entity);
        public Task<Ptw_Confined_Space_Add> Edit_Electrical_Work(Ptw_Confined_Space_Add entity);
        public Task<M_Return_Message> Add_Zone_HSE_EWP_Approve(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Sp_EWP_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Edit_Sp_EWP_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Add_Sp_EWP_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_EWP_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        //Reject
        public Task<M_Return_Message> Add_Zone_EWP_Reject(Ptw_History_of_Approval entity);

        #endregion

        #region [Hot Work Permit]
        public Task<IReadOnlyList<M_MajorQuestion>> Get_All_HotWork_Question();
        public Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Hot_Work(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Hot_Work_Req(Ptw_Confined_Space_Add entity);
        public Task<Ptw_Confined_Space_Add> Edit_Hot_Work(Ptw_Confined_Space_Add entity);
        public Task<M_Return_Message> Add_Zone_HSE_HW_Approve(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Sp_HW_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Edit_Sp_HW_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);

        public Task<M_Return_Message> Add_Sp_HW_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_HW_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Add_Zone_HW_Reject(Ptw_History_of_Approval entity);
        #endregion

        #region [Work At Height Permit]
        public Task<IReadOnlyList<M_MajorQuestion>> Get_All_Work_Height_Question();
        public Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Work_Height(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Work_Height_Req(Ptw_Confined_Space_Add entity);
        public Task<Ptw_Confined_Space_Add> Edit_Work_Height(Ptw_Confined_Space_Add entity);
        public Task<M_Return_Message> Add_Zone_HSE_WAH_Approve(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Sp_WAH_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Edit_Sp_WAH_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Add_Sp_WAH_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_WAH_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Add_Zone_WAH_Reject(Ptw_History_of_Approval entity);

        #endregion

        #region [Fire & Safety Work Permit]
        public Task<IReadOnlyList<M_MajorQuestion>> Get_All_Fire_Safety_Question();
        public Task<IReadOnlyList<Ptw_Confined_Space_Add>> Get_All_Fire_Safety_Req(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Add_Fire_Safety_Req(Ptw_Confined_Space_Add entity);
        public Task<Ptw_Confined_Space_Add> Edit_Fire_Safety(Ptw_Confined_Space_Add entity);
        public Task<M_Return_Message> Add_Sp_FS_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        public Task<M_Return_Message> Add_Sp_FS_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_FS_Renewal_Details(Ptw_Sp_Add_Renewal_Details entity);
        public Task<M_Return_Message> Edit_Sp_FS_Additional_Details(Ptw_Sp_Add_Evidence_Details entity);
        //Approve & Reject
        public Task<M_Return_Message> Add_Zone_HSE_FS_Approve(Ptw_History_of_Approval entity);
        public Task<M_Return_Message> Add_Zone_FS_Reject(Ptw_History_of_Approval entity);

        #endregion
    }
}
