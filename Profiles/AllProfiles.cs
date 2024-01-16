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
            CreateMap<AdministracionDto, Administracion>();
            CreateMap<Administracion, AdministracionDto>();
            CreateMap<CarrerasDto, Carrera>();
            CreateMap<Carrera, CarrerasDto>();
            CreateMap<Materia, MateriasDto>();
            CreateMap<MateriasDto, Materia>();
            CreateMap<Matriculacione, MatriculacionesDto>();
            CreateMap<MatriculacionesDto, Matriculacione>();
            CreateMap<MatriculacionesCarrerasEstudiante, MatriCarreraEstDto>();
            CreateMap<MatriCarreraEstDto, MatriculacionesCarrerasEstudiante>();
            CreateMap < MatriculacionesCarrerasProfesore,MatriCarreProfesorDto>();
            CreateMap< MatriCarreProfesorDto, MatriculacionesCarrerasProfesore > ();



            // Agrega más mapeos según sea necesario
        }
    }
}
