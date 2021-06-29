using DepartmentStore.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentStore.API.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly Exercises2Context _context;

        public OperationRepository(Exercises2Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
