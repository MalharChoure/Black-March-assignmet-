using System;
using System.Security.Principal;
using UnityEditor;
using UnityEngine;


public class GridHolder : ScriptableObject
{
    public Wrapper<tiletype>[] grid;
    public const int gridsize=10;
    public Texture[] textures;

    private void Awake()
    {
        if(grid==null)
        {
            ResetGrid();
        }
    }

    public void ResetGrid()
    {
        grid = new Wrapper<tiletype>[gridsize];
        for(int i=0;i<gridsize;i++)
        {
            grid[i]= new Wrapper<tiletype>();
            grid[i].values = new tiletype[gridsize];
        }
    }
}



[System.Serializable]
public class Wrapper<T>
{
    public T[] values;
}

[CustomEditor(typeof(GridHolderEditor))]
public class GridHolderEditor : Editor
{
    SerializedProperty grid;
    SerializedProperty array;
    SerializedProperty texture;
    int _length;

    private void OnEnable()
    {
        grid = serializedObject.FindProperty("Grid");
        texture= serializedObject.FindProperty("textures");
        _length=Enum.GetValues(typeof(tiletype)).Length;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GridHolder _script= (GridHolder) target;
        _DrawGrid();
        if(GUILayout.Button("Reset"))
            _script.ResetGrid();
        serializedObject.ApplyModifiedProperties();
    }

    private void _DrawGrid()
    {
        try
        {
            GUILayout.BeginVertical();
            for(int i=0;i<GridHolder.gridsize;i++)
            {
                GUILayout.BeginHorizontal();
                array=grid.GetArrayElementAtIndex(i).FindPropertyRelative("Values");
                for(int j=0;j<GridHolder.gridsize;j++)
                {
                    var value= array.GetArrayElementAtIndex(j);
                    tiletype types = (tiletype)array.GetArrayElementAtIndex(j).intValue;
                    
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
        }
        catch(System.Exception e)
        {
            Debug.Log(e);
        }
    }

    private int _NextIndex(int index)
    {
        int result = ++index % _length;
        return result;
    }
}