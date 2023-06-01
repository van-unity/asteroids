using UnityEngine;

public interface IAsteroidTriggerEnterHandler {
    void HandleTriggerEnter(IAsteroid asteroid, Collider other);
}
