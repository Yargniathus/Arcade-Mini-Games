using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Xamk.GymApi;

public class MovementCode : MonoBehaviour
{
    // Start is called before the first frame update

    private float forceOfMovement = 200000f;

    //values here should be between 1+(gymEquipmentMinPower/gymEquipmentMaxpower*4) and 1+(gymEquipmentMaxPower/gymEquipmentMaxpower*4)
    private float gymControlMovementPower = 1f;
    
    private Rigidbody2D rigBdy;
    private CancellationTokenSource cancelTokenSource;
    private GymMachineListener gymMachineListener;

    public static Animator MainCharAnimator;


    void Start()
    {
        rigBdy = this.GetComponent<Rigidbody2D>();
        MainCharAnimator = this.GetComponent<Animator>();

        cancelTokenSource = new CancellationTokenSource();
        gymMachineListener = new GymMachineListener((HurObject.Machine)PlayerPrefs.GetInt("SelectedMachine"));
        gymMachineListener.LeftRepHandler += LeftRepHandler;
        gymMachineListener.RightRepHandler += RightRepHandler;
        gymMachineListener.StartListener(cancelTokenSource.Token);

    }

    private void LeftRepHandler(object sender, LeftRepEventArgs e)
    {
        rigBdy.velocity = Vector2.zero;
        rigBdy.AddForce(Vector2.left * (this.forceOfMovement * 1) * Time.deltaTime);
    }

    private void RightRepHandler(object sender, RightRepEventArgs e)
    {
        rigBdy.velocity = Vector2.zero;
        rigBdy.AddForce(Vector2.right * (this.forceOfMovement * 1) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rigBdy.velocity.x < -0.1)
        {
            MainCharAnimator.SetBool("LastMovementRight", false);
            MainCharAnimator.SetBool("IsMoving", true);
        }
        if (rigBdy.velocity.x > 0.1)
        {
            MainCharAnimator.SetBool("LastMovementRight", true);
            MainCharAnimator.SetBool("IsMoving", true);
        }
        if (rigBdy.velocity.x >= -0.1 && rigBdy.velocity.x <= 0.1)
        {
            MainCharAnimator.SetBool("IsMoving", false);
        }
        if (rigBdy.velocity.y <0)
        {
            MainCharAnimator.SetBool("IsInAir", true);
        }
        else
        {
            MainCharAnimator.SetBool("IsInAir", false);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigBdy.velocity = Vector2.zero;
            rigBdy.AddForce(Vector2.right * (this.forceOfMovement*gymControlMovementPower) * Time.deltaTime);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigBdy.velocity = Vector2.zero;
            rigBdy.AddForce(Vector2.left * (this.forceOfMovement*gymControlMovementPower) * Time.deltaTime);
        }
    }

    private void OnDestroy()
    {
        if (gymMachineListener != null)
        {
            //Kills the UDP message listening thread 
            cancelTokenSource.Cancel();
        }
    }

}
