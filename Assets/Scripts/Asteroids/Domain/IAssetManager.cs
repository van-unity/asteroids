using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Domain {
    public interface IAssetManager {
        Task<GameObject> InstantiateAsync(IAssetPath path);
        bool ReleaseInstance(GameObject objectToRelease);
    }
}