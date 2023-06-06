namespace RovioAsteroids.Domain {
    public interface IAsteroidCatalog {
        IAssetPath GetAsteroidPathByType(AsteroidType asteroidType);
    }
}