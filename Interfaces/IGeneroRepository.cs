using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{

    /// <summary>
    /// Interface para Genero: Contrato
    /// Toda classe que herdar(implementar) essa interface, devera implementar todos os metodos definidos aqui
    /// </summary>
    public interface IGeneroRepository
    {

        ///CRUD : Metodos
        ///C :Create: Cadastrar um novo objeto
        ///R :Read: Listar todos os objetos
        ///U :Update: Alterar um objeto
        ///D :Delete: Deleto ou excluo um objetos
        
        ///Metodos = TipoDeRetorno NomeDoMetodo(Argumentos)
        
        void Cadastrar(Generos novoGenero);

        List<Generos> Listar();

        void Atualizar(Guid id, Generos genero);

        void Deletar(Guid id);

        Generos BuscarPorId(Guid id);
    }
}
