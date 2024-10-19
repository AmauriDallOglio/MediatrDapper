using AutoMapper;
using MediatrDapper.Aplicacao.Usuarios;
using MediatrDapper.Dominio.Entidade;

namespace MediatrDapper.Aplicacao
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
