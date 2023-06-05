using UnityEngine;

namespace RovioAsteroids {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour, IBullet {
        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private IBulletTriggerHandler[] _triggerHandlers;
        
        public bool IsActive => _gameObject.activeSelf;

        private void Awake() {
            _gameObject = gameObject;
            _transform = _gameObject.transform;
            _rigidbody = _gameObject.GetComponent<Rigidbody2D>();
            _triggerHandlers = GetComponents<IBulletTriggerHandler>();
        }

        public void SetPosition(Vector3 position) {
            _transform.position = position;
        }
        
        public void SetParent(Transform parent) {
            _transform.SetParent(parent);
        }

        public void SetActive(bool isActive) {
            _gameObject.SetActive(isActive);
        }

        public void SetForce(Vector2 force) {
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            foreach (var triggerHandler in _triggerHandlers) {
                triggerHandler.HandleTriggerEnter(this, col);
            }
        }
    }
}