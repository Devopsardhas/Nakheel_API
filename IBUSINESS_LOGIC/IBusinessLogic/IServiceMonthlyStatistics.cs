using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IServiceMonthlyStatistics : IGenericRepo<ServiceMonthlyStatistics>
    {
        public Task<IReadOnlyList<ServiceMonthlyStatistics>> Get_Service_Monthly_Statics(ServiceMonthlyStatistics entity);
        public Task<M_Return_Message> Add_Service_Monthly_Statics(ServiceMonthlyStatistics entity);
        public Task<ServiceMonthlyStatistics> Edit_Service_Monthly_Statics(ServiceMonthlyStatistics entity);
        public Task<IReadOnlyList<ServiceMonthlyStatistics>> Get_Service_Monthly_Statics_Filter(ServiceMonthlyStatistics entity);
        public Task<M_Return_Message> Service_Monthly_Statics_Approve(ServiceMonthlyStatistics entity);
        public Task<M_Return_Message> Service_Monthly_Statics_Reject(Reject_Reason entity);

    }
}
