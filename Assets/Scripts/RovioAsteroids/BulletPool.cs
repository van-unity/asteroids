using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RovioAsteroids {
    public class BulletPool : MonoBehaviourObjectPoolBase<IBullet> {
        [Inject] private readonly IBulletFactory _bulletFactory;

        private int count;

        protected override Task<IBullet> CreateTask() => _bulletFactory.CreateAsync();
    }
}