using Aplication.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Api.Controllers.Interfaces
{
    public interface IEmployeeController
    {

        Task<ActionResult<IEnumerable<EmployeeDto>>> Get();

        Task<ActionResult<EmployeeDto>> Get(int id);

        Task<IActionResult> Post([FromBody] EmployeeDto employee);

        Task<IActionResult> Put(int id, [FromBody] EmployeeDto employee);

        Task<IActionResult> Delete(int id);
    }
}
