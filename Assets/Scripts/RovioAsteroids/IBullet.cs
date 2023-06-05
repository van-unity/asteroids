using UnityEngine;

namespace RovioAsteroids {
    public interface IBullet : ISpawnable {
        void SetPosition(Vector3 position);
        void SetForce(Vector2 force);
    }
}