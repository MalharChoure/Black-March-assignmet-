using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.PlayerSettings;

/// <summary>
/// This algorithm is rather close to BFS as we dont have weights assigned to paths because they are all equidistant and is used to pathfind on a 2d grid with four direction manuverability.
/// </summary>
public class DIjkstraAlgo2D 
{
    /// <summary>
    /// This forms the basis of the actual grid used by the algorithm to detect non walkable tiles.
    /// </summary>
    private tiletype[,] _grid;
    /// <summary>
    /// Gridsize for reference 
    /// </summary>
    private int _gridsize;
    /// <summary>
    ///holds the start position of the object on the grid
    /// </summary>
    private Vector2Int _start;
    /// <summary>
    /// holds the endpos of the object on the grid
    /// </summary>
    private Vector2Int _end;
    /// <summary>
    /// Queue used to hold the nodes to visit next
    /// </summary>
    private Queue<cell> _inQueue= new Queue<cell>();
    /// <summary>
    /// List holds the nodes that have already been visited. It is useful in backtracking the path after it is found.
    /// </summary>
    private List<cell> _visited= new List<cell>();
    /// <summary>
    /// Boolean used to control start of the algorithm
    /// </summary>
    private bool _startSearch;
    /// <summary>
    /// List that holds the backtracked path once the actual path is found
    /// </summary>
    private List<Vector2Int> _actualMotion= new List<Vector2Int>();
    /// <summary>
    /// Bool used to check whether the algo is being used by player or bot. To stop the bots from invading player space.
    /// </summary>
    private bool _player = true;

    /// <summary>
    /// Contructor requires grid, grid size and the player distinction factor
    /// </summary>
    /// <param name="_gridHandler"> This grabs the gridhandler instance to access the grid that holds the walkable and unwalkable tiles</param>
    /// <param name="size"></param>
    /// <param name="player"></param>
    public DIjkstraAlgo2D(GridMaker _gridHandler, int size, bool player)
    {
        _gridsize = size;
        _grid = new tiletype[size, size];
        _grid=_gridHandler.getGrid();
        this._player = player;
    }

    /// <summary>
    /// This function starts the search for the shortest path. It also reinitializes the the queues and list alongside control flags
    /// </summary>
    /// <param name="startpos"></param>
    /// <param name="endpos"></param>
    /// <returns>The list returned is 2d coordinates x and z and needs to be converted to vector 3</returns>
    public List<Vector2Int> SetStart(Vector2Int startpos, Vector2Int endpos)
    {
        _actualMotion.Clear();
        _start = startpos;
        _end = endpos;
        _inQueue = new Queue<cell>();
        _visited = new List<cell>();
        cell temp = new cell(_start, _checkWalkable(startpos));
        _inQueue.Enqueue(temp);
        _startSearch = true;
        _workQueue();
        if(_player && _actualMotion.Count!=0)
        {
            _actualMotion.Add(endpos);
        }
        return _actualMotion;
    }
    /// <summary>
    /// This function takes the neighbours of a visited cell and adds them in the queue. 
    /// </summary>
    /// <param name="c"></param>
    private void _addneighbours(cell c)
    {
        
        if(c.pos.x>0)
        {
            Vector2Int t = new Vector2Int(c.pos.x - 1, c.pos.y);
            cell temp = new cell(t, _checkWalkable(t),c.pos);
            if(!_searchQueue(temp) && !_searchlist(temp) && temp.walkable)
                _inQueue.Enqueue(temp);
        }
        if(c.pos.x<_gridsize-1)
        {
            Vector2Int t = new Vector2Int(c.pos.x + 1, c.pos.y);
            cell temp = new cell(t, _checkWalkable(t), c.pos);
            if (!_searchQueue(temp) && !_searchlist(temp) && temp.walkable)
                _inQueue.Enqueue(temp);
        }
        if (c.pos.y >0)
        {
            Vector2Int t = new Vector2Int(c.pos.x, c.pos.y-1);
            cell temp = new cell(t, _checkWalkable(t), c.pos);
            if (!_searchQueue(temp) && !_searchlist(temp) && temp.walkable)
                _inQueue.Enqueue(temp);
        }
        if (c.pos.y < _gridsize - 1)
        {
            Vector2Int t = new Vector2Int(c.pos.x, c.pos.y+1);
            cell temp = new cell(t, _checkWalkable(t), c.pos);
            if (!_searchQueue(temp) && !_searchlist(temp) && temp.walkable)
                _inQueue.Enqueue(temp);
        }
    }
    /// <summary>
    /// The function that runs the loop to check whether the element is end node or not
    /// </summary>
    private void _workQueue()
    {
        while(_inQueue.Count!=0 && _startSearch)
        {
            //checks for end node found
            if(_inQueue.Peek().pos==_end)
            {
                _startSearch = false;
                _backTrack(_inQueue.Peek());
            }
            else
            {
                cell temp = new cell();
                temp= _inQueue.Dequeue();
                _visited.Add(temp);
                _addneighbours(temp);
            }
        }
    }

    /// <summary>
    /// This checks whether a tile is walkable
    /// </summary>
    /// <param name="pos"></param>
    /// <returns>Returns true or false</returns>
    private bool _checkWalkable(Vector2Int pos)
    {
        return _grid[pos.x, pos.y] == tiletype.Grass;
    }

    /// <summary>
    /// This function backtracks the cells in order to form the shortest path and then adds the elements to a list. It also reverses it so that the entity can traverse it.
    /// </summary>
    /// <param name="c"></param>
    private void _backTrack(cell c)
    {
        cell temp = c;
        bool rootreached = false;
        while(!rootreached)
        {
            _actualMotion.Add(temp.previous);
            if(temp.previous==new Vector2Int(-1,-1))
            {
                rootreached= true;
            }
            for(int i=0;i<_visited.Count;i++)
            {
                if (_visited[i].pos == temp.previous)
                {
                    temp = _visited[i];
                    break;
                }
            }
        }
        _actualMotion.RemoveAt(_actualMotion.Count - 1);
        _actualMotion.Reverse();
    }

    /// <summary>
    /// Function to seach the queue if an object is already in unvisited queue.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool _searchQueue(cell c)
    {
        for(int i=0;i<_inQueue.Count;i++)
        {
            if (_inQueue.ElementAt(i).pos == c.pos)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Function to check the list whether an element is already visited.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private bool _searchlist(cell c)
    {
        for (int i = 0; i < _visited.Count; i++)
        {
            if (_visited[i].pos == c.pos)
                return true;
        }
        return false;
    }
}
/// <summary>
/// Class to create cells that allow back traversal using the previous Vector2 position
/// </summary>
public class cell
{
    public Vector2Int pos;
    public bool walkable = false;
    public Vector2Int previous;

    public cell()
    {
        this.pos = new Vector2Int(0,0);
        this.walkable = false;
        this.previous = new Vector2Int(0, 0);
    }
    public cell(Vector2Int pos, bool walkable)
    {
        this.pos = pos;
        this.walkable = walkable;
        previous= new Vector2Int(-1,-1);
    }

    public cell(Vector2Int pos, bool walkable,Vector2Int previous)
    {
        this.pos = pos;
        this.walkable = walkable;
        this.previous = previous;
    }

    public bool compare(cell c)
    {
        if (c.pos == this.pos)
            return true;
        return false;
    }
};

