﻿namespace SisacadFinal.Models.Dto
{
    public class EstudiantesDto
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public int? Dni { get; set; }

        public string? Correo { get; set; }

        public DateTime? FechaCreacion { get; set; }
    }
}
