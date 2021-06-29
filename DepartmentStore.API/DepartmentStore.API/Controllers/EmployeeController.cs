using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.API.Data;
using DepartmentStore.API.Repository;
using AutoMapper;
using DepartmentStore.API.DTOs;

namespace DepartmentStore.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IOperationRepository _repo;
        private readonly IMapper _mapper;
        public EmployeeController(IOperationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("TestEmployee")]
        public IActionResult Index()
        {
            return Ok("Employee Succeed");
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEmployees()
        {
            var employeeFromRepo = await _repo.GetEmployees();
            var employeeToReturn = _mapper.Map<IEnumerable<EmployeeToPresent>>(employeeFromRepo);

            return Ok(employeeToReturn);
        }
    }
}
