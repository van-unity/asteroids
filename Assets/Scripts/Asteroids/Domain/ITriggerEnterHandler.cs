using UnityEngine;

namespace Asteroids.Domain {
    public interface ITriggerEnterHandler<T> {
        void HandleTriggerEnter(T self, Collider2D other);
    }
}