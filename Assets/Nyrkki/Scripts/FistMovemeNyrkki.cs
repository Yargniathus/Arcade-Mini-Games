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
            LeftMovingUp = true;
        } 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMovingUp = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovingMiddle = true;
        }
        LeftPunch();
        RightPunch();
        MiddlePunch();
    }

    void LeftPunch()
    {
        if (LeftFist.GetComponent<Transform>().position.y < 0.5 && LeftMovingUp == true)
        {
            LeftFist.transform.Translate(new Vector3(0, 25f * Time.deltaTime, 0));
        }
        if (LeftFist.GetComponent<Transform>().position.y >= 0.5)
        {
            LeftMovingUp = false;
        }
        if (LeftMovingUp == false && LeftFist.GetComponent<Transform>().position.y > -3.5)
        {
            LeftFist.transform.Translate(new Vector3(0, -25f * Time.deltaTime, 0));
        }
    }
    void RightPunch()
    {
        if (RightFist.GetComponent<Transform>().position.y < 0.5 && RightMovingUp == true)
        {
            RightFist.transform.Translate(new Vector3(0, 25f * Time.deltaTime, 0));
        }
        if (RightFist.GetComponent<Transform>().position.y >= 0.5)
        {
            RightMovingUp = false;
        }
        if (RightMovingUp == false && RightFist.GetComponent<Transform>().position.y > -3.5)
        {
            RightFist.transform.Translate(new Vector3(0, -25f * Time.deltaTime, 0));
        }
    }
    void MiddlePunch()
    {
        if (LeftFist.GetComponent<Transform>().position.x < -1 && MovingMiddle == true)
        {
            LeftFist.transform.Translate(new Vector3(-25f * Time.deltaTime,0,  0));
            RightFist.transform.Translate(new Vector3(-25f * Time.deltaTime, 0, 0));
        }
        if (LeftFist.GetComponent<Transform>().position.x >= -1)
        {
            MovingMiddle = false;
        }
        if (MovingMiddle == false && LeftFist.GetComponent<Transform>().position.x > -5)
        {
            LeftFist.transform.Translate(new Vector3(25f * Time.deltaTime, 0, 0));
            RightFist.transform.Translate(new Vector3(25f * Time.deltaTime, 0, 0));
        }
    }


}
