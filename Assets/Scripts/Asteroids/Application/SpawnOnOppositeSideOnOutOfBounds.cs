using System.Threading;
using System.Threading.Tasks;
using Asteroids.Domain;
using UnityEngine;
using Zenject;

namespace Asteroids.Application {
    public class SpawnOnOppositeSideOnOutOfBounds : MonoBehaviour, IOutOfBoundsHandler {
        private Transform _transform;

        [Inject] private readonly IMainCamera _mainCamera;
        [Inject] private readonly IOutOfBoundsChecker _outOfBoundsChecker;

        private CancellationTokenSource _registerCancellation;

        private void Awake() {
            _transform = transform;
        }

        private async void OnEnable() {
            await Task.Yield();//waiting one frame 
            _registerCancellation = new CancellationTokenSource();
            while (_outOfBoundsChecker == null) {
                await Task.Delay((int)(Time.deltaTime * 1000), _registerCancellation.Token);
            }

            _outOfBoundsChecker.Register(this);
        }

        public Vector3 GetPosition() => _transform.position;

        public void OnOutOfBounds() {
            var viewportPosition = _mainCamera.WorldToViewportPoint(GetPosition());

            viewportPosition.x = viewportPosition.x switch {
                > 1 => 0,
                < 0 => 1,
                _ => viewportPosition.x
            };

            viewportPosition.y = viewportPosition.y switch {
                > 1 => 0,
                < 0 => 1,
                _ => viewportPosition.y
            };

            _transform.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
        }

        private void OnDisable() {
            _outOfBoundsChecker.UnRegister(this);
        }

        private void OnDestroy() {
            _registerCancellation?.Cancel();
        }
    }
}