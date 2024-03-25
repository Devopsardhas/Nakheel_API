using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface ICommunityMasterRepo: IGenericRepo<M_Community_Master>
    {
        public Task<IReadOnlyList<M_Community_Master>> GetAllCommunityByZone(M_Community_Master entity);

        //public Task<IReadOnlyList<M_Community_Master>> GetAllMasterCommunityByZone(M_Community_Master entity);
    }
}
