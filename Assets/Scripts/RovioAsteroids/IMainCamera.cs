using UnityEngine;

namespace RovioAsteroids {
    public interface IMainCamera {
        Vector3 WorldToViewportPoint(Vector3 worldPoint);
    }
}