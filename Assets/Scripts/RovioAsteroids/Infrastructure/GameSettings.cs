using RovioAsteroids.Domain;
using UnityEngine;

namespace RovioAsteroids.Infrastructure {
    [CreateAssetMenu(fileName = "GameSettings", menuName = "RovioAsteroids/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject, IGameSettings {
        [SerializeField] private int _initialLifeCount;
        [SerializeField] private int _lifeCountIncreaseScore;
        [SerializeField] private Vector2 _bigAsteroidSpeedRange;
        [SerializeField] private Vector2 _mediumAsteroidSpeedRange;
        [SerializeField] private Vector2 _smallAsteroidSpeedRange;
        [SerializeField] private Vector2 _bigAsteroidAngularVelocityRange;
        [SerializeField] private Vector2 _mediumAsteroidAngularVelocityRange;
        [SerializeField] private Vector2 _smallAsteroidAngularVelocityRange;
        [SerializeField] private float _asteroidsSpeedLevelMultiplier;
        [SerializeField] private float _shipBulletThrust;
        [SerializeField] private int _bigAsteroidScore;
        [SerializeField] private int _mediumAsteroidScore;
        [SerializeField] private int _smallAsteroidScore;
        [SerializeField] private int _asteroidCountForFirstLevel;
        [SerializeField] private int _additionalAsteroidsCountForNewLevel;
        [SerializeField] private int _mediumAsteroidsCount;
        [SerializeField] private int _smallAsteroidsCount;

        public int InitialLifeCount => _initialLifeCount;
        public int LifeCountIncreaseScore => _lifeCountIncreaseScore;
        public Vector2 BigAsteroidSpeedRange => _bigAsteroidSpeedRange;
        public Vector2 MediumAsteroidSpeedRange => _mediumAsteroidSpeedRange;
        public Vector2 SmallAsteroidSpeedRange => _smallAsteroidSpeedRange;
        public Vector2 BigAsteroidAngularVelocityRange => _bigAsteroidAngularVelocityRange;
        public Vector2 MediumAsteroidAngularVelocityRange => _mediumAsteroidAngularVelocityRange;
        public Vector2 SmallAsteroidAngularVelocityRange => _smallAsteroidAngularVelocityRange;
        public float AsteroidsSpeedLevelMultiplier => _asteroidsSpeedLevelMultiplier;
        public float ShipBulletThrust => _shipBulletThrust;
        public int BigAsteroidScore => _bigAsteroidScore;
        public int MediumAsteroidScore => _mediumAsteroidScore;
        public int SmallAsteroidScore => _smallAsteroidScore;
        public int AsteroidCountForFirstLevel => _asteroidCountForFirstLevel;
        public int AdditionalAsteroidsCountForNewLevel => _additionalAsteroidsCountForNewLevel;
        public int MediumAsteroidsCount => _mediumAsteroidsCount;
        public int SmallAsteroidsCount => _smallAsteroidsCount;
    }
}