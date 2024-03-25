using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Emergency_Param
    {
        public string? Year { get; set; }
        public string? Category_Name { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? From_Date { get; set; }
        public string? To_date { get; set; }
        public string? CreatedBy { get; set; }
        public string? Card_Access_Id { get; set; }
    }
    public class Emergency_Dashboard
    {
        public string? Fire_Planned { get; set; }
        public string? Drowning_Planned { get; set; }
        public string? Elevator_Rescue_Planned { get; set; }
        public string? Spill_Control_Planned { get; set; }
        public string? Fire_Completed { get; set; }
        public string? Elevator_Rescue_Completed { get; set; }
        public string? Spill_Control_Completed { get; set; }
        public string? Drowning_Completed { get; set; }
        public string? Total_Planned { get; set; }
        public string? Total_Completed { get; set; }

    }
    public class Emergency_Drill_Improvement
    {
        public string? Fire_Pending { get; set; }
        public string? Drowning_Pending { get; set; }
        public string? Elevator_Rescue_Pending { get; set; }
        public string? Spill_Control_Pending { get; set; }
        public string? Fire_Completed { get; set; }
        public string? Drowning_Completed { get; set; }
        public string? Elevator_Rescue_Completed { get; set; }
        public string? Spill_Control_Completed { get; set; }
        public string? Total_Pending { get; set; }
        public string? Total_Completed { get; set; }

    }
    public class Emergency_Counts
    {
        public string? Name { get; set; }
        public string? Counts_Triggered { get; set; }
        public string? Counts_completed { get; set; }
    }
    public class Emergency_Escalations_Counts
    {
        public string? Bronze { get; set; }
        public string? Silver { get; set; }
        public string? Gold { get; set; }
        public string? Completed { get; set; }
        public string? Escalate_Bronze_Silver { get; set; }
        public string? Total { get; set; }
    }
    public class Emergency_ERT
    {
        public string? Valid_Fire_Warden { get; set; }
        public string? NotValid_Fire_Warden { get; set; }
        public string? Valid_Fire_Aider { get; set; }
        public string? NotValid_Fire_Aider { get; set; }
        public string? Total_Valid { get; set; }
        public string? Total_Invalid { get; set; }
    }
    public class Emergency_ZoneWiseData
    {
        public string? Name { get; set; }
        public string? Planned_Count { get; set; }
        public string? Completed_Count { get; set; }
    }
    public class EMR_Dashboard
    {
        public IReadOnlyList<Emergency_Dashboard>? Total_Emer_List { get; set; }
        public IReadOnlyList<Emergency_Drill_Improvement>? Total_Emer_Drill_Improve_List { get; set; }
        public IReadOnlyList<Emergency_Counts>? Total_Emer_Mitigation_List { get; set; }
        public IReadOnlyList<Emergency_Escalations_Counts>? Total_Emer_Escalation_List{ get; set; }
        public IReadOnlyList<Emergency_ERT>? Total_ERT_List { get; set; }
        public IReadOnlyList<Emergency_ZoneWiseData>? Total_Zone_Comp_Count { get; set; }
    }
}
