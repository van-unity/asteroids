using UnityEngine;

public interface IAsteroidTriggerHandler {
    void HandleTriggerEnter(IAsteroid asteroid, Collider2D other);
}
