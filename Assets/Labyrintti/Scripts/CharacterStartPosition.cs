using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStartPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var pos = this.transform.position;
        pos.y += PlayerPrefs.GetInt("LabyrinttiLevel");
        this.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
