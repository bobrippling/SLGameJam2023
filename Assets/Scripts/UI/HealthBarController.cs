using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {
    [SerializeField] private int myUniverse;

    [SerializeField] private int maxHealth;

    [SerializeField] private Image bar;

    [SerializeField] private CharacterStats myStats;

    // Start is called before the first frame update
    private void Start() {
        maxHealth = myStats.maxHealths[myUniverse];
        myStats.OnHealthChange.AddListener(HandleHealthChange);
    }

    // Update is called once per frame
    private void HandleHealthChange(int universe, int newHealth) {
        if (myUniverse != universe) return;

        bar.fillAmount = (float)newHealth / (float)maxHealth;
    }
}