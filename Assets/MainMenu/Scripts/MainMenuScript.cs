using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Xamk.GymApi;
using System.Threading;

public class MainMenuScript : MonoBehaviour
{
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    private int chosenMenuOption;
    private int maxMenuOption;
    Outline game1;
    Outline game2;
    Outline game3;
    Image background1;
    Image background2;
    Image background3;
    Image background4;
    Outline credits;
    private bool isTimerRunnig = false;
    private float combinedPullTimeDelay = 0.350f;
    private float targetTime = 0f;
    private bool isLeftRep = false;
    private bool isRightRep = false;
    private bool confirmingSelection = false;


    void Start()
    {
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener(HurObject.Machine.OptimalRhomb);
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        chosenMenuOption = 0;
        maxMenuOption = 3;
        game1 = GameObject.Find("Game1").GetComponent<Outline>();
        game2 = GameObject.Find("Game2").GetComponent<Outline>();
        game3 = GameObject.Find("Game3").GetComponent<Outline>();
        background1 = GameObject.Find("Background1").GetComponent<Image>();
        background2 = GameObject.Find("Background2").GetComponent<Image>();
        background3 = GameObject.Find("Background3").GetComponent<Image>();
        background4 = GameObject.Find("Background4").GetComponent<Image>();

        credits = GameObject.Find("Credits").GetComponent<Outline>();

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
        if (Input.GetKeyDown(KeyCode.DownArrow) || confirmingSelection)
        {
            if (game1.enabled == true)
            {
                SceneManager.LoadScene("HyppyYlosMain");
            }
            else if (game2.enabled == true)
            {
                PlayerPrefs.SetInt("LabyrinttiLevel", 1);
                SceneManager.LoadScene("LabyrinttiRandomLevel");
            }
            else if(game3.enabled == true)
            {
                SceneManager.LoadScene("MenuNyrkkiMode");
            }
            else if (credits.enabled == true)
            {
                //Not implemented yet
                //SceneManager.LoadScene("Credits");
            }
        }
       
        switch (chosenMenuOption)
        {
            case 0:
                game1.enabled = true;
                game2.enabled = false;
                game3.enabled = false;
                background1.enabled = true;
                background2.enabled = false;
                background3.enabled = false;
                background4.enabled = false;
                credits.enabled = false;
                break;
            case 1:
                game1.enabled = false;
                game2.enabled = true;
                game3.enabled = false;
                background1.enabled = false;
                background2.enabled = true;
                background3.enabled = false;
                background4.enabled = false;
                credits.enabled = false;
                break;
            case 2:
                game1.enabled = false;
                game2.enabled = false;
                game3.enabled = true;
                background1.enabled = false;
                background2.enabled = false;
                background3.enabled = true;
                background4.enabled = false;
                credits.enabled = false;
                break;
            case 3:
                game1.enabled = false;
                game2.enabled = false;
                game3.enabled = false;
                background1.enabled =false;
                background2.enabled = false;
                background3.enabled = false;
                background4.enabled = true;
                credits.enabled = true;
                break;

        }
        HandleRepetitionLogic();
    }
    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {
        isTimerRunnig = true;
        isLeftRep = true;
        StartCoroutine(LeftDelay());



    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        isTimerRunnig = true;
        isRightRep = true;
        StartCoroutine(RightDelay());

    }
    private void HandleRepetitionLogic()
    {
        if (isTimerRunnig)
        {
            targetTime += Time.deltaTime;

            if (targetTime >= combinedPullTimeDelay)
            {       
                isTimerRunnig = false;
                targetTime = 0;
            }

            if (isLeftRep && isRightRep)
            {
                confirmingSelection = true;
                isTimerRunnig = false;
                targetTime = 0;
            }
        }
    }
    IEnumerator LeftDelay()
    {

        yield return new WaitForSeconds(combinedPullTimeDelay);
        if (!isRightRep)
        {
            if (chosenMenuOption > 0)
            {
                chosenMenuOption--;
            }
            else
            {
                chosenMenuOption = maxMenuOption;
            }
        }
        isLeftRep = false;

}
IEnumerator RightDelay()
{

        yield return new WaitForSeconds(combinedPullTimeDelay);
        if (!isLeftRep)
        {
            if (chosenMenuOption < maxMenuOption)
            {
                chosenMenuOption++;
            }
            else
            {
                chosenMenuOption = 0;
            }
        }
        isRightRep = false;

    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }
}
