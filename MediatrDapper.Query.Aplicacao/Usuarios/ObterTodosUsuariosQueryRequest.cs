using MediatR;
using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Query.Aplicacao.Usuarios
{
    public class ObterTodosUsuariosQueryRequest : IRequest<IEnumerable<Usuario>>
    {
    }
}
