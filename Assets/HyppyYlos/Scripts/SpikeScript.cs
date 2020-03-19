using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
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
            PlayerPrefs.SetString("reasonOfDeath", "You've been brutally impaled by a stalagmite.");
            StartCoroutine(SpikeSoundCoroutine());

            
        }
    }
    IEnumerator SpikeSoundCoroutine()
    {
        GameObject player = GameObject.Find("stickfigure");
        GameObject.Find("SoundObject").GetComponents<AudioSource>()[1].Play();
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        player.GetComponent<Animator>().SetBool("IsDead", true);




        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("HyppyYlosEnd");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
