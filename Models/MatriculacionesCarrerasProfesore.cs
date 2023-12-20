using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class MatriculacionesCarrerasProfesore
{
    public int? ProfesorId { get; set; }

    public int? CarreraId { get; set; }

    public virtual Carrera? Carrera { get; set; }

    public virtual Profesore? Profesor { get; set; }
}
