using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisacadFinal.Models;

public partial class Estudiantes
{
    [Required]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
