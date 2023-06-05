using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace RovioAsteroids {
    public interface IAsteroidsManager {
        void InstantiateMediumAsteroidAsync(Vector3 position);
        void InstantiateSmallAsteroidAsync(Vector3 position);
    }

    public class AsteroidsManager : MonoBehaviour, IAsteroidsManager {
        private enum AsteroidPlacement {
            Bottom = 0,
            Top = 1
        }

        private IPool<IAsteroid> _bigAsteroidPool;
        private IPool<IAsteroid> _mediumAsteroidPool;
        private IPool<IAsteroid> _smallAsteroidPool;

        [Inject] private readonly IMainCamera _mainCamera;
        [Inject] private readonly IGameSettings _gameSettings;
        [Inject] private readonly IGameplayModel _gameplayModel;

        private void Awake() {
            _bigAsteroidPool = GameObject.FindGameObjectWithTag("BigAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
            _mediumAsteroidPool = GameObject.FindGameObjectWithTag("MediumAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
            _smallAsteroidPool = GameObject.FindGameObjectWithTag("SmallAsteroidPool")
                .GetComponent<IPool<IAsteroid>>();
        }

        private void Start() {
            _gameplayModel.GameStarted += GenerateAsteroidsForLevel;
            _gameplayModel.LevelChanged += GameplayModelOnLevelChanged;
        }

        private void GenerateAsteroidsForLevel() {
            var asteroidsCount = GetBigAsteroidsCountForLevel();
            for (int i = 0; i < asteroidsCount; i++) {
                InstantiateBigAsteroidAsync();
            }
        }

        private void GameplayModelOnLevelChanged() {
            GenerateAsteroidsForLevel();
        }

        private int GetBigAsteroidsCountForLevel() {
            return _gameSettings.AsteroidCountForFirstLevel +
                   _gameplayModel.Level * _gameSettings.AdditionalAsteroidsCountForNewLevel;
        }

        private async void InstantiateBigAsteroidAsync() {
            var asteroid = await _bigAsteroidPool.SpawnAsync();
            var position = CreateRandomPosition(out var placement);
            var velocity = GetVelocityForBigAsteroid();
            if (placement == AsteroidPlacement.Top) {
                velocity.y *= -1;
            }

            var angularVelocity = Random.Range(_gameSettings.BigAsteroidAngularVelocityRange.x,
                _gameSettings.BigAsteroidAngularVelocityRange.y);
            asteroid.SetPosition(position);
            asteroid.SetVelocity(velocity);
            asteroid.SetAngularVelocity(angularVelocity);
            _gameplayModel.OnAsteroidGenerated();
        }

        private Vector3 CreateRandomPosition(out AsteroidPlacement placement) {
            placement = AsteroidPlacement.Bottom;
            var x = Random.Range(0f, 1f);
            var y = 0; //on bottom
            if (Random.Range(0f, 1f) > .5f) {
                //generate on top
                y = 1;
                placement = AsteroidPlacement.Top;
            }

            var screenPosition = new Vector3(x, y, _mainCamera.NearClipPlane());
            screenPosition = _mainCamera.ViewportToWorldPoint(screenPosition);
            screenPosition.z = 0;
            return screenPosition;
        }

        private Vector2 GetVelocityForBigAsteroid() {
            var xVelocity = Random.Range(_gameSettings.BigAsteroidSpeedRange.x, _gameSettings.BigAsteroidSpeedRange.y);
            var yVelocity = Random.Range(_gameSettings.BigAsteroidSpeedRange.x, _gameSettings.BigAsteroidSpeedRange.y);

            return new Vector2(xVelocity, yVelocity);
        }

        public async void InstantiateMediumAsteroidAsync(Vector3 position) {
            var asteroid = await _mediumAsteroidPool.SpawnAsync();
            var velocity = GetVelocityForMediumAsteroid();
            var angularVelocity = Random.Range(_gameSettings.MediumAsteroidAngularVelocityRange.x,
                _gameSettings.MediumAsteroidAngularVelocityRange.y);
            var randomPosition = Random.insideUnitCircle;
            asteroid.SetPosition(position + new Vector3(randomPosition.x, randomPosition.y, -position.z));//setting z to 0
            asteroid.SetVelocity(velocity);
            asteroid.SetAngularVelocity(angularVelocity);
            _gameplayModel.OnAsteroidGenerated();
        }

        private Vector2 GetVelocityForMediumAsteroid() {
            var xVelocity = Random.Range(_gameSettings.MediumAsteroidSpeedRange.x,
                _gameSettings.MediumAsteroidSpeedRange.y);
            var yVelocity = Random.Range(_gameSettings.MediumAsteroidSpeedRange.x,
                _gameSettings.MediumAsteroidSpeedRange.y);

            return new Vector2(xVelocity, yVelocity);
        }

        public async void InstantiateSmallAsteroidAsync(Vector3 position) {
            var asteroid = await _smallAsteroidPool.SpawnAsync();
            var velocity = GetVelocityForSmallAsteroid();
            var angularVelocity = Random.Range(_gameSettings.SmallAsteroidAngularVelocityRange.x,
                _gameSettings.SmallAsteroidAngularVelocityRange.y);
            asteroid.SetPosition(position);
            asteroid.SetVelocity(velocity);
            asteroid.SetAngularVelocity(angularVelocity);
            _gameplayModel.OnAsteroidGenerated();
        }

        private Vector2 GetVelocityForSmallAsteroid() {
            var xVelocity = Random.Range(_gameSettings.SmallAsteroidSpeedRange.x,
                _gameSettings.SmallAsteroidSpeedRange.y);
            var yVelocity = Random.Range(_gameSettings.SmallAsteroidSpeedRange.x,
                _gameSettings.SmallAsteroidSpeedRange.y);

            return new Vector2(xVelocity, yVelocity);
        }

        private void OnDestroy() {
            _gameplayModel.GameStarted -= GenerateAsteroidsForLevel;
            _gameplayModel.LevelChanged -= GameplayModelOnLevelChanged;
        }
    }
}