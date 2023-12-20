using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Materia
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Ano { get; set; }

    public int? ProfesorId { get; set; }

    public int? IdCarrera { get; set; }

    public virtual Carrera? IdCarreraNavigation { get; set; }

    public virtual Profesore? Profesor { get; set; }
}
