using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

/// <summary>
/// Script that holds information of a particular block.
/// </summary>
public class Information : MonoBehaviour
{
    /// <summary>
    /// The string holding the info
    /// </summary>
    [SerializeField] private string _info;
    public string GetInfo(){return _info;}//getter method to return the string.
}
