using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class OnHealthChangeEvent : UnityEvent<int, int> {
}

public class OnTakeDamageEvent : UnityEvent<int> {
}

public class CharacterStats : MonoBehaviour {
    public List<int> maxHealths;
    private List<int> currentHealths;

    public AudioClip deathClip;
    public OnHealthChangeEvent OnHealthChange = new OnHealthChangeEvent();
    public OnTakeDamageEvent OnTakeDamage = new OnTakeDamageEvent();

    [SerializeField] public bool isPlayer = false;

    [SerializeField] private GameObject healthPickupPrefab;

    private void Awake() {
        currentHealths = new List<int>();

        maxHealths.ForEach((max) => currentHealths.Add(max));
    }

    public void TakeDamage(int damage) {
        var currentUniverse = UniverseManager.Instance.currentUniverse;
        var currentHealth = currentHealths[currentUniverse];
        var newHealth = Mathf.Max(currentHealth - damage, 0);
        currentHealths[currentUniverse] = newHealth;

        Debug.Log("TakeDamage(" + damage + ")");

        OnHealthChange.Invoke(currentUniverse, newHealth);
        OnTakeDamage.Invoke(damage);

        if (newHealth <= 0) {
            CheckDeath();
        }
    }

    private void CheckDeath() {
        bool isDead = isPlayer ? IsDeadPlayer() : IsDeadEnemy();

        if (isDead) {
            Debug.Log("Dead");
            Die();
        }
    }

    private bool IsDeadPlayer() {
        bool isDead = false;

        foreach (var health in currentHealths) {
            if (health <= 0) {
                isDead = true;
            }
        }

        return isDead;
    }

    private bool IsDeadEnemy() {
        int healthSum = 0;

        foreach (var health in currentHealths) {
            healthSum += health;
        }

        return healthSum <= 0;
    }

    public void Die() {
        if (isPlayer) {
            GameManager.Instance.OnPlayerDeath();
        } else {
            GameObject hp = Instantiate(healthPickupPrefab);
            hp.transform.position = transform.position;

            ScoreController.Instance.OnAIDeath();
        }

        AudioManager.Instance.PlaySound(deathClip, transform.position);
        Destroy(gameObject);
    }

    public void Heal() {
        for (int i = 0; i < currentHealths.Count; i++) {
            currentHealths[i] = maxHealths[i];
        }
    }
}