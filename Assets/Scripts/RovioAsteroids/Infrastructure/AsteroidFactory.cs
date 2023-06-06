using System.Threading.Tasks;
using RovioAsteroids.Domain;

namespace RovioAsteroids.Infrastructure {
    public class AsteroidFactory : IAsteroidFactory {
        private readonly IAssetManager _assetManager;
        private readonly IAsteroidCatalog _catalog;

        public AsteroidFactory(IAssetManager assetManager, IAsteroidCatalog catalog) {
            _catalog = catalog;
            _assetManager = assetManager;
        }

        public async Task<IAsteroid> CreateAsync(AsteroidType asteroidType) {
            var path = _catalog.GetAsteroidPathByType(asteroidType);
            var asteroid = await _assetManager.InstantiateAsync(path);
            
            return asteroid.GetComponent<IAsteroid>();
        }
    }
}