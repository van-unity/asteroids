using System.Threading.Tasks;

namespace Asteroids.Domain {
    public interface IPool<T> where T : ISpawnable {
        Task<T> SpawnAsync();
        void Despawn(T objectToDespawn);
        void Clear();
    }
}