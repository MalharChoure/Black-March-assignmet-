using System;
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
    [SerializeField] private tiletype currentTileToBePlaced;
    [Space]
    [Header("Save system")]
    [SerializeField] private GridScriptableObject[] _gridSave;
    [SerializeField] private int _CurrentSave;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            UpdateGrid();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            SetGrid();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            CreateGrid();
        }
    }

    public void CreateGrid()
    {
        for (int i = 0; i < _gridSize; i++)
        {
            for (int j = 0; j < _gridSize; j++)
            {
                Instantiate(_prefabs[(int)_grid[i, j]], new Vector3(i, 0, j), Quaternion.identity,gameObject.transform );
            }
        }
    }

    public void ResetGrid()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        CreateGrid();
    }

    private void Awake()
    {
        _CurrentSave = PlayerPrefs.GetInt("CurrentSave", 0);
        SetGrid();
        CreateGrid();
        //updateGrid();
    }

    public void UpdateGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <10; j++)
            {
                _gridSave[_CurrentSave]._grid[i, j] = (int)_grid[i, j];
            }
            Debug.Log(_gridSave[_CurrentSave]._grid[i, 0] + " " + _gridSave[_CurrentSave]._grid[i, 1] + " " + _gridSave[_CurrentSave]._grid[i, 2] + " " + _gridSave[_CurrentSave]._grid[i, 3] + _gridSave[_CurrentSave]._grid[i, 4] + " " + _gridSave[_CurrentSave]._grid[i, 5] + " " + _gridSave[_CurrentSave]._grid[i, 6] + _gridSave[_CurrentSave]._grid[i, 7] + " " + _gridSave[_CurrentSave]._grid[i, 8] + " " + _gridSave[_CurrentSave]._grid[i, 9]);
        }
        EditorUtility.SetDirty(_gridSave[_CurrentSave]);
    }

    public void SetGrid()
    {

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _grid[i, j] = (tiletype) _gridSave[_CurrentSave]._grid[i, j];
            }
            Debug.Log(_grid[i, 0] + " " + _grid[i, 1] + " " + _grid[i, 2] + " " + _grid[i, 3] + _grid[i, 4] + " " + _grid[i, 5] + " " + _grid[i, 6] + _grid[i, 7] + " " + _grid[i, 8] + " " + _grid[i, 9]);

        }
    }

    public void SetCurrentSaveIndex(int index)
    {
        if(index>=0 && index<3)
        _CurrentSave = index;
    }

    public int GetCurrentSaveIndex()
    {
        return _CurrentSave;
    }

    public void SetBrush(int type)
    {
        currentTileToBePlaced = (tiletype)type;
    }

    public void SetCurrentTile(GameObject obj, Vector3 pos)
    {
        Destroy(obj);
        Instantiate(_prefabs[(int)currentTileToBePlaced], pos, Quaternion.identity, gameObject.transform);
        _grid[(int)pos.x, (int)pos.z] = currentTileToBePlaced;
    }

    public tiletype[,] getGrid()
    {
        return _grid;
    }
}

public enum tiletype
{
    Grass,
    Water,
    Obstacle
}