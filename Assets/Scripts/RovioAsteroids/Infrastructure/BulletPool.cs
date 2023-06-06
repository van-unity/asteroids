using System.Threading.Tasks;
using RovioAsteroids.Domain;
using Zenject;

namespace RovioAsteroids.Infrastructure {
    public class BulletPool : MonoBehaviourObjectPoolBase<IBullet> {
        [Inject] private readonly IBulletFactory _bulletFactory;

        protected override Task<IBullet> CreateTask() => _bulletFactory.CreateAsync();
    }
}