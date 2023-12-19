using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Administracion
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Rol { get; set; }

    public int? Dni { get; set; }

    public string? Correo { get; set; }

    public string? Contrasena { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
