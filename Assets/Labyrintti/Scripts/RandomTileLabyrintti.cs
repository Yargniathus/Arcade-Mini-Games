using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomTileLabyrintti : MonoBehaviour
{
    public Tilemap GroundTileMap;
    public Tilemap WaterTileMap;
    public Tilemap FinishTileMap;
    public Tile VerticalTile;
    public Tile HorizontalRightToLeft;
    public Tile HorizontalLeftToRight;
    public Tile DownToRightTile;
    public Tile DownToLeftTile;
    public Tile LeftToDownTile;
    public Tile RightToDownTile;
    public Tile WaterTile;
    public Tile FinishTile;
    public static Tile EmptyTile;
    private int yValue;
    private int xValue;
    public Tile LastPlacedTile;
    private int leftEdgeValue;
    private int rightEdgeValue;
    private int bottomEdgeValue;
    private bool allTilesGenerated;
 
    void Start()
    {
        
        xValue = -1;
        yValue = PlayerPrefs.GetInt("LabyrinttiLevel");
        leftEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")*-1-1;
        rightEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")-2;
        bottomEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")*-1-1;
        float cameraSize = this.GetComponent<Camera>().orthographicSize;
        this.GetComponent<Camera>().orthographicSize = cameraSize + PlayerPrefs.GetInt("LabyrinttiLevel")-2;
        LastPlacedTile = EmptyTile;
        allTilesGenerated = false;

    }

    void Update()
    {
        if ( allTilesGenerated!=true)
        {
            var tile = GetNextTile();
            WaterTileMap.SetTile(new Vector3Int(xValue, yValue, 0), null);
            GroundTileMap.SetTile(new Vector3Int(xValue, yValue, 0), tile);           
            LastPlacedTile = tile;
            if (LastPlacedTile==VerticalTile || LastPlacedTile == LeftToDownTile || LastPlacedTile == RightToDownTile)
            {
                yValue -= 1;
                if (yValue == bottomEdgeValue)
                {
                    WaterTileMap.SetTile(new Vector3Int(xValue, yValue, 0), null);
                    FinishTileMap.SetTile(new Vector3Int(xValue, yValue, 0), FinishTile);                
                    allTilesGenerated = true;
                }
                
            }
            if (LastPlacedTile==HorizontalRightToLeft || LastPlacedTile== DownToLeftTile)
            {
                xValue -= 1;
            }
            if(LastPlacedTile==HorizontalLeftToRight || LastPlacedTile == DownToRightTile)
            {
                xValue += 1;
            }
        }
    }
    private Tile GetNextTile()
    {
        Tile tileToBePlaced = EmptyTile;

        if (LastPlacedTile==EmptyTile || LastPlacedTile == VerticalTile || LastPlacedTile == LeftToDownTile || LastPlacedTile == RightToDownTile)
        {
            if (xValue < rightEdgeValue && xValue > leftEdgeValue)
            {
                int rnd = Random.Range(1, 4);
                switch (rnd)
                {
                    case 1:
                        tileToBePlaced = VerticalTile;
                        break;

                    case 2:
                        if (LastPlacedTile != LeftToDownTile)
                        {
                            tileToBePlaced = DownToLeftTile;
                        }
                        else { tileToBePlaced = VerticalTile; }
                        break;
                    case 3:
                        if (LastPlacedTile != RightToDownTile)
                        {
                            tileToBePlaced = DownToRightTile;
                        }
                        else { tileToBePlaced = VerticalTile; }
                        break;
                }
            }
            else if(xValue == rightEdgeValue)
            {
                int rnd = Random.Range(1, 3);
                switch (rnd)
                {
                    case 1:
                        tileToBePlaced = VerticalTile;
                        break;
                    case 2:
                        if (LastPlacedTile == EmptyTile || LastPlacedTile == VerticalTile)
                        {
                            tileToBePlaced = DownToLeftTile;
                        }
                        else tileToBePlaced = VerticalTile;
                        break;
                }
            } else { int rnd = Random.Range(1, 3);
            switch (rnd)
                {
                    case 1:
                        tileToBePlaced = VerticalTile;
                    break;

                    case 2:
                        if (LastPlacedTile == EmptyTile || LastPlacedTile == VerticalTile)
                        {
                            tileToBePlaced = DownToRightTile;
                        }
                        else tileToBePlaced = VerticalTile;
                    break;
                }

            }

        }
        if (LastPlacedTile == HorizontalRightToLeft || LastPlacedTile == DownToLeftTile)
        {
            
            if (xValue > leftEdgeValue)
            {
                int rnd = Random.Range(1, 3);
                switch (rnd)
                {
                    case 1:
                        tileToBePlaced = HorizontalRightToLeft;
                        break;

                    case 2:
                        tileToBePlaced = RightToDownTile;
                        break;
                }
            }
            else { tileToBePlaced = RightToDownTile; }
        }
        if (LastPlacedTile == HorizontalLeftToRight || LastPlacedTile == DownToRightTile)
        {
            if (xValue < rightEdgeValue)
            {
                
                int rnd = Random.Range(1, 3);
                switch (rnd)
                {
                    case 1:
                        tileToBePlaced = HorizontalLeftToRight;
                        break;

                    case 2:
                        tileToBePlaced = LeftToDownTile;
                        break;
                }
            }
            else { tileToBePlaced = LeftToDownTile; }
        }

        return tileToBePlaced;
    }
}
