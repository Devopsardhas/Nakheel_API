using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MODELS
{
    public class Trigger : Common_TRG
    {
        public string? Trigger_ID { get; set; }
        public string? Zone_Id { get; set; }
        public string? Mitigation_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? REF_NO { get; set; }
        public List<TRG_Building_List>? _Building_Lists { get; set; }
        public List<ChecklistMap>? ChecklistMaps { get; set; }
        public List<Alert_Spot>? _Spots { get; set; }
        public List<TRIG_Reject>? _Reject { get; set; }
    }

    public class TRG_Building_List
    {
        public string? Building_Name { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? Service_Provider { get; set; }
        public string? Alert_Task_Id { get; set; }
        public string? Reason { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
    }
    public class Get_Trigger
    {
        public Trigger? trigger { get; set; }
        public List<TRG_Building_List>? _Building_Lists { get; set; }
    }

    public class Trigger_Param
    {
        public string? Trigger_ID { get; set; }
        public string? Alert_Task_Id { get; set; }
        public string? Hot_Spot_Id { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? Created_By { get; set; }
        public string? Status { get; set; }
    }

    public class Common_TRG
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
        public string? Mitigation { get; set; }
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
    }

    public class TRIG_Assignee : Common_TRG
    {
        public string? Alert_Task_Id { get; set; }
        public string? Trigger_ID { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? Service_Provider { get; set; }
    }

    public class ChecklistMap : Common_Tbl
    {
        public string? Chk_Map_Id { get; set; }
        public string? Hot_Spot_Id { get; set; }
        public string? Alert_Checklist_Id { get; set; }
        public string? Alert_Task_Id { get; set; }
        public string? Action_Taken { get; set; }
        public string? File_Path { get; set; }
    }

    public class TRIG_Reject
    {
        public string? Alert_Trig_Rej_Id { get; set; }
        public string? Alert_Task_Id { get; set; }
        public string? Trigger_ID { get; set; }
        public string? Reason { get; set; }
        public string? Rejected_By { get; set; }
        public string? Hot_Spot_Id { get; set; }
        public string? Status { get; set; }
        public string? Created_Date { get; set; }
    }

}
