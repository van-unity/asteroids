using System.Threading.Tasks;

namespace RovioAsteroids.Domain {
    public interface IBulletFactory {
        Task<IBullet> CreateAsync();
    }
}