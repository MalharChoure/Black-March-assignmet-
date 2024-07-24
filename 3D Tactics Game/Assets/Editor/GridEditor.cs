using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GridEditor : EditorWindow
{
    /// <summary>
    /// Bool 2d array to create grid
    /// </summary>
    bool[,] grid = new bool[10,10];
    /// <summary>
    /// Grid scriptable object to get the scriptable object and edit data in editor.
    /// </summary>
    GridScriptableObject obj;

    [MenuItem("Tools/Grid Editor")]
    public static void ShowWindow()
    {
        GridEditor wnd= GetWindow<GridEditor>();
    }


    private void OnGUI()
    {
        obj = (GridScriptableObject)EditorGUILayout.ObjectField("Scriptable object",obj,typeof(GridScriptableObject),false);
        for (int i = 0; i < 10; i++)
        {
            GUILayout.BeginHorizontal();
            for(int j=0;j<10;j++)
            {
                GUILayout.BeginVertical();
                if (GUILayout.Toggle(grid[i,j], " "))
                {
                    grid[i, j] = true;
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Save layout"))
        {

            for(int i=0;i<10;i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (grid[i,j])
                    {
                        obj.val[((10*i)+j)-1] = (int)tiletype.Obstacle;
                    }
                }
            }
            obj.test = true;
            EditorUtility.SetDirty(obj);
           
        }
        
    }

}
