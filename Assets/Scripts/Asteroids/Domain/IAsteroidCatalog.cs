namespace Asteroids.Domain {
    public interface IAsteroidCatalog {
        IAssetPath GetAsteroidPathByType(AsteroidType asteroidType);
    }
}