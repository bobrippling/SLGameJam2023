using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {
    [SerializeField] private float attackCooldown;
    private float remainingCooldown;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform gunTransform;

    private void Update() {
        if (remainingCooldown > 0) {
            remainingCooldown -= Time.deltaTime;
        }
    }

    public void Shoot(Vector3 angle) {
        if (bulletPrefab == null) {
            Debug.LogError("Tried to fire a bullet that doesnt exist");
            return;
        }

        if (remainingCooldown <= 0) {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = gunTransform.position;

            ProjectileController projectile = newBullet.GetComponent<ProjectileController>();

            projectile.Initialise(angle);

            remainingCooldown = attackCooldown;
        }
    }
}