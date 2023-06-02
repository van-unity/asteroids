
using UnityEngine;

public interface ISpawnable {
    bool IsActive { get; }
    void SetParent(Transform parent);
    void SetActive(bool isActive);
}
