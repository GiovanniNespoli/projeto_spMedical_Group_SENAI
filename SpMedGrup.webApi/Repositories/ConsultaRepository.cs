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

            if (NovaConsulta.Exames != null)
            {
                ConBuscada.Exames = NovaConsulta.Exames;
            }

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
                .Include(e => e.IdPacienteNavigation.NomePaciente)
                .Include(e => e.IdPacienteNavigation.Telefone)
                .Include(e => e.IdMedicoNavigation.NomeMedico)
                .Include(e => e.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades)
                .Include(e => e.IdSituacaoNavigation.TipoSituacao)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation.IdClinica)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation.Endereco)
                .ToList();
        }

        public List<Consultum> MedicoCon(int id)
        {
            return ctx.Consulta
               .Include(e => e.IdPacienteNavigation.NomePaciente)
               .Include(e => e.IdPacienteNavigation.Telefone)
               .Include(e => e.IdPacienteNavigation.Consulta)
               .Include(e => e.IdPacienteNavigation.DataDeNasc)
               .Include(e => e.IdSituacaoNavigation.TipoSituacao)
               .Where(e => e.IdMedico == id)
               .ToList();
        }

        public List<Consultum> MinhasCon(int id)
        {
            return ctx.Consulta
                .Include(e => e.IdPacienteNavigation.NomePaciente)
                .Include(e => e.IdPacienteNavigation.Telefone)
                .Include(e => e.IdMedicoNavigation.NomeMedico)
                .Include(e => e.IdMedicoNavigation.IdEspecialidadeNavigation.Especialidades)
                .Include(e => e.IdSituacaoNavigation.TipoSituacao)
                .Include(e => e.IdMedicoNavigation.IdClinicaNavigation.Endereco)
                .Where(e => e.IdPaciente == id)
                .ToList();
        }

        public void Status(int id, string status)
        {
            Consultum consulta = ctx.Consulta
                .Include(e => e.IdMedicoNavigation)
                .Include(e => e.IdPacienteNavigation)
                .Include(e => e.IdSituacaoNavigation)
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
        }
    }
}
