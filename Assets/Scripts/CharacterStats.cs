using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnHealthChangeEvent : UnityEvent<int, int> {
}

public class CharacterStats : MonoBehaviour {
    public List<int> maxHealths;
    private List<int> currentHealths;

    public OnHealthChangeEvent OnHealthChange = new OnHealthChangeEvent();

    private void Awake() {
        currentHealths = new List<int>();

        maxHealths.ForEach((max) => currentHealths.Add(max));
    }

    public void TakeDamage(int damage) {
        var currentUniverse = UniverseManager.Instance.currentUniverse;
        var currentHealth = currentHealths[currentUniverse];
        var newHealth = currentHealths[currentUniverse] - Mathf.Max(currentHealth - damage, 0);
        currentHealths[currentUniverse] = newHealth;

        OnHealthChange.Invoke(currentUniverse, newHealth);
    }
}