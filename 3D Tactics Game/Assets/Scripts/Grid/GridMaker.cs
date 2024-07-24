using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class GridMaker: MonoBehaviour
{
    /// <summary>
    /// Defines the size of the grid
    /// </summary>
    [SerializeField] private int _gridSize;
    /// <summary>
    /// Holds the various types of blocks that can be placed in the grid
    /// </summary>
    [SerializeField] private GameObject[] _prefabs;
    /// <summary>
    /// The actual grid holds integer values in enum format so that values cannot go out of bounds
    /// </summary>
    [SerializeField] private tiletype[,] _grid= new tiletype[10,10];
    /// <summary>
    /// For the tile layer brush to place tiles in editor tool
    /// </summary>
    [SerializeField] private tiletype _currentTileToBePlaced;
    [Space]
    [Header("Save system")]
    [SerializeField] private GridScriptableObject[] _gridSave;// This is to hold the scriptable objects to transfer data to the other scenes.The assignment explicitly mentions using scriptable objects but it would be easier and locally savable if we use serialization in the form of a json file.
    [SerializeField] private int _CurrentSave;// Denotes the index of the current save

    //public TestScriptableObject t;
    void Update()
    {
        //These were test inputs used for quick testing
      /*  if(Input.GetKeyDown(KeyCode.S))
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
        }*/
    }

    /// <summary>
    /// Generates the actual grid in 3D space. A way to improve performance would be to use object pooling but since the grid is small Instantiate works.
    /// </summary>
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

    /// <summary>
    /// This is to quickly reset the grid when someone is editing the grid. It resets it to all grass by default.
    /// </summary>
    public void ResetGrid()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        CreateGrid();
    }

    /// <summary>
    /// Awake function to create grids on scene load in play and tool edit scene.
    /// </summary>
    private void Awake()
    {
        _CurrentSave = PlayerPrefs.GetInt("CurrentSave", 0);
        SetGrid();
        CreateGrid();
        //updateGrid();
    }

    /// <summary>
    /// This functions updates the scriptable objects so as to carry the grid data from edit scene to play scene
    /// </summary>
    public void UpdateGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j <10; j++)
            {
                _gridSave[_CurrentSave]._grid[i, j] = (int)_grid[i, j];
            }
        }
        //t.test = true;
        //Undo.RecordObject(t, " ");
        EditorUtility.SetDirty(t);
        //AssetDatabase.SaveAssets();
        //EditorUtility.SetDirty(_gridSave[_CurrentSave]);
    }
    /// <summary>
    /// This function sets the actual grid data to the current save. it essentially loads the save.
    /// </summary>
    public void SetGrid()
    {

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                _grid[i, j] = (tiletype) _gridSave[_CurrentSave]._grid[i, j];
            }
        }
    }

    /// <summary>
    /// allows us to set the current save index to acces scriptable object saves.
    /// </summary>
    /// <param name="index"></param>
    public void SetCurrentSaveIndex(int index)
    {
        if(index>=0 && index<3)
        _CurrentSave = index;
    }

    /// <summary>
    /// Returns the current active scriptable object index
    /// </summary>
    /// <returns>_CurrentSave</returns>
    public int GetCurrentSaveIndex()
    {
        return _CurrentSave;
    }

    /// <summary>
    /// Sets the brush in the edit tool to paint obstacles water and dirt
    /// </summary>
    /// <param name="type"></param>
    public void SetBrush(int type)
    {
        _currentTileToBePlaced = (tiletype)type;
    }

    /// <summary>
    /// This allows us to make temoporary changes to a already loaded grid.  This combined
    /// with the brush allows us to paint the blocks.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="pos"></param>
    public void SetCurrentTile(GameObject obj, Vector3 pos)
    {
        Destroy(obj);
        Instantiate(_prefabs[(int)_currentTileToBePlaced], pos, Quaternion.identity, gameObject.transform);
        _grid[(int)pos.x, (int)pos.z] = _currentTileToBePlaced;
    }

    /// <summary>
    /// Gets the actual grid so that Dijkstra's works on it
    /// </summary>
    /// <returns></returns>
    public tiletype[,] getGrid()
    {
        return _grid;
    }

    /// <summary>
    /// This allows you to temporarily alter a tiles type without changing the prefab. This is done when enemy is occupying a tile to make it unwalkable.
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="type"></param>
    public void AlterTile(Vector2Int pos,tiletype type)
    {
        _grid[pos.x, pos.y] = type;
    }
}

/// <summary>
/// Enumerator to confine the tile types
/// </summary>
public enum tiletype
{
    Grass,
    Water,
    Obstacle,
    occupied
}