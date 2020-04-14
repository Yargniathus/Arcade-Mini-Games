using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistMovemeNyrkki : MonoBehaviour
{
    bool LeftMovingUp;
    bool RightMovingUp;
    bool MovingMiddle;
    public GameObject LeftFist;
    public GameObject RightFist;
    // Start is called before the first frame update
    void Start()
    {
        LeftMovingUp = false;
        RightMovingUp = false;
        MovingMiddle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftPunch();
        }
    }

    void LeftPunch()
    {
        LeftMovingUp = true;
        
    }
}
