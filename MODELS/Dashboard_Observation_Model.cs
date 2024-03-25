using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Dashboard_Observation_Model
    {
        public string? Name { get; set; }
        public string? January { get; set; }
        public string? February { get; set; }
        public string? March { get; set; }
        public string? April { get; set; }
        public string? May { get; set; }
        public string? June { get; set; }
        public string? July { get; set; }
        public string? August { get; set; }
        public string? September { get; set; }
        public string? October { get; set; }
        public string? November { get; set; }
        public string? December { get; set; }
    }
    public class Obs_Dashboard_Count
    {
        public string? Count { get; set; }
        public string? Name { get; set; }
    }
    public class Observation_Dashboard_Count
    {
        public string? Total_Observation { get; set; }
        public string? Total_Open_OBS { get; set; }
        public string? Total_Closed_OBS { get; set; }
        public string? Total_Today_Count { get; set; }
        public string? Total_Approval_Pending { get; set; }
        public string? Total_Action { get; set; }
        public string? Open_Action { get; set; }
        public string? Closed_Action { get; set; }
        public string? OverDue_Action { get; set; }
        public string? Total_Positive { get; set; }
        public string? Total_Negative { get; set; }
        public string? Total_Health_Safety { get; set; }
        public string? Total_Environment { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Employee_Name { get; set; }
        public string? Observation_Time { get; set; }
    }
    public class Observation_Dashboard
    {
        public IReadOnlyList<Dashboard_Observation_Model>? Graph_Obs_Category { get; set; }
        public IReadOnlyList<Dashboard_Observation_Model>? Graph_Obs_Type { get; set; }
        //public IReadOnlyList<Dashboard_Observation_Model>? Graph_Nature_Injury { get; set; }
        public IReadOnlyList<Dashboard_Observation_Model>? Graph_Zone { get; set; }
        //public IReadOnlyList<Dashboard_Observation_Model>? Graph_NCM_Injured { get; set; }
        public IReadOnlyList<Observation_Dashboard_Count>? G_List_Location { get; set; }
        public IReadOnlyList<Observation_Dashboard_Count>? G_List_Building { get; set; }
        public IReadOnlyList<Observation_Dashboard_Count>? G_List_Obs_Type { get; set; }
        //public IReadOnlyList<Observation_Dashboard_Count>? G_List_Inc_Nature_Injury { get; set; }
        public IReadOnlyList<Observation_Dashboard_Count>? G_Cards_Obs_Counts { get; set; }
        public IReadOnlyList<Dashboard_Observation_Model>? Graph_Obs_Company { get; set; }
        public IReadOnlyList<Obs_Dashboard_Count>? Zone_Count_List { get; set; }
        public IReadOnlyList<Dashboard_Observation_Model>? Community_Count_List { get; set; }
        public IReadOnlyList<Obs_Dashboard_Count>? Raised_By_Ser_Prov_List { get; set; }
        public IReadOnlyList<Obs_Dashboard_Count>? Raised_By_Against_Ser_Prov_List { get; set; }
        public IReadOnlyList<Obs_Dashboard_Count>? Zone_Base_Emp_Details { get; set; }
    }
}
