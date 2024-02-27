using Domain.Entidades;
using Infraestructure.Data.Repository.ExternalApis.Employee;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test.Repository
{
    public class ApiClientEmployeeRepositoryTests
    {
        [Fact]
        public async Task GetAllEmployees_Success_ReturnsEmployees()
        {
            // Arrange
            var httpClientMock = new Mock<HttpClient>();
            var expectedEmployees = new List<EmployeeEntidad>
        {
            new EmployeeEntidad { id = 1, employee_name = "John Doe", employee_salary = 50000, employee_age = 30 ,profile_image = "none"},
            new EmployeeEntidad { id = 2, employee_name = "Jane Smith", employee_salary = 60000, employee_age = 35,profile_image = "none" }
        };
            var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedEmployees))
            };
            httpClientMock
                .Setup(client => client.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(httpResponseMessage);
            var repository = new ApiClientEmployeeRepository(httpClientMock.Object);

            // Act
            var result = await repository.GetAllEmployees();

            // Assert
            Assert.Equal(expectedEmployees.Count, result.Count);
            // Add more assertions as needed
        }
    }
}
