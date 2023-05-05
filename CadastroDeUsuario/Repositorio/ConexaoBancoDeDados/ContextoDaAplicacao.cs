using CadastroDeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeUsuario.Repositorio.ConexaoBancoDeDados
{
    public class ContextoDaAplicacao : DbContext
    {
        public ContextoDaAplicacao(DbContextOptions options)
            : base(options) 
            {

            }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioModel>().HasKey(c => c.ID);
        }
    }
}
