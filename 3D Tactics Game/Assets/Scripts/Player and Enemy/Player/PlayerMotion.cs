using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour , IArtificialIntelligence
{
    /// <summary>
    /// Creates an instance of the pathfinding algorithm 
    /// </summary>
    private DIjkstraAlgo2D _pathfinder;
    /// <summary>
    /// Handle to the gridmaker to pass the grid to the pathfinder. 
    /// </summary>
    [SerializeField] private GridMaker _gridMaker;// I did contemplate making the GridMaker Singleton here. Especially since this script is on a prefab
    /// <summary>
    /// Height needs to be set due to lerp based motion.
    /// </summary>
    [SerializeField] private float _height;
    /// <summary>
    /// Handle to the player motion function
    /// </summary>
    [SerializeField] private Movement _movement;

    /// <summary>
    /// Initializes the pathfinding algo with the grid and necessary parameters.
    /// </summary>
    public void InitializeDijkstraAlgo()
    {
        _pathfinder= new DIjkstraAlgo2D(_gridMaker,10,true);
    }

    /// <summary>
    /// Whenever the player is actually placed on the grid this is called.
    /// </summary>
    /// <param name="pos"></param>
    public void OnInitialized(Vector3 pos)
    {
        //playerUninitialized=false;
        transform.position = pos+ new Vector3 (0,_height,0);
        InitializeDijkstraAlgo();
    }

    /// <summary>
    /// This function is triggered when the player is actually told to move. 
    /// </summary>
    /// <param name="pos"></param>
    public void RunDijkstra(Vector3 pos)
    {
        _movement.EnqueueMovement(_pathfinder.SetStart(new Vector2Int((int)transform.position.x, (int)transform.position.z), new Vector2Int((int)pos.x, (int)pos.z)));
    }
}
