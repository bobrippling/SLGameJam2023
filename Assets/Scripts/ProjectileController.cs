using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public const float DEFAULT_SPEED = 20f;
    [SerializeField] public float SPEED = DEFAULT_SPEED;

    private Vector3 direction = Vector2.up;
    public int damage;
    public AttackController creator;

    public void Initialise(Vector2 startDirection, int damage, AttackController creator) {
        transform.up = startDirection;
        this.damage = damage;
        this.creator = creator;
    }

    // Update is called once per frame
    private void Update() {
        transform.position += transform.up * SPEED * Time.deltaTime;
    }
}