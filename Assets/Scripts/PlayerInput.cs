using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput> {

    // Update is called once per frame
    private void Update() {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        var movementInput = new Vector2(moveX, moveY).normalized;

        var mousePos = Input.mousePosition;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        GetComponent<CharacterController>().MovementDirection = movementInput;
        GetComponent<CharacterController>().FacingAt = mouseWorldPosition;

        if (Input.GetMouseButton(0)) {
            GetComponent<AttackController>().Shoot();
        }
    }
}