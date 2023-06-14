using System.Threading;
using System.Threading.Tasks;
using Asteroids.Domain;
using Asteroids.Infrastructure;
using UnityEngine;
using Zenject;

namespace Asteroids.Application {
    public class ShipAsteroidCollisionEnterHandler : MonoBehaviour, ICollisionEnterHandler<IShip> {
        [Inject] private readonly IGameplayModel _gameplayModel;
        [Inject] private readonly IAssetManager _assetManager;

        [SerializeField] private int _respawnDelayInMilliseconds;
        [SerializeField] private int _explosionReleaseDelayInMilliseconds;
        [SerializeField] private AddressableAssetPath _explosionPath;

        private CancellationTokenSource _respawnCancellation;
        private CancellationTokenSource _releaseExplosionCancellation;
        private GameObject _explosionGameObject;

        public void HandleCollisionEnter(IShip self, Collision2D collision) {
            self.SetActive(false);
            _gameplayModel.OnShipCollidedWithAnAsteroid();
            InstantiateExplosionAsync(self.Position, self.Rotation);
            if (_gameplayModel.LifeCount > 0) {
                RespawnShipAsync(self);
            }
        }

        private async void InstantiateExplosionAsync(Vector3 position, Quaternion rotation) {
            _explosionGameObject = await _assetManager.InstantiateAsync(_explosionPath);
            _explosionGameObject.transform.position = position;
            _explosionGameObject.transform.rotation = rotation;
            ReleaseExplosionAsync(_explosionGameObject);
        }

        private async void ReleaseExplosionAsync(GameObject explosionGameObject) {
            _releaseExplosionCancellation = new CancellationTokenSource();
            try {
                await Task.Delay(_explosionReleaseDelayInMilliseconds, _releaseExplosionCancellation.Token);
            }
            catch (TaskCanceledException) {
                return;
            }

            if (explosionGameObject == null) {
                return;
            }

            _assetManager.ReleaseInstance(explosionGameObject);
        }

        private async void RespawnShipAsync(IShip ship) {
            _respawnCancellation = new CancellationTokenSource();
            try {
                await Task.Delay(_respawnDelayInMilliseconds, _respawnCancellation.Token);
            }
            catch (TaskCanceledException) {
                return;
            }

            if (ship != null) {
                ship.Position = Vector3.zero;
                ship.SetActive(true);
            }
        }

        private void OnDestroy() {
            _respawnCancellation?.Cancel();
            _releaseExplosionCancellation?.Cancel();
        }
    }
}