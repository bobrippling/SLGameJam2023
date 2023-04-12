using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    [SerializeField] private GameObject GameOverCanvas;

    public void Start() {
        GameOverCanvas.SetActive(false);
    }

    public void OnPlayerDeath() {
        Debug.Log("Player dead");

        GameOverCanvas.SetActive(true);
    }

    public void ReloadLevel() {
        SceneManager.LoadScene("GamingTestScene");
    }
}