using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public Text gameOverText, title;


    void Start() {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
        title.enabled = true;
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            GameEventManager.TriggerGameStart();
        }
    }

    private void GameStart() {
        gameOverText.enabled = false;
        //instructionsText.enabled = false;
        title.enabled = false;
        enabled = false;
    }


    private void GameOver() {
        gameOverText.enabled = true;
        //instructionsText.enabled = true;
        enabled = true;
    }


}
