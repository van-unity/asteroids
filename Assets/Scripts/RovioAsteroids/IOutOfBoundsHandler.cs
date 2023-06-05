using UnityEngine;

namespace RovioAsteroids {
    public interface IOutOfBoundsHandler {
        Vector3 GetPosition();
        void OnOutOfBounds();
    }
}