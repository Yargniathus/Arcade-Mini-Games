﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Xamk.GymApi;
using System.Threading;

public class EndScriptNyrkki : MonoBehaviour
{
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    // Start is called before the first frame update
    void Start()
    {
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener((HurObject.Machine)PlayerPrefs.GetInt("SelectedMachine"));
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        int endScoreNyrkki = PlayerPrefs.GetInt("NyrkkiPoints");
        int highScoreNyrkki = PlayerPrefs.GetInt("NyrkkiHighScore");
        this.GetComponent<Text>().text = "SCORE: " + endScoreNyrkki.ToString();
        if (endScoreNyrkki>highScoreNyrkki)
        {
            GameObject.Find("ReachedHighScore").GetComponent<Text>().text = "NEW HIGH SCORE!";
            PlayerPrefs.SetInt("NyrkkiHighScore", endScoreNyrkki);
            highScoreNyrkki = PlayerPrefs.GetInt("NyrkkiHighScore");

        }
        GameObject.Find("HighScore").GetComponent<Text>().text = "HI-SCORE: " + highScoreNyrkki.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            gymMachineListener.SimulateRightRep(1, 20, 500);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gymMachineListener.SimulateLeftRep(1, 20, 500);

        }
    }
    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousModeNyrkki"));
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }
}

