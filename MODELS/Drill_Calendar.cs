using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Drill_Calendar : Common_EMR
    {
        public string? Drill_Calendar_ID { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? Initial_Date { get; set; }
        public string? Frequency { get; set; }
        public string? HSE_Officer { get; set; }
        public string? Commander { get; set; }
        public string? Service_Provider { get; set; }
        public string? Drill_Type_ID { get; set; }
    }

    public class Common_EMR
    {
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? Created_By { get; set; }
        public string? Created_Date { get; set; }
        public string? Updated_By { get; set; }
        public string? Updated_Date { get; set; }
        public string? Remarks { get; set; }
        public string? Unique_ID { get; set; }
        public string? Building_Name { get; set; }
        public string? Zone { get; set; }
        public string? Community { get; set; }
        public string? Drill_Type { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
    }

    public class Common_Tbl
    {
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? Created_By { get; set; }
        public string? Created_Date { get; set; }
        public string? Updated_By { get; set; }
        public string? Updated_Date { get; set; }
        public string? Remarks { get; set; }
        public string? Unique_ID { get; set; }
      
    }
    public class Drill_Calendar_Param
    {
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Drill_Type_ID { get; set; }
        public string? Action { get; set; }
    }


    public class Get_Drill_Calendar
    {
        public List<Drill_Calendar>? Drill_SCH{ get; set;}
        public List<Dropdown_Values>? HSE_Team{ get; set;}
        public List<Dropdown_Values>? Commander_Team { get; set; }
        public List<Dropdown_Values>? SP_Team { get; set; }
    }
}
