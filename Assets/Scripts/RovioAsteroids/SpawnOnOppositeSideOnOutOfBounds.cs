using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class SpawnOnOppositeSideOnOutOfBounds : MonoBehaviour, IOutOfBoundsHandler {
        private Transform _transform;

        [Inject] private readonly IMainCamera _mainCamera;
        [Inject] private readonly IOutOfBoundsChecker _outOfBoundsChecker;

        private void Awake() {
            _transform = transform;
        }

        private async void OnEnable() {
            while (_outOfBoundsChecker == null) {
                await Task.Delay((int)(Time.deltaTime * 1000));
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
    }
}