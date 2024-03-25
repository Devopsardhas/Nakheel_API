using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class EMR_Alert_CHK :Common_Tbl
    {
        public string? Alert_Checklist_Id { get; set; }
        public string? Mitigation_Type { get; set; }
        public string? Mitigation_Name { get; set; }
        public string? Check_List { get; set; }

    }
}
