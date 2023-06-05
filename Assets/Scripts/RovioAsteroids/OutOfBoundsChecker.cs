using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class OutOfBoundsChecker : MonoBehaviour, IOutOfBoundsChecker {
        private List<Transform> _items;

        [Inject] private IMainCamera _mainCamera;

        private void Awake() {
            _items = new List<Transform>();
        }

        public void Register(Transform objectToRegister) {
            _items.Add(objectToRegister);
        }

        public void UnRegister(Transform objectToUnRegister) {
            _items.Remove(objectToUnRegister);
        }

        private void LateUpdate() {
            foreach (var item in _items) {
                var viewportPosition = _mainCamera.WorldToViewportPoint(item.position);

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

                item.position = _mainCamera.ViewportToWorldPoint(viewportPosition);
            }
        }
    }
}