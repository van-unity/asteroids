using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    [RequireComponent(typeof(IBullet))]
    public class BulletOutOfBoundsHandler : MonoBehaviour, IOutOfBoundsHandler {
        private Transform _transform;
        private IBullet _bullet;
        private IPool<IBullet> _pool;

        [Inject] private readonly IOutOfBoundsChecker _outOfBoundsChecker;

        private void Awake() {
            _transform = transform;
            _bullet = GetComponent<Bullet>();
        }

        private async void OnEnable() {
            while (_outOfBoundsChecker == null) {
                await Task.Delay((int)(Time.deltaTime * 1000));
            }

            _outOfBoundsChecker.Register(this);
            Debug.LogError("eneble");
        }

        private void Start() {
            _pool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<IPool<IBullet>>();
        }

        public Vector3 GetPosition() => _transform.position;

        public void OnOutOfBounds() {
            _pool.Despawn(_bullet);
        }

        private void OnDisable() {
            _outOfBoundsChecker.UnRegister(this);
            Debug.LogError("disable");
        }
    }
}