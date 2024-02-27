using Domain.Entidades;
using Domain.Interfaces;
using Infraestructure.Data.Repository.ExternalApis.Employee.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repository.ExternalApis.Employee
{
    public class ApiClientEmployeeRepository : IApiClientEmployeeRepository
    {
        private readonly HttpClient _httpClient;

        public ApiClientEmployeeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeEntidad>> GetAllEmployees()
        {
            try
            {
                var response = await _httpClient.GetAsync("http://dummy.restapiexample.com/api/v1/employees");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(content);

                    if (employeeResponse.Data is JArray)
                    {
                        // Si Data es un arreglo, entonces es una lista de empleados
                        return ((JArray)employeeResponse.Data).ToObject<List<EmployeeEntidad>>();
                    }             
                    else
                    {
                        // Manejar otros casos si es necesario
                        return new List<EmployeeEntidad>();
                    }
                }
                else if (response.StatusCode.ToString().Equals("TooManyRequests"))
                {
                    // Si el empleado no se encuentra, retornar null
                    throw new Exception($"Has hecho demasiadas solicitudes seguidas, espera unos minutos.");
                }
                else
                {
                    // Si la respuesta no es exitosa (excepto por Not Found), lanzar una excepción
                    throw new HttpRequestException($"Error al obtener la lista de empleados. Estado de la respuesta: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar la excepción y registrarla
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                // Opcionalmente, lanzar la excepción nuevamente para que la capa superior pueda manejarla
                throw;
            }
        }

        public async Task<EmployeeEntidad> GetEmployeeById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"http://dummy.restapiexample.com/api/v1/employee/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employeeResponse = JsonConvert.DeserializeObject<EmployeeResponse>(content);
                    EmployeeEntidad employeeEntidad = new EmployeeEntidad();
                    try
                    {
                        employeeEntidad = ((JObject)employeeResponse.Data).ToObject<EmployeeEntidad>();
                    }
                    catch (Exception e)
                    {

                        throw new Exception($"No se encontró el usuario con ID {id}.");
                    }
                    
                    return employeeEntidad;

                }
                else if (response.StatusCode.ToString().Equals("TooManyRequests"))
                {
                    // Si el empleado no se encuentra, retornar null
                    throw new Exception($"Has hecho demasiadas solicitudes seguidas, espera unos minutos.");
                }
                else
                {
                    // Si la respuesta no es exitosa (excepto por Not Found), lanzar una excepción
                    throw new HttpRequestException($"Error al obtener el empleado con ID {id}. Estado de la respuesta: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                // Manejar la excepción y registrarla
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                // Opcionalmente, lanzar la excepción nuevamente para que la capa superior pueda manejarla
                throw;
            }
        }
    }
}
