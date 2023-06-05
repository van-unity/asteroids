using UnityEngine;

public interface IAsteroid : ISpawnable {
    void SetVelocity(Vector2 velocity);
    void SetPosition(Vector3 position);
    Vector3 GetPosition();
    void SetAngularVelocity(float angularVelocity);
}
