using System.Threading.Tasks;

namespace RovioAsteroids.Domain {
    public interface IAsteroidFactory {
        Task<IAsteroid> CreateAsync(AsteroidType asteroidType);
    }
}