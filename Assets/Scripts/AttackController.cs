using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {
    private float attackCooldown;
    [SerializeField] private float attackCooldownBlue;
    [SerializeField] private float attackCooldownGreen;
    [SerializeField] private float attackCooldownRed;
    private float remainingCooldown;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform gunTransform;
    private int damage;
    [SerializeField] private int damageBlue;
    [SerializeField] private int damageGreen;
    [SerializeField] private int damageRed;

    private void Start() {
        UniverseManager.Instance.OnUniverseChange.AddListener(HandleUniverseChange);

        damage = damageBlue;
        attackCooldown = attackCooldownBlue;
    }

    private void HandleUniverseChange(int universe) {
        switch (universe) {
            case 0: damage = damageBlue; attackCooldown = attackCooldownBlue; break;
            case 1: damage = damageGreen; attackCooldown = attackCooldownGreen; break;
            case 2: damage = damageRed; attackCooldown = attackCooldownRed; break;
        }
    }

    private void Update() {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public void Shoot() {
        if (bulletPrefab == null) {
            Debug.LogError("Tried to fire a bullet that doesnt exist");
            return;
        }

        if (remainingCooldown <= 0) {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = gunTransform.position;

            ProjectileController projectile = newBullet.GetComponent<ProjectileController>();

            projectile.Initialise(gunTransform.up, damage, this);

            remainingCooldown = attackCooldown;
        }
    }
}