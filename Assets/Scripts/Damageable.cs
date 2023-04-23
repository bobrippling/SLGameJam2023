using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {
    void Start() {
    }

    void Update() {
    }

    public void OnTriggerEnter2D(Collider2D col) {
        var other = col.gameObject;

        var projectile = other.GetComponent<ProjectileController>();
        if (projectile) {
            OnBulletCollide(projectile);
            return;
        }

        var health = other.tag == "HealthPickup";
        if (health) {
            OnHealthCollide();
            return;
        }
    }

    void OnBulletCollide(ProjectileController projectile) {
        var attackCtrl = GetComponent<AttackController>();

        if(projectile.creator == attackCtrl){
            // my sweet child
            return;
        }
        Destroy(projectile.gameObject);

        GetComponent<CharacterStats>().TakeDamage(projectile.damage);
    }

    void OnHealthCollide() {
        var stats = GetComponent<CharacterStats>();
        if(!stats) return;
        stats.Heal();
    }
}
