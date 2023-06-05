using System;
using System.Threading.Tasks;

public interface IPool<T> where T : ISpawnable {
    Task<T> SpawnAsync();
    void Despawn(T objectToDespawn);
    void Clear();
}