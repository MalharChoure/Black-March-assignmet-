using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the player inputs in general.
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    /// <summary>
    /// The main camera that the player uses to select objects or obtain information
    /// </summary>
    [SerializeField] private Camera _playerCam;
    /// <summary>
    /// To get the _point hit by raycast and then send that to the grid manager to handle gridcoordinates and so on
    /// </summary>
    private Vector3 _rayCastHitPoint;

    // Raycast ray
    private Ray _ray;
    //hit to store raycast data
    private RaycastHit _hit;
    /// <summary>
    /// Sets interactable layer
    /// </summary>
    [Tooltip("This sets the interactable layers for the raycast to detect objects")]
    [SerializeField] private LayerMask _interactableObjectMask;



    // Update is called once per frame
    void Update()
    {
        //Debug.Log(OnHover());
    }

    /// <summary>
    /// Returns position where raycast strikes an object on interactable layer
    /// </summary>
    /// <returns></returns>
    public Vector3 OnHover()
    {
        Vector3 currentMousePos = Input.mousePosition;
        currentMousePos.z = _playerCam.nearClipPlane;// This is done to avoid selecting objects camera cant see if its too close.
        _ray = _playerCam.ScreenPointToRay(currentMousePos);
        if(Physics.Raycast(_ray,out _hit,100,_interactableObjectMask))
        {
            // Here check the object and call its respective information function
            _rayCastHitPoint = _hit.point;
        }
        return _rayCastHitPoint;
    }

    public GameObject OnHoverGameobject()
    {
        Vector3 currentMousePos = Input.mousePosition;
        currentMousePos.z = _playerCam.nearClipPlane;
        _ray = _playerCam.ScreenPointToRay(currentMousePos);
        if (Physics.Raycast(_ray, out _hit, 100, _interactableObjectMask))
        {
            // Here check the object and call its respective information function
            return _hit.transform.gameObject;
        }
        return null;
    }
}
