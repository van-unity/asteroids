using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class OutOfBoundsChecker : MonoBehaviour, IOutOfBoundsChecker {
        private List<Transform> _items;

        [Inject] private IMainCamera _mainCamera;
        
        public void Register(Transform objectToRegister) {
            _items.Add(objectToRegister);
        }

        public void UnRegister(Transform objectToUnRegister) {
            _items.Remove(objectToUnRegister);
        }

        private void LateUpdate() {
            foreach (var item in _items) {
                if (IsObjectOffScreen(item)) {
                    var itemPosition = item.position;
                    itemPosition.y *= -1;
                    item.position = itemPosition;
                }
            }
        }
        
        private bool IsObjectOffScreen(Transform itemTransform)
        {
            // Convert the object's world position to viewport coordinates
            Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(itemTransform.position);

            // Check if the viewport coordinates fall outside the visible screen area
            if (viewportPosition.x < 0 || viewportPosition.x > 1 ||
                viewportPosition.y < 0 || viewportPosition.y > 1)
            {
                return true;
            }

            return false;
        }
    }
}