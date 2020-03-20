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
            float currentTime = TimeCounter.Timer;
            PlayerPrefs.SetFloat("points", currentTime);

           PlayerPrefs.SetString("reasonOfDeath", "You have become one with lava!");
            if (HighScoreTrackerHyppyYlos.IsHighScore == true)
            {
                PlayerPrefs.SetFloat("highscore", currentTime);
            }

            StartCoroutine(LavaSoundCoroutine());
           
           
        }
    }
    IEnumerator LavaSoundCoroutine()
    {
        Color roastedColor = new Color(0.9f, 0.5f, 0.5f);
        GameObject player = GameObject.Find("stickfigure");
        GameObject.Find("SoundObject").GetComponents<AudioSource>()[0].Play();
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<Animator>().SetBool("IsDead", true);
        player.GetComponent<SpriteRenderer>().color = roastedColor;


         


        yield return new WaitForSeconds(3);
       
        SceneManager.LoadScene("HyppyYlosEnd");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
