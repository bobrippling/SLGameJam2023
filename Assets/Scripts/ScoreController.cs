using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int Score;

    void Start() {
    }

    void Update() {
        scoreText.SetText("Score: " + Score);
    }


}
