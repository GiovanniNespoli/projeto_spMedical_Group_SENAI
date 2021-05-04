using SpMedGrup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Interfaces
{
    interface ITipoDeUsuarioRepository
    {
        List<TipoDeUsuario> Listar();
        List<TipoDeUsuario> ListarUser();
        void Cadastrar(TipoDeUsuario NovoTipo);
        void Deletar(int id);
        void Atualizar(int id,TipoDeUsuario NovoTipo);
    }
}
