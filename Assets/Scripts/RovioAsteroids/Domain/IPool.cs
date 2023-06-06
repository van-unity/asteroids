using System.Threading.Tasks;

namespace RovioAsteroids.Domain {
    public interface IPool<T> where T : ISpawnable {
        Task<T> SpawnAsync();
        void Despawn(T objectToDespawn);
        void Clear();
    }
}