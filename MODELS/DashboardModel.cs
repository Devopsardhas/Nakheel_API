using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class DashboardModel
    {
    }
    public class DashboardGraphModel
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
    public class DashboardParam
    {
        public string? Year { get; set; }
        public string? CreatedBy { get; set; }
        public string? Business_Unit_ID { get; set; }
        public string? Zone_ID { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_ID { get; set; }
        public string? Master_Community_Id { get; set; }
        public string? From_Date { get; set; }
        public string? To_date { get; set; }
        public string? Category_Name { get; set; }
        public string? Category_Type { get; set; }
        public string? Employee_Type { get; set; }
        public string? Remarks { get; set; }
        public string? Card_Access { get; set; }
        public string? If_HSE_Team { get; set; }
        public string? HSE_Team_Id { get; set; }
    }
    public class Incident_Dashboard_New
    {
        public IReadOnlyList<Inc_Serverit_Count>? Total_INC_Ser_Count { get; set; }
        public IReadOnlyList<Incident_Management_Count>? Total_Inc_Manage_Count{ get; set; }
        public IReadOnlyList<DashboardGraphModel>? Injury_NonInjury_List { get; set; }
        public IReadOnlyList<Inc_TotalCount_YearWise>? Classification_List { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Recordable_NonRecord_List { get; set; }
        public IReadOnlyList<Inc_Zone_Count>? Zone_Count_List { get; set; }
        public IReadOnlyList<Inc_Category_Count>? Categroy_Count_List { get; set; }
        public IReadOnlyList<Inc_RelationTo_NCM>? Related_NCM_List { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Incident_Statistics_List { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Incident_Trend_Statistics_List { get; set; }
        //public IReadOnlyList<DashboardGraphModel>? Incident_Trend_Statistics_Yearwise { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Incident_Type_List{ get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Total_Count_List { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Total_Incident_Count_List { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Zone_List_Dropdown { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Commnuity_List_Dropdown { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? Buidling_List_Dropdown { get; set; }
        public IReadOnlyList<Inc_TotalCount_YearWise>? Total_Inc_count_YearList { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Community_List { get; set; }
        public IReadOnlyList<Inc_TotalCount_YearWise>? Incident_TotalCount { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Inc_Sev_Month_List { get; set; }
    }
    public class Incident_Management_Count
    {
        public string? Total_Inc_Count { get; set; }
        public string? Injury_Count { get; set; }
        public string? Non_Injury_Count { get; set; }
        public string? Fire { get; set; }
        public string? Vehicle_Accident { get; set; }
        public string? Property_Damage { get; set; }
        public string? Total_ManDays_Lost { get; set; }
        public string? Total_Man_Hours { get; set; }
        public string? Fatality { get; set; }
        public string? NearMiss { get; set; }

    }

    public class Inc_Serverit_Count
    {
        public string? Incident_Rate { get; set; }
        public string? Severity_Rate { get; set; }
        public string? Injury_Incident_Rate { get; set; }
        public string? Total_Daily_Manpower { get; set; }
    }
    public class Inc_TotalCount_YearWise
    {
        public string? Name { get; set; }
        public string? Year { get; set; }
        public string? Total { get; set; }
    }

    public class Inc_Zone_Count
    {
        public string? Zone_Name { get; set; }
        public string? Zone_Count { get; set; }
    }
    public class Inc_Category_Count
    {
        public string? Category_Name { get; set; }
        public string? Category_Count { get; set; }
    }

    public class Inc_RelationTo_NCM
    {
        public string? Direct_Employee { get; set; }
        public string? Contractor { get; set; }
        public string? Work_Visitor { get; set; }
        public string? Resident { get; set; }
        public string? NA { get; set; }
    }
    public class Incident_Dashboard
    {
        public IReadOnlyList<DashboardGraphModel>? Graph_Inc_Category { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Graph_Inc_Type { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Graph_Nature_Injury { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Graph_Zone { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Graph_NCM_Injured { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? G_List_Location { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? G_List_Building { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? G_List_Inc_Type { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? G_List_Inc_Nature_Injury { get; set; }
        public IReadOnlyList<Incident_Dashboard_Count>? G_Cards_Inc_Counts { get; set; }
        public IReadOnlyList<DashboardGraphModel>? Graph_Inc_Company { get; set; }
    }
    public class Incident_Dashboard_Count
    {
        public string? Total_Inc_Count { get; set; }
        public string? Today_Inc_Count { get; set; }
        public string? Inc_Closed_Count { get; set; }
        public string? Inc_Open_Count { get; set; }
        public string? Inc_Approval_Pending { get; set; }
        public string? Inc_Man_Day_Lost { get; set; }
        public string? Inc_Total_Action { get; set; }
        public string? Inc_Open_Action { get; set; }
        public string? Inc_Closed_Action { get; set; }
        public string? Inc_OverDue_Action { get; set; }
        public string? Inc_Injured_Employee { get; set; }
        public string? Inc_Injured_Contractor { get; set; }
        public string? Inc_High_Potential { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Employee_Name { get; set; }
        public string? Incident_Time { get; set; }
    }

    public class Dashboard_Table_View_Param
    {
        public string? Year { get; set; }
        public string? CreatedBy { get; set; }
        public string? Zone_ID { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_ID { get; set; }
        public string? From_Date { get; set; }
        public string? To_date { get; set; }
        //public string? Controller_Type { get; set; }
        //public string? Category_Type { get; set; }
        //public string? Three_Month { get; set; }
        public string? Category_Name { get; set; }
        public string? Card_View_Id { get; set; }
        public string? Employee_Type { get; set; }
    }
}
