using UnityEngine;

namespace RovioAsteroids {
    public interface ICollisionEnterHandler<T> {
        void HandleCollisionEnter(T self, Collision2D collision);
    }
}