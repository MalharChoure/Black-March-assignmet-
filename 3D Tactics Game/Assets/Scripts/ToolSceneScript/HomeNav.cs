using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeNav : MonoBehaviour
{
    public void HomeNavFunc()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
