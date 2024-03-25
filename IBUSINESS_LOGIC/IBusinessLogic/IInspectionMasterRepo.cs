using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IInspectionMasterRepo : IGenericRepo<M_Insp_Category>
    {
        #region [Insp Sub Category Master]
        public Task<IReadOnlyList<M_Insp_Sub_Category>> Insp_Sub_Cat_GetAll();
        public Task<IReadOnlyList<M_Insp_Sub_Category>> Insp_Sub_Cat_GetById(M_Insp_Sub_Category entity);
        public Task<M_Return_Message> Insp_Sub_Cat_Add(List<M_Insp_Sub_Category> entity);
        public Task<M_Return_Message> Insp_Sub_Cat_Delete(M_Insp_Sub_Category entity);
        #endregion

        #region [Insp Type Master]
        public Task<IReadOnlyList<M_Insp_Type>> Insp_Type_GetAll();
        public Task<M_Return_Message> Insp_Type_Add(M_Insp_Type entity);
        public Task<M_Return_Message> Insp_Type_Update(M_Insp_Type entity);
        public Task<M_Insp_Type> Insp_Type_GetById(M_Insp_Type entity);
        public Task<M_Return_Message> Insp_Type_Delete(M_Insp_Type entity);
        #endregion

        #region [Insp Observation Master]
        public Task<IReadOnlyList<M_Insp_Observation>> Insp_Observation_GetAll();
        public Task<M_Return_Message> Insp_Observation_Add(M_Insp_Observation entity);
        public Task<M_Return_Message> Insp_Observation_Update(M_Insp_Observation entity);
        public Task<M_Insp_Observation> Insp_Observation_GetById(M_Insp_Observation entity);
        public Task<M_Return_Message> Insp_Observation_Delete(M_Insp_Observation entity);
        #endregion

        #region [Insp Topic Master]
        public Task<IReadOnlyList<M_Insp_Topic>> Insp_Topic_GetAll();
        public Task<IReadOnlyList<M_Insp_Topic>> Insp_Topic_GetById(M_Insp_Topic entity);
        public Task<M_Return_Message> Insp_Topic_Add(List<M_Insp_Topic> entity);
        public Task<M_Return_Message> Insp_Topic_Delete(M_Insp_Topic entity);
        #endregion

        #region [Insp Questionnaires Master]
        public Task<IReadOnlyList<M_Insp_Questionnaires>> Insp_Questionnaires_GetAll();
        public Task<IReadOnlyList<M_Insp_Questionnaires>> Insp_Questionnaires_GetById(M_Insp_Questionnaires entity);
        public Task<M_Return_Message> Insp_Questionnaires_Add(List<M_Insp_Questionnaires> entity);
        public Task<M_Return_Message> Insp_Questionnaires_Delete(M_Insp_Questionnaires entity);
        #endregion

        #region [Inspection Landscaping Master]
        public Task<IReadOnlyList<M_Insp_Landscap_Master>> Insp_Landscap_Mas_GetAll();
        public Task<M_Return_Message> Insp_Landscap_Mas_Add(M_Insp_Landscap_Master entity);
        public Task<M_Return_Message> Insp_Landscap_Mas_Update(M_Insp_Landscap_Master entity);
        public Task<M_Insp_Landscap_Master> Insp_Landscap_Mas_GetById(M_Insp_Landscap_Master entity);
        public Task<M_Return_Message> Insp_Landscap_Mas_Delete(M_Insp_Landscap_Master entity);

        #endregion

        #region [Inspection Landscaping Sub Master]
        public Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_Landscap_Sub_Cat_GetAll();
        public Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_Landscap_Sub_Cat_GetById(M_Insp_Landscap_Sub_Master entity);
        public Task<M_Return_Message> Insp_Landscap_Sub_Cat_Add(List<M_Insp_Landscap_Sub_Master> entity);
        public Task<M_Return_Message> Insp_Landscap_Sub_Cat_Delete(M_Insp_Landscap_Sub_Master entity);

        #endregion

        #region [Inspection SoftService Master]
        public Task<IReadOnlyList<M_Insp_Landscap_Master>> Insp_SoftService_Mas_GetAll();
        public Task<M_Return_Message> Insp_SoftService_Mas_Add(M_Insp_Landscap_Master entity);
        public Task<M_Return_Message> Insp_SoftService_Mas_Update(M_Insp_Landscap_Master entity);
        public Task<M_Insp_Landscap_Master> Insp_SoftService_Mas_GetById(M_Insp_Landscap_Master entity);
        public Task<M_Return_Message> Insp_SoftService_Mas_Delete(M_Insp_Landscap_Master entity);

        #endregion

        #region [Inspection SoftService Sub Master]
        public Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_SoftService_Sub_Cat_GetAll();
        public Task<IReadOnlyList<M_Insp_Landscap_Sub_Master>> Insp_SoftService_Sub_Cat_GetById(M_Insp_Landscap_Sub_Master entity);
        public Task<M_Return_Message> Insp_SoftService_Sub_Cat_Add(List<M_Insp_Landscap_Sub_Master> entity);
        public Task<M_Return_Message> Insp_SoftService_Sub_Cat_Delete(M_Insp_Landscap_Sub_Master entity);

        #endregion
    }
}
