using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Profesore
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();

    public virtual ICollection<MatriculacionesCarrerasProfesore> MatriculacionesCarrerasProfesores { get; set; } = new List<MatriculacionesCarrerasProfesore>();
}
