using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

    // universe properties (set by spawner)
    public float attackCooldown;

    public int damage;
    public AudioClip shootClip;

    // state
    private float remainingCooldown;

    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private Transform gunTransform;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
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

            AudioManager.Instance.PlaySound(shootClip, transform.position);
        }
    }
}