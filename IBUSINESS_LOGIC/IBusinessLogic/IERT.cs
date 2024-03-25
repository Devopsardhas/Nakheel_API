using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IERT : IGenericRepo<EMR_Team>
    {
        Task<Get_EMR_Team> GetAllAsync(ERT_Param _Param);
    }
}
