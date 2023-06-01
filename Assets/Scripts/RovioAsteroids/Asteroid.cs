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

        private void OnEnable() {
            _outOfBoundsChecker.Register(_transform);
        }

        public void OnSpawn() {
            _gameObject.SetActive(true);
        }

        public void OnDespawn() {
            _gameObject.SetActive(false);
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

        private void OnDisable() {
            _outOfBoundsChecker.UnRegister(_transform);
        }
    }
}