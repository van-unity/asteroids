using Asteroids.Domain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Asteroids.Presentation {
    public class InitialScreen : MonoBehaviour {
        [SerializeField] private Button _startButton;

        [Inject] private readonly IGameplayModel _gameplayModel;

        private void Start() {
            _startButton.onClick.AddListener(() => {
                _gameplayModel.StartTheGame();
                Destroy(gameObject);
            });
        }
    }
}