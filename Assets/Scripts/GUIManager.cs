using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public Text gameOverText, title;
    public Button button;

    void Start() {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
        title.enabled = true;
    }

    void Update() {
        button.onClick.AddListener(() => { GameEventManager.TriggerGameStart(); button.gameObject.SetActive(false);});
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
}
