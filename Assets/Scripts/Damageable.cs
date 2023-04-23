using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

    private void Start() {
    }

    private void Update() {
    }

    public void OnTriggerEnter2D(Collider2D col) {
        var other = col.gameObject;

        var projectile = other.GetComponent<ProjectileController>();
        if (projectile) {
            OnBulletCollide(projectile);
            return;
        }

        var health = other.tag.Equals("HealthPickup");
        if (health) {
            OnHealthCollide();

            Destroy(other.gameObject);
            return;
        }
    }

    private void OnBulletCollide(ProjectileController projectile) {
        var attackCtrl = GetComponent<AttackController>();

        if (projectile.creator == attackCtrl) {
            // my sweet child
            return;
        }
        Destroy(projectile.gameObject);

        GetComponent<CharacterStats>().TakeDamage(projectile.damage);
    }

    private void OnHealthCollide() {
        var stats = GetComponent<CharacterStats>();
        if (!stats) return;
        stats.Heal();
    }
}