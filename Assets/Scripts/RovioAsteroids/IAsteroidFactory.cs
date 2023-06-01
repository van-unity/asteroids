using System.Threading.Tasks;

namespace RovioAsteroids {
    public interface IAsteroidFactory {
        Task<IAsteroid> CreateAsync(AsteroidType asteroidType);
    }
}