using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    public void OnPlayerDeath() {
        Debug.Log("Player dead");
        ReloadLevel();
    }

    public void ReloadLevel() {
        SceneManager.LoadScene("GamingTestScene");
    }
}