using RovioAsteroids.Domain;
using UnityEngine;
using Zenject;

namespace RovioAsteroids.Presentation {
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ship : MonoBehaviour, IShip {
        [Inject] private readonly IGameSettings _settings;
        [Inject] private readonly IGameplayModel _gameplayModel;

        [SerializeField] private GameObject _thrustParticle;
        [SerializeField] private float _thrustForce;
        [SerializeField] private float _torque;
        [SerializeField] private Transform _bulletPosition;

        private GameObject _gameObject;
        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private IPool<IBullet> _bulletPool;
        private bool _shoot;
        private ICollisionEnterHandler<IShip>[] _collisionEnterHandlers;

        public Vector3 Position {
            get => _transform.position;
            set => _transform.position = value;
        }

        public Quaternion Rotation => _transform.rotation;

        public void SetActive(bool isActive) {
            _gameObject.SetActive(isActive);
        }

        private void Awake() {
            _gameObject = gameObject;
            _transform = _gameObject.transform;
            _rigidbody = _gameObject.GetComponent<Rigidbody2D>();
            _collisionEnterHandlers = _gameObject.GetComponents<ICollisionEnterHandler<IShip>>();
        }

        private void Start() {
            _bulletPool = GameObject.FindWithTag("BulletPool").GetComponent<IPool<IBullet>>();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Space)) {
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

        private void OnCollisionEnter2D(Collision2D collision) {
            foreach (var collisionEnterHandler in _collisionEnterHandlers) {
                collisionEnterHandler.HandleCollisionEnter(this, collision);
            }
        }
    }
}