﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour {

    public static float distanceTraveled;
    public float acceleration;
    private bool touchingPlatform;
    public Vector3 jumpVelocity;
    public float gameOverY;
    private Vector3 startPosition;
    public Camera cam;
    private Color random;

    void Update() {
        if (touchingPlatform && Input.GetButtonDown("Jump")) {
            GetComponent<Rigidbody>().AddForce(jumpVelocity, ForceMode.VelocityChange);
            touchingPlatform = false;
        }
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        distanceTraveled = transform.localPosition.x;

        if (transform.localPosition.y < gameOverY) {
            GameEventManager.TriggerGameOver();
        }
    }

    void FixedUpdate(){
        if (touchingPlatform)
        {
            GetComponent<Rigidbody>().AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);
        }
    }

    void OnCollisionEnter() {
        touchingPlatform = true;
    }

    void OnCollisionExit() {
        touchingPlatform = false;
    }

    void Start() {
        cam = Camera.main;
        cam.clearFlags = CameraClearFlags.SolidColor;
        cam.backgroundColor = new Color32(140, 174, 250, 255);
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        startPosition = transform.localPosition;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }

    private void GameStart() {
        random = new Color32((byte)Random.Range(100, 150), (byte)Random.Range(100, 170), (byte)Random.Range(200, 255), 255);
        cam.backgroundColor = random;
        distanceTraveled = 0f;
        transform.localPosition = startPosition;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        enabled = true;
    }

    private void GameOver() {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        enabled = false;
    }
}