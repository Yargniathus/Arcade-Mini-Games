using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class DeathScriptLabyrintti : MonoBehaviour
{
   
    
    public AnimatedTile tile;
    public Tilemap tileMap;
     
    void Start()
    {
        
        
    }


    void Update()
    {
        Vector3Int currentCell = tileMap.WorldToCell(transform.position);
       currentCell.x += 1;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            
            tileMap.SetTile(new Vector3Int(1, 1, 0), tile);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            Debug.Log("Collsiion");
            SceneManager.LoadScene("LabyrinttiGameOver");
        }
    }
}
