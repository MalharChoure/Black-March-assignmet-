using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script helps set the marker where the mouse is currently at
/// </summary>
public class GridTileMarker : MonoBehaviour
{
    /// <summary>
    /// Creates a handle to the Player Input Handler script.
    /// </summary>
    [SerializeField] private PlayerInputHandler _input;
    /// <summary>
    /// The actual prefab that the spotter uses. It a simple plane with a square hole cutout
    /// </summary>
    [SerializeField] private GameObject _spotter;


    void Update()
    {
        _OnTileClicked();
    }
    /// <summary>
    /// This allows us to set the poisiton of the spotter on the grid whenever the player is hovering on a tile.
    /// </summary>
    private void _OnTileClicked()
    {
        Vector3 temp = _input.OnHover();

        temp.x = Mathf.RoundToInt(temp.x);
        temp.z = Mathf.RoundToInt(temp.z);
        temp.y = temp.y + 0.01f;
        //Debug.Log(temp);
        _spotter.transform.position = temp;
    }
}
