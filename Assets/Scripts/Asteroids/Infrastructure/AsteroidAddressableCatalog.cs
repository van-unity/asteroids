using System;
using System.Collections.Generic;
using Asteroids.Domain;
using UnityEngine;

namespace Asteroids.Infrastructure {
    [CreateAssetMenu(fileName = "AsteroidCatalog", menuName = "RovioAsteroids/AsteroidCatalog", order = 0)]
    public class AsteroidAddressableCatalog : ScriptableObject, IAsteroidCatalog {
        [Serializable]
        private class AsteroidPathByType {
            public AsteroidType asteroidType;
            public AddressableAssetPath path;
        }

        [SerializeField] private List<AsteroidPathByType> _paths;

        public IAssetPath GetAsteroidPathByType(AsteroidType asteroidType) {
            foreach (var asteroidPathByType in _paths) {
                if (asteroidPathByType.asteroidType == asteroidType) {
                    return asteroidPathByType.path;
                }
            }

            throw new NullReferenceException($"Path for {asteroidType} asteroid is not registered.");
        }
    }
}