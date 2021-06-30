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
    public class ConsultaRepository : IConsultaRepository
    {
        MedicalGrupContext ctx = new MedicalGrupContext();

        public void Atualizar(int id, Consultum NovaConsulta)
        {
            Consultum ConBuscada = ctx.Consulta.Find(id);

            if (NovaConsulta.Descricao != null)
            {
                ConBuscada.Descricao = NovaConsulta.Descricao;
            }

            ctx.Consulta.Update(ConBuscada);
            ctx.SaveChanges();
        }

        public Consultum BuscarId(int id)
        {
            return ctx.Consulta.FirstOrDefault(e => e.IdConsulta == id);
        }

        public void Cadastrar(Consultum NovoConsulta)
        {
            ctx.Consulta.Add(NovoConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consultum ConBuscada = ctx.Consulta.Find(id);
            ctx.Consulta.Remove(ConBuscada);
            ctx.SaveChanges();
        }


        public List<Consultum> ListarCon()
        {
            return ctx.Consulta.ToList();
        }

        public List<Consultum> ListarTudo()
        {
            return ctx.Consulta
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .ToList();
        }

        public List<Consultum> MedicoCon(int id)
        {
            Medico MedBuscado = ctx.Medicos.FirstOrDefault(e => e.IdUsuario == id);

            return ctx.Consulta
               .Include(e => e.IdPacienteNavigation)
               .Include(e => e.IdSituacaoNavigation)
               .Where(e => e.IdMedico == MedBuscado.IdMedico)
               .ToList();
        }

        public List<Consultum> MinhasCon(int id)
        {
            Paciente PacBuscado = ctx.Pacientes.FirstOrDefault(e => e.IdUsuario == id);

            return ctx.Consulta
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation)
                .Include(e => e.IdMedicoNavigation.IdEspecialidadeNavigation)
                .Include(e => e.IdSituacaoNavigation)
                .Where(e => e.IdPaciente == PacBuscado.IdPaciente)
                .ToList();
        }

        public void Status(int id, string status)
        {
            Consultum consulta = ctx.Consulta
                .FirstOrDefault(e => e.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consulta.IdSituacao = 1;
                    break;

                case "2":
                    consulta.IdSituacao = 2;
                    break;

                case "3":
                    consulta.IdSituacao = 3;
                    break;

                default:
                    consulta.IdSituacao = consulta.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consulta);
            ctx.SaveChanges();
        }
    }
}
