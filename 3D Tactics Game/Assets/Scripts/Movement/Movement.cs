using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows player movement without rigid body and character controller. Since this is controlled movement (we know exactly where we are going on a grid) 
/// I felt it best to implement it using linear Interpolation as it provides the smoothest motion
/// </summary>
public class Movement : MonoBehaviour
{
    /// <summary>
    /// Holds the motions to be done per tile in the path. This is computed by the pathfinding algorithm.
    /// </summary>
    private Queue<Vector3> _movements=new Queue<Vector3>();
    /// <summary>
    /// Timer to increment the time step of Vector3 lerp function.
    /// </summary>
    private float _timer = 0f;
    /// <summary>
    /// Since we are interpolating its easier to set time rather than speed so the lower the time required the faster the player.
    /// </summary>
    [SerializeField] private float _movementtime;
    /// <summary>
    /// Checks if the player is currently idling or is moving. Can be useful when implementing animations.
    /// </summary>
    private bool _isMoving=false;
    /// <summary>
    /// Holds the value of the absolute endpoint.
    /// </summary>
    private Vector3 _destination;
    /// <summary>
    /// Holds the value of the absolute startpoint.
    /// </summary>
    private Vector3 _startPoint;
    /// <summary>
    /// Height the player needs to be elevated to as we are interpolating 
    /// </summary>
    [SerializeField] private float _moveHeight;
    /// <summary>
    /// Boolean to wait till all the point pairs are enqueued.
    /// </summary>
    private bool _start=false;


    void Update()
    {
        //Debug.Log(_movements.Count);
        if(_movements.Count!=0 && !_isMoving && _start)// initial condition to check if there are any movements to perform.
        {
            _isMoving = true;
            _destination = _movements.Dequeue();
            _startPoint = transform.position;
            IsMovingChecker.Instance.SetIsMoving();

        }
        if(_isMoving)
        {
            _timer += Time.deltaTime/_movementtime;
            if(_timer<=1)
            {
                transform.position=Vector3.Lerp(_startPoint, _destination, _timer);// Interpolating between point pairs until we reach the end.
            }
            else
            {
                _timer = 0f;
                _isMoving = false;
                transform.position = _destination;
                if (_movements.Count == 0 && IsMovingChecker.Instance.GetIsMoving())// Resetting the singleton to allow movement one at a time
                {
                    IsMovingChecker.Instance.ResetIsMoving();
                }
            }
        }
        
    }

    /// <summary>
    /// Function converts Vector 2 grid coordinates to Vector 3 spatial coordinates. See Dijkstra's implementation for better reference.
    /// </summary>
    /// <param name="Directions"></param>
    public void EnqueueMovement(List<Vector2Int> Directions)
    {
        for(int i=0;i<Directions.Count;i++)
        {
            _movements.Enqueue(new Vector3(Directions[i].x,_moveHeight, Directions[i].y));
        }
        _start = true;
    }
}
