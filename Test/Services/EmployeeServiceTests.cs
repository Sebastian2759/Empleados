using Aplication.Dto;
using Aplication.Mapper.Employee.Interfaces;
using Aplication.Services;
using Domain.Entidades;
using Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Services
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllEmployees_ReturnsListOfEmployees()
        {
            // Arrange
            var mockRepo = new Mock<IApiClientEmployeeRepository>();
            var mockMapper = new Mock<IMapperEmployee>();

            // Simulate the repository returning a list of employees
            mockRepo.Setup(repo => repo.GetAllEmployees()).ReturnsAsync(new List<EmployeeEntidad>());

            // Simulate the mapper returning a list of employee DTOs
            mockMapper.Setup(mapper => mapper.EntidadesToDtos(It.IsAny<List<EmployeeEntidad>>()))
                      .Returns(new List<EmployeeDto>());

            var service = new EmployeeService(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await service.GetAllEmployees();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<EmployeeDto>>(result);
        }

        [Fact]
        public async Task GetEmployeeById_ReturnsEmployeeDto()
        {
            // Arrange
            var mockRepo = new Mock<IApiClientEmployeeRepository>();
            var mockMapper = new Mock<IMapperEmployee>();

            // Simulate the repository returning an employee
            mockRepo.Setup(repo => repo.GetEmployeeById(It.IsAny<int>())).ReturnsAsync(new EmployeeEntidad());

            // Simulate the mapper returning an employee DTO
            mockMapper.Setup(mapper => mapper.EntidadToDto(It.IsAny<EmployeeEntidad>()))
                      .Returns(new EmployeeDto());

            var service = new EmployeeService(mockRepo.Object, mockMapper.Object);

            // Act
            var result = await service.GetEmployeeById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EmployeeDto>(result);
        }
    }
}
