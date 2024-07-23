using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnityGridToolInputs : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _inputHandler;
    [SerializeField] private GridMaker _gridMaker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_inputHandler.OnHoverGameobject()!=null)
            _gridMaker.SetCurrentTile(_inputHandler.OnHoverGameobject(), _inputHandler.OnHoverGameobject().transform.position);
        }
    }


}
