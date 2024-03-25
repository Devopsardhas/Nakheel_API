using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmergency_Dashboard : IGenericRepo<Emergency_Param>
    {
        public Task<EMR_Dashboard> Emergency_Dashboard(Emergency_Param entity);

    }
}
