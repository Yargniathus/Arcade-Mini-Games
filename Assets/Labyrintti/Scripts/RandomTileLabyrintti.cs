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
    public Tile TileToBePlaced;
    public Tile LastPlacedTile;
    private int leftEdgeValue;
    private int rightEdgeValue;
    private int bottomEdgeValue;
    private bool allTilesGenerated;
 
    void Start()
    {
        
        xValue = -1;
        yValue = PlayerPrefs.GetInt("LabyrinttiLevel")+1;
        leftEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")*-1-2;
        rightEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")-1;
        bottomEdgeValue = PlayerPrefs.GetInt("LabyrinttiLevel")*-1-2;
        float cameraSize = this.GetComponent<Camera>().orthographicSize;
        this.GetComponent<Camera>().orthographicSize = cameraSize + PlayerPrefs.GetInt("LabyrinttiLevel")-1;
        LastPlacedTile = EmptyTile;
        allTilesGenerated = false;

    }

    void Update()
    {
        if ( allTilesGenerated!=true)
        {
            RandomizePiece();
            WaterTileMap.SetTile(new Vector3Int(xValue, yValue, 0), null);
            GroundTileMap.SetTile(new Vector3Int(xValue, yValue, 0), TileToBePlaced);           
            LastPlacedTile = TileToBePlaced;
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
    private void RandomizePiece()
    {
        if (LastPlacedTile==EmptyTile || LastPlacedTile == VerticalTile || LastPlacedTile == LeftToDownTile || LastPlacedTile == RightToDownTile)
        {
            if (xValue < rightEdgeValue && xValue > leftEdgeValue)
            {
                int rnd = Random.Range(1, 4);
                switch (rnd)
                {
                    case 1:
                        TileToBePlaced = VerticalTile;
                        break;

                    case 2:
                        if (LastPlacedTile != LeftToDownTile)
                        {
                            TileToBePlaced = DownToLeftTile;
                        }
                        else { TileToBePlaced = VerticalTile; }
                        break;
                    case 3:
                        if (LastPlacedTile != RightToDownTile)
                        {
                            TileToBePlaced = DownToRightTile;
                        }
                        else { TileToBePlaced = VerticalTile; }
                        break;
                }
            }
            else if(xValue == rightEdgeValue)
            {
                int rnd = Random.Range(1, 3);
                switch (rnd)
                {
                    case 1:
                        TileToBePlaced = VerticalTile;
                        break;
                    case 2:
                        if (LastPlacedTile == EmptyTile || LastPlacedTile == VerticalTile)
                        {
                            TileToBePlaced = DownToLeftTile;
                        }
                        else TileToBePlaced = VerticalTile;
                        break;
                }
            } else { int rnd = Random.Range(1, 3);
            switch (rnd)
                {
                    case 1:
                    TileToBePlaced = VerticalTile;
                    break;

                    case 2:
                        if (LastPlacedTile == EmptyTile || LastPlacedTile == VerticalTile)
                        {
                            TileToBePlaced = DownToRightTile;
                        }
                        else TileToBePlaced = VerticalTile;
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
                        TileToBePlaced = HorizontalRightToLeft;
                        break;

                    case 2:
                        TileToBePlaced = RightToDownTile;
                        break;
                }
            }
            else { TileToBePlaced = RightToDownTile; }
        }
        if (LastPlacedTile == HorizontalLeftToRight || LastPlacedTile == DownToRightTile)
        {
            
            if (xValue < rightEdgeValue)
            {
                
                int rnd = Random.Range(1, 3);
                switch (rnd)
                {
                    case 1:
                        TileToBePlaced = HorizontalLeftToRight;
                        break;

                    case 2:
                        TileToBePlaced = LeftToDownTile;
                        break;
                }
            }
            else { TileToBePlaced = LeftToDownTile; }
        }

    }


}
