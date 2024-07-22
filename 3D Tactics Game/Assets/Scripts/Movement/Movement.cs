using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Queue<Vector3> _movements=new Queue<Vector3>();
    private float _timer = 0f;
    [SerializeField] private float movementspeed;
    private bool _isMoving=false;
    private Vector3 _destination;
    private Vector3 _startPoint;

    //[SerializeField]private List<Vector3> testPos;
    // Start is called before the first frame update
    void Start()
    {
        //EnqueueMovement(testPos);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_movements.Count);
        if(_movements.Count!=0 && !_isMoving)
        {
            _isMoving = true;
            _destination = _movements.Dequeue();
            _startPoint = transform.position;
        }
        if(_isMoving)
        {
            _timer += Time.deltaTime/movementspeed;
            if(_timer<1)
            {
                transform.position=Vector3.Lerp(_startPoint, _destination, _timer);
            }
            else
            {
                _timer = 0f;
                _isMoving = false;
            }
        }
    }

    public void EnqueueMovement(List<Vector3> Directions)
    {
        for(int i=0;i<Directions.Count;i++)
        {
            _movements.Enqueue(Directions[i]);
        }
    }
}
