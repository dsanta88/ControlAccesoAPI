using System;
using System.Collections.Generic;

namespace ControlAccesoAPI.Models
{
    public partial class HorariosDetalle
    {
        public int Id { get; set; }
        public int HorarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }

        public virtual Horarios Horario { get; set; }
    }
}
