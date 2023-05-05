using CadastroDeUsuario.Models;
using CadastroDeUsuario.Repositorio.ConexaoBancoDeDados;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private ContextoDaAplicacao _contextoDaAplicacao;
        public UsuarioRepositorio(ContextoDaAplicacao contextoDaAplicacao)
        {
            _contextoDaAplicacao = contextoDaAplicacao;
        }

        public void Criar(UsuarioModel usuario)
        {
            _contextoDaAplicacao.Set<UsuarioModel>().Add(usuario);
            Salvar();
        }
        public void Atualizar(UsuarioModel usuarioAtualizado, int id)
        {
            var usuario = ObterPorId(id);

            if (usuario is null)
                throw new Exception("Usuário não encontrado!!!");

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;
            usuario.Telefone = usuarioAtualizado.Telefone;
            usuario.Observacao = usuarioAtualizado.Observacao;

            _contextoDaAplicacao.Entry(usuario).State = EntityState.Modified; 
            Salvar();
        }

        public UsuarioModel ObterPorId(int id)
        {
            var usuario = _contextoDaAplicacao.Set<UsuarioModel>().FirstOrDefault(c => c.ID == id);
            
            if (usuario is null) 
                throw new Exception("Usuário não encontrado!!!");

            return usuario;
        }

        public List<UsuarioModel> ObterTodos()
        {
            return _contextoDaAplicacao.Set<UsuarioModel>().ToList();
        }

        public void Remover(int id)
        {
            var usuario = ObterPorId(id);
            if (usuario is null) throw new Exception("Usuário não encontrado!!!");

            _contextoDaAplicacao.Entry(usuario).State = EntityState.Deleted;
            Salvar();
        }

        private void Salvar()
        {
            _contextoDaAplicacao.SaveChanges();
        }
    }
}
