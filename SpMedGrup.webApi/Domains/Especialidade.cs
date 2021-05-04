using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedGrup.webApi.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        public string Especialidades { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
