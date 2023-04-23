using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : Singleton<ScoreController> {
    [SerializeField] private TextMeshProUGUI scoreText;
    private int Score = 0, LastScore = -1;

    private void Start() {
    }

    private void Update() {
        if (LastScore == Score) return;
        LastScore = Score;

        scoreText.SetText("Score: " + Score);
    }

    public void OnAIDeath() {
        Score += 1;
    }
}