using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace api_filmes_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GeneroController : ControllerBase
    {

        private readonly IGeneroRepository _generoRepository;
        public GeneroController(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_generoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }

        }


        [Authorize]
        [HttpPost]
        public IActionResult Post(Generos novoGenero)
        {
            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Generos generosBuscado = _generoRepository.BuscarPorId(id);

                return Ok(generosBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

        try 
	{	        
		_generoRepository.Deletar(id);
            
            return NoContent();
    }
	catch (Exception)
	{

		throw;
	}


     }

        [HttpPut("{id}")]

        public IActionResult Put(Guid id, Generos generos)
        {
            try
            {
                _generoRepository.Atualizar(id, generos);

                return NoContent();
            }
            catch (Exception e)
            {

              return BadRequest(e.Message);
            }
        }
    }
}
