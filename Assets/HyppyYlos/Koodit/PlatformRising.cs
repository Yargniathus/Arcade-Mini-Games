﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRising: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Transform>().Translate(0f, Time.deltaTime * 0.3f + (TimeCounter.Timer*0.001f), 0f);
    }
}
