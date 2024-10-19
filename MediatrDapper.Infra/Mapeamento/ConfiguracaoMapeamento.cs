using Microsoft.EntityFrameworkCore;

namespace MediatrDapper.Infra.Mapeamento
{
    public class ConfiguracaoMapeamento
    {
        public static void Injetar(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMapeamento());

        }
    }
}