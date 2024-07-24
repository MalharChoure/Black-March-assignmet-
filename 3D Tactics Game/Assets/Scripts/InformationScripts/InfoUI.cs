using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Script to 
/// </summary>
public class InfoUI : MonoBehaviour
{
    /// <summary>
    /// INput handle to get on hover
    /// </summary>
    [SerializeField] PlayerInputHandler _inputhandler;
    /// <summary>
    /// Holds the text handle to display info
    /// </summary>
    [SerializeField] TMP_Text _info;
    /// <summary>
    /// Holds the position text handle to display position.
    /// </summary>
    [SerializeField] TMP_Text _position;
    // Start is called before the first frame update
    void Start()
    {
        _info.text = "Info";
        _position.text = "Position:";
    }

    void Update()
    {
        GameObject temp = _inputhandler.OnHoverGameobject();
        if (temp != null)
        {
            if(temp.TryGetComponent<Information>(out Information tempe))//check to see if the object hit actually has a Information component.
            _info.text = "Info: " + tempe.GetInfo();
            _position.text = "Position: "+"X: "+temp.transform.position.x + " Z: " + temp.transform.position.z;
        }
    }
}
