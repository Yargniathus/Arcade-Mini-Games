using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Xamk.GymApi;
using System.Threading;

public class EndScore : MonoBehaviour
{
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    // Start is called before the first frame update
    void Start()
    {
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener(HurObject.Machine.OptimalRhomb);
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        float endScore = PlayerPrefs.GetFloat("points");
        string endReasonOfDeath = PlayerPrefs.GetString("reasonOfDeath");
        float highScore = PlayerPrefs.GetFloat("highscore");

        GameObject.Find("deathreason").GetComponent<Text>().text = endReasonOfDeath;
        this.GetComponent<Text>().text = "Score: " + endScore.ToString("0");
        GameObject.Find("highscore").GetComponent<Text>().text = "High Score: " + highScore.ToString("0");
        if (endScore == highScore)
        {
            GameObject.Find("reachedhighscore").GetComponent<Text>().text = "NEW HIGH SCORE!";
           

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gymMachineListener.SimulateLeftRep(1, 20, 500);
          
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gymMachineListener.SimulateRightRep(1, 20, 500);
          
        }
    }
    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {

        SceneManager.LoadScene("MainMenu");
    }
    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        SceneManager.LoadScene("HyppyYlosMain");
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }
}
