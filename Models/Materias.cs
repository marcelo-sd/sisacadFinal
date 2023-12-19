using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Materias
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Ano { get; set; }

    public int? ProfesorId { get; set; }

    public virtual Profesores? Profesor { get; set; }
}
