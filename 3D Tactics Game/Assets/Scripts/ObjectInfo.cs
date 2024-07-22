using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Information : MonoBehaviour
{
    [SerializeField] private string _info;
    public string GetInfo(){return _info;}
}
