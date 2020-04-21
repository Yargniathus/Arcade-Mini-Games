using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodInstantiateNyrkki : MonoBehaviour
{
    public GameObject bloodSplatter;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OrcHitsPlayer()
    {
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
            var createImage = Instantiate(bloodSplatter) as GameObject;
            createImage.transform.SetParent(canvas.transform, false);
        //}
    }
}
