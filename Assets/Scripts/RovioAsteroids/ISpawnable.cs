using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    bool IsActive { get; }
    void OnSpawn();
    void OnDespawn();
}
