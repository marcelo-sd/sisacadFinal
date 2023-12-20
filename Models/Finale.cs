using System;
using System.Collections.Generic;

namespace SisacadFinal.Models;

public partial class Finale
{
    public int? EstudianteId { get; set; }

    public int? MateriaId { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Materia? Materia { get; set; }
}
