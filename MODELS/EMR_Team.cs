using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class EMR_Team : Common_EMR
    {
        public string? ERT_ID { get; set; }
        public string? EMR_Type { get; set; }
        public string? Mem_ID { get; set; }
        public string? Role { get; set; }
        public string? Sub_Building_ID { get; set; }
        public string? Training_Status { get; set; }
        public string? Certificate_Date { get; set; }
        public string? Expiry_Date { get; set; }
        public string? Certificate_Path { get; set; }
        public string? Contact { get; set; }
        public string? Dept { get; set; }
        public string? Mem_Type { get; set; }
       
    }

    public class ERT_Param
    {
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Action { get; set; }
    }

    public class Get_EMR_Team
    {
        public List<EMR_Team>? EMR_Teams { get; set; }
        public List<Dropdown_Values>? Team_Members { get; set; }

    }
}
