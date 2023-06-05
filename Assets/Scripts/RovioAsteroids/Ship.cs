using System;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : MonoBehaviour {
        [SerializeField] private GameObject _thrustParticle;
        [SerializeField] private float _thrustForce;
        [SerializeField] private float _torque;
        [SerializeField] private Transform _bulletPosition;

        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody2D _rigidbody;

        [Inject] private readonly IOutOfBoundsChecker _outOfBoundsChecker;
        [Inject] private readonly IGameSettings _settings;

        private IPool<IBullet> _bulletPool;
        private bool _shoot;

        private void Awake() {
            _gameObject = gameObject;
            _transform = _gameObject.transform;
            _rigidbody = _gameObject.GetComponent<Rigidbody2D>();
        }

        private void Start() {
            _outOfBoundsChecker.Register(_transform);
            _bulletPool = GameObject.FindWithTag("BulletPool").GetComponent<IPool<IBullet>>();
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                _shoot = true;
            }
        }

        private void FixedUpdate() {
            var moveInput = Input.GetAxis("Vertical");
            _thrustParticle.SetActive(Mathf.Abs(moveInput) > 0);
            var force = _transform.up * (moveInput * _thrustForce);
            _rigidbody.AddForce(force);
            var rotationInput = Input.GetAxis("Horizontal");
            var torque = rotationInput * _torque;
            _rigidbody.AddTorque(-torque);

            if (_shoot) {
                _shoot = false;
                ShootAsync();
            }
        }

        private async void ShootAsync() {
            var bullet = await _bulletPool.SpawnAsync();
            bullet.SetPosition(_bulletPosition.position);
            bullet.SetForce(_transform.up * _settings.ShipBulletThrust);
        }

        private void OnDestroy() {
            _outOfBoundsChecker.UnRegister(_transform);
        }
    }
}