using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SisacadFinal.Models;

public partial class Matriculacione
{
 
    public int? EstudianteId { get; set; }
    public int? MateriaId { get; set; }
    // [Key]
    public int MatriculacioneID { get; set; } // Clave primaria
    public virtual Estudiante? Estudiante { get; set; }
    public virtual Materia? Materia { get; set; }


  
}
