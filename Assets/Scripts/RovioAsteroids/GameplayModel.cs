using System;

namespace RovioAsteroids {
    public class GameplayModel : IGameplayModel {
        private readonly IGameSettings _gameSettings;
        private int _destroyedAsteroidsCountOnCurrentLevel;
        private int _generatedAsteroidsCountForLevel;

        public int Level { get; private set; }
        public int Score { get; private set; }
        public int LifeCount { get; private set; }

        public event Action GameStarted;
        public event Action GameOver;
        public event Action LevelChanged;
        public event Action<int> LifeCountChanged;
        public event Action<int> ScoreChanged;

        public GameplayModel(IGameSettings settings) {
            _gameSettings = settings;
        }

        public void StartTheGame() {
            Level = 0;
            GameStarted?.Invoke();
        }

        public void OnShipCollidedWithAnAsteroid() {
            LifeCount -= 1;
            if (LifeCount < 0) {
                GameOver?.Invoke();
                return;
            }

            LifeCountChanged?.Invoke(LifeCount);
        }

        public void OnAsteroidDestroyed(AsteroidType asteroidType) {
            _destroyedAsteroidsCountOnCurrentLevel += 1;
            CheckForNewLevel();

            Score += asteroidType switch {
                AsteroidType.Small => _gameSettings.SmallAsteroidScore,
                AsteroidType.Medium => _gameSettings.MediumAsteroidScore,
                AsteroidType.Big => _gameSettings.BigAsteroidScore,
                _ => throw new ArgumentOutOfRangeException($"Score for {asteroidType} asteroid is not set!")
            };

            ScoreChanged?.Invoke(Score);
        }

        private void CheckForNewLevel() {
            if (_destroyedAsteroidsCountOnCurrentLevel == _generatedAsteroidsCountForLevel) {
                Level += 1;
                _destroyedAsteroidsCountOnCurrentLevel = 0;
                _generatedAsteroidsCountForLevel = 0;

                LevelChanged?.Invoke();
            }
        }

        public void OnAsteroidGenerated() => _generatedAsteroidsCountForLevel += 1;
    }
}