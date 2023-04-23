using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInput : MonoBehaviour {

    private enum AIState {
        ClosingIn,
        BackingOff,
        Circling,
    }

    private AIState State = AIState.ClosingIn;
    private CharacterController Character;
    private float waitTimeRemaining;
    private float circlingAngle;

    private void Start() {
        Character = GetComponent<CharacterController>();
    }

    private void Update() {
        var player = PlayerInput.Instance;

        if (!player) return;

        FacePlayer(player);
        UpdateState(player);
        ApplyState(player);
    }

    private void FacePlayer(PlayerInput player) {
        var angleToPlayer = Mathf.Atan2(
            player.transform.position.y - transform.position.y,
            player.transform.position.x - transform.position.x
        ) * Mathf.Rad2Deg - 90;

        Character.FacingAt = player.transform.position;
    }

    private void UpdateState(PlayerInput player) {
        var distanceToPlayer = (player.transform.position - transform.position).magnitude;

        // states that we want to stay in for a while
        if (waitTimeRemaining > 0) {
            waitTimeRemaining -= Time.deltaTime;
            if (waitTimeRemaining < 0) {
                switch (State) {
                    case AIState.Circling:
                        //Debug.Log("backing off (timeout)");
                        State = AIState.BackingOff;
                        waitTimeRemaining = 3;
                        break;
                    case AIState.BackingOff:
                        //Debug.Log("closing in (timeout)");
                        State = AIState.ClosingIn;
                        // and maybe go straight to circling
                        break;
                }
            }
            return;
        }

        // states based on distances
        if (distanceToPlayer < 3) {
            State = AIState.BackingOff;
            //Debug.Log("backing off (distance)");
        } else if (distanceToPlayer < 6) {
            //Debug.Log("circling (distance)");
            State = AIState.Circling;

            circlingAngle = Random.value > 0.5
                ? Mathf.PI / 2
                : 3 * Mathf.PI / 2;

            waitTimeRemaining = 2;
        } else if (distanceToPlayer > 9) {
            //Debug.Log("closing in (distance)");
            State = AIState.ClosingIn;
        }
    }

    private void ApplyState(PlayerInput player) {
        var vecToPlayer = (player.transform.position - transform.position).normalized;

        switch (State) {
            case AIState.ClosingIn:
                Character.MovementDirection = vecToPlayer;
                break;

            case AIState.BackingOff:
                Character.MovementDirection = -vecToPlayer;
                break;

            case AIState.Circling:
                var angle = Mathf.Atan2(vecToPlayer.y, vecToPlayer.x) + circlingAngle;
                Character.MovementDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                // bullet flight time to player
                var t = (player.transform.position - transform.position).magnitude / ProjectileController.DEFAULT_SPEED;

                // player pos at that time
                var movementDir = new Vector3(player.Character.MovementDirection.x, player.Character.MovementDirection.y, 0);
                var futurePos = player.transform.position
                    + CharacterController.SPEED * movementDir * t;

                // crack out a bullet to that position
                var aim = (futurePos - transform.position).normalized;
                GetComponent<AttackController>().Shoot();
                break;
        }
    }
}
