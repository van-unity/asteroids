using RovioAsteroids.Domain;
using TMPro;
using UnityEngine;
using Zenject;

namespace RovioAsteroids.Presentation {
    public class GameplayScreen : MonoBehaviour {
        private const string SCORE_FORMAT = "Score: {0}";
        private const string LIFE_FORMAT = "Life: {0}";

        [Inject] private readonly IGameplayModel _gameplayModel;

        [SerializeField] private GameObject _container;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _lifeText;

        private void Start() {
            _gameplayModel.GameStarted += OnGameStarted;
            _gameplayModel.GameOver += GameOver;
            _gameplayModel.ScoreChanged += ScoreChanged;
            _gameplayModel.LifeCountChanged += OnLifeCountChanged;
        }

        private void OnGameStarted() {
            _container.SetActive(true);
        }

        private void GameOver() {
            _container.SetActive(false);
        }

        private void ScoreChanged(int score) {
            _scoreText.text = string.Format(SCORE_FORMAT, score);
        }

        private void OnLifeCountChanged(int lifeCount) {
            _lifeText.text = string.Format(LIFE_FORMAT, lifeCount);
        }

        private void OnDestroy() {
            _gameplayModel.GameStarted -= OnGameStarted;
            _gameplayModel.GameOver -= GameOver;
            _gameplayModel.ScoreChanged -= ScoreChanged;
            _gameplayModel.LifeCountChanged -= OnLifeCountChanged;
        }
    }
}