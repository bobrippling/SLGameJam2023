using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    enum AIState {
        ClosingIn,
        BackingOff,
        Circling,
    }

    AIState State = AIState.ClosingIn;
    CharacterController Character;

    void Start() {
        Character = GetComponent<CharacterController>();
    }

    void Update() {
        var player = PlayerInput.Instance;

        FacePlayer(player);
        UpdateState(player);
        ApplyState(player);
    }

    void FacePlayer(PlayerInput player) {
        var angleToPlayer = Mathf.Atan2(
            player.transform.position.y - transform.position.y,
            player.transform.position.x - transform.position.x
        ) * Mathf.Rad2Deg - 90;

        Character.FacingAt = player.transform.position;
    }

    void UpdateState(PlayerInput player) {
        var distanceToPlayer = (player.transform.position - transform.position).magnitude;

        if (distanceToPlayer < 3) {
            State = AIState.BackingOff;
        } else if (distanceToPlayer < 6) {
            State = AIState.Circling;
        } else if (distanceToPlayer > 9) {
            State = AIState.ClosingIn;
        }
    }

    void ApplyState(PlayerInput player) {
        var vecToPlayer = (player.transform.position - transform.position).normalized;

        switch (State) {
            case AIState.ClosingIn:
                Character.MovementDirection = vecToPlayer;
                break;

            case AIState.BackingOff:
                Character.MovementDirection = -vecToPlayer;
                break;

            case AIState.Circling:
                var angle = Mathf.Atan2(vecToPlayer.y, vecToPlayer.x);
                angle += Mathf.PI / 2; // right angles to the player
                Character.MovementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // bullet flight time to player
                var t = (player.transform.position - transform.position).magnitude / ProjectileController.DEFAULT_SPEED;

                // player pos at that time
                var movementDir = new Vector3(player.Character.MovementDirection.x, player.Character.MovementDirection.y, 0);
                var futurePos = player.transform.position
                    + CharacterController.SPEED * movementDir * t;

                // crack out a bullet to that position
                var aim = (futurePos - transform.position).normalized;
                GetComponent<AttackController>().Shoot(aim);
                break;
        }
    }
}
