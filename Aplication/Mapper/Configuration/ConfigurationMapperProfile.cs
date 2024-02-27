using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mapper.Configuration
{
    public class ConfigurationMapperProfile : Profile
    {
        public ConfigurationMapperProfile()
        {
            //Creacion de mapeos de entidades a dtos y viceversa

            CreateMap<Domain.Entidades.EmployeeEntidad, Aplication.Dto.EmployeeDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.employee_name))
                .ForMember(dest => dest.urlImg, opt => opt.MapFrom(src => src.profile_image))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.employee_name))
                .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.employee_age))
                .ForMember(dest => dest.salary, opt => opt.MapFrom(src => src.employee_salary))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id)).ReverseMap();
        }
    }
}
