using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface ICollisionEnterHandler<T> {
        void HandleCollisionEnter(T self, Collision2D collision);
    }
}