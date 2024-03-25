using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class HSE_BulletinMaster 
    {
        public string? HSE_Bulletin_Id { get; set; }
        public string? HSE_Bulletin_Name { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Unique_Id { get; set; }
        public List<file_Upload_Bulletin>? File_Upl_List { get; set; }
    }
    public class file_Upload_Bulletin 
    {
        public string? Bulletin_File_Upl_Id { get; set; }
        public string? HSE_Bulletin_Id { get; set; }
        public string? File_Path { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }  
    }
}
