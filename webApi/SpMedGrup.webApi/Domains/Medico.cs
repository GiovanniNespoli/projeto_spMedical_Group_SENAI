using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedGrup.webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdMedico { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdClinica { get; set; }
        public string NomeMedico { get; set; }
        public string Rg { get; set; }
        public string Endereco { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Telefone { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
