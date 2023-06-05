using UnityEngine;

namespace RovioAsteroids {
    public interface IGameSettings {
        Vector2 BigAsteroidSpeedRange { get; }
        Vector2 MediumAsteroidSpeedRange { get; }
        Vector2 SmallAsteroidSpeedRange { get; }
        Vector2 BigAsteroidAngularVelocityRange { get; }
        Vector2 MediumAsteroidAngularVelocityRange { get; }
        Vector2 SmallAsteroidAngularVelocityRange { get; }
        float AsteroidsSpeedLevelMultiplier { get; }
        float ShipBulletThrust { get; }
    }
}