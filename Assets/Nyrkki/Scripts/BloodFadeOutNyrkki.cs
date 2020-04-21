using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodFadeOutNyrkki : MonoBehaviour
{
    private float alphaColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alphaColor = this.gameObject.GetComponent<Image>().color.a;
        this.gameObject.GetComponent<Image>().color = new Color(1,1,1,alphaColor-0.5f*Time.deltaTime);

    }
}
