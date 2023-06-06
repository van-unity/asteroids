using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface IGameSettings {
        int InitialLifeCount { get; }
        int LifeCountIncreaseScore { get; }
        Vector2 BigAsteroidSpeedRange { get; }
        Vector2 MediumAsteroidSpeedRange { get; }
        Vector2 SmallAsteroidSpeedRange { get; }
        Vector2 BigAsteroidAngularVelocityRange { get; }
        Vector2 MediumAsteroidAngularVelocityRange { get; }
        Vector2 SmallAsteroidAngularVelocityRange { get; }
        float AsteroidsSpeedLevelMultiplier { get; }
        float ShipBulletThrust { get; }
        int BigAsteroidScore { get; }
        int MediumAsteroidScore { get; }
        int SmallAsteroidScore { get; }
        int AsteroidCountForFirstLevel { get; }
        int AdditionalAsteroidsCountForNewLevel { get; }
        int MediumAsteroidsCount { get; }
        int SmallAsteroidsCount { get; }
    }
}