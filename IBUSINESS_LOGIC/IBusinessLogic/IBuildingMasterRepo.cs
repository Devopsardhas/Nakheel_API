using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IBuildingMasterRepo : IGenericRepo<M_Building_Master>
    {
        public Task<M_Return_Message> SubDeleteAsync(M_Building_List entity);

        public Task<IReadOnlyList<M_Building_List>> Get_All_Building_byZone(M_Building_Master entity);

        public Task<M_Return_Message> CheckBuilding_Name(M_Building_List entity);
    }
}
