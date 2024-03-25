using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Incident_Master
    {
    }

    #region [M_Inc_Category_Master]
    public class M_Inc_Category_Master : M_Common_Fields
    {
        public string? Inc_Category_Id { get; set; }
        public string? Inc_Category_Name { get; set; }
    }
    #endregion

    #region [M_Inc_Type_Master]
    public class M_Inc_Type_Master : M_Common_Fields
    {
        public string? Inc_Type_Id { get; set; }
        public string? Inc_Cat_Id { get; set; }
        public string? Inc_Type_Name { get; set; }
    }
    #endregion

    #region [Injury Type Master]
    public class M_Inc_Injury_Type_Master : M_Common_Fields
    {
        public string? Injury_Type_Id { get; set; }
        public string? Injury_Type_Name { get; set; }
    }
    #endregion

    #region [Nature Injury Illness Master]
    public class M_Nature_Injury_Illness_Master : M_Common_Fields
    {
        public string? Injury_Illness_Id { get; set; }
        public string? Injury_Illness_Name { get; set; }
    }
    #endregion

    #region [Unsafe Act Master]
    public class M_Inc_Unsafe_Act_Master : M_Common_Fields
    {
        public string? Unsafe_Act_Id { get; set; }
        public string? Unsafe_Act_Name { get; set; }
    }
    #endregion

    #region [Unsafe Condition Master]
    public class M_Inc_Unsafe_Condition_Master : M_Common_Fields
    {
        public string? Unsafe_Condition_Id { get; set; }
        public string? Unsafe_Condition_Name { get; set; }
    }
    #endregion

    #region [Personal Factor Master]
    public class M_Inc_Personal_Factor_Master : M_Common_Fields
    {
        public string? Personal_Factor_Id { get; set; }
        public string? Personal_Factor_Name { get; set; }
    }
    #endregion

    #region [System Factor Master]
    public class M_Inc_System_Factor_Master : M_Common_Fields
    {
        public string? System_Factor_Id { get; set; }
        public string? System_Factor_Name { get; set; }
    }
    #endregion
}
