using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IZoneMasterRepo: IGenericRepo<M_Zone_Master>
    {
        public Task<IReadOnlyList<M_Zone_Master>> GetALL_Zone_by_Is_Community();
        public Task<IReadOnlyList<M_Zone_Master>> GetALL_Zone_by_Is_MasterCommunity();
    }
}
