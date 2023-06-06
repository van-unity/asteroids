using System.Threading.Tasks;
using RovioAsteroids.Domain;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RovioAsteroids.Infrastructure {
    public class AddressableAssetManager : IAssetManager {
        public Task<GameObject> InstantiateAsync(IAssetPath path) => Addressables.InstantiateAsync(path.Path).Task;

        public bool ReleaseInstance(GameObject objectToRelease) => Addressables.ReleaseInstance(objectToRelease);
    }
}