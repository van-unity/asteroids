using UnityEngine;

public interface IAsteroid : ISpawnable {
    void SetVelocity(Vector2 velocity);
    void SetPosition(Vector3 position);
    void SetAngularVelocity(float angularVelocity);
}
