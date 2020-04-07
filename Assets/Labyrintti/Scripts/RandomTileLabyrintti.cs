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
    public Tile[,] TileList;
    public Tile TileToBePlaced;
    public Tile LastPlacedTile;
    private int yToArrayValue;
    private int leftEdgeValue;
    private int rightEdgeValue;
    private int bottomEdgeValue;
    private int topEdgeValue;
    private bool allTilesGenerated;
    // Start is called before the first frame update
    void Start()
    {
        xValue = -1;
        yValue = 2;
        leftEdgeValue = -3;
        rightEdgeValue = 0;
        bottomEdgeValue = -3;
        LastPlacedTile = EmptyTile;
        yToArrayValue = yValue * -1 + 2;
        allTilesGenerated = false;
        TileList = new Tile[6, 6] {
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile } ,
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile } ,
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile } ,
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile } ,
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile } ,
        {EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile, EmptyTile }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (/*Input.GetKeyDown(KeyCode.UpArrow) &&*/
            allTilesGenerated!=true)
        {
                      
            yToArrayValue = yValue * -1 + 2;
            int xToArrayValue = xValue+3;
            
            RandomizePiece();


            WaterTileMap.SetTile(new Vector3Int(xValue, yValue, 0), null);
            GroundTileMap.SetTile(new Vector3Int(xValue, yValue, 0), TileToBePlaced);
            TileList.SetValue(TileToBePlaced, yToArrayValue, xToArrayValue);
            LastPlacedTile = TileToBePlaced;
            if (LastPlacedTile==VerticalTile || LastPlacedTile == LeftToDownTile || LastPlacedTile == RightToDownTile)
            {
                yValue -= 1;
                if (yValue == bottomEdgeValue)
                {
                    yToArrayValue = yValue * -1 + 2;
                    WaterTileMap.SetTile(new Vector3Int(xValue, yValue, 0), null);
                    TileList.SetValue(FinishTile, yToArrayValue, xToArrayValue);
                    FinishTileMap.SetTile(new Vector3Int(xValue, yValue, 0), FinishTile);
                    //foreach (Tile tiles in TileList)
                    //{
                    //    if (tiles == EmptyTile)
                    //    {
                    //        Debug.Log("EmptytileFoudn");
                    //    }
                    //}
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
