using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float COOLDOWN;
    [SerializeField] private GameObject spawnPrefab;

    private float cooldown = 0;

    void Start() {
    }

    void Update() {
        cooldown -= Time.deltaTime;
        if (cooldown > 0) return;

        cooldown = COOLDOWN;

        GameObject newAI = Instantiate(spawnPrefab);

        newAI.transform.position = transform.position;
    }
}
