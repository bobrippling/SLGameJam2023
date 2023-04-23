using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnUniverseChangeEvent : UnityEvent<int> {
}

public class UniverseManager : Singleton<UniverseManager> {
    [SerializeField] private float universeSwitchCooldown;

    private float remainingUniverseSwitchCooldown;

    private const int UNIVERSES = 3;
    public int currentUniverse = 0;

    public OnUniverseChangeEvent OnUniverseChange = new OnUniverseChangeEvent();

    private void Update() {
        if (remainingUniverseSwitchCooldown > 0) {
            remainingUniverseSwitchCooldown -= Time.deltaTime;
        }
    }

    private void SwitchUniverse(int universe) {
        currentUniverse = universe;

        remainingUniverseSwitchCooldown = universeSwitchCooldown;

        OnUniverseChange.Invoke(currentUniverse);

        Debug.Log(currentUniverse);
    }

    public void NextUniverse() {
        if (!CanChangeUniverse()) {
            return;
        }

        var nextUniverse = (currentUniverse + 1) % UNIVERSES;
        SwitchUniverse(nextUniverse);
    }

    public void PreviousUniverse() {
        if (!CanChangeUniverse()) {
            return;
        }

        var previousUniverse = (currentUniverse + UNIVERSES - 1) % UNIVERSES;
        SwitchUniverse(previousUniverse);
    }

    private bool CanChangeUniverse() {
        return remainingUniverseSwitchCooldown <= 0;
    }
}
