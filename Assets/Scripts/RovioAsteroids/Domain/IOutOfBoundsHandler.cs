using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface IOutOfBoundsHandler {
        Vector3 GetPosition();
        void OnOutOfBounds();
    }
}