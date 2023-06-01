using System;
using System.Collections.Generic;
using UnityEngine;

namespace RovioAsteroids {
    [CreateAssetMenu(fileName = "AsteroidCatalog", menuName = "RovioAsteroids/AsteroidCatalog", order = 0)]
    public class AsteroidAddressableCatalog : ScriptableObject, IAsteroidCatalog {
        [Serializable]
        private class AsteroidPathByType {
            public AsteroidType asteroidType;
            public AddressableAssetPath path;
        }

        [SerializeField] private List<AsteroidPathByType> _paths;

        public string GetAsteroidPathByType(AsteroidType asteroidType) {
            foreach (var asteroidPathByType in _paths) {
                if (asteroidPathByType.asteroidType == asteroidType) {
                    return asteroidPathByType.path.Path;
                }
            }

            throw new NullReferenceException($"Path for {asteroidType} asteroid is not registered.");
        }
    }
}