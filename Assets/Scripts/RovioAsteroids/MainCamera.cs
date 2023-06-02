using UnityEngine;

namespace RovioAsteroids {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour, IMainCamera {
        private Camera _camera;

        private void Awake() {
            _camera = GetComponent<Camera>();
        }

        public Vector3 WorldToViewportPoint(Vector3 worldPoint) => _camera.WorldToViewportPoint(worldPoint);
        public Vector3 ViewportToWorldPoint(Vector3 viewportPoint) => _camera.ViewportToWorldPoint(viewportPoint);
        public Vector3 ScreenToWorldPoint(Vector3 screenPoint) => _camera.ScreenToWorldPoint(screenPoint);

        public float NearClipPlane() => _camera.nearClipPlane;
    }
}