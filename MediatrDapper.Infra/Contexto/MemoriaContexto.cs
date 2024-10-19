using MediatrDapper.Dominio.Entidade;
using System.Collections.Concurrent;

namespace MediatrDapper.Infra.Contexto
{
    public class MemoriaContexto
    {
        private readonly ConcurrentDictionary<int, Usuario> _usuarios = new ConcurrentDictionary<int, Usuario>();

        public IEnumerable<Usuario> ObterTodos() => _usuarios.Values;

        public Usuario? ObterPorId(int id) => _usuarios.TryGetValue(id, out var usuario) ? usuario : null;

        public void Adicionar(Usuario usuario) => _usuarios.TryAdd(usuario.Id, usuario);

        public void Atualizar(Usuario usuario) => _usuarios[usuario.Id] = usuario;

        public void Remover(int id) => _usuarios.TryRemove(id, out _);
    }
}