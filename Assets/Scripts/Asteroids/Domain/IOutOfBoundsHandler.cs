using UnityEngine;

namespace Asteroids.Domain {
    public interface IOutOfBoundsHandler {
        Vector3 GetPosition();
        void OnOutOfBounds();
    }
}