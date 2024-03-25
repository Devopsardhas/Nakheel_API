using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Insp_Category : M_Insp_Common
    {
        public string? Insp_Category_Id { get; set; }
        public string? Insp_Category_Name { get; set; }
    }
    public class M_Insp_Sub_Category : M_Insp_Common
    {
        public string? Insp_Sub_Category_Id { get; set; }
        public string? Insp_Category_Id { get; set; }
        public string? Insp_Category_Name { get; set; }
        public string? Insp_Sub_Category_Name { get; set; }
    }
    public class M_Insp_Type : M_Insp_Common
    {
        public string? Insp_Type_Id { get; set; }
        public string? Insp_Type_Name { get; set; }
    }
    public class M_Insp_Observation : M_Insp_Common
    {
        public string? Insp_Observation_Id { get; set; }
        public string? Insp_Observation_Name { get; set; }
    }
    public class M_Insp_Topic : M_Insp_Common
    {
        public string? Insp_Topic_Id { get; set; }
        public string? Insp_Type_Id { get; set; }
        public string? Insp_Topic_Name { get; set; }
        public string? Insp_Type_Name { get; set; }
    }
    public class M_Insp_Questionnaires : M_Insp_Common
    {
        public string? Insp_Questionnaires_Id { get; set; }
        public string? Insp_Topic_Id { get; set; }
        public string? Insp_Type_Id { get; set; }
        public string? Insp_Topic_Name { get; set; }
        public string? Insp_Type_Name { get; set; }
        public string? Insp_Questionnaires_Name { get; set; }
    }

    public class M_Insp_Common
    {
        public string? Unique_Id { get; set; }
        public string? Status { get; set; }
        public string? Is_Active { get; set; }
        public string? CreatedDate { get; set; }
        public string? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public string? Remarks { get; set; }
        public string? Description { get; set; }

    }

    #region [Inspection Landscaping Master]
    public class M_Insp_Landscap_Master : M_Insp_Common
    {
        public string? Insp_Landscap_Mas_Id { get; set; }
        public string? Insp_Landscap_Mas_Name { get; set; }
    }
    #endregion

    #region [Inspection Landscaping Sub Master]
    public class M_Insp_Landscap_Sub_Master : M_Insp_Common
    {
        public string? Insp_Landscap_Sub_Mas_Id { get; set; }
        public string? Insp_Landscap_Mas_Id { get; set; }
        public string? Insp_Landscap_Mas_Name { get; set; }
        public string? Insp_Landscap_Sub_Mas_Name { get; set; }
    }
    #endregion
}
