using Microsoft.EntityFrameworkCore;
using SpMedGrup.webApi.Contexts;
using SpMedGrup.webApi.Domains;
using SpMedGrup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Repositories
{
    public class TipoDeUsuarioRepository : ITipoDeUsuarioRepository
    {
        MedicalGrupContext ctx = new MedicalGrupContext();

        public void Atualizar(int id, TipoDeUsuario NovoTipo)
        {
            TipoDeUsuario TipoBuscado = ctx.TipoDeUsuarios.Find(id);

            if (NovoTipo.TipoDeUsuario1 != null)
            {
                TipoBuscado.TipoDeUsuario1 = NovoTipo.TipoDeUsuario1;
            }

            ctx.TipoDeUsuarios.Update(TipoBuscado);
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoDeUsuario NovoTipo)
        {
            ctx.TipoDeUsuarios.Add(NovoTipo);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoDeUsuario TipoBuscado = ctx.TipoDeUsuarios.Find(id);
            ctx.TipoDeUsuarios.Remove(TipoBuscado);
            ctx.SaveChanges();
        }

        public List<TipoDeUsuario> Listar()
        {
            return ctx.TipoDeUsuarios.ToList();
        }

        public List<TipoDeUsuario> ListarUser()
        {
            return ctx.TipoDeUsuarios.
                Include(e => e.Usuarios).ToList();
        }
    }
}
