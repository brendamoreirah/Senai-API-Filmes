using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;

namespace api_filmes_senai.Repositories
{

    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository
    /// Ou seja, vamos implementar os metodos, toda a logica dos metodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {


        private readonly Filmes_Context _context;
        /// <summary>
        /// Construtor do repository
        /// Aqui, toda vez que o construtor for chamado,
        /// os dados do contexto estarao disponiveis
        /// </summary>
        /// <param name="contexto">Dados do contexto</param>

        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;


        }
        public void Atualizar(Guid id, Generos genero)
        {
            try
            {
                Generos generosBuscado = _context.Generos.Find(id)!;

                if (generosBuscado != null)
                {
                    generosBuscado.Nome = genero.Nome;
                }
                
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Generos BuscarPorId(Guid id)
        {
            try
            {
                Generos generosBuscado =  _context.Generos.Find(id)!;

                return generosBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Generos novoGenero)
        {
            try
            {
                //Adiciona um novo genero na tabela Genero(BD)
                _context.Generos.Add(novoGenero);

                //Apos o cadastro, salva as alteracoes(BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Generos generosBuscado = _context.Generos.Find(id)!;

                if (generosBuscado != null)
                {
                _context.Generos.Remove(generosBuscado);

                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Generos> Listar()
        {
            try
            {
                List<Generos> listaGeneros = _context.Generos.ToList();

                return listaGeneros;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

