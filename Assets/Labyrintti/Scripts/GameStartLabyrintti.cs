using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Xamk.GymApi;
using System.Threading;

public class GameStartLabyrintti : MonoBehaviour
{
    public static bool LabyrinttiGameStarted;
    GameObject instructions;
    GameObject instructionScreen;
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    GameObject labyrinttiPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
        LabyrinttiGameStarted = false;
        this.instructions = GameObject.Find("Instructions");
        this.instructionScreen = GameObject.Find("InstructionScreen");
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener((HurObject.Machine)PlayerPrefs.GetInt("SelectedMachine"));
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        labyrinttiPlayer = GameObject.Find("Snake");
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
        StartCoroutine(ExecuteAfterTime());
    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        StartCoroutine(ExecuteAfterTime());
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }

    IEnumerator ExecuteAfterTime()
    {
        this.instructions.GetComponent<Text>().text = "";
        Destroy(this.instructionScreen);

        yield return new WaitForSeconds(0.5f);
        labyrinttiPlayer.GetComponent<BoxCollider2D>().enabled = true;
        LabyrinttiGameStarted = true;
    }
}
