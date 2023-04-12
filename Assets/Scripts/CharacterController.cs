using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    private const float SPEED = 5f;

    public Vector2 MovementDirection { get; set; }

    public Vector3 FacingDirection { get; set; }

    // Start is called before the first frame update
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        if (MovementDirection != Vector2.zero) {
            transform.position += new Vector3(MovementDirection.x, MovementDirection.y) * SPEED * Time.deltaTime;
        }

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(FacingDirection.y - transform.position.y, FacingDirection.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}