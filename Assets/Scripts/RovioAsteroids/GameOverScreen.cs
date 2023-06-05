using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace RovioAsteroids {
    public class GameOverScreen : MonoBehaviour {
        [Inject] private readonly IGameplayModel _gameplayModel;
        [SerializeField] private GameObject _container;
        [SerializeField] private Button _playAgainButton;

        private void Start() {
            _gameplayModel.GameOver += OnGameOver;
            _playAgainButton.onClick.AddListener(() => {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
        }

        private void OnGameOver() {
            _container.SetActive(true);
        }
    }
}