using UnityEngine;

public interface IAsteroidTriggerEnterHandler {
    void HandleTriggerEnter(IAsteroid asteroid, Collider2D other);
}
