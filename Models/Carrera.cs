using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Carrera
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<MatriculacionesCarrerasEstudiante> MatriculacionesCarrerasEstudiantes { get; set; } = new List<MatriculacionesCarrerasEstudiante>();

    public virtual ICollection<MatriculacionesCarrerasProfesore> MatriculacionesCarrerasProfesores { get; set; } = new List<MatriculacionesCarrerasProfesore>();
}
