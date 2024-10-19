using AutoMapper;
using MediatrDapper.Command.Aplicacao.Usuarios;
using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Command.Aplicacao
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {


            CreateMap<Usuario, InserirUsuarioCommandRequest>().ReverseMap();


            CreateMap<Usuario, InserirUsuarioCommandResponse>().ReverseMap();
        }
    }
}
