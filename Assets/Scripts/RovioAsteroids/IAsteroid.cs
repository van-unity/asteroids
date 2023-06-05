using UnityEngine;

public interface IAsteroid : ISpawnable {
    GameObject GameObject { get; }
    void SetVelocity(Vector2 velocity);
    void SetPosition(Vector3 position);
    Vector3 GetPosition();
    void SetAngularVelocity(float angularVelocity);
}
