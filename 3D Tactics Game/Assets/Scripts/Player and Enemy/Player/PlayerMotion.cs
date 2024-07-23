using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour , IArtificialIntelligence
{
    private DIjkstraAlgo2D _pathfinder;
    [SerializeField] private GridMaker _gridMaker;
    //[SerializeField] private PlayerInputHandler _playerInputHandler;
    private bool playerUninitialized=true;
    [SerializeField] private float height;
    [SerializeField] private Movement _movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void InitializeDijkstraAlgo()
    {
        _pathfinder= new DIjkstraAlgo2D(_gridMaker,10,true);
    }


    public void OnInitialized(Vector3 pos)
    {
        playerUninitialized=false;
        transform.position = pos+ new Vector3 (0,height,0);
        InitializeDijkstraAlgo();
    }

/*    public void moveTo(Vector3 pos)
    {
        _movement.EnqueueMovement(_pathfinder.SetStart(new Vector2Int((int)transform.position.x, (int)transform.position.z), new Vector2Int((int)pos.x, (int)pos.z)));
    }*/

    public void RunDijkstra(Vector3 pos)
    {
        _movement.EnqueueMovement(_pathfinder.SetStart(new Vector2Int((int)transform.position.x, (int)transform.position.z), new Vector2Int((int)pos.x, (int)pos.z)));
    }

    public void StartTurn()
    {
        
    }
}
