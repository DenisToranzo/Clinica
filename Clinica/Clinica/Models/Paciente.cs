using System;
using System.Collections.Generic;

namespace Clinica.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Genero { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
