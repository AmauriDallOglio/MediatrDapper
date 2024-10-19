using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace MediatrDapper.Infra.Contexto
{
    public class GenericoContexto : DbContext
    {

        public GenericoContexto(DbContextOptions<GenericoContexto> options) : base(options)
        {

        }


        public DbSet<Usuario> Usuario { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Injetar(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
