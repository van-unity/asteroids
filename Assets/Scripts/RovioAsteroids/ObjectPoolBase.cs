using System;
using System.Threading.Tasks;
using Zenject;

namespace RovioAsteroids {
    public abstract class ObjectPoolBase<T> : IInitializable, IPool<T> where T : ISpawnable {
        public bool IsReady { get; private set; }
        private int _size;
        private T[] _pool;

        public ObjectPoolBase(int size) {
            _size = size;
        }

        public async void Initialize() {
            _pool = new T[_size];
            for (int i = 0; i < _size; i++) {
                _pool[i] = await Create();
            }

            IsReady = true;
        }

        protected abstract Task<T> Create();

        public async Task<T> SpawnAsync() {
            foreach (var spawnable in _pool) {
                if (spawnable.IsActive) {
                    continue;
                }

                spawnable.OnSpawn();
                return spawnable;
            }

            Array.Resize(ref _pool, ++_size);
            var newItem = await Create();
            _pool[_size - 1] = newItem;
            newItem.OnSpawn();
            return newItem;
        }

        public void Despawn(T objectToDespawn) {
            objectToDespawn.OnDespawn();
        }

        public void Reset() {
            foreach (var spawnable in _pool) {
                spawnable.OnDespawn();
            }
        }
    }
}