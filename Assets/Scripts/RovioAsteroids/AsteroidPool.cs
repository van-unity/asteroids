using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.Exceptions;
using Zenject;

namespace RovioAsteroids {
    public class AsteroidPool : MonoBehaviourObjectPoolBase<IAsteroid> {
        [SerializeField] private AsteroidType _asteroidType;
        [Inject] private readonly IAsteroidFactory _factory;

        protected override Task<IAsteroid> CreateTask() => _factory.CreateAsync(_asteroidType);

        protected override Task ReleaseTask(IAsteroid objectToRelease) {
            var released = Addressables.ReleaseInstance(objectToRelease.GameObject);
            if (!released) {
                return Task.FromException(new OperationException("Failed to release asteroid!"));
            }

            return Task.CompletedTask;
        }
    }
}