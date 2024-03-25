using System;
using System.Collections.Generic;
using System.Text;

namespace MODELS
{
    public class M_Return_Message
    {
        public string? Status_Code { get; set; }
        public bool? Status { get; set; }
        public string? Message { get; set; }
        public string? Return_1 { get; set; }
        public string? Return_2 { get; set; }
        public string? Return_3 { get; set; }
        public string? Return_Status { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
    }
    public class M_Common_Fields
    {
        public string? Action { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Role_Id { get; set; }
        public string? Module_Name { get; set; }
        public string? Hyper_Link { get; set; }
        public string? Schedule_Type_Id { get; set; }
        public byte[]? Mail_Remarks { get; set; }
    }
    public class M_Common_Dropdown_Fields
    {
        public string? Value { get; set; }
        public string? Text { get; set; }
    }
    public static class M_Return_Status_Text
    {
        public static string DELETED = "Deleted Successfully";
        public static string UPDATED = "Updated Successfully";
        public static string NODATA = "No records found";
        public static string ERROR = "Error during fetching records";
        public static string ALREADYEXIST = "Record Already Exist";
        public static string LISTSUCCESS = "List of data";
        public static string INVALIDTRANSID = "Invalid TransID";
        public static string INVALIDCREDENTIAL = "Invalid UserName or Password";
        public static string LOGINSUCCESS = "Login Successfully";
        public static string ADDED_SUCCESS = "Added Successfully";
        public static string PASSWORDFORGOT = "New Password Created Successfully! Please Check Your Email / SMS!";
        public static string PASSWORDCHANGE = "Password Changed Successfully!";
        public static string PASSWORDRESET = "Password Reseted Successfully for ";
        public static string CHILDDATA = "This data Currently using another Screen So you don't have Permission to delete This data";
        public static string REDEEMCODE = "Your RedeemCode Created Successfully! Please Check Your SMS!";
        public static string UpdateFaild = "Updated Failed!";
        public static string FILEEXIST = "File Already Exist!";
        public static string NODATAORERROR = "No data or Error during fetching record";
        public static string OTPPASSWORD = "OTP Created Successfully! Please Check Your Email / SMS!";
        public static string NOTREGISITERNO = "Your Number is not Registered in Portal";
        public static string NOTOTP = "Mobile Number or OTP not Match";
        public static string INVALID_JSON = "Invalid JSON";
        public static string SUCCESS = "Added Successfully";
        public static string FAILED = "Failed";
        public static string APPROVED = "Approved Successfully";
        public static string REJECTED = "Rejected Successfully";
        public static string EMAILEXIST = "Email Already Exist!";
        public static string ALLEXIST = "Already Exist!";

    }
    public static class M_Return_Status_Code
    {
        public static string OK = "200";
        public static string INVALID_JSON = "400";
        public static string FAILED = "500";
        public static string NODATA = "404";
        public static string ISDATA = "100";
        public static bool TRUE = true;
        public static bool FALSE = false;
    }
}