using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Singleton to check if the player is moving or not to stop any inputs during that time.
/// </summary>
public class IsMovingChecker : MonoBehaviour
{
    /// <summary>
    /// Static Instance of the singleton accessible by other scripts to access public functions and variables.
    /// </summary>
    public static IsMovingChecker Instance { get; private set; }
    private bool _isMoving = false;

    /// <summary>
    /// Standard deletion of excess instances.
    /// </summary>
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Sets the isMoving variable to true.
    /// </summary>
    public void SetIsMoving()
    {
        _isMoving = true;
    }
    /// <summary>
    /// Sets the isMoving variable to false.
    /// </summary>
    public void ResetIsMoving()
    {
        _isMoving = false;
    }
    /// <summary>
    /// Gets the isMoving variables current value.
    /// </summary>
    /// <returns></returns>
    public bool GetIsMoving()
    {
        return _isMoving;
    }

}
