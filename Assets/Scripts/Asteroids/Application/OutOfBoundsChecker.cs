using System.Collections.Generic;
using Asteroids.Domain;
using UnityEngine;
using Zenject;

namespace Asteroids.Application {
    public class OutOfBoundsChecker : MonoBehaviour, IOutOfBoundsChecker {
        private List<IOutOfBoundsHandler> _items;

        [Inject] private IMainCamera _mainCamera;

        private void Awake() {
            _items = new List<IOutOfBoundsHandler>();
        }

        public void Register(IOutOfBoundsHandler objectToRegister) {
            _items.Add(objectToRegister);
        }

        public void UnRegister(IOutOfBoundsHandler objectToUnRegister) {
            _items.Remove(objectToUnRegister);
        }

        private void LateUpdate() {
            for (var index = 0; index < _items.Count; index++) {
                var item = _items[index];
                var viewportPosition = _mainCamera.WorldToViewportPoint(item.GetPosition());

                if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 ||
                    viewportPosition.y > 1) {
                    item.OnOutOfBounds();
                }
            }
        }
    }
}