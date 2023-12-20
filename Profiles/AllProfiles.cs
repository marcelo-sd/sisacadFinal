using SisacadFinal.Models.Dto;
using SisacadFinal.Models;
using AutoMapper;

namespace SisacadFinal.Profiles
{
    public class AllProfiles:Profile
    {
        public AllProfiles()
        {
            CreateMap<Estudiante, EstudiantesDto>();
            CreateMap<Profesore, ProfesoresDto>();
            CreateMap<ProfesoresDto, Profesore>();
            CreateMap < AdministracionDto, Administracion>();
            CreateMap<Administracion, AdministracionDto>();
            CreateMap<CarrerasDto, Carrera>();
            CreateMap<Carrera, CarrerasDto>();

            // Agrega más mapeos según sea necesario
        }
    }
}
