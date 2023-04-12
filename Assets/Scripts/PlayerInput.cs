using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public static PlayerInput Instance;

    // Start is called before the first frame update
    private void Start() {
        Instance = this;
    }

    // Update is called once per frame
    private void Update() {
        var moveX = Input.GetAxisRaw("Horizontal");
        var moveY = Input.GetAxisRaw("Vertical");

        var movementInput = new Vector2(moveX, moveY).normalized;

        var mousePos = Input.mousePosition;
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePos);

        GetComponent<CharacterController>().MovementDirection = movementInput;
        GetComponent<CharacterController>().FacingDirection = mouseWorldPosition;
    }
}