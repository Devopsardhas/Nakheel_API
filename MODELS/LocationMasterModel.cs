using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Location_Master : M_Common_Fields
    {
        public string? Location_Id { get; set; }
        public string? Zone_Id { get; set; }
        public string? Community_Id { get; set; }
        public string? Building_Id { get;set; }
        public string? Location_Name { get; set; }
        public string? Community_Master_Name { get; set; }
        public List<M_Location_List>? L_M_Location { get; set; }
    }

    public class M_Location_List
    {
        public string? Sub_Location_Id { get; set; }
        public string? Location_Id { get; set; }
        public string? Sub_Location_Name { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
    }
}

