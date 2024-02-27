using Aplication.Dto;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Employee.Interfaces
{
    public interface IMapperEmployee
    {
        EmployeeEntidad DtoToEntidad(EmployeeDto employeeDto);
        EmployeeDto EntidadToDto(EmployeeEntidad employeeEntidad);

        List<EmployeeEntidad> DtosToEntidades(List<EmployeeDto> employeeDtos);
        List<EmployeeDto> EntidadesToDtos(List<EmployeeEntidad>  employeeEntidades);
    }
}
