﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Xamk.GymApi;
using System.Threading;

public class EndScriptLabyrintti : MonoBehaviour
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
        PlayerPrefs.SetInt("LabyrinttiLevel", 1);
        SceneManager.LoadScene("MainMenu");
    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LabyrinttiMode"));
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }
}
