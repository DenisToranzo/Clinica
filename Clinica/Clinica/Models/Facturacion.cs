using System;
using System.ComponentModel;

namespace Clinica.Models
{
    public partial class Facturacion
    {
        public int Id { get; set; }

        public int CitaId { get; set; }

        public decimal Monto { get; set; } 
        [DisplayName("Fecha de facturación")]
        public DateTime? FechaFacturacion { get; set; }

        [DisplayName("Estado de pago")]
        public string EstadoPago { get; set; } = null!;

        public virtual Cita? Cita { get; set; } = null!;
    }
}