using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Clinica.Models;

public partial class Cita
{
    public int Id { get; set; }
    [DisplayName("Fecha de la cita")]
    public DateTime FechaCita { get; set; }

    public string? Motivo { get; set; }

    public string? Estado { get; set; }

    public int? PacienteId { get; set; }

    public int? MedicoId { get; set; }

    public virtual ICollection<Facturacion> Facturacions { get; set; } = new List<Facturacion>();

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
