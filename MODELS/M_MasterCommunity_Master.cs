using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_MasterCommunity_Master : M_Common_Fields
    {
        public string? MasterCommunity_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_Master_Name { get; set; }
        public List<M_MasterCommunity_List>? L_M_MasterCommunity_List { get; set; }
    }

    public class M_MasterCommunity_List
    {
        public string? Sub_MasterCommunity_Id { get; set; }
        public string? MasterCommunity_Id { get; set; }
        public string? MasterCommunity_Name { get; set; }
        public string? MasterCommunity_Description { get; set; }
        public string? CreatedBy { get; set; }
    }



    public class Level_Master
    {
        public string? LevelM_Id { get; set; }
        public string? LevelM_Name { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
    }


    public class Crisis_Master
    {
        public string? Crisis_Master_Id { get; set; }
        public string? LevelM_Id { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public List<Crisis_SubEmp_Master>? L_Crisis_SubEmp_Master_Details { get; set; }
    }

    public class Crisis_SubEmp_Master
    {
        public string? Crisis_Sub_Id { get; set; }
        public string? Crisis_Master_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? LevelM_Id { get; set; }
        public string? Emp_Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
    }

    public class Crisis_Team_Master
    {
        public string? Crisis_Master_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public List<Crisis_Emp_Team_Master>? L_M_Crisis_Team_Details { get; set; }
    }

    public class Crisis_Emp_Team_Master
    {
        public string? Crisis_Emp_Team_Master_Id { get; set; }
        public string? Crisis_Master_Id { get; set; }
        public string? Level_Id { get; set; }
        public string? Role { get; set; }
        public string? Position { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? A_Role { get; set; }
        public string? A_Position { get; set; }
        public string? A_Name { get; set; }
        public string? A_Mobile { get; set; }
        public string? CreatedBy { get; set; }
        public string? Remarks { get; set; }
    }

    public class Emergency_Category_Master
    {
        public string? Emergency_Category_Id { get; set; }
        public string? Emergency_Category_Name { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
    }


    public class Service_Provider_Scope_of_Work
    {
        public string? Scope_of_Work_Id { get; set; }
        public string? Scope_of_Work { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
    }

    public class ERT_Team_Details
    {
        public string? ERT_Id { get; set; }
        public string? Employee_Name { get; set; }
        public string? Gender { get; set; }
        public string? Langauge { get; set; }
        public string? Nationality { get; set; }
        public string? Age { get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public string? Role { get; set; }
        public string? Type { get; set; }
        public string? Certificate_Date { get; set; }
        public string? Exprity_Date { get; set; }
        public string? Staff_Status { get; set; }
        public string? Training_Status { get; set; }
        public string? Business_Unit { get; set; }
        public string? Building_No { get; set; }
        public string? Floor_No { get; set; }
        public string? Declaration_Completed { get; set; }
        public string? ERT_Upload_File { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? Is_Active { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Unique_Id { get; set; }
        public string? Card_Id { get; set; }
    }



    public class ERT_Team_Details_Master
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
    }
}
