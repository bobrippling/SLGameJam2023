using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    [SerializeField] private float SPEED = 20f;

    private Vector3 direction = Vector2.up;

    public void Initialise(Vector2 startDirection) {
        transform.up = startDirection;
    }

    // Update is called once per frame
    private void Update() {
        transform.position += transform.up * SPEED * Time.deltaTime;
    }
}