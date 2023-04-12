using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    public const float DEFAULT_SPEED = 20f;
    [SerializeField] public float SPEED = DEFAULT_SPEED;

    private Vector3 direction = Vector2.up;

    public void Initialise(Vector2 startDirection) {
        transform.up = startDirection;
    }

    // Update is called once per frame
    private void Update() {
        transform.position += transform.up * SPEED * Time.deltaTime;
    }
}