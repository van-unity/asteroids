using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface ITriggerEnterHandler<T> {
        void HandleTriggerEnter(T self, Collider2D other);
    }
}