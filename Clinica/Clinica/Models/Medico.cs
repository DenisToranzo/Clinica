﻿using System;
using System.Collections.Generic;

namespace Clinica.Models;

public partial class Medico
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Especialidad { get; set; }

    public DateOnly? FechaContratacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
