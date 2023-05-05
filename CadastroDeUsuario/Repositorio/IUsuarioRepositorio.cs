using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.Repositorio
{
    public interface IUsuarioRepositorio
    {
        void Criar(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuarioAtualizado, int id);
        UsuarioModel ObterPorId(int id);
        List<UsuarioModel> ObterTodos();
        void Remover(int id);
    }
}
