using System.Threading.Tasks;
using Asteroids.Domain;
using Zenject;

namespace Asteroids.Infrastructure {
    public class BulletPool : MonoBehaviourObjectPoolBase<IBullet> {
        [Inject] private readonly IBulletFactory _bulletFactory;

        protected override Task<IBullet> CreateTask() => _bulletFactory.CreateAsync();
    }
}