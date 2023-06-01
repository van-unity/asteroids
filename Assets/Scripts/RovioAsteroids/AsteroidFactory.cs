using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace RovioAsteroids {
    public class AsteroidFactory : IAsteroidFactory {
        private readonly IAsteroidCatalog _catalog;

        public AsteroidFactory(IAsteroidCatalog catalog) {
            _catalog = catalog;
        }

        public async Task<IAsteroid> CreateAsync(AsteroidType asteroidType) {
            var path = _catalog.GetAsteroidPathByType(asteroidType);
            var asteroid = await Addressables.InstantiateAsync(path).Task;

            return asteroid.GetComponent<IAsteroid>();
        }
    }
}