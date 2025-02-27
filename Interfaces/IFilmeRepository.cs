using api_filmes_senai.Controllers;
using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    public interface IFilmeRepository
    {

        void Cadastrar(Filme novoFilme);

        void Atualizar(Guid id, Filme filme);

        void Deletar (Guid id);

        Filme BuscarPorId(Guid id);

        List<Filme> Listar();

        List<Filme> ListarPorGeneros(Guid idGenero);
     
    }
}
