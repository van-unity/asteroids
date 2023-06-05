using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class ShipAsteroidCollisionEnterHandler : MonoBehaviour, ICollisionEnterHandler<IShip> {
        [Inject] private readonly IGameplayModel _gameplayModel;

        public void HandleCollisionEnter(IShip self, Collision2D collision) {
            self.SetActive(false);
            _gameplayModel.OnShipCollidedWithAnAsteroid();
        }
    }
}