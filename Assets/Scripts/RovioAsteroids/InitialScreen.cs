using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RovioAsteroids {
    public class InitialScreen : MonoBehaviour {
        [SerializeField] private Button _startButton;

        [Inject] private readonly IGameplayModel _gameplayModel;

        private IEnumerator Start() {
            _startButton.gameObject.SetActive(false);
            yield return new WaitForSeconds(3);
            _startButton.gameObject.SetActive(true);
            
            _startButton.onClick.AddListener(() => {
                _gameplayModel.StartTheGame();
                Destroy(gameObject);
            });
        }
    }
}