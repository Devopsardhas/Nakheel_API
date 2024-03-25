using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Accounts
    {
        public string? Employee_Identity_Id { get; set; }
        public string? Employee_Id { get; set; }
        public string? Employee_Type { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Mobile_Number { get; set; }
        public string? Email_Id { get; set; }
        public string? Address { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Role_Id { get; set; }
        public string? Role_Name { get; set; }
        public string? Designation_Id { get; set; }
        public string? Designation_Name { get; set; }
        public string? Department_Id { get; set; }
        public string? Department_Name { get; set; }
        public string? Company_Name { get; set; }
        public string? Unique_Id { get; set; }
        public string? User_Name { get; set; }
        public string? Password { get; set; }
        public string? Email_OTP { get; set; }
        public bool? Status { get; set; }
        public bool? Return_Status { get; set; }
        public string? Status_Code { get; set; }
        public string? Message { get; set; }
        public string? Device_Id { get; set; }
        public string? JWT_Token { get; set; }
        public Employee_Common_Model? Employee_Common_List { get; set; }
    }

    #region [Bell Notification]
    public class BellNotificationModel
    {
        public string? ANS_Notification_ID { get; set; }
        public string? ANS_UserAccessID { get; set; }
        public string? ANS_RequestID { get; set; }
        public string? ANS_UserMobile { get; set; }
        public string? ANS_Notification_Type { get; set; }
        public string? ANS_Notification_Language { get; set; }
        public string? ANS_SendFlag { get; set; }
        public string? ANS_createdtime { get; set; }
        public string? ANS_Modifiedtime { get; set; }
        public string? ANS_Notification_Content { get; set; }
        public string? ANS_Attempts { get; set; }
        public string? ANS_Content_Title { get; set; }
        public string? ANS_Content_Title_Description { get; set; }
        public string? ANS_Content_For { get; set; }
        public string? ANS_Notification_Send_Status { get; set; }
        public string? ANS_Notification_Send_Time { get; set; }
        public string? ANS_Notification_Attempts { get; set; }
        public string? ANS_Event_From { get; set; }
        public string? ANS_Read_Status { get; set; }
        public string? ANS_Notification_Set_Id { get; set; }
        public string? ANS_Appointment_Category { get; set; }
        public string? Login_User_Id { get; set; }
        public string? Hyper_Link { get; set; }
        public string? Hyper_Link2 { get; set; }
        public string? Designation { get; set; }
        public string? Notification_Date { get; set; }

    }
    #endregion
    public class Employee_Common_Model
    {
        public List<Employee_Sub_Model>? Emp_Community_List { get; set; }
        public List<Employee_Sub_Model>? Emp_Master_Community_List { get; set; }
        public List<Employee_Sub_Model>? Emp_Building_List { get; set; }

    }
    public class Employee_Sub_Model
    {
        public string? Identity_Id { set; get; }
        public string? Common_Id { set; get; }
        public string? Common_Name { set; get; }
        public string? Employee_Id { set; get; }
        public string? Employee_Identity_Id { set; get; }
    }

    #region [MOBILE LOGIN]
    public class Mobile_User_Login
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Desi_Id { get; set; }
        public string? FireBase_Id { get; set; }
        public string? Role_Id { get; set; }
    }

    public class Get_Notification_Count
    {
        public string? Role_Id { get; set; }
        public string? User_Id { get; set; }
    }

    public class Get_Notification_Count_List
    {
        public string? Notification_Count { get; set; }
    }

    public class Update_Read_Notification
    {
        public string? Notification_Id { get; set; }
    }

    public class Get_Notification_Details
    {
        public string? USM_USERNAME { get; set; }
        public string? USM_PASSWORD { get; set; }
        public string? ULS_FIREBASEID { get; set; }
        public string? NUD_APPLICATIONID { get; set; }
        public string? USM_APP_API_KEY { get; set; }
        public string? NUD_SENDERID { get; set; }
        public string? MSG_MESSAGE { get; set; }
        public string? Type { get; set; }
        public string? MSG_DEFAULT_TITLE { get; set; }
        public string? NOTIFICATION_COUNT { get; set; }
        public string? NOTIFICATION_ID { get; set; }
        public string? VISIT_TYPE { get; set; }
        public string? NAME_DISCRIPTION { get; set; }
    }


    public class Get_Notification_Count_Details
    {
        public string? NOTIFICATION_ID { get; set; }
        public string? LOGIN_USER_ID { get; set; }
        public string? NOTIFICATION_CONTENT { get; set; }
        public string? NOTIFICATION_TITLE { get; set; }
        public string? READ_STATUS { get; set; }
        public string? ANS_Event_From { get; set; }
        public string? ANS_Appointment_Category { get; set; }
    }

    public class GET_TOKEN
    {
        public string? ACCESS_TOKEN { get; set; }

    }

    public class Get_User_Details
    {
        public string? EMP_ID { get; set; }
        public string? MESSAGE { get; set; }
        public string? LANG_ID { get; set; }
        public string? DISPLAY_NAME { get; set; }
        public string? DESI_NAME { get; set; }
        public string? EMP_USERNAME { get; set; }
        public string? EMP_PASSWORD { get; set; }
        public string? EMP_STATUS { get; set; }
        public string? STATUS { get; set; }
        public string? EMP_EMAIL { get; set; }
        public string? EXPIRED_DATE { get; set; }

    }
    public class TokenJwt
    {
        public string? Token { set; get; }
        public string? User_Name { set; get; }
    }
    #endregion


    #region [SERVICE_PROVIDER_SIGNUP]

    public class ServiceProviderSignUp : M_Common_Fields
    {
        public string? SignUp_Id { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Company_Name { get; set; }
        public string? Inc_Business_Unit_Type { get; set; }
        public string? Manager_Incharge { get; set; }
        public string? Designation { get; set; }
        public string? Mobile_No { get; set; }
        public string? Official_Email_Id { get; set; }
        public string? Purchase_Order_Number { get; set; }
        public string? DMS_Number { get; set; }
        public string? HSE_Officer { get; set; }
        public string? HSE_Officer_Email { get; set; }
        public string? HSE_Officer_Mobile_Number { get; set; }
        public string? Contract_Start_Date { get; set; }
        public string? Contract_End_Date { get; set; }
        public string? W_Name_Position { get; set; } //Project Title
        public string? W_Contact { get; set; } // Contract Type
        public string? W_Email_Id { get; set; }
        public string? W_Work_Description { get; set; }
        public string? W_Specific_Requirements { get; set; }
        public string? W_From_Date { get; set; }
        public string? W_To_date { get; set; }
        public string? W_Night_Schedule { get; set; }
        public string? W_Permit_Validity { get; set; }
        public string? W_Scope_of_work { get; set; }
        public string? Company_Id { get; set; }
        public string? ApproveRes_1 { get; set; }
        public string? ApproveRes_2 { get; set; }
        public List<L_M_Work_Superviosor_List>? L_M_Work_Superviosor_List { get; set; }
        public List<L_M_RequiredAttachments_List>? L_M_RequiredAttachments_List { get; set; }
        public List<L_M_Major_HSE_Risk_List>? L_M_Major_HSE_Risk_List { get; set; }
        public List<L_M_Service_Provider_Update_History>? L_M_Service_Provider_Update_History { get; set; }
        public List<L_M_Building_List>? L_M_Building_List { get; set; }
    }

    public class L_M_Building_List
    {
        public string? M_Service_Provider_Bu_Id { get; set; }
        public string? SignUp_Id { get; set; }
        public string? Building_Id { get; set; }
    }
    public class L_M_Work_Superviosor_List
    {
        public string? Work_Superviosor_Id { get; set; }
        public string? SignUp_Id { get; set; }
        public string? Name_Position { get; set; }
        public string? Contact { get; set; }
        public string? Email_Id { get; set; }
    }
    public class L_M_RequiredAttachments_List
    {
        public string? RequiredDcouments_Id { get; set; }
        public string? SignUp_Id { get; set; }
        public string? Document_Type { get; set; }
        public string? Required_File_Path { get; set; }
        public string? Expiry_Date { get; set; }
        public string? Description { get; set; }
    }

    public class L_M_Major_HSE_Risk_List
    {
        public string? Major_HSE_Risk_Id { get; set; }
        public string? SignUp_Id { get; set; }
        public string? Major_HSE_Work_Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
    }

    public class L_M_Service_Provider_Update_History
    {
        public string? Service_Provider_History_Id { get; set; }
        public string? SignUp_Id { get; set; }
        public string? Emp_Id { get; set; }
        public string? Role_Id { get; set; }
        public string? Updated_DateTime { get; set; }
        public string? Status { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? Remarks4 { get; set; }
        public string? Remarks5 { get; set; }
    }

    public class Company_Details : M_Common_Fields
    {
        public string? Company_Id { get; set; }
        public string? Company_Name { get; set; }
        public string? Company_MobileNo { get; set; }
        public string? Company_Email { get; set; }
    }

    public class Upcoming_Activity_Dashboard
    {
        public string? Activity_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Module_Name { get; set; }
        public string? Hyper_Link { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
        public string? Schedule_Type_Id { get; set; }
        public string? Status { get; set; }
        public string? Role_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Color_Code { get; set; }
    }

    public class Upcoming_Activity_Dashboard_Team_Task
    {
        public string? Activity_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Module_Name { get; set; }
        public string? Hyper_Link { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
        public string? Schedule_Type_Id { get; set; }
        public string? Status { get; set; }
        public string? Role_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Color_Code { get; set; }
        //public string? ANS_Event_From { get; set; }
        //public string? ANS_Appointment_Category { get; set; }
    }

    public class Upcoming_Activity_Dashboard_My_Task
    {
        public string? Activity_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Module_Name { get; set; }
        public string? Hyper_Link { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
        public string? Schedule_Type_Id { get; set; }
        public string? Status { get; set; }
        public string? Role_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Color_Code { get; set; }
        //public string? ANS_Event_From { get; set; }
        //public string? ANS_Appointment_Category { get; set; }
    }

    public class Upcoming_Activity_Dashboard_Emer_Escal
    {
        public string? Activity_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Module_Name { get; set; }
        public string? Hyper_Link { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
        public string? Schedule_Type_Id { get; set; }
        public string? Status { get; set; }
        public string? Role_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Color_Code { get; set; }
    }

    public class Emergency_SubZone_Alert_Master_Dashboard
    {
        public string? Emergency_SubZoneAlert_Id { get; set; }
        public string? Emergency_Alert_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? Emergency_Category_Id { get; set; }
        public string? Description { get; set; }
        public string? Emergency_Date { get; set; }
    }

    public class Hse_Bulletin
    {
        public string? HSE_Bulletin_Id { get; set; }
        public string? HSE_Bulletin_Name { get; set; }
        public string? File_Path { get; set; }
    }
    public class MainDashBoards_Model
    {
        public string? CreatedBy { get; set; }
        public string? Zone_Id { get; set; }
        public List<Upcoming_Activity_Dashboard>? L_M_Upcoming_Activity { get; set; }
        public List<Notification_Dashboard_Count>? L_M_Notification_Dashboard_Count { get; set; }
        public List<Upcoming_Activity_Dashboard_Team_Task>? L_M_Upcoming_Activity_Team { get; set; }
        public List<Upcoming_Activity_Dashboard_My_Task>? L_M_Upcoming_Activity_My { get; set; }
        public List<Upcoming_Activity_Dashboard_Emer_Escal>? L_M_Upcoming_Activity_Emer_Escal { get; set; }
        public List<Emergency_SubZone_Alert_Master_Dashboard>? L_M_Emergency_SubZone_Alert_Master_Dashboard { get; set; }
        public Notification_Dashboard_Count? Main_Dash_Insp_Count { get; set; }
        public List<Hse_Bulletin>? L_Hse_Bulletins { get; set; }
    }

    #endregion
}
