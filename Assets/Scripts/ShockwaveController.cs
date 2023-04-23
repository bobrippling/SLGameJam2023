using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveController : MonoBehaviour {
    [SerializeField] private float shockwaveTime = 0.75f;

    private Material material;

    private static int waveDistance = Shader.PropertyToID("_WaveDistance");

    private float startDis = -0.1f;
    private float endDis = 1f;

    private float elapsedTime = 0f;
    private float lerpedAmount = 0f;

    private void Awake() {
        material = GetComponent<SpriteRenderer>().material;
        material.SetFloat(waveDistance, startDis);
    }

    public void Update() {
        elapsedTime += Time.deltaTime;
        lerpedAmount = Mathf.Lerp(startDis, endDis, elapsedTime / shockwaveTime);

        material.SetFloat(waveDistance, lerpedAmount);
    }
}