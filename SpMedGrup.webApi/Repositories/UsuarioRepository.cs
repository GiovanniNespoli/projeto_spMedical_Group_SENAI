using SpMedGrup.webApi.Contexts;
using SpMedGrup.webApi.Domains;
using SpMedGrup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        MedicalGrupContext ctx = new MedicalGrupContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }
    }
}
