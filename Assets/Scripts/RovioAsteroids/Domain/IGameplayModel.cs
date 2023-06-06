using System;

namespace RovioAsteroids.Domain {
    public interface IGameplayModel {
        int Level { get; }
        int Score { get; }
        int LifeCount { get; }

        event Action GameStarted;
        event Action GameOver;
        event Action LevelChanged;
        event Action<int> LifeCountChanged;
        event Action<int> ScoreChanged;
        void StartTheGame();
        void OnShipCollidedWithAnAsteroid();
        void OnAsteroidDestroyed(AsteroidType asteroidType);
        void OnAsteroidGenerated();
    }
}