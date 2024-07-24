using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GridScriptableObject", order = 1)]
public class GridScriptableObject : ScriptableObject
{


    public bool test = false;

    public int[] val = new int[100];
 
}

