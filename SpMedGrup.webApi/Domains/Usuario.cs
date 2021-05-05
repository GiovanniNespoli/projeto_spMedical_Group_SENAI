using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedGrup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoDeUsuario { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Você ultrapassou ou não atingiu os limites de carecteres")]
        [Required(ErrorMessage = "Email necessário")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Você ultrapassou ou não atingiu os limites de carecteres")]
        [Required(ErrorMessage = "Senha necessário")]
        public string Senha { get; set; }

        public virtual TipoDeUsuario IdTipoDeUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
