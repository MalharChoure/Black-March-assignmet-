using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityGridToolInputs : MonoBehaviour
{
    /// <summary>
    /// Player input hadler handle to get gameobject on hover.
    /// </summary>
    [SerializeField] private PlayerInputHandler _inputHandler;
    /// <summary>
    /// Grid handle to set paint tiles.
    /// </summary>
    [SerializeField] private GridMaker _gridMaker;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_inputHandler.OnHoverGameobject()!=null)
            _gridMaker.SetCurrentTile(_inputHandler.OnHoverGameobject(), _inputHandler.OnHoverGameobject().transform.position);// If we actually hit a tile change it to whatever the brush is.
        }
    }


}
