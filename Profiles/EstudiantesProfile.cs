using SisacadFinal.Models.Dto;
using SisacadFinal.Models;
using AutoMapper;

namespace SisacadFinal.Profiles
{
    public class EstudiantesProfile : Profile
    {
        public EstudiantesProfile()
        {
            CreateMap<Estudiantes, EstudiantesDto>();
            // Agrega más mapeos según sea necesario
        }
    }
}
