using UnityEngine;

namespace RovioAsteroids {
    public interface ITriggerEnterHandler<T> {
        void HandleTriggerEnter(T self, Collider2D other);
    }
}