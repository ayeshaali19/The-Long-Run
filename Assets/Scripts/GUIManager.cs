using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public Text gameOverText, title;
    GameObject button;

    void Start() {
        button = GameObject.Find("Button");
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
        title.enabled = false;
        enabled = false;
    }

    private void GameOver() {
        gameOverText.enabled = true;
        enabled = true;
    }

    public void ButtonClicked() {
        GameEventManager.TriggerGameStart();
        button.SetActive(false);
    }

}
