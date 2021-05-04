using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Necessita de um Tipo de Usuário")]
        [StringLength(20,MinimumLength = 3,ErrorMessage = "Você ultrapassou ou não atingiu os limites de carecteres")]
        public string TipoDeUsuario1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
