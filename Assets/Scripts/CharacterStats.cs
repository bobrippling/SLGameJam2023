using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {
    [SerializeField] private List<int> maxHealths;
    private List<int> currentHealths;

    public void TakeDamage(int damage) {
        var currentHealth = currentHealths[UniverseManager.Instance.currentUniverse];
        currentHealths[UniverseManager.Instance.currentUniverse] -= Mathf.Max(currentHealth - damage, 0);
    }
}