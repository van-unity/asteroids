using UnityEngine;

namespace RovioAsteroids.Domain {
    public interface IShip {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; }
        void SetActive(bool isActive);
    }
}