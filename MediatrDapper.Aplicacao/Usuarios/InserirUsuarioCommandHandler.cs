using AutoMapper;
using MediatR;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Dominio.Interface;

namespace MediatrDapper.Aplicacao.Usuarios
{
    public class InserirUsuarioCommandHandler : IRequestHandler<InserirUsuarioCommandRequest, InserirUsuarioCommandResponse>
    {
        private readonly IUsuarioRepositorio _iusuarioRepositorio;
        private readonly IMapper _mapper;
        public InserirUsuarioCommandHandler(IMapper mapper, IUsuarioRepositorio iusuarioRepositorio)
        {
            _mapper = mapper;
            _iusuarioRepositorio = iusuarioRepositorio;
        }

        public async Task<InserirUsuarioCommandResponse> Handle(InserirUsuarioCommandRequest request, CancellationToken cancellationToken)
        {

            Usuario usuario = _mapper.Map<Usuario>(request);

            try
            {
                _iusuarioRepositorio.Inserir(usuario, true);
                _iusuarioRepositorio.Comitar();
                return new InserirUsuarioCommandResponse();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir o usuário no banco de dados.", ex);
            }
        }
    }
}
