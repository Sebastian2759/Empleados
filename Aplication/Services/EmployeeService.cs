using Aplication.Dto;
using Aplication.Mapper.Employee.Interfaces;
using Aplication.Services.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApiClientEmployeeRepository _repositorioEmployee;
        private readonly IMapperEmployee _mapperEmployee;
        public EmployeeService(IApiClientEmployeeRepository repositorioEmployee, IMapperEmployee mapperEmployee)
        {
            _repositorioEmployee = repositorioEmployee;
            _mapperEmployee = mapperEmployee;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var employees = _mapperEmployee.EntidadesToDtos(await _repositorioEmployee.GetAllEmployees());
            if (employees.Count > 0)
            {
                return employees = employees.Select(e =>
                {
                    e.salaryAnual = e.salary * 12;
                    return e;
                }).ToList();
            }
            return employees;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {   
            var employee = _mapperEmployee.EntidadToDto(await _repositorioEmployee.GetEmployeeById(id));
            if (employee != null)
            {
                employee.salaryAnual = employee.salary * 12;
                return employee;
            }
            return new EmployeeDto();
        }

    }
}
