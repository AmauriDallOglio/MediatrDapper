using MediatR;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Dominio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDapper.Query.Aplicacao.Usuarios
{
    public class ObterTodosUsuariosQueryHandler : IRequestHandler<ObterTodosUsuariosQueryRequest, IEnumerable<Usuario>>
    {
        private readonly IUsuarioRepositorio _iusuarioRepositorio;

        public ObterTodosUsuariosQueryHandler(IUsuarioRepositorio iusuarioRepositorio)
        {
            _iusuarioRepositorio = iusuarioRepositorio;
        }


        public async Task<IEnumerable<Usuario>> Handle(ObterTodosUsuariosQueryRequest request, CancellationToken cancellationToken)
        {


            var usuarios = _iusuarioRepositorio.ObterTodosDapper();


            return usuarios;
        }
    }
}
