using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour {
    [SerializeField] private float lifeTime = 0.5f;

    // Start is called before the first frame update
    private void Start() {
        Destroy(gameObject, lifeTime);
    }
}