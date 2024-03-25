using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Zone_Master: M_Common_Fields
    {
        public string? Zone_Id { get; set; }
        public string? Business_Unit_Id { get; set; }
        public string? Zone_Name { get; set; }
        public string? Is_Community { get; set; }
        public string? Is_Master_Community { get; set; }
    }
}
