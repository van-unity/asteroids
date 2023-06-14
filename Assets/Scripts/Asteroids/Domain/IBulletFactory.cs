using System.Threading.Tasks;

namespace Asteroids.Domain {
    public interface IBulletFactory {
        Task<IBullet> CreateAsync();
    }
}