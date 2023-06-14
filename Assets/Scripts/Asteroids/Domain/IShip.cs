using UnityEngine;

namespace Asteroids.Domain {
    public interface IShip {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; }
        void SetActive(bool isActive);
    }
}