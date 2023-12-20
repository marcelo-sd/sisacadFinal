using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SisacadFinal.Models;

public partial class Carrera
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    [JsonIgnore]
    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
