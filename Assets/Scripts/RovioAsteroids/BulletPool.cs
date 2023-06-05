using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.Exceptions;
using Zenject;

namespace RovioAsteroids {
    public class BulletPool : MonoBehaviourObjectPoolBase<IBullet> {
        [Inject] private readonly IBulletFactory _bulletFactory;

        protected override Task<IBullet> CreateTask() => _bulletFactory.CreateAsync();

        protected override Task ReleaseTask(IBullet objectToRelease) {
            var released = Addressables.ReleaseInstance(objectToRelease.GameObject);
            if (!released) {
                return Task.FromException(new OperationException("Failed to release bullet!"));
            }

            return Task.CompletedTask;
        }
    }
}