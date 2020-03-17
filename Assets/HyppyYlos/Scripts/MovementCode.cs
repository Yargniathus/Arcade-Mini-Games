using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCode : MonoBehaviour
{
    // Start is called before the first frame update

    private float forceOfMovement = 200000f;
    
    private Rigidbody2D rigBdy;
    void Start()
    {
        rigBdy = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //liikkeenVastavoima = -rigBdy.velocity;
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
