using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.gameObject.tag == "Player")
        {
           PlayerPrefs.SetFloat("points", TimeCounter.Timer);
           PlayerPrefs.SetString("reasonOfDeath", "You have become one with lava!");
           StartCoroutine(LavaSoundCoroutine());
           
           
        }
    }
    IEnumerator LavaSoundCoroutine()
    {
        
        GameObject.Find("SoundObject").GetComponents<AudioSource>()[0].Play();
     
        yield return new WaitForSeconds(3);
       
        SceneManager.LoadScene("HyppyYlosEnd");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
