using UnityEngine;

namespace RovioAsteroids {
    public class BulletAsteroidTriggerEnter : MonoBehaviour, IBulletTriggerHandler {
        private IPool<IBullet> _pool;

        private void Start() {
            _pool = GameObject.FindGameObjectWithTag("BulletPool").GetComponent<IPool<IBullet>>();
        }

        public void HandleTriggerEnter(IBullet bullet, Collider2D other) {
            _pool.Despawn(bullet);
        }
    }
}