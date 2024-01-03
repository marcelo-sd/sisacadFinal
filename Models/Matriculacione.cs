using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Matriculacione
{
    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public int MatriculacioneId { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Materia? Materia { get; set; }
}
