using System.Threading.Tasks;
using Asteroids.Domain;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Asteroids.Infrastructure {
    public class AddressableAssetManager : IAssetManager {
        public Task<GameObject> InstantiateAsync(IAssetPath path) => Addressables.InstantiateAsync(path.Path).Task;

        public bool ReleaseInstance(GameObject objectToRelease) => Addressables.ReleaseInstance(objectToRelease);
    }
}