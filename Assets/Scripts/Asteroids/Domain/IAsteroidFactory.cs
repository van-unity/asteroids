using System.Threading.Tasks;

namespace Asteroids.Domain {
    public interface IAsteroidFactory {
        Task<IAsteroid> CreateAsync(AsteroidType asteroidType);
    }
}