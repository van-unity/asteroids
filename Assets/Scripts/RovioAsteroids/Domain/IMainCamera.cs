using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface IMainCamera {
        Vector3 WorldToViewportPoint(Vector3 worldPoint);
        Vector3 ViewportToWorldPoint(Vector3 viewportPoint);
        Vector3 ScreenToWorldPoint(Vector3 screenPoint);
        float NearClipPlane();
    }
}