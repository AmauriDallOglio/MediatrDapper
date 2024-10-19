namespace MediatrDapper.Dominio.Interface
{
    public interface IGenericoRepositorio<TEntity> where TEntity : class
    {
        TEntity Inserir(TEntity entidade, bool finalizar);

        void Comitar();
    }
}