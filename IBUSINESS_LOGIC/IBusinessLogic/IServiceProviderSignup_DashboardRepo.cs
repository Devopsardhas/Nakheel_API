using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IServiceProviderSignup_DashboardRepo : IGenericRepo<Dashboard_Serv_Provi_Model>
    {   
        public Task<ServiceProvider_Model> ServiceProvider_Dashboard(ServiceProviderSignup_Dashboard entity);
        public Task<IReadOnlyList<ServiceProvider_Model>> ServiceProv_Dashboard_Card_View(ServiceProviderSignup_Dashboard entity);

    }
}
