using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IIncidentMasterRepo : IGenericRepo<M_Inc_Category_Master>
    {
        public Task<IReadOnlyList<M_Inc_Type_Master>> Type_GetAllAsync();
        public Task<M_Return_Message> Type_AddAsync(M_Inc_Type_Master entity);
        public Task<M_Return_Message> Type_UpdateAsync(M_Inc_Type_Master entity);
        public Task<M_Inc_Type_Master> Type_GetByIdAsync(M_Inc_Type_Master entity);
        public Task<M_Return_Message> Type_DeleteAsync(M_Inc_Type_Master entity);
        public Task<IReadOnlyList<M_Inc_Type_Master>> Type_GetByCatIdAsync(M_Inc_Type_Master entity);

        #region [Injury Type Master]
        public Task<IReadOnlyList<M_Inc_Injury_Type_Master>> Injury_Type_GetAllAsync();
        public Task<M_Return_Message> Injury_Type_AddAsync(M_Inc_Injury_Type_Master entity);
        public Task<M_Return_Message> Injury_Type_UpdateAsync(M_Inc_Injury_Type_Master entity);
        public Task<M_Inc_Injury_Type_Master> Injury_Type_GetByIdAsync(M_Inc_Injury_Type_Master entity);
        public Task<M_Return_Message> Injury_Type_DeleteAsync(M_Inc_Injury_Type_Master entity);
        #endregion

        #region [Nature Injury Illness Master]
        public Task<IReadOnlyList<M_Nature_Injury_Illness_Master>> Nature_Injury_GetAllAsync();
        public Task<M_Return_Message> Nature_Injury_AddAsync(M_Nature_Injury_Illness_Master entity);
        public Task<M_Return_Message> Nature_Injury_UpdateAsync(M_Nature_Injury_Illness_Master entity);
        public Task<M_Nature_Injury_Illness_Master> Nature_Injury_GetByIdAsync(M_Nature_Injury_Illness_Master entity);
        public Task<M_Return_Message> Nature_Injury_DeleteAsync(M_Nature_Injury_Illness_Master entity);
        #endregion

        #region [Unsafe Act Master]
        public Task<IReadOnlyList<M_Inc_Unsafe_Act_Master>> Unsafe_Act_GetAllAsync();
        public Task<M_Return_Message> Unsafe_Act_AddAsync(M_Inc_Unsafe_Act_Master entity);
        public Task<M_Return_Message> Unsafe_Act_UpdateAsync(M_Inc_Unsafe_Act_Master entity);
        public Task<M_Inc_Unsafe_Act_Master> Unsafe_Act_GetByIdAsync(M_Inc_Unsafe_Act_Master entity);
        public Task<M_Return_Message> Unsafe_Act_DeleteAsync(M_Inc_Unsafe_Act_Master entity);
        #endregion

        #region [Unsafe Condition Master]
        public Task<IReadOnlyList<M_Inc_Unsafe_Condition_Master>> Unsafe_Condition_GetAllAsync();
        public Task<M_Return_Message> Unsafe_Condition_AddAsync(M_Inc_Unsafe_Condition_Master entity);
        public Task<M_Return_Message> Unsafe_Condition_UpdateAsync(M_Inc_Unsafe_Condition_Master entity);
        public Task<M_Inc_Unsafe_Condition_Master> Unsafe_Condition_GetByIdAsync(M_Inc_Unsafe_Condition_Master entity);
        public Task<M_Return_Message> Unsafe_Condition_DeleteAsync(M_Inc_Unsafe_Condition_Master entity);
        #endregion

        #region [Personal Factor Master]
        public Task<IReadOnlyList<M_Inc_Personal_Factor_Master>> Personal_Factor_GetAllAsync();
        public Task<M_Return_Message> Personal_Factor_AddAsync(M_Inc_Personal_Factor_Master entity);
        public Task<M_Return_Message> Personal_Factor_UpdateAsync(M_Inc_Personal_Factor_Master entity);
        public Task<M_Inc_Personal_Factor_Master> Personal_Factor_GetByIdAsync(M_Inc_Personal_Factor_Master entity);
        public Task<M_Return_Message> Personal_Factor_DeleteAsync(M_Inc_Personal_Factor_Master entity);
        #endregion

        #region [System Factor Master]
        public Task<IReadOnlyList<M_Inc_System_Factor_Master>> System_Factor_GetAllAsync();
        public Task<M_Return_Message> System_Factor_AddAsync(M_Inc_System_Factor_Master entity);
        public Task<M_Return_Message> System_Factor_UpdateAsync(M_Inc_System_Factor_Master entity);
        public Task<M_Inc_System_Factor_Master> System_Factor_GetByIdAsync(M_Inc_System_Factor_Master entity);
        public Task<M_Return_Message> System_Factor_DeleteAsync(M_Inc_System_Factor_Master entity);
        #endregion

    }

}
