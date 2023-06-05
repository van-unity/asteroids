using System;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour, IAsteroid {
        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private IAsteroidTriggerHandler[] _triggerEnterHandlers;

        public bool IsActive => _gameObject.activeSelf;

        private void Awake() {
            _gameObject = gameObject;
            _transform = _gameObject.GetComponent<Transform>();
            _rigidbody = _gameObject.GetComponent<Rigidbody2D>();
            _triggerEnterHandlers = _gameObject.GetComponents<IAsteroidTriggerHandler>();
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

        public Vector3 GetPosition() => _transform.position;

        public void SetAngularVelocity(float angularVelocity) {
            _rigidbody.AddTorque(angularVelocity);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            foreach (var triggerEnterHandler in _triggerEnterHandlers) {
                triggerEnterHandler.HandleTriggerEnter(this, col);
            }
        }

        public void SetActive(bool isActive) {
            _gameObject.SetActive(isActive);
        }
    }
}