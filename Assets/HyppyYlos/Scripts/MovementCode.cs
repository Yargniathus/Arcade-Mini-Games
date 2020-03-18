using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCode : MonoBehaviour
{
    // Start is called before the first frame update

    private float forceOfMovement = 200000f;
    
    private Rigidbody2D rigBdy;
    public static Animator MainCharAnimator;
    void Start()
    {
        rigBdy = this.GetComponent<Rigidbody2D>();
        MainCharAnimator = this.GetComponent<Animator>();
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
            rigBdy.AddForce(Vector2.right * this.forceOfMovement * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigBdy.velocity = Vector2.zero;
            rigBdy.AddForce(Vector2.left * this.forceOfMovement * Time.deltaTime);
        }
    }
    
}
