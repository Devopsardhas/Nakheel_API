using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS
{
    public class M_Incident_Sub_Master
    {
    }

    #region [Mechanism Injury Master]
    public class M_Inc_Mechanism_Injury_Master : M_Common_Fields
    {
        public string? Inc_Mechanism_Injury_Id { get; set; }
        public string? Inc_Mechanism_Injury_Name { get; set; }
    }
    #endregion

    #region [Agency Injury Master]
    public class M_Inc_Agency_Injury_Master : M_Common_Fields
    {
        public string? Inc_Agency_Injury_Id { get; set; }
        public string? Inc_Agency_Injury_Name { get; set; }
    }
    #endregion

    #region [Health Safety Type Master]
    public class M_Inc_Health_Safety_Master : M_Common_Fields
    {
        public string? Health_Safety_Type_Id { get; set; }
        public string? Health_Safety_Type_Name { get; set; }
    }
    #endregion

    #region [Environment Type Master]
    public class M_Inc_Environment_Type_Master : M_Common_Fields
    {
        public string? Environment_Type_Id { get; set; }
        public string? Environment_Type_Name { get; set; }
    }
    #endregion

    #region [Type Environmental Factor Master]
    public class M_Type_Environmental_Factor_Master : M_Common_Fields
    {
        public string? Type_Eml_Factor_Id { get; set; }
        public string? Type_Eml_Factor_Name { get; set; }
    }
    #endregion

    #region [Classification Master]
    public class M_Inc_Classification_Master : M_Common_Fields
    {
        public string? Classification_Id { get; set; }
        public string? Classification_Name { get; set; }
    }
    #endregion

    #region [Type Security Incident Master]
    public class M_Type_Security_Incident_Master : M_Common_Fields
    {
        public string? Inc_Type_Security_Id { get; set; }
        public string? Classification_Id { get; set; }
        public string? Classification_Name { get; set; }
        public string? Inc_Type_Security_Name { get; set; }
    }
    #endregion

    #region [Vehicle Accident Cause Type Master]
    public class M_Vehicle_Accident_Type_Master : M_Common_Fields
    {
        public string? Vehicle_Accident_Type_Id { get; set; }

        public string? Vehicle_Accident_Type_Name { get; set; }
    }
    #endregion

    #region [Incident_Related_Master]
    public class M_Incident_Related_Master : M_Common_Fields
    {
        public string? Incident_Related_Id { get; set; }
        public string? Incident_Related_Name { get; set; }
    }
    #endregion
}
