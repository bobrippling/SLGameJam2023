using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveManager : Singleton<ShockwaveManager> {
    [SerializeField] private GameObject shockwavePrefab;

    public void CreateShockwave(Vector3 spawnPosition) {
        var shockwave = Instantiate(shockwavePrefab);

        shockwave.transform.position = spawnPosition;
    }
}