using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptLabyrintti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position = new Vector2(this.transform.position.x+1, this.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position = new Vector2(this.transform.position.x + -1, this.transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y-1);
        }
    }
}
