using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeLabyrintti : MonoBehaviour
{
    public Camera startCamera;
    public Camera gameCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Pimennys").GetComponent<DarknessScriptLabyrintti>().startGameTimer < 0)
        {
            startCamera.enabled = false;
            gameCamera.enabled = true;
        }


    }
}
