using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IAccountsRepo
    {
        public Task<M_Accounts> User_Verification(M_Accounts entity);
        //public Task<M_Return_Message> LocalUser_Verification(M_Accounts User_Name);
        public Task<IReadOnlyList<BellNotificationModel>> GetWebBellNotification(BellNotificationModel entity);
        public Task<M_Return_Message> UpdateWebBellReadStatus(BellNotificationModel entity);
        public Task<Get_User_Details> User_Login(Mobile_User_Login entity);
        public Task<Get_Notification_Count_List> Get_Notification_Count(Get_Notification_Count entity);
        public Task<IReadOnlyList<Get_Notification_Count_Details>> Get_Notification_Count_List(Get_Notification_Count entity);
        public Task<IReadOnlyList<Get_Notification_Details>> Get_Master_Notification_Details_Alert(Mobile_User_Login entity);
        public Task<M_Return_Message> USP_Update_Notification_Send(string NOTIFICATION_ID);
        public Task<M_Return_Message> Update_Read_Notification(Update_Read_Notification entity);
        public Task<M_Return_Message> Add_Service_Provider_Sign_Up(ServiceProviderSignUp entity);
        public Task<IReadOnlyList<ServiceProviderSignUp>> SP_Sign_Up_Users_List(ServiceProviderSignUp entity);
        public Task<ServiceProviderSignUp> Get_Service_Provider_Sign_Up(ServiceProviderSignUp entity);
        public Task<M_Return_Message> UpdateSignUpStatus(ServiceProviderSignUp entity);
        public Task<ServiceProviderSignUp> Update_Service_Provider_Sign_Up(ServiceProviderSignUp entity);
        public Task<M_Return_Message> UpdateDetails_Service_Provider_Sign_Up(ServiceProviderSignUp entity);
        public Task<M_Return_Message> Email_Id_Check_Duilpcate(M_Accounts entity);
        public Task<M_Return_Message> Add_Company_Details(Company_Details entity);
        public Task<Company_Details> Get_Company_Details(Company_Details entity);
        public Task<IReadOnlyList<ServiceProviderSignUp>> Get_Service_Provider_DetailsbyId(ServiceProviderSignUp entity);
        public Task<M_Return_Message> UpdateService_Provider_Id(ServiceProviderSignUp entity);
        public Task<IReadOnlyList<ServiceProviderSignUp>> Get_SP_Sign_Up_Users_List(ServiceProviderSignUp entity);
        public Task<MainDashBoards_Model> Get_MainDashBoards_Details(MainDashBoards_Model entity);
        public Task<M_Return_Message> Company_Name_Check_Duilpcate(M_Accounts entity);
        public Task<M_Return_Message> Purchase_Order_Number_Check_Duilpcate(M_Accounts entity);
        public Task<IReadOnlyList<ServiceProviderSignUp>> SP_Sign_Up_Users_List_Email(ServiceProviderSignUp entity);
        public Task<IReadOnlyList<ServiceProvider_Model>> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity);
        public Task<M_Return_Message> UpdateDelete_Service_Provider_Sign_Up(ServiceProviderSignUp entity);
        public Task<M_Return_Message> User_Mobile_Logout(M_Accounts entity);
        public Task<M_Return_Message> Update_SignUp_Document_Submission(L_M_RequiredAttachments_List entity);

    }
}
