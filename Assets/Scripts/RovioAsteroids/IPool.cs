using System.Threading.Tasks;

public interface IPool<T> where T : ISpawnable {
    bool IsReady { get; }
    Task<T> SpawnAsync();
    void Despawn(T objectToDespawn);
    void Clear();
}