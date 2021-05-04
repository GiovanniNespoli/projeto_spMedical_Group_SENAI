using SpMedGrup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarCon();
        List<Consultum> ListarTudo();
        List<Consultum> MinhasCon(int id);
        List<Consultum> MedicoCon(int id);
        Consultum BuscarId(int id);
        void Cadastrar(Consultum NovoConsulta);
        void Deletar(int id);
        void Atualizar(int id, Consultum NovaConsulta);
        void Status(int id, string status);
    }
}
