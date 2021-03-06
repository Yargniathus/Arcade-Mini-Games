﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreMultiplierNyrkki : MonoBehaviour
{
    public static float ScoreMultiplier;
    public static int KillCounter;
    private GameObject multiplierText = null;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        this.multiplierText = GameObject.Find("Multiplier");
        ScoreMultiplier = 1;
        KillCounter = 0;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "NyrkkiEndless")
        {
            this.multiplierText.GetComponent<Text>().text = "Multiplier: " + ScoreMultiplier;
        }

        if (KillCounter > 0 && Math.Abs((KillCounter / 5f) % 1f) == 0)
        {
            ScoreMultiplier = 1f + (KillCounter / 5f);
        }
        else if(KillCounter < 5)
        {
            ScoreMultiplier = 1;
        }
    }
}
