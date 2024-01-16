using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class MatriculacionesCarrerasEstudiante
{
    public int? EstudianteId { get; set; }

    public int? CarreraId { get; set; }

    public int MaCarreEstId { get; set; }

    public virtual Carrera? Carrera { get; set; }

    public virtual Estudiante? Estudiante { get; set; }
}
