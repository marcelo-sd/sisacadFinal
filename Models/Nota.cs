using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Nota
{
    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public int? Nota1 { get; set; }

    public DateTime? FechaNota { get; set; }

    public int? EstadoId { get; set; }

    public virtual EstadosEstudiante? Estado { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Materia? Materia { get; set; }
}
