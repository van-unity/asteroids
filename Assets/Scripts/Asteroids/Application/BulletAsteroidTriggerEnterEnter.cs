using Asteroids.Domain;
using UnityEngine;

namespace Asteroids.Application {
    public class BulletAsteroidTriggerEnterEnter : MonoBehaviour, ITriggerEnterHandler<IBullet> {
        private IPool<IBullet> _pool;

        private void Start() {
            _pool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<IPool<IBullet>>();
        }

        public void HandleTriggerEnter(IBullet bullet, Collider2D other) {
            _pool.Despawn(bullet);
        }
    }
}