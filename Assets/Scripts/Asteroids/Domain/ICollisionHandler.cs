using UnityEngine;

namespace Asteroids.Domain {
    public interface ICollisionEnterHandler<T> {
        void HandleCollisionEnter(T self, Collision2D collision);
    }
}