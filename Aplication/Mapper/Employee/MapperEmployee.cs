using Aplication.Dto;
using Aplication.Mapper.Employee.Interfaces;
using AutoMapper;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Employee
{
    public class MapperEmployee : IMapperEmployee
    {
        private readonly IMapper _mapper;
        public MapperEmployee(IMapper mapper)
        {
            _mapper = mapper;
        }
        //Metodos de mapeo de entidades a dtos y viceversa


        public List<EmployeeEntidad> DtosToEntidades(List<EmployeeDto> employeeDtos)
        {
           return _mapper.Map<List<EmployeeEntidad>>(employeeDtos);
        }

        public EmployeeEntidad DtoToEntidad(EmployeeDto employeeDto)
        {
           return _mapper.Map<EmployeeEntidad>(employeeDto);
        }

        public EmployeeDto EntidadToDto(EmployeeEntidad employeeEntidad)
        {
            return _mapper.Map<EmployeeDto>(employeeEntidad);
        }

        public List<EmployeeDto> EntidadesToDtos(List<EmployeeEntidad> employeeEntidades)
        {
           return _mapper.Map<List<EmployeeDto>>(employeeEntidades);
        }
    }
}
