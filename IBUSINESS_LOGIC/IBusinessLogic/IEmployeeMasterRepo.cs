using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBUSINESS_LOGIC.IBusinessLogic
{
    public interface IEmployeeMasterRepo : IGenericRepo<M_Employee_Management>
    {
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter(M_Employee_Master_Filter entity);
        public Task<M_Employee_Management> Get_Contact_GetByEmpID(M_Employee_Management entity);
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_by_Role(M_Employee_Master_Filter_by_Role entity);
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_by_Zone(M_Employee_Master_Filter_by_Role entity);
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Filter(ServiceProviderSignUp entity);

        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Gold();
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Silver();
        public Task<IReadOnlyList<M_Employee_Management>> Get_Employee_Master_Filter_Bronze(M_Employee_Master_Filter entity);
    }
}
