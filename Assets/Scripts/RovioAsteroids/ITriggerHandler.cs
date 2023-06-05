using UnityEngine;

namespace RovioAsteroids {
    public interface ITriggerHandler<T> {
        void HandleTriggerEnter(T self, Collider2D other);
    }
}