using System.Threading.Tasks;
using RovioAsteroids.Domain;
using UnityEngine;
using Zenject;

namespace RovioAsteroids.Infrastructure {
    public class BulletFactory : MonoBehaviour, IBulletFactory {
        [SerializeField] private AddressableAssetPath _bulletAssetReference;

        [Inject] private readonly IAssetManager _assetManager;

        public async Task<IBullet> CreateAsync() {
            var bullet = await _assetManager.InstantiateAsync(_bulletAssetReference);

            return bullet.GetComponent<IBullet>();
        }
    }
}