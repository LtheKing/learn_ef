using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.API.Data;

namespace DepartmentStore.API.Repository
{
    public interface IOperationRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
