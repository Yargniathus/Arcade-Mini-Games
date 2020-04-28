using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Xamk.GymApi;
using System.Threading;

public class FistMovemeNyrkki : MonoBehaviour
{
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;
    bool LeftMovingUp;
    bool RightMovingUp;
    bool MovingMiddle;
    public GameObject LeftFist;
    public GameObject RightFist;
    public GameObject Lightning;


    private bool isTimerRunnig = false;
    private float combinedPullTimeDelay = 0.350f;
    private float targetTime = 0f;
    private bool isLeftRep = false;
    private bool isRightRep = false;

    // Start is called before the first frame update
    void Start()
    {
        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener(HurObject.Machine.OptimalRhomb);
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);
        LeftMovingUp = false;
        RightMovingUp = false;
        MovingMiddle = false;
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovingMiddle = true;
        }
        LeftPunch();
        RightPunch();
        MiddlePunch();
        FistAnimationController();

        HandleRepetitionLogic();
    }

    private void HandleRepetitionLogic()
    {
        if (isTimerRunnig)
        {
            targetTime += Time.deltaTime;

            if (targetTime >= combinedPullTimeDelay)
            {
                RightMovingUp = isRightRep;
                LeftMovingUp = isLeftRep;
                isTimerRunnig = false;
                targetTime = 0;
            }

            if (isLeftRep && isRightRep)
            {
                MovingMiddle = true;
                isTimerRunnig = false;
                targetTime = 0;
            }
        }
    }

    private double leftLoad = 0;

    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {
        leftLoad = e.Load;

        isTimerRunnig = true;
        isLeftRep = true;
    }
    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        isTimerRunnig = true;
        isRightRep = true;
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
            isLeftRep = false;
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
            isRightRep = false;
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
            Instantiate(Lightning, new Vector3(0, 2, 0), Quaternion.identity);
            MovingMiddle = false;
            isLeftRep = false;
            isRightRep = false;
        }
        if (MovingMiddle == false && LeftFist.GetComponent<Transform>().position.x > -5)
        {
            LeftFist.transform.Translate(new Vector3(25f * Time.deltaTime, 0, 0));
            RightFist.transform.Translate(new Vector3(25f * Time.deltaTime, 0, 0));
        }
    }
    void FistAnimationController()
    {
        if (LeftFist.GetComponent<Transform>().position.x > -4)
        {
            LeftFist.GetComponent<Animator>().SetBool("FistIsOnSide", false);
            RightFist.GetComponent<Animator>().SetBool("FistIsOnSide", false);
        }
        else
        {
            LeftFist.GetComponent<Animator>().SetBool("FistIsOnSide", true);
            RightFist.GetComponent<Animator>().SetBool("FistIsOnSide", true);
        }
    }
    private void OnDestroy()
    {
        if (gymMachineListener != null) cancelTokenSource.Cancel();
    }


}
