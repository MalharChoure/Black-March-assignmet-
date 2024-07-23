using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DIjkstraAlgo2D 
{
    private tiletype[,] _grid;
    private int _gridsize;
    private Vector2Int _start;
    private Vector2Int _end;
    private Queue<cell> _inQueue= new Queue<cell>();
    private List<cell> _visited= new List<cell>();
    private bool _startSearch;
    private List<Vector2Int> _actualMotion= new List<Vector2Int>();
    private bool _endedSearch = false;

    private bool player = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public DIjkstraAlgo2D(GridMaker _gridHandler, int size)
    {
        _gridsize = size;
        _grid = new tiletype[size, size];
        _grid=_gridHandler.getGrid();
    }


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
        if(player)
        {
            _actualMotion.Add(endpos);
        }
        return _actualMotion;
    }

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

    private void _workQueue()
    {
        while(_inQueue.Count!=0 && _startSearch)
        {
            if(_inQueue.Peek().pos==_end)
            {
                _endedSearch = true;
                _startSearch = false;
                _backTrack(_inQueue.Peek());
            }
            else
            {
                cell temp = new cell();
                temp= _inQueue.Dequeue();
                _visited.Add(temp);
                //_visited.Append(temp);
                _addneighbours(temp);
            }
        }
    }
    private bool _checkWalkable(Vector2Int pos)
    {
        return _grid[pos.x, pos.y] == tiletype.Grass;
    }

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

    private bool _searchQueue(cell c)
    {
        for(int i=0;i<_inQueue.Count;i++)
        {
            if (_inQueue.ElementAt(i).pos == c.pos)
                return true;
        }
        return false;
    }

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

