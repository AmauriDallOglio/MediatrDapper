using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Dominio.Interface
{
    public interface IUsuarioRepositorio : IGenericoRepositorio<Usuario>
    {
        List<Usuario> BuscarTodosPorDescricao(string descricao);
        List<Usuario> BuscarTodosPorDescricaoDapper(string descricao);
        IEnumerable<Usuario> ObterTodosDapper();
    }
}
