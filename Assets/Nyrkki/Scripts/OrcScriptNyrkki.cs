using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcScriptNyrkki : MonoBehaviour
{
    bool reachedTop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Transform>().position.y >= 2)
        {
            reachedTop = true;
        }

        if (this.gameObject.GetComponent<Transform>().position.y >=0)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        ClimbingUp();
    }

    void ClimbingUp()
    {
        if (!reachedTop)
        {
            this.gameObject.transform.Translate(new Vector3(0, 2 * Time.deltaTime));
        }
    }
}
