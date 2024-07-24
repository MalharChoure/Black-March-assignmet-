using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy motion class. In hindsight i should hhave just made a super class called entity for player and enemy movement,
/// </summary>
public class EnemyMotion : MonoBehaviour,IArtificialIntelligence
{
    /// <summary>
    /// Creates an instance of the pathfinding algorithm 
    /// </summary>
    private DIjkstraAlgo2D _pathfinder;
    /// <summary>
    /// Handle to the gridmaker to pass the grid to the pathfinder. 
    /// </summary>
    [SerializeField] private GridMaker _gridMaker;
    /// <summary>
    /// Height needs to be set due to lerp based motion.
    /// </summary>
    [SerializeField] private float _height;
    /// <summary>
    /// Handle to the player motion function
    /// </summary>
    [SerializeField] private Movement _movement;

    /// <summary>
    /// Here we run pathfinding algorithm but we also make sure the enemy tile is unwalkable.
    /// </summary>
    /// <param name="pos"></param>
    public void RunDijkstra(Vector3 pos)
    {
        List<Vector2Int> temp = new List<Vector2Int>();
        temp = _pathfinder.SetStart(new Vector2Int((int)transform.position.x, (int)transform.position.z), new Vector2Int((int)pos.x, (int)pos.z));
        if (temp.Count != 0)
        {
            _gridMaker.AlterTile(new Vector2Int((int)transform.position.x, (int)transform.position.z), tiletype.Grass);//When moving return current tile to walkable category
            _gridMaker.AlterTile(temp[temp.Count - 1], tiletype.occupied);// Makes sure that the destination is considered unwalkable after path is calculated.
        }
        _movement.EnqueueMovement(temp);
    }

    /// <summary>
    /// Alters tile when the enemy is first placed to unwalkable. Else the player passes through enemy.
    /// </summary>
    public void alterTileOnInitialize()
    {
        _gridMaker.AlterTile(new Vector2Int((int)transform.position.x, (int)transform.position.z), tiletype.occupied);
    }

    /// <summary>
    /// Calls pathfinidn initialization
    /// </summary>
    /// <param name="pos"></param>
    public void OnInitialized(Vector3 pos)
    {
        transform.position = pos + new Vector3(0, _height, 0);
        InitializeDijkstraAlgo();
    }

    /// <summary>
    /// Initializes pathfinding algo with the grid, grid size and enmey identifier.
    /// </summary>
    public void InitializeDijkstraAlgo()
    {
        _pathfinder = new DIjkstraAlgo2D(_gridMaker, 10, false);
    }
}
