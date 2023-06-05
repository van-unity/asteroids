using UnityEngine;

namespace RovioAsteroids {
    public interface IBulletTriggerHandler {
        void HandleTriggerEnter(IBullet bullet, Collider2D other);
    }
}