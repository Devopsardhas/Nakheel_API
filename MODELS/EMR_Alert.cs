using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class EMR_Alert : Common_Alert
    {
        public string? EMR_Alert_ID { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Sub_Building_Id { get; set; }
        public string? Mitigation_Type { get; set; }
        public List<Alert_Spot>? _Spots { get; set; }
        public List<EMR_Reject>? Reject { get; set; }

    }

    public class EMR_Reject
    {
        public string? Alert_Rej_Id { get; set; }
        public string? EMR_Alert_ID { get; set; }
        public string? Reason { get; set; }
        public string? Rejected_By { get; set; }
        public string? Status { get; set; }
        public string? Hot_Spot_Id { get; set; }
        public string? Address { get; set; }
        public string? Created_Date { get; set; }
    }

    public class Alert_Spot : Common_Tbl
    {
        public string? Hot_Spot_Id { get; set; }
        public string? EMR_Alert_ID { get; set; }
        public string? Alert_Task_Id { get; set; }
        public string? Address { get; set; }
        public string? Exact_Loc { get; set; }
        public string? Reason { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Service_Provider { get; set; }

    }

    public class Common_Alert
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
        public string? RecordsTotal { get; set; }
        public string? RecordsFiltered { get; set; }
    }

    public class Drill_Alert_Param
    {
        public string? EMR_Alert_ID { get; set; }
        public string? Created_By { get; set; }
        public string? Building_ID { get; set; }
        public string? Mitigation_ID { get; set; }
        public string? Status { get; set; }
    }
}
