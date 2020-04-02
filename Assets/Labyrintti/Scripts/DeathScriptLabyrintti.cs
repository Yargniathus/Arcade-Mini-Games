using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class DeathScriptLabyrintti : MonoBehaviour
{
   
    
    public AnimatedTile tileRight;
    public AnimatedTile tileLeft;
    public Tilemap tileMap;
    private GameObject labyrinttiPlayer;
    private bool crocHasSpawned = false;
   
     
    void Start()
    {

        labyrinttiPlayer = GameObject.Find("Snake");
    }


    void Update()
    {
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            StartCoroutine(CrocDelayDeath());
           
        }
    }
    IEnumerator CrocDelayDeath()
    {

        if (labyrinttiPlayer.GetComponent<Animator>().GetBool("MovingRight") == true && crocHasSpawned == false)
        {

            crocHasSpawned = true;
            tileMap.SetTile(new Vector3Int(MovementTrackerLabyrintti.MainCharLabyrinttiX, MovementTrackerLabyrintti.MainCharLabyrinttiY, 0), tileRight);
        }
        if (labyrinttiPlayer.GetComponent<Animator>().GetBool("MovingLeft") == true && crocHasSpawned == false)
        {

            crocHasSpawned = true;
            tileMap.SetTile(new Vector3Int(MovementTrackerLabyrintti.MainCharLabyrinttiX-2, MovementTrackerLabyrintti.MainCharLabyrinttiY, 0), tileLeft);
        }
        if (labyrinttiPlayer.GetComponent<Animator>().GetBool("MovingDown") == true && crocHasSpawned == false)
        {

            crocHasSpawned = true;
            tileMap.SetTile(new Vector3Int(MovementTrackerLabyrintti.MainCharLabyrinttiX-1, MovementTrackerLabyrintti.MainCharLabyrinttiY-1, 0), tileRight);
        }
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("LabyrinttiGameOver");
       

    }
}
