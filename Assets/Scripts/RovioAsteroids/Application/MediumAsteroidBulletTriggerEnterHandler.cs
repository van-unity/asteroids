using RovioAsteroids.Domain;
using UnityEngine;
using Zenject;

namespace RovioAsteroids.Application {
    public class MediumAsteroidBulletTriggerEnterHandler : MonoBehaviour, ITriggerEnterHandler<IAsteroid> {
        private IPool<IAsteroid> _pool;

        [Inject] private readonly IGameplayModel _gameplayModel;
        [Inject] private readonly IAsteroidsManager _asteroidsManager;
        [Inject] private readonly IGameSettings _gameSettings;

        private void Start() {
            _pool = GameObject.FindGameObjectWithTag("BigAsteroidPool").GetComponent<IPool<IAsteroid>>();
        }

        public void HandleTriggerEnter(IAsteroid asteroid, Collider2D other) {
            if (other.CompareTag("PlayerBullet")) {
                for (int i = 0; i < _gameSettings.SmallAsteroidsCount; i++) {
                    _asteroidsManager.InstantiateSmallAsteroidAsync(asteroid.GetPosition());
                }

                _pool.Despawn(asteroid);
                _gameplayModel.OnAsteroidDestroyed(AsteroidType.Medium);
            }
        }
    }
}