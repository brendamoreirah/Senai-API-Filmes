using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;


        }
        /// <summary>
        /// EndPoint para Listar um Filme
        /// </summary>
        /// <param name="id"> id do filme listado</param>
        /// <returns>Filme Listado</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Filme> listaDeFilmes = _filmeRepository.Listar();

                return Ok(listaDeFilmes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
        /// <summary>
        /// EndPoint para Cadastrar umc Filme
        /// </summary>
        /// <param name="id"> id do filme cadastrado</param>
        /// <returns>Filme Cadastrado</returns>
        [Authorize]
        [HttpPost]
        public IActionResult Post(Filme novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// EndPoint para Buscar um Filme
        /// </summary>
        /// <param name="id"> id do filme buscado</param>
        /// <returns>Filme Buscado</returns>
    
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Filme filmesBuscados = _filmeRepository.BuscarPorId(id);
                return Ok(filmesBuscados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        /// <summary>
        /// EndPoint para Deletar um Filme
        /// </summary>
        /// <param name="id"> id do filme deletado</param>
        /// <returns>Filme Deletado</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _filmeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// EndPoint para Atualizar um Filme
        /// </summary>
        /// <param name="id"> id do filme atualizado</param>
        /// <returns>Filme Atualizado</returns>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Filme filme)
        {
            try
            {
                _filmeRepository.Atualizar(id, filme);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// EndPoint para Listar um Filme
        /// </summary>
        /// <param name="id"> id do filme listado</param>
        /// <returns>Filme Listado</returns>
        [Authorize]
        [HttpGet("ListarPorGenero/{id}")]
        public IActionResult GetByGenero(Guid id)
        {
            try
            {
                List<Filme> listaDeFilmePorGenero = _filmeRepository.ListarPorGeneros(id);

                return Ok(listaDeFilmePorGenero);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }
    }
}
