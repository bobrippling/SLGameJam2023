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
        if (!projectile) {
            Debug.LogError("no projectile in collision - player overlap?");
            return;
        }
        var attackCtrl = GetComponent<AttackController>();

        if(projectile.creator == attackCtrl){
            // my sweet child
            return;
        }

        //GetComponent<Health>().Hurt(projectile.damage);

        Destroy(col.gameObject);
    }
}
