using System;
using System.Collections.Generic;

namespace ControlAccesoAPI.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Sedes = new HashSet<Sedes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<Sedes> Sedes { get; set; }
    }
}
