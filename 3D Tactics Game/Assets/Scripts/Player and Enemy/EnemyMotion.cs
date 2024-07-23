using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour,IArtificialIntelligence
{
    private DIjkstraAlgo2D _pathfinder;
    [SerializeField] private GridMaker _gridMaker;
    private bool enemyUninitialized = true;
    [SerializeField] private float height;
    [SerializeField] private Movement _movement;

    public void RunDijkstra(Vector3 pos)
    {
        _movement.EnqueueMovement(_pathfinder.SetStart(new Vector2Int((int)transform.position.x, (int)transform.position.z), new Vector2Int((int)pos.x, (int)pos.z)));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnInitialized(Vector3 pos)
    {
        enemyUninitialized = false;
        transform.position = pos + new Vector3(0, height, 0);
        InitializeDijkstraAlgo();
    }

    public void InitializeDijkstraAlgo()
    {
        _pathfinder = new DIjkstraAlgo2D(_gridMaker, 10, false);
    }
}
