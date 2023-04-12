using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    enum State {
        ClosingIn,
        BackingOff,
        Circling,
    }

    void Start() {

    }

    void Update() {
        var player = PlayerInput.Instance;
        if(!player) return;
        
        var angleToPlayer = Mathf.Atan2(
            player.transform.position.y - transform.position.y,
            player.transform.position.x - transform.position.x
        ) * Mathf.Rad2Deg - 90;
        
        GetComponent<CharacterController>().FacingAt = player.transform.position;
    }
}
