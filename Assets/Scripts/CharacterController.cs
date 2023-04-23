using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    public const float SPEED = 5f;

    public Vector2 MovementDirection { get; set; }

    public Vector3 FacingAt { get; set; }

    [SerializeField] private Transform graphics;

    // Start is called before the first frame update
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        if (MovementDirection != Vector2.zero) {
            var newPos = transform.position + new Vector3(MovementDirection.x, MovementDirection.y) * SPEED * Time.deltaTime;

            if (GetComponent<CharacterStats>().isPlayer) {
                var w = 156;
                var h = 83;

                newPos.x = Mathf.Clamp(newPos.x, -w / 2, w / 2);
                newPos.y = Mathf.Clamp(newPos.y, -h / 2, h / 2);
            }

            transform.position = newPos;
        }

        graphics.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(FacingAt.y - transform.position.y, FacingAt.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }
}
