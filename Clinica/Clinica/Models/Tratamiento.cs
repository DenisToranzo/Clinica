using System;
using System.Collections.Generic;

namespace Clinica.Models;

public partial class Tratamiento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? CitaId { get; set; }

    public virtual Cita? Cita { get; set; }
}
