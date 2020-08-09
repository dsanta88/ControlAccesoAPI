using System;
using System.Collections.Generic;

namespace ControlAccesoAPI.Models
{
    public partial class Horarios
    {
        public Horarios()
        {
            HorariosDetalle = new HashSet<HorariosDetalle>();
        }

        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Nombre { get; set; }
        public int RegistrarDesde { get; set; }
        public int RegistrarHasta { get; set; }

        public virtual Areas Area { get; set; }
        public virtual ICollection<HorariosDetalle> HorariosDetalle { get; set; }
    }
}
