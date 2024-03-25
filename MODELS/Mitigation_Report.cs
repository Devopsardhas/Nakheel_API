using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class Mitigation_Report : Common_Tbl
    {
        public string? Alert_Report_Id { get; set; }
        public string? Trigger_ID { get; set; }
        public string? REF_NO { get; set; }
        public string? Area { get; set; }
        public string? Start_Time { get; set; }
        public string? End_Time { get; set; }
        public string? Resp_Time { get; set; }
        public string? Duration { get; set; }
        public string? Pumps_Deployed { get; set; }
        public string? Pump_OP_Duration { get; set; }
        public string? Tankers_Deployed { get; set; }
        public string? No_Trips { get; set; }
        public string? Clear_Time { get; set; }
        public string? Deployed_SP { get; set; }
        public string? Deployed_NCM { get; set; }
        public string? Mitigation_Cost { get; set; }
        public string? Gauge_Reading { get; set; }
        public string? Total_Pumps { get; set; }
        public string? Total_Tankers { get; set; }
        public string? Total_No_Trips { get; set; }
        public string? Total_Deployed_SP { get; set; }
        public string? Total_Deployed_NCM { get; set; }
        public string? Total_Mitigation_Cost { get; set; }
        public List<Report_File>? _Files { get; set; }
    }

    public class Report_File : Common_Tbl
    {
        public string? Report_File_Id { get; set; }
        public string? Alert_Report_Id { get; set; }
        public string? File_Name { get; set; }
        public string? File_Path { get; set; }
        public string? File_Size { get; set; }
        public string? File_Type { get; set; }

    }
    public class Mitigation_Param
    {
        public string? Zone_Id { get; set; }
        public string? Year { get; set; }
        public string? REF_NO { get; set; }
        public string? From_Date { get; set; }
        public string? To_Date { get; set; }
    }

}
