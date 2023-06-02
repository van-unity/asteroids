using System;
using System.Threading.Tasks;
using UnityEngine;

namespace RovioAsteroids {
    public abstract class MonoBehaviourObjectPoolBase<T> : MonoBehaviour, IPool<T> where T : ISpawnable {
        [SerializeField] private Transform _container;
        [SerializeField] private int _size;
        private T[] _pool;

        public bool IsReady { get; private set; }

        private async void Start() {
            await InitializeAsync();
        }

        private async Task InitializeAsync() {
            _pool = new T[_size];
            for (int i = 0; i < _size; i++) {
                _pool[i] = await Create();
                _pool[i].SetParent(_container);
                _pool[i].SetActive(false);
            }

            IsReady = true;
        }

        protected abstract Task<T> Create();

        public async Task<T> SpawnAsync() {
            foreach (var spawnable in _pool) {
                if (spawnable.IsActive) {
                    continue;
                }

                spawnable.SetActive(true);
                return spawnable;
            }

            Array.Resize(ref _pool, ++_size);
            var newItem = await Create();
            _pool[_size - 1] = newItem;
            newItem.SetActive(true);
            return newItem;
        }

        public void Despawn(T objectToDespawn) {
            objectToDespawn.SetActive(false);
        }

        public void Clear() {
            foreach (var spawnable in _pool) {
                spawnable.SetActive(false);
            }
        }
    }
}