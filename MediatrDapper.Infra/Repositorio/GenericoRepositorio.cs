using MediatrDapper.Dominio.Interface;
using MediatrDapper.Infra.Contexto;

namespace MediatrDapper.Infra.Repositorio
{
    public class GenericoRepositorio<TEntity> : IGenericoRepositorio<TEntity> where TEntity : class
    {
        private readonly GenericoContexto _dbContext;
        public GenericoRepositorio(GenericoContexto dbContext)
        {
            _dbContext = dbContext;
        }



        public TEntity Inserir(TEntity entidade, bool finalizar)
        {
            _dbContext.Set<TEntity>().Add(entidade);
            if (finalizar)
            {
                Comitar();
            }

            return entidade;
        }

        public void Comitar()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar salvar as alterações no banco de dados.", ex);
            }
        }



    }
}
