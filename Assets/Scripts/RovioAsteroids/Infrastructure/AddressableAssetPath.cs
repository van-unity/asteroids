using System;
using RovioAsteroids.Domain;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RovioAsteroids.Infrastructure {
    [Serializable]
    public class AddressableAssetPath : IAssetPath {
        [SerializeField] private AssetReference _assetReference;
        
        public string Path => _assetReference.RuntimeKey.ToString();
    }
}