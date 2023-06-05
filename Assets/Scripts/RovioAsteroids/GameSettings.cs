using UnityEngine;

namespace RovioAsteroids {
    [CreateAssetMenu(fileName = "GameSettings", menuName = "RovioAsteroids/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject, IGameSettings {
        [SerializeField] private Vector2 _bigAsteroidSpeedRange;
        [SerializeField] private Vector2 _mediumAsteroidSpeedRange;
        [SerializeField] private Vector2 _smallAsteroidSpeedRange;
        [SerializeField] private Vector2 _bigAsteroidAngularVelocityRange;
        [SerializeField] private Vector2 _mediumAsteroidAngularVelocityRange;
        [SerializeField] private Vector2 _smallAsteroidAngularVelocityRange;
        [SerializeField] private float _asteroidsSpeedLevelMultiplier;
        [SerializeField] private float _shipBulletThrust;

        public Vector2 BigAsteroidSpeedRange => _bigAsteroidSpeedRange;
        public Vector2 MediumAsteroidSpeedRange => _mediumAsteroidSpeedRange;
        public Vector2 SmallAsteroidSpeedRange => _smallAsteroidSpeedRange;
        public Vector2 BigAsteroidAngularVelocityRange => _bigAsteroidAngularVelocityRange;
        public Vector2 MediumAsteroidAngularVelocityRange => _mediumAsteroidAngularVelocityRange;
        public Vector2 SmallAsteroidAngularVelocityRange => _smallAsteroidAngularVelocityRange;
        public float AsteroidsSpeedLevelMultiplier => _asteroidsSpeedLevelMultiplier;
        public float ShipBulletThrust => _shipBulletThrust;
    }
}