using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // spawner properties
    [SerializeField] private float COOLDOWN;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private List<Sprite> sprites;

    // spawned AI properties
    [SerializeField] private float attackCooldownBlue;
    [SerializeField] private float attackCooldownGreen;
    [SerializeField] private float attackCooldownRed;
    [SerializeField] private int damageBlue;
    [SerializeField] private int damageGreen;
    [SerializeField] private int damageRed;
    [SerializeField] private AudioClip shootBlueClip;
    [SerializeField] private AudioClip shootGreenClip;
    [SerializeField] private AudioClip shootRedClip;

    private float cooldown = 0;

    void Start() {
    }

    void Update() {
        cooldown -= Time.deltaTime;
        if (cooldown > 0) return;

        cooldown = COOLDOWN;

        GameObject newAI = Instantiate(spawnPrefab);

        newAI.transform.position = transform.position;

        var newAIAttackCtrl = newAI.GetComponent<AttackController>();
        var currentUniverse = UniverseManager.Instance.currentUniverse;
        switch (currentUniverse) {
            case 0:
                newAIAttackCtrl.damage = damageBlue;
                newAIAttackCtrl.attackCooldown = attackCooldownBlue;
                newAIAttackCtrl.shootClip = shootBlueClip;
                break;
            case 1:
                newAIAttackCtrl.damage = damageGreen;
                newAIAttackCtrl.attackCooldown = attackCooldownGreen;
                newAIAttackCtrl.shootClip = shootGreenClip;
                break;
            case 2:
                newAIAttackCtrl.damage = damageRed;
                newAIAttackCtrl.attackCooldown = attackCooldownRed;
                newAIAttackCtrl.shootClip = shootRedClip;
                break;
        }

        var newAIBody = newAI.GetComponent<AIGraphicController>();
        newAIBody.targetGraphic.sprite = sprites[currentUniverse];
    }
}
