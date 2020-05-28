using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Xamk.GymApi;
using System.Threading;

public class MenuNyrkkiModeScript : MonoBehaviour
{
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    private int chosenMenuOption;
    private int maxMenuOption;
    Outline mode1;
    Outline mode2;
    Outline mode3;
    Text mode1Instruction;
    Text mode2Instruction;
    Text mode3Instruction;
    private bool isTimerRunnig = false;
    private float combinedPullTimeDelay = 0.350f;
    private float targetTime = 0f;
    private bool isLeftRep = false;
    private bool isRightRep = false;
    private bool confirmingSelection = false;


    void Start()
    {
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener((HurObject.Machine)PlayerPrefs.GetInt("SelectedMachine"));
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        chosenMenuOption = 0;
        maxMenuOption = 2;
        mode1 = GameObject.Find("Mode1").GetComponent<Outline>();
        mode2 = GameObject.Find("Mode2").GetComponent<Outline>();
        mode3 = GameObject.Find("Mode3").GetComponent<Outline>();
        mode1Instruction = GameObject.Find("StandardText").GetComponent<Text>();
        mode2Instruction = GameObject.Find("EndlessText").GetComponent<Text>();
        mode3Instruction = GameObject.Find("UncensoredText").GetComponent<Text>();


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
            if (gymMachineListener != null) cancelTokenSource.Cancel();

            if (mode1.enabled == true)
            {
                SceneManager.LoadScene("NyrkkiMain");
            }
            else if (mode2.enabled == true)
            {
                SceneManager.LoadScene("NyrkkiEndless");
            }
            else if(mode3.enabled == true)
            {
                SceneManager.LoadScene("NyrkkiUncensored");
            }

        }
       
        switch (chosenMenuOption)
        {
            case 0:
                mode1.enabled = true;
                mode1Instruction.enabled = true;
                mode2.enabled = false;
                mode2Instruction.enabled = false;
                mode3.enabled = false;
                mode3Instruction.enabled = false;
                break;
            case 1:
                mode1.enabled = false;
                mode1Instruction.enabled = false;
                mode2.enabled = true;
                mode2Instruction.enabled = true;
                mode3.enabled = false;
                mode3Instruction.enabled = false;
                break;
            case 2:
                mode1.enabled = false;
                mode1Instruction.enabled = false;
                mode2.enabled = false;
                mode2Instruction.enabled = false;
                mode3.enabled = true;
                mode3Instruction.enabled = true;
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
