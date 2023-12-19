using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Matriculaciones
{
    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public virtual Estudiantes? Estudiante { get; set; }

    public virtual Materias? Materia { get; set; }
}
