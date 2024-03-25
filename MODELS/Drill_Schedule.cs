using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MODELS
{
    public class Drill_Schedule : Common_EMR
    {
        public string? Drill_Schedule_ID { get; set; }
        public string? Drill_Calendar_ID { get; set; }
        public string? Drill_Type_ID { get; set; }
        public string? Commander { get; set; }
        public string? Service_Provider { get; set; }
    }

    public class Drill_Schedule_Param
    {
        public string? Drill_Schedule_ID { get; set; }
        public string? Created_By { get; set; }
        public string? Status { get; set; }

    }

    public class Drill_Sch_Assignee
    {
        public List<Dropdown_Values>? ServiceProviders { get; set; }
        public List<Dropdown_Values>? Commanders { get; set; }

    }
    public class Drill_Fire : Drill_Files
    {
        public string? Drill_Schedule_ID { get; set; }
        public string? Fire_Drill_ID { get; set; }
        public string? Weather_Condition { get; set; }
        public string? Start_Time { get; set; }
        public string? End_Time { get; set; }
        public string? LP_Reporting { get; set; }
        public string? PLP_Reporting { get; set; }
        public string? Total_Participants { get; set; }
        public string? Assembly_Point { get; set; }
        public string? Total_FW { get; set; }
        public string? TT_Evacuation { get; set; }
        public string? Extinguish_Fire { get; set; }
        public string? Smoke_Mgmt { get; set; }
        public string? ERT_Mgmt { get; set; }
        public string? Rating { get; set; }
        public string? Drill_Comments { get; set; }
    }

    public class Drill_CommonFRM : Drill_Files
    {
        public string? Drill_Schedule_ID { get; set; }
        public string? Common_ID { get; set; }
        public string? Dril_Loc { get; set; }
        public string? Rating { get; set; }
        public string? Drill_Comments { get; set; }
        public string? Common_Ques { get; set; }
        public string? ERT { get; set; }
        public string? Security_Res { get; set; }
        public string? Drill_Type_ID { get; set; }
    }

    public class Get_All_DrillSCH
    {
        public Drill_Schedule? Schedule { get; set; }
        public Drill_Fire? _Fire { get; set; }
        public Drill_Fire_Obsr? Drill_Obsr { get; set; }
        public Drill_CommonFRM? Drill_Common { get; set; }
        public IReadOnlyCollection<Dropdown_Values>? Access { get; set; }
        public List<Improvement_Act>? TotalActions { get; set; }
        public List<Dropdown_Values>? ServiceProvider { get; set; }
        public List<Dropdown_Values>? HseTeam { get; set; }
        public List<Appr_History>? Histories { get; set; }
        public List<Drill_REJ>? Rej { get; set; }
    }

    public class Drill_REJ
    {
        public string? IMP_CA_Reject_Id { get; set; }
        public string? Drill_CRR_ID { get; set; }
        public string? Reject_Reason { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }
        public string? Drill_Schedule_ID { get; set; }
        public string? Date { get; set; }
        public string? Reject_By { get; set; }
    }
    public class Drill_Access
    {
        public string? Value { get; set; }
        public string? Text { get; set; }
        public string? Remarks { get; set; }
    }
    public class Drill_Access1
    {
        public List<Dropdown_Values>? Zone_Supervisor { get; set; }
        public List<Dropdown_Values>? Zone_Manager { get; set; }
        public List<Dropdown_Values>? Commander { get; set; }
        public List<Dropdown_Values>? ServiceProviders { get; set; }
        public List<Dropdown_Values>? Created_By { get; set; }
    }

    public class Improvement_Act : Common_Tbl
    {
        public string? Drill_CRR_ID { get; set; }
        public string? Drill_Schedule_ID { get; set; }
        public string? Action_Des { get; set; }
        public string? Assignee_Id { get; set; }
        public string? Target_Date { get; set; }
        public string? Corrective_Action { get; set; }
        public string? Photo_Path { get; set; }
        public string? Close_On_Spot { get; set; }
        public string? Assign_Type { get; set; }

    }

    public class Drill_Fire_Obsr : Drill_Files
    {
        public string? Fire_Drill_OBS_ID { get; set; }
        public string? Drill_Schedule_ID { get; set; }
        public string? First_Sound { get; set; }
        public string? First_Occupant { get; set; }
        public string? Last_Occupant { get; set; }
        public string? Ocuupant_Nature { get; set; }
        public string? Life_Safety_Equip { get; set; }
        public string? Lift_Status { get; set; }
        public string? Pantry_Status { get; set; }
        public string? Evac_Process { get; set; }


    }

    public class Drill_Files : Common_Tbl
    {
        public List<Improvement_Act>? _Acts { get; set; }
        public List<Drill_Photos>? Drill_Photos { get; set; }
        public List<Drill_Videos>? Drill_Vedios { get; set; }
    }

    public class Drill_Action_Param
    {
        public string? Drill_Schedule_ID { get; set; }
        public string? Created_By { get; set; }
        public string? Status { get; set; }
        public List<Improvement_Act>? _Acts { get; set; }

    }

    public class Appr_History
    {
        public string? Appr_History_Id { get; set; }
        public string? Role { get; set; }
        public string? Drill_Schedule_ID { get; set; }
        public string? Action_Date { get; set; }
        public string? Nxt_Action_Date { get; set; }
        public string? Action_Des { get; set; }
        public string? Action_Done_By { get; set; }
        public string? Nxt_Action_Done_By { get; set; }
        public string? Status { get; set; }
    }

   
}
