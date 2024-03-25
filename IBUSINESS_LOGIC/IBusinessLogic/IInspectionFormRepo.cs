using Microsoft.AspNetCore.Http;
using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IInspectionFormRepo : IGenericRepo<M_Insp_Request>
    {

        #region [Spot Insp]

        #region [Insp Spot Request]
        public Task<IReadOnlyList<M_Insp_Request>> Insp_Request_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Insp_Request_ApprovalReject(M_Insp_Request entity);
        public List<string> UploadImage(List<IFormFile> file);
        public List<string> UploadImagePdf(List<IFormFile> file);
        public List<string> UploadPicture(List<IFormFile> file);
        public Task<M_Return_Message> Insp_Req_Photo_Delete(Insp_Req_Doc_Review entity);
        #endregion
        #region [Insp Spot Finding]
        public Task<M_Return_Message> Add_Insp_Spot_Finding(M_Insp_Spot_Finding entity);
        public Task<List<M_Insp_Value_Text>> Insp_Sub_Category_Master_GetbyId(M_Insp_Value_Text entity);
        public Task<M_Return_Message> Insp_Find_ApprovalReject(M_Insp_Finding_Approval entity);
        public Task<M_Insp_Spot_Sub_Finding> Insp_Sub_Find_List_GetById(M_Insp_Spot_Sub_Finding entity);
        public Task<M_Return_Message> Insp_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity);
        public Task<M_Return_Message> Insp_Sub_Finding_Delete(M_Insp_Spot_Sub_Finding entity);
        public Task<M_Insp_Spot_WalkIn_Master> Load_Spot_Find_WalkinZone(M_Insp_Spot_WalkIn_Master entity);
        public Task<M_Return_Message> Add_Insp_Spot_Walk_In_Finding(M_Insp_Request entity);
        #endregion
        #region [Insp Spot Corrective Action]
        public Task<M_Return_Message> Insp_Spot_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity);
        public Task<IReadOnlyList<M_Insp_Request>> Insp_Spot_Corrective_Action_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Insp_Spot_CA_ReAssign(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Insp_Spot_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Insp_Request> Insp_Spot_CA_GetById(M_Insp_Request entity);
        public Task<M_Return_Message> Insp_Spot_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity);
        public Task<M_Return_Message> Insp_Spot_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity);
        #endregion
        #region [Safety Violation]
        public Task<IReadOnlyList<M_Insp_Request>> Insp_Safety_Violation_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Safety_Violation> Insp_Safety_Violation_GetById(M_Insp_Safety_Violation entity);
        public Task<M_Return_Message> Insp_Safety_Violation_Create(M_Insp_Safety_Violation entity);
        public Task<M_Return_Message> Insp_Safety_Violation_Add(M_Insp_Safety_Violation entity);
        public Task<M_Return_Message> Insp_Safe_Vio_ApprovalReject(M_Insp_Safety_ViolationReject entity);
        public Task<M_Return_Message> Insp_Safe_Vio_Corrective_Action_Add(List<M_Safety_Vio_Corrective_Action> entity);
        public Task<M_Return_Message> Insp_Safe_Vio_Spot_CA_ApprovalReject(M_Safety_Vio_Corrective_Action entity);
        public Task<M_Insp_Safety_Violation> Insp_Safety_Violation_Add_GetById(M_Insp_Safety_Violation entity);
        public Task<IReadOnlyList<M_Emp_Service_Provider>> Insp_Safety_Vio_Ser_Pro_GetAll(M_Insp_Safety_Violation entity);
        public List<string> UploadImage_Safe(List<IFormFile> file);
        public Task<M_Return_Message> Insp_Safe_Photo_Delete(M_Insp_Safety_Photos entity);
        #endregion
        #region [Safety Violation Corrective Action]
        public Task<IReadOnlyList<M_Insp_Request>> Insp_Safety_Vio_CA_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Safety_Violation> Insp_Safety_Violation_CA_GetById(M_Insp_Safety_Violation entity);
        public Task<M_Return_Message> Insp_SV_CA_Action_Closure_Add(M_Safety_Vio_Corrective_Action entity);
        public Task<M_Return_Message> Insp_SV_CA_ReAssign(M_Safety_Vio_Corrective_Action entity);
        public Task<M_Return_Message> Insp_SV_CA_Photo_Delete(M_Insp_SV_CA_Photo entity);
        #endregion

        #endregion

        #region [Joint Insp]

        #region [Joint Insp Request]
        public Task<IReadOnlyList<M_Insp_Joint_Request>> Insp_Joint_Request_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Insp_Joint_Request_Add(M_Insp_Joint_Request entity);
        public Task<M_Return_Message> Insp_Joint_Request_Update(M_Insp_Joint_Request entity);
        public Task<M_Insp_Joint_Request> Insp_Joint_Request_GetById(M_Insp_Joint_Request entity);
        public Task<IReadOnlyList<Dropdown_Values>> Insp_Joint_Req_Supervisor_GetbyId(Dropdown_Values entity);
        public Task<M_Return_Message> Insp_Joint_Req_ApprovalReject(M_Insp_Joint_Request entity);
        public Task<IReadOnlyList<Dropdown_Values>> Insp_Joint_Zone_based_HSE_Team_Emp(M_Insp_Joint_Request entity);
        #endregion

        #region [Joint Insp Finding]
        public Task<M_Return_Message> Add_Insp_Joint_Finding(M_Insp_Spot_Finding entity);
        public Task<M_Return_Message> Insp_Joint_Find_ApprovalReject(M_Insp_Finding_Approval entity);
        public Task<M_Insp_Spot_Sub_Finding> Insp_Joint_Sub_Find_List_GetById(M_Insp_Spot_Sub_Finding entity);
        public Task<M_Return_Message> Insp_Joint_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity);
        public Task<M_Return_Message> Insp_Joint_Sub_Finding_Delete(M_Insp_Spot_Sub_Finding entity);
        #endregion

        #region [Joint Insp Corrective Action]
        public Task<M_Return_Message> Insp_Joint_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity);
        public Task<IReadOnlyList<M_Insp_Joint_Request>> Insp_Joint_Corrective_Action_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Joint_Request> Insp_Joint_CA_GetById(M_Insp_Joint_Request entity);
        public Task<M_Return_Message> Insp_Joint_CA_ReAssign(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Insp_Joint_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Insp_Joint_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity);
        public Task<M_Return_Message> Insp_Joint_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity);
        #endregion

        #endregion

        #region [Leadership Tour Insp]

        public Task<IReadOnlyList<M_Insp_Leader_Request>> Insp_Leader_Request_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Leader_Request> Insp_Leader_Request_GetById(M_Insp_Leader_Request entity);
        public Task<M_Insp_Leader_Request> Insp_Leader_Zone_based_Dir_Hsse(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Insp_Leader_Request_Add(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Insp_Leader_Request_Update(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Insp_Leader_Req_ApprovalReject(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Add_Insp_Leader_Finding(M_Insp_Spot_Finding entity);
        public Task<M_Return_Message> Insp_Leader_Sub_Find_Photo_Delete(M_Insp_Spot_Find_Sub_Photo entity);
        public Task<M_Return_Message> Insp_Leader_Find_ApprovalReject(M_Insp_Finding_Approval entity);
        public Task<M_Return_Message> Insp_Leader_Corrective_Action_Add(List<M_Insp_Spot_Corrective_Action> entity);
        public Task<IReadOnlyList<M_Insp_Leader_Request>> Insp_Leader_Corrective_Action_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Leader_Request> Insp_Leader_CA_GetById(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Insp_Leader_CA_Action_Closure_Add(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Insp_Leader_CA_ReAssign(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Insp_Leader_CA_Photo_Delete(M_Insp_Spot_CA_Photo entity);
        public Task<M_Return_Message> Insp_Leader_CA_ApprovalReject(M_Insp_Spot_Corrective_Action entity);
        public Task<M_Return_Message> Add_Insp_Leader_WalkIn_Finding(M_Insp_Leader_Request entity);
        public Task<M_Return_Message> Insp_Leader_Find_Photo_Delete(M_Insp_Leader_Finding_Sub_Photo entity);
        #endregion

        #region [Advisory Notice Insp]
        public Task<IReadOnlyList<M_Complaint_Register>> Insp_Complaint_Register_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Complaint_Register> Insp_Complaint_Register_GetById(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Complaint_Register_Add(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Complaint_Service_Request_Add(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Complaint_Assessment_Add(M_Complaint_Register entity);
        public Task<M_Complaint_Register> Insp_Pre_Advisory_Notice_GetById(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Pre_Sub_Advisory_Notice_Report_Add(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Pre_Advisory_Notice_Report_Add(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Pre_Sub_Advisory_Notice_No_Add(M_Complaint_Register entity);
        public Task<M_Return_Message> Insp_Advisory_Notice_Final_Add(M_Complaint_Register entity);
        #endregion

        #region [Create Schedule]
        public Task<IReadOnlyList<Insp_Audit_Building_Model>> Get_All_Building_Load(Insp_Audit_Building_Model entity);
        public Task<IReadOnlyList<Audit_Insp_Emp_List>> Get_All_Audit_Insp_Emp();
        public Task<IReadOnlyList<Insp_Audit_Building_Model>> Get_Building_Base_Sch_Load(Insp_Audit_Building_Model entity);
        public Task<M_Return_Message> Add_Audit_Insp_Sch_Row_Submit(Audit_Insp_Row_Submit entity);
        //public Task<M_Return_Message> Add_Audit_Insp_Sch_Table_Submit(Audit_Insp_Table_List entity);
        public Task<M_Return_Message> Add_Audit_Insp_Sch_Table_Submit(Insp_Sch_Calendar_List entity);
        public Task<Audit_Insp_Row_Submit> Insp_Audit_Edit_Row(Audit_Insp_Row_Submit entity);
        public Task<M_Return_Message> Update_Insp_Sch_Row_Submit(Update_Audit_Insp_Row_Submit entity);
        public Task<IReadOnlyList<Audit_Insp_Emp_List>> LoadAll_Service_Provider(Insp_Audit_Building_Model entity);

        #endregion

        #region [Landscape Inspection]
        public Task<IReadOnlyList<M_Insp_Landscape>> Insp_Landscape_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Landscape> Insp_Landscape_GetById(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_Landscape_Add(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_Landscape_CA_Add(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_Landscape_CA_Closue_Add(Insp_Landscape_Qns entity);

        public Task<IReadOnlyList<M_Insp_Landscape>> Insp_Landscape_CA_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Insp_Landscape_CA_Approval(Insp_Landscape_Qns entity);
        public Task<M_Return_Message> Insp_Landscape_CA_Multi_Reject(Insp_Landscape_Qns entity);
        public Task<M_Return_Message> Insp_Landscape_CA_Final_Approve(M_Insp_Landscape entity);


        public Task<IReadOnlyList<M_Insp_Master_List>> Insp_Land_ZoneWise_All_Emp_GetbyId(M_Insp_Master_List entity);
        public Task<IReadOnlyList<M_Insp_Master_List>> Insp_Land_Service_Provider_Company_GetbyId(M_Insp_Master_List entity);

        #endregion

        #region [SoftService Inspection]
        public Task<IReadOnlyList<M_Insp_Landscape>> Insp_SoftService_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Insp_Landscape> Insp_SoftService_GetById(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_SoftService_Add(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_SoftService_CA_Add(M_Insp_Landscape entity);
        public Task<M_Return_Message> Insp_SoftService_CA_Closue_Add(Insp_Landscape_Qns entity);

        public Task<IReadOnlyList<M_Insp_Landscape>> Insp_SoftService_CA_GetAll(DataTableAjaxPostModel entity);
        public Task<M_Return_Message> Insp_SoftService_CA_Approval(Insp_Landscape_Qns entity);
        public Task<M_Return_Message> Insp_SoftService_CA_Multi_Reject(Insp_Landscape_Qns entity);
        public Task<M_Return_Message> Insp_SoftService_CA_Final_Approve(M_Insp_Landscape entity);

        #endregion
    }
}

