using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentStore.API.DTOs
{
    public class EmployeeToPresent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public int? AssignedBranchId { get; set; }
        public int? DeptId { get; set; }
        public int? SuperiorEmpId { get; set; }
    }
}
