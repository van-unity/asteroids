using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour, IAsteroid {
        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private IAsteroidTriggerEnterHandler[] _triggerEnterHandlers;

        [Inject] private readonly IOutOfBoundsChecker _outOfBoundsChecker;

        public bool IsActive => _gameObject.activeSelf;

        private void Awake() {
            _gameObject = gameObject;
            _transform = _gameObject.GetComponent<Transform>();
            _rigidbody = _gameObject.GetComponent<Rigidbody2D>();
            _triggerEnterHandlers = _gameObject.GetComponents<IAsteroidTriggerEnterHandler>();
        }

        private async void OnEnable() {
            while (_outOfBoundsChecker == null) {
                await Task.Yield();
            }

            _outOfBoundsChecker.Register(_transform);
        }

        public void SetParent(Transform parent) {
            _transform.SetParent(parent);
        }

        public void SetVelocity(Vector2 velocity) {
            _rigidbody.velocity = velocity;
        }

        public void SetPosition(Vector3 position) {
            _transform.position = position;
        }

        private void OnTriggerEnter(Collider other) {
            foreach (var triggerEnterHandler in _triggerEnterHandlers) {
                triggerEnterHandler.HandleTriggerEnter(this, other);
            }
        }

        public void SetActive(bool isActive) {
            _gameObject.SetActive(isActive);
        }

        private void OnDisable() {
            _outOfBoundsChecker.UnRegister(_transform);
        }
    }
}