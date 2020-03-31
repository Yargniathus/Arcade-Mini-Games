using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartLabyrintti : MonoBehaviour
{
    public static bool LabyrinttiGameStarted;
    GameObject instructions;
    GameObject instructionScreen;
    // Start is called before the first frame update
    void Start()
    {
        LabyrinttiGameStarted = false;
        this.instructions = GameObject.Find("Instructions");
        this.instructionScreen = GameObject.Find("InstructionScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            StartCoroutine(ExecuteAfterTime());
        }

    }

    IEnumerator ExecuteAfterTime()
    {
        this.instructions.GetComponent<Text>().text = "";
        Destroy(this.instructionScreen);

        yield return new WaitForSeconds(0.5f);

        LabyrinttiGameStarted = true;

        
    }
}
