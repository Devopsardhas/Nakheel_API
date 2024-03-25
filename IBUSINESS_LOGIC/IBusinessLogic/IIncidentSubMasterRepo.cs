using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IIncidentSubMasterRepo : IGenericRepo<M_Inc_Mechanism_Injury_Master>
    {
        #region [Mechanism Injury Master]
        public Task<IReadOnlyList<M_Inc_Mechanism_Injury_Master>> Mechanism_Injury_GetAllAsync();
        public Task<M_Return_Message> Mechanism_Injury_AddAsync(M_Inc_Mechanism_Injury_Master entity);
        public Task<M_Return_Message> Mechanism_Injury_UpdateAsync(M_Inc_Mechanism_Injury_Master entity);
        public Task<M_Inc_Mechanism_Injury_Master> Mechanism_Injury_GetByIdAsync(M_Inc_Mechanism_Injury_Master entity);
        public Task<M_Return_Message> Mechanism_Injury_DeleteAsync(M_Inc_Mechanism_Injury_Master entity);
        #endregion

        #region [Agency Injury Master]
        public Task<IReadOnlyList<M_Inc_Agency_Injury_Master>> Agency_Injury_GetAllAsync();
        public Task<M_Return_Message> Agency_Injury_AddAsync(M_Inc_Agency_Injury_Master entity);
        public Task<M_Return_Message> Agency_Injury_UpdateAsync(M_Inc_Agency_Injury_Master entity);
        public Task<M_Inc_Agency_Injury_Master> Agency_Injury_GetByIdAsync(M_Inc_Agency_Injury_Master entity);
        public Task<M_Return_Message> Agency_Injury_DeleteAsync(M_Inc_Agency_Injury_Master entity);
        #endregion

        #region [Health Safety Type Master]
        public Task<IReadOnlyList<M_Inc_Health_Safety_Master>> Health_Safety_GetAllAsync();
        public Task<M_Return_Message> Health_Safety_AddAsync(M_Inc_Health_Safety_Master entity);
        public Task<M_Return_Message> Health_Safety_UpdateAsync(M_Inc_Health_Safety_Master entity);
        public Task<M_Inc_Health_Safety_Master> Health_Safety_GetByIdAsync(M_Inc_Health_Safety_Master entity);
        public Task<M_Return_Message> Health_Safety_DeleteAsync(M_Inc_Health_Safety_Master entity);
        #endregion

        #region [Environment Type Master]
        public Task<IReadOnlyList<M_Inc_Environment_Type_Master>> Environment_Type_GetAllAsync();
        public Task<M_Return_Message> Environment_Type_AddAsync(M_Inc_Environment_Type_Master entity);
        public Task<M_Return_Message> Environment_Type_UpdateAsync(M_Inc_Environment_Type_Master entity);
        public Task<M_Inc_Environment_Type_Master> Environment_Type_GetByIdAsync(M_Inc_Environment_Type_Master entity);
        public Task<M_Return_Message> Environment_Type_DeleteAsync(M_Inc_Environment_Type_Master entity);
        #endregion

        #region [Type Environmental Factor Master]
        public Task<IReadOnlyList<M_Type_Environmental_Factor_Master>> Type_Environmental_Factor_GetAllAsync();
        public Task<M_Return_Message> Type_Environmental_Factor_AddAsync(M_Type_Environmental_Factor_Master entity);
        public Task<M_Return_Message> Type_Environmental_Factor_UpdateAsync(M_Type_Environmental_Factor_Master entity);
        public Task<M_Type_Environmental_Factor_Master> Type_Environmental_Factor_GetByIdAsync(M_Type_Environmental_Factor_Master entity);
        public Task<M_Return_Message> Type_Environmental_Factor_DeleteAsync(M_Type_Environmental_Factor_Master entity);
        #endregion

        #region [Classification Master]
        public Task<IReadOnlyList<M_Inc_Classification_Master>> Classification_GetAllAsync();
        public Task<M_Return_Message> Classification_AddAsync(M_Inc_Classification_Master entity);
        public Task<M_Return_Message> Classification_UpdateAsync(M_Inc_Classification_Master entity);
        public Task<M_Inc_Classification_Master> Classification_GetByIdAsync(M_Inc_Classification_Master entity);
        public Task<M_Return_Message> Classification_DeleteAsync(M_Inc_Classification_Master entity);
        #endregion

        #region [Type Security Master]
        public Task<IReadOnlyList<M_Type_Security_Incident_Master>> Type_Security_GetAllAsync();
        public Task<M_Return_Message> Type_Security_AddAsync(M_Type_Security_Incident_Master entity);
        public Task<M_Return_Message> Type_Security_UpdateAsync(M_Type_Security_Incident_Master entity);
        public Task<M_Type_Security_Incident_Master> Type_Security_GetByIdAsync(M_Type_Security_Incident_Master entity);
        public Task<M_Return_Message> Type_Security_DeleteAsync(M_Type_Security_Incident_Master entity);
        public Task<IReadOnlyList<M_Type_Security_Incident_Master>> Type_Security_GetAllbyClassid(M_Type_Security_Incident_Master entity);
        #endregion

        #region [Vehicle Accident Type Master]
        public Task<IReadOnlyList<M_Vehicle_Accident_Type_Master>> Vehicle_Accident_Type_GetAllAsync();
        public Task<M_Return_Message> Vehicle_Accident_Type_AddAsync(M_Vehicle_Accident_Type_Master entity);
        public Task<M_Return_Message> Vehicle_Accident_Type_UpdateAsync(M_Vehicle_Accident_Type_Master entity);
        public Task<M_Vehicle_Accident_Type_Master> Vehicle_Accident_Type_GetByIdAsync(M_Vehicle_Accident_Type_Master entity);
        public Task<M_Return_Message> Vehicle_Accident_Type_DeleteAsync(M_Vehicle_Accident_Type_Master entity);
        #endregion

        #region [Incident Related Master]
        public Task<IReadOnlyList<M_Incident_Related_Master>> Incident_Related_GetAllAsync();
        public Task<M_Return_Message> Incident_Related_AddAsync(M_Incident_Related_Master entity);
        public Task<M_Return_Message> Incident_Related_UpdateAsync(M_Incident_Related_Master entity);
        public Task<M_Incident_Related_Master> Incident_Related_GetByIdAsync(M_Incident_Related_Master entity);
        public Task<M_Return_Message> Incident_Related_DeleteAsync(M_Incident_Related_Master entity);
        #endregion
    }
}
