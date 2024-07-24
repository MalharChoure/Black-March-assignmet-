using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script to navigate to home scene
/// </summary>
public class HomeNav : MonoBehaviour
{
    /// <summary>
    /// Navigates to home scene.
    /// </summary>
    public void HomeNavFunc()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
