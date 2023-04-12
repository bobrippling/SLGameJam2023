using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGraphicController : MonoBehaviour {
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private SpriteRenderer targetGraphic;

    // Start is called before the first frame update
    private void Start() {
        UniverseManager.Instance.OnUniverseChange.AddListener(HandleUniverseChange);
        targetGraphic.sprite = sprites[UniverseManager.Instance.currentUniverse];
    }

    // Update is called once per frame
    private void HandleUniverseChange(int universe) {
        if (universe > sprites.Count) {
            return;
        }

        targetGraphic.sprite = sprites[universe];
    }
}