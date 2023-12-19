using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Notas
{
    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public int? Nota1 { get; set; }

    public DateTime? FechaNota { get; set; }

    public int? EstadoId { get; set; }

    public virtual EstadosEstudiantes? Estado { get; set; }

    public virtual Estudiantes? Estudiante { get; set; }

    public virtual Materias? Materia { get; set; }
}
