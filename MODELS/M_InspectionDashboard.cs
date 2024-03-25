using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_InspectionDashboard
    {
        public Insp_Dash_Management? Insp_Dash_Management_Count { get; set; }
        public Insp_Dash_Types_Insp? Insp_Dash_Types_Insp_Count { get; set; }
        public List<Insp_Dash_ZoneWise_Graph>? Insp_Dash_ZoneWise_Count { get; set; }
        public List<Insp_Dash_ZoneWise>? Insp_Dash_CommunityWise_Count { get; set; }
        public List<Insp_Dash_ZoneWise>? Insp_Dash_CategoryWise_Count { get; set; }
        public List<Insp_Dash_ZoneWise>? Insp_Dash_SubCategoryWise_Count { get; set; }
        public Insp_Dash_Management? Insp_Dash_ServiceProvider_Count { get; set; }
        public List<Insp_Dash_Management_Graph>? Insp_Dash_Management_Graph { get; set; }
        public List<Insp_Dash_Management_Year_Graph>? Insp_Dash_Management_Year_Graph { get; set; }
        public Insp_Dash_Management? Insp_Dash_Mgmt_Schedule_Count { get; set; }
        public Insp_Dash_Management? Insp_Dash_Mgmt_WalkIn_Count { get; set; }
        public List<Insp_Dash_ZoneWise_Graph>? Insp_Dash_HSE_Officer_Count { get; set; }
    }
    public class Insp_Dash_Management_Year_Graph
    {
        public string? Name { get; set; }
        public string? Year2030 { get; set; }
        public string? Year2029 { get; set; }
        public string? Year2028 { get; set; }
        public string? Year2027 { get; set; }
        public string? Year2026 { get; set; }
        public string? Year2025 { get; set; }
        public string? Year2024 { get; set; }
        public string? Year2023 { get; set; }
        public string? Year2022 { get; set; }
        public string? Year2021 { get; set; }
        public string? Year2020 { get; set; }
        public string? Year2019 { get; set; }
    }
    public class Insp_Dash_Management_Graph
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

    public class Insp_Dash_Management
    {
        public string? Total_Insp_Persentage { get; set; }
        public string? Total_Insp_Count { get; set; }
        public string? Planned_Count { get; set; }
        public string? Closed_Count { get; set; }
        public string? Total_Actions_Count { get; set; }
        public string? Action_Open_Count { get; set; }
        public string? Action_Closed_Count { get; set; }
        public string? Action_Overdue_Count { get; set; }
        public string? Insp_Completed_Count { get; set; }
        public string? Findings_Overdue_Count { get; set; }
    }
    public class Insp_Dash_Types_Insp
    {
        public string? Spot_Count { get; set; }
        public string? Joint_Count { get; set; }
        public string? Leadership_Count { get; set; }
        public string? Handover_Count { get; set; }
        public string? Health_Safety_Count { get; set; }
        public string? Service_Provider_Count { get; set; }
        public string? Fire_Safety_Count { get; set; }
    }
    public class Insp_Dash_ZoneWise
    {
        public string? Value { get; set; }
        public string? Name { get; set; }
        public string? Id { get; set; }
    }
    public class Insp_Dash_ZoneWise_Graph
    {
        public string? Zone_Name { get; set; }
        public string? HSE_Officer { get; set; }
        public string? Planned { get; set; }
        public string? Completed { get; set; }
    }

    public class Insp_DashboardParam
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
    }


    public class Insp_Dash_Card_View_Data
    {
        public string? Corrective_Action_Id { get; set; }
        public string? Insp_Request_Id { get; set; }
        public string? Unique_Id { get; set; }
        public string? Business_Unit_Name { get; set; }
        public string? Zone_Name { get; set; }
        public string? Community_Name { get; set; }
        public string? Building_Name { get; set; }
        public string? Inspection_Date { get; set; }
        public string? Reported_By { get; set; }
        public string? Status { get; set; }
        public string? Module_Name { get; set; }
        public string? Priority_Module { get; set; }
        public string? Assignee_Type { get; set; }
        public string? Responsibility_To { get; set; }
        public string? Target_Date { get; set; }
        public string? Assign_Action_HSE { get; set; }
        public string? Action { get; set; }
    }
}
