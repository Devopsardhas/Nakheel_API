using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    internal class M_Emergency
    {
    }
    public class M_Emer_Mitigation_Add
    {
        public string? Emer_Miti_Id { get; set; }
        public string? Emer_Company { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_name { get; set; }
        public string? Building_Id { get; set; }
        public string? Building_Name { get; set; }
        public string? Emer_Description { get; set; }
        public string? Emer_Risk { get; set; }
        public string? Emer_Situation { get; set; }
        public string? Emer_Evidence { get; set; }
        public string? Emer_level { get; set; }
        public string? Unique_Id { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy_Name { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
        public string? Role_Id { get; set; }
        public string? Remarks { get; set; }
        public string? Remarks1 { get; set; }
        public string? Remarks2 { get; set; }
        public string? Remarks3 { get; set; }
        public string? Emer_Title { get; set; }
        public List<M_Emer_Miti_Photos>? L_Emer_Miti_Photos { get; set; }
        public List<Crisis_SubEmp_Master>? L_Crisis_SubEmp_Master_Details { get; set; }
        public List<Emergency_Mitigation_Update_History>? L_Crisis_SubEmp_Update_History { get; set; }
    }
    public class M_Emer_Miti_Photos : M_Common_Fields
    {
        public string? Emer_Miti_Photo_Id { get; set; }
        public string? Emer_Miti_Id { get; set; }
        public string? Photo_File_Path { get; set; }
    }


    public class Emergency_Mitigation_Update_History
    {
        public string? History_Id { get; set; }
        public string? Em_Mit_Id { get; set; }
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

    public class Emergency_Alert_Master
    {
        public string? Emergency_Alert_Id { get; set; }
        public string? Emergency_Category_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Description { get; set; }
        public string? Emergency_Date { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public List<Emergency_SubZone_Alert_Master>? L_Emergency_SubZone_Alert_Master { get; set; }
    }
    public class Emergency_SubZone_Alert_Master
    {
        public string? Emergency_SubZoneAlert_Id { get; set; }
        public string? Emergency_Alert_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
