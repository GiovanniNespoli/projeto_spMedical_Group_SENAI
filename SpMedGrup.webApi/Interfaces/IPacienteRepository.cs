using SpMedGrup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();
        List<Paciente> ListarTudo();
        Paciente BuscarId(int id);
        void Cadastrar(Paciente NovoPac);
        void Deletar(int id);
        void Atualizar(int id, Paciente NovoPac);
    }
}
