using UnityEngine;

namespace RovioAsteroids {
    [RequireComponent(typeof(Camera))]
    public class MainCamera : MonoBehaviour, IMainCamera {
        private Camera _camera;

        private void Awake() {
            _camera = GetComponent<Camera>();
        }

        public Vector3 WorldToViewportPoint(Vector3 worldPoint) => _camera.WorldToViewportPoint(worldPoint);
    }
}