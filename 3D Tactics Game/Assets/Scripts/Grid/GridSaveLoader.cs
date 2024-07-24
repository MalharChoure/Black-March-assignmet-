using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class simply sets the load file where the player has saved the grid used in loading scene.
/// </summary>
public class GridSaveLoader : MonoBehaviour
{
    /// <summary>
    /// It defaults the Current save index to 0. Incase calls are made to the Int by accessing different scene first.
    /// </summary>
    private void Awake()
    {
        PlayerPrefs.SetInt("CurrentSave", 0);// Player prefs provide easy alternative to transfer data from scenes. If much more data needed to be transfered scriptable objects or dont destroy on load is viable.
    }

    /// <summary>
    /// Allows the user to start saved scriptable object grids.
    /// </summary>
    /// <param name="save"></param>
    public void setSave(int save)
    {
        PlayerPrefs.SetInt("CurrentSave", save);
        SceneManager.LoadScene("PlayScene");
    }
}
