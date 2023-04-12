using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput> {
    private CharacterController Character;

    // Start is called before the first frame update
    private void Start() {
        Character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update() {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        var movementInput = new Vector2(moveX, moveY).normalized;

        var mousePos = Input.mousePosition;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        Character.MovementDirection = movementInput;
        Character.FacingAt = mouseWorldPosition;

        if (Input.GetMouseButton(0)) {
            GetComponent<AttackController>().Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            UniverseManager.Instance.PreviousUniverse();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            UniverseManager.Instance.NextUniverse();
        }
    }
}