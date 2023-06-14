using System;
using Asteroids.Domain;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Asteroids.Infrastructure {
    [Serializable]
    public class AddressableAssetPath : IAssetPath {
        [SerializeField] private AssetReference _assetReference;
        
        public string Path => _assetReference.RuntimeKey.ToString();
    }
}