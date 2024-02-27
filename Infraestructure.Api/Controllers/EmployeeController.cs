using Microsoft.AspNetCore.Mvc;
using Aplication.Dto;
using Aplication.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infraestructure.Api.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Infraestructure.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase, IEmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            var employees = await _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employee)
        {
            // Implementar lógica para agregar un nuevo empleado
            // El cuerpo de la solicitud contendrá los datos del nuevo empleado
            return NoContent();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto employee)
        {
            // Implementar lógica para actualizar un empleado existente por su ID
            // El cuerpo de la solicitud contendrá los datos actualizados del empleado
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Implementar lógica para eliminar un empleado existente por su ID
            return NoContent();
        }
    }
}
