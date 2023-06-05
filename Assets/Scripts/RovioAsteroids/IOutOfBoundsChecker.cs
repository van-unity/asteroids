using UnityEngine;

namespace RovioAsteroids {
    public interface IOutOfBoundsChecker {
        void Register(IOutOfBoundsHandler objectToRegister);
        void UnRegister(IOutOfBoundsHandler objectToUnRegister);
    }
}