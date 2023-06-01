using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RovioAsteroids {
    [Serializable]
    public class AddressableAssetPath : IAssetPath {
        [SerializeField] private AssetReference _assetReference;
        
        public string Path => _assetReference.RuntimeKey.ToString();
    }
}