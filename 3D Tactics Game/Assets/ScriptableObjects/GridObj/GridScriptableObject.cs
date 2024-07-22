using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GridScriptableObject", order = 1)]
public class GridScriptableObject : ScriptableObject
{

    public int[,] _grid= new int[20,20];
 
/*
    public void setGrid(tiletype[,] gridTiles)
    {
        for(int i=0;i<gridTiles.Length;i++)
        {
            for (int j = 0; j < gridTiles.Length; j++)
            {
                _grid[i,j]= gridTiles[i,j];
            }
        }
    }

    public tiletype[,] getGrid()
    {
        return _grid;
    }*/
}

