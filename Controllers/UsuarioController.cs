using api_filmes_senai.Interface;
using api_filmes_senai.Domains;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Authorization;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// EndPoint para Cadastrar um usuario
        /// </summary>
        /// <param name="id"> id do usuario cadastrado</param>
        /// <returns>Usuario Cadastrado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201, usuario);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }
        }

           
        /// <summary>
        /// EndPoint para Buscar um usuario
        /// </summary>
        /// <param name="id"> id do usuario buscado</param>
        /// <returns>Usuario Buscado</returns>
        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid Id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(Id);

                return Ok(usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
    }


