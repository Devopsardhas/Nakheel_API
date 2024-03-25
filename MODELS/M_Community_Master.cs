using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Community_Master : M_Common_Fields
    {
        public string? Community_Master_Id { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Master_Name { get; set; }
    }



    public class SafetyPer_Dash_Card_View_Data
    {
        public string? CSP_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Name { get; set; }
        public string? Company_Name { get; set; }
        public string? Created_by { get; set; }
        public string? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? Permit_Name { get; set; }
        public string? Action { get; set; }
        public string? Priority_Module { get; set; }
    }



    public class Audit_Dash_Card_View_Data
    {
        public string? Audit_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Name { get; set; }
        public string? Company_Name { get; set; }
        public string? Created_by { get; set; }
        public string? CreatedDate { get; set; }
        public string? Status { get; set; }
        public string? Audit_Type_Name { get; set; }
        public string? HSE_Rep_Name { get; set; }
        public string? Action { get; set; }
        public string? Service_Provider_Name { get; set; }
        public string? Initial_Date { get; set; }
    }
}
