using Dapper;
using MediatrDapper.Dominio.Entidade;
using MediatrDapper.Dominio.Interface;
using MediatrDapper.Infra.Contexto;
using System.Data;

namespace MediatrDapper.Infra.Repositorio
{
    public class UsuarioRepositorio : GenericoRepositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly GenericoContexto _contexto;
        private readonly IDbConnection _dbConnection;
        public UsuarioRepositorio(GenericoContexto dbContext, IDbConnection dbConnection) : base(dbContext)
        {
            _contexto = dbContext;
            _dbConnection = dbConnection;
        }

        public List<Usuario> BuscarTodosPorDescricao(string descricao)
        {
            var resultado = new List<Usuario>();
            if (string.IsNullOrEmpty(descricao))
            {
                resultado = _contexto.Usuario.ToList();
            }
            else
            {
                resultado = _contexto.Usuario.Where(b => b.Nome.Contains(descricao)).ToList();
            }
            return resultado;
        }

        public List<Usuario> BuscarTodosPorDescricaoDapper(string descricao)
        {
            var sql = "SELECT * FROM Usuario WHERE @Descricao IS NULL OR Nome LIKE '%' + @Descricao + '%'";
            var resultado = _dbConnection.Query<Usuario>(sql, new { Descricao = descricao }).ToList();
            return resultado;
        }

        public IEnumerable<Usuario> ObterTodosDapper()
        {
            var sql = "SELECT * FROM Usuario";
            var usuarios = _dbConnection.Query<Usuario>(sql);
            return usuarios;
        }



    }
}