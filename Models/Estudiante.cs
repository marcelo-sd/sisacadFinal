using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Matriculacione> Matriculaciones { get; set; } = new List<Matriculacione>();
}
