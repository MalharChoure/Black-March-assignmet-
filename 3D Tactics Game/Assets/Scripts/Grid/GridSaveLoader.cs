using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridSaveLoader : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("CurrentSave", 0);
    }

    public void setSave(int save)
    {
        PlayerPrefs.SetInt("CurrentSave", save);
        SceneManager.LoadScene("PlayScene");
    }
}
