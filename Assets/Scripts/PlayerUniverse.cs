using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUniverse : MonoBehaviour
{
    [SerializeField] private float attackCooldownBlue;
    [SerializeField] private float attackCooldownGreen;
    [SerializeField] private float attackCooldownRed;
    [SerializeField] private int damageBlue;
    [SerializeField] private int damageGreen;
    [SerializeField] private int damageRed;
    [SerializeField] private AudioClip shootBlueClip;
    [SerializeField] private AudioClip shootGreenClip;
    [SerializeField] private AudioClip shootRedClip;

    void Start() {
        UniverseManager.Instance.OnUniverseChange.AddListener(HandleUniverseChange);
    }

    void Update() {
    }

    private void HandleUniverseChange(int universe) {
        var self = GetComponent<AttackController>();
        var currentUniverse = UniverseManager.Instance.currentUniverse;

        switch (currentUniverse) {
            case 0:
                self.damage = damageBlue;
                self.attackCooldown = attackCooldownBlue;
                self.shootClip = shootBlueClip;
                break;
            case 1:
                self.damage = damageGreen;
                self.attackCooldown = attackCooldownGreen;
                self.shootClip = shootGreenClip;
                break;
            case 2:
                self.damage = damageRed;
                self.attackCooldown = attackCooldownRed;
                self.shootClip = shootRedClip;
                break;
        }
    }
}
