using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SisacadFinal.Models;

public partial class Profesores
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Materias> Materia { get; set; } = new List<Materias>();
}
