
using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface ISpawnable {
        bool IsActive { get; }
        void SetParent(Transform parent);
        void SetActive(bool isActive);
        void OnSpawn();
        void OnDespawn();
    }
}
