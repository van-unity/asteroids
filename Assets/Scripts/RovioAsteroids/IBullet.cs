using UnityEngine;

namespace RovioAsteroids {
    public interface IBullet : ISpawnable {
        GameObject GameObject { get; }
        void SetPosition(Vector3 position);
        void SetForce(Vector2 force);
    }
}