using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RovioAsteroids {
    public class BulletFactory : MonoBehaviour, IBulletFactory {
        [SerializeField] private AssetReference _bulletAssetReference;
        
        public async Task<IBullet> CreateAsync() {
            var bullet = await Addressables.InstantiateAsync(_bulletAssetReference).Task;

            return bullet.GetComponent<IBullet>();
        }
    }
}