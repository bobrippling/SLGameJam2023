using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGraphicController : MonoBehaviour {
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private SpriteRenderer targetGraphic;

    private void Start() {
        UniverseManager.Instance.OnUniverseChange.AddListener(HandleUniverseChange);
        targetGraphic.sprite = sprites[UniverseManager.Instance.currentUniverse];
    }

    private void HandleUniverseChange(int universe) {
        if (universe > sprites.Count) {
            return;
        }

        targetGraphic.sprite = sprites[universe];
    }
}
