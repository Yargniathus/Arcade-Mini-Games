using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTrackerLabyrintti : MonoBehaviour
{
    public static int MainCharLabyrinttiX;
    public static int MainCharLabyrinttiY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        MainCharLabyrinttiX = Mathf.CeilToInt(transform.position.x);
        MainCharLabyrinttiY = Mathf.FloorToInt(transform.position.y);
        
    }
}
