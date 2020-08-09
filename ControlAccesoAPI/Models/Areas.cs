using System;
using System.Collections.Generic;

namespace ControlAccesoAPI.Models
{
    public partial class Areas
    {
        public Areas()
        {
            Horarios = new HashSet<Horarios>();
        }

        public int Id { get; set; }
        public int SedeId { get; set; }
        public string EmpresaNombre { get; set; }
        public string SedeNombre { get; set; }
        public string Nombre { get; set; }

        public virtual Sedes Sede { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
    }
}
