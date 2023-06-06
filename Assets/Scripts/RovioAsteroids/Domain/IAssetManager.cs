using System.Threading.Tasks;
using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface IAssetManager {
        Task<GameObject> InstantiateAsync(IAssetPath path);
        bool ReleaseInstance(GameObject objectToRelease);
    }
}