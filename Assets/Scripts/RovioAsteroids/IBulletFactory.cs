using System.Threading.Tasks;

namespace RovioAsteroids {
    public interface IBulletFactory {
        Task<IBullet> CreateAsync();
    }
}