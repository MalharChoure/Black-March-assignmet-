using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class GridMaker: MonoBehaviour
{
    [SerializeField] private int _gridSize;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private tiletype[,] _grid= new tiletype[10,10];
    [SerializeField] private GridScriptableObject[] _gridSave;
    [SerializeField] private int currentSave;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            updateGrid();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            setGrid();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            createGrid();
        }
    }

    private void createGrid()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                Instantiate(_prefabs[(int)_grid[i, j]], new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }

    private void Awake()
    {
        //setGrid();
        //createGrid();
        //updateGrid();
    }

    private void updateGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <10; j++)
            {
                _gridSave[currentSave]._grid[i, j] = (int)_grid[i, j];
            }
            Debug.Log(_gridSave[currentSave]._grid[i, 0] + " " + _gridSave[currentSave]._grid[i, 1] + " " + _gridSave[currentSave]._grid[i, 2] + " " + _gridSave[currentSave]._grid[i, 3] + _gridSave[currentSave]._grid[i, 4] + " " + _gridSave[currentSave]._grid[i, 5] + " " + _gridSave[currentSave]._grid[i, 6] + _gridSave[currentSave]._grid[i, 7] + " " + _gridSave[currentSave]._grid[i, 8] + " " + _gridSave[currentSave]._grid[i, 9]);
        }
        EditorUtility.SetDirty(_gridSave[currentSave]);
    }

    private void setGrid()
    {

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _grid[i, j] = (tiletype) _gridSave[currentSave]._grid[i, j];
            }
            Debug.Log(_grid[i, 0] + " " + _grid[i, 1] + " " + _grid[i, 2] + " " + _grid[i, 3] + _grid[i, 4] + " " + _grid[i, 5] + " " + _grid[i, 6] + _grid[i, 7] + " " + _grid[i, 8] + " " + _grid[i, 9]);

        }
    }
}

public enum tiletype
{
    Grass,
    Water,
    Obstacle
}