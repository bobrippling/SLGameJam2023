using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnHealthChangeEvent : UnityEvent<int, int> {
}

public class CharacterStats : MonoBehaviour {
    public List<int> maxHealths;
    private List<int> currentHealths;

    public OnHealthChangeEvent OnHealthChange = new OnHealthChangeEvent();

    [SerializeField] public bool isPlayer = false;

    private void Awake() {
        currentHealths = new List<int>();

        maxHealths.ForEach((max) => currentHealths.Add(max));
    }

    public void TakeDamage(int damage) {
        var currentUniverse = UniverseManager.Instance.currentUniverse;
        var currentHealth = currentHealths[currentUniverse];
        var newHealth = Mathf.Max(currentHealth - damage, 0);
        currentHealths[currentUniverse] = newHealth;

        OnHealthChange.Invoke(currentUniverse, newHealth);

        if (newHealth <= 0) {
            CheckDeath();
        }
    }

    private void CheckDeath() {
        int healthSum = 0;

        foreach (var health in currentHealths) {
            healthSum += health;
        }

        if (healthSum <= 0) {
            Die();
        }
    }

    public void Die() {
        if (isPlayer) {
            GameManager.Instance.OnPlayerDeath();
        } else {
            ScoreController.Instance.OnAIDeath();
        }

        Destroy(gameObject);
    }
}
