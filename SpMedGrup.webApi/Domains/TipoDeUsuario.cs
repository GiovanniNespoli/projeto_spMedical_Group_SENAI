using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedGrup.webApi.Domains
{
    public partial class TipoDeUsuario
    {
        public TipoDeUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoDeUsuario { get; set; }
        public string TipoDeUsuario1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
