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

        public void Atualizar(int id, Usuario NovoUser)
        {
            Usuario UserBuscado = ctx.Usuarios.Find(id);

            if (NovoUser.Email != null)
            {
                UserBuscado.Email = NovoUser.Email;
            }
            ctx.Usuarios.Update(UserBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastro(Usuario NovoUser)
        {
            ctx.Add(NovoUser);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario UserBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UserBuscado);
            ctx.SaveChanges();
        }

        public List<Usuario> Lista()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == email && e.Senha == senha);
        }

    }
}
