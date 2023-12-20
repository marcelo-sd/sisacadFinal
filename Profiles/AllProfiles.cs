using SisacadFinal.Models.Dto;
using SisacadFinal.Models;
using AutoMapper;

namespace SisacadFinal.Profiles
{
    public class AllProfiles:Profile
    {
        public AllProfiles()
        {
            CreateMap<Estudiantes, EstudiantesDto>();
            CreateMap<Profesores, ProfesoresDto>();
            CreateMap<ProfesoresDto, Profesores>();
            CreateMap < AdministracionDto, Administracion>();
            CreateMap<Administracion, AdministracionDto>();
            // Agrega más mapeos según sea necesario
        }
    }
}
