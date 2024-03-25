using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Building_Master : M_Common_Fields
    {
        public string? Building_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Community_Master_Name { get; set; }
        public List<M_Building_List>? L_M_Building { get; set; }
    }

    public class M_Building_List
    {
        public string? Sub_Building_Id { get; set; }
        public string? Building_Id { get; set; }
        public string? Building_Name { get; set; }
        public string? Building_Description { get; set; }
        public string? CreatedBy { get; set; }
    }
}
