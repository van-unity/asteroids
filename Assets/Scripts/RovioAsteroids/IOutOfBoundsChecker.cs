using UnityEngine;

namespace RovioAsteroids {
    public interface IOutOfBoundsChecker {
        void Register(Transform objectToRegister);
        void UnRegister(Transform objectToUnRegister);
    }
}