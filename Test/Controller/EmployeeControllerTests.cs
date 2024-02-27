using Aplication.Dto;
using Aplication.Services.Interfaces;
using Infraestructure.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Controller
{
    public class EmployeeControllerTests
    {
        [Fact]
        public async Task Get_ReturnsListOfEmployees()
        {
            // Arrange
            var mockEmployeeService = new Mock<IEmployeeService>();
            var expectedEmployees = new List<EmployeeDto>
            {
                new EmployeeDto { id = 1, name = "John Doe", age = 30 ,salary = 123000,urlImg = "none"},
                new EmployeeDto { id = 2, name = "Jane Smith", age = 33 ,salary = 222000,urlImg = "none" }
                // Agrega más empleados según sea necesario para tu prueba
            };
            mockEmployeeService.Setup(service => service.GetAllEmployees()).ReturnsAsync(expectedEmployees);
            var controller = new EmployeeController(mockEmployeeService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<EmployeeDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var actualEmployees = Assert.IsAssignableFrom<IEnumerable<EmployeeDto>>(okResult.Value);
            Assert.Equal(expectedEmployees.Count, actualEmployees.Count());
            // Aquí puedes agregar más aserciones según sea necesario
        }
    }
}
