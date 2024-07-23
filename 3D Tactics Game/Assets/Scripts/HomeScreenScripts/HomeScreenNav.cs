using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreenNav : MonoBehaviour
{

    public void _PlayScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void _EditScene()
    {
        SceneManager.LoadScene("GridSetterToolScene");
    }

    public void _exitapplication()
    {
        Application.Quit();
    }
}
