using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class MatriculacionesCarrerasEstudiante
{
    public int? EstudianteId { get; set; }

    public int? CarreraId { get; set; }

    public virtual Carreras? Carrera { get; set; }

    public virtual Estudiantes? Estudiante { get; set; }
}
