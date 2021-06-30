using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedGrup.webApi.Domains;
using SpMedGrup.webApi.Interfaces;
using SpMedGrup.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedGrup.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDeUsuarioController : ControllerBase
    {
        private ITipoDeUsuarioRepository Tipo { get; set; }

        public TipoDeUsuarioController()
        {
            Tipo = new TipoDeUsuarioRepository();
        }
        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Tipo.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("Lista")]
        public IActionResult ListarUser()
        {
            try
            {
                return Ok(Tipo.ListarUser());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoDeUsuario NovoTipo)
        {
            try
            {
                Tipo.Cadastrar(NovoTipo);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Tipo.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoDeUsuario NovoTipo)
        {
            try
            {
                Tipo.Atualizar(id, NovoTipo);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
