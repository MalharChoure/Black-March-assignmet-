using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script used in home scene to navigate the other scenes
/// </summary>
public class HomeScreenNav : MonoBehaviour
{


    /// <summary>
    /// navigate to the Loading scene where save data is loaded.
    /// </summary>
    public void PlayScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    /// <summary>
    /// navigates to the eidt scene where the save data is created.
    /// </summary>
    public void EditScene()
    {
        SceneManager.LoadScene("GridSetterToolScene");
    }

    /// <summary>
    /// Quits application
    /// </summary>
    public void exitapplication()
    {
        Application.Quit();
    }
}
