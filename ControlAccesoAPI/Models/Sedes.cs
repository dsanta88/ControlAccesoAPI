using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlAccesoAPI.Models
{
    public partial class Sedes
    {
        public Sedes()
        {
            Areas = new HashSet<Areas>();
        }

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
       
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<Areas> Areas { get; set; }


        [NotMapped]
        public string EmpresaNombre { get; set; }
    }
}
