using Dapper;
using MediatrDapper.Dominio.Entidade;
using System.Data;

namespace MediatrDapper.Infra.Repositorio
{
    public class UsuarioRepositorioMemoria
    {

        private readonly IDbConnection _dbConnection;

        public UsuarioRepositorioMemoria(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> InserirUsuarioAsync(Usuario usuario)
        {
            var sql = "INSERT INTO Usuario (Nome, Codigo, Email) VALUES (@Nome, @Codigo, @Email);";
            return await _dbConnection.ExecuteAsync(sql, usuario);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuariosAsync()
        {
            var sql = "SELECT * FROM Usuario;";
            return await _dbConnection.QueryAsync<Usuario>(sql);
        }

        public async Task<int> AtualizarUsuarioAsync(Usuario usuario)
        {
            var sql = "UPDATE Usuario SET Nome = @Nome, Codigo = @Codigo, Email = @Email WHERE Id = @Id;";
            return await _dbConnection.ExecuteAsync(sql, usuario);
        }

        public async Task<int> ExcluirUsuarioAsync(int id)
        {
            var sql = "DELETE FROM Usuario WHERE Id = @Id;";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
