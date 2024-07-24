using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICurrentSaveUpdate : MonoBehaviour
{
    /// <summary>
    /// Holds the text displaying the current save file being altered.
    /// </summary>
    [SerializeField] TMP_Text _text;
    /// <summary>
    /// Handle to the gridmaker to be able to get save indexes.
    /// </summary>
    [SerializeField] GridMaker _gridMaker;

    /// <summary>
    /// Gets save index on awake
    /// </summary>
    public void Awake()
    {
        _text.text = "Current Save: " + _gridMaker.GetCurrentSaveIndex();
    }

    /// <summary>
    /// gets save index when save scriptable object is changed.
    /// </summary>
    public void TextUpdate()
    {
        _text.text="Current Save: "+ _gridMaker.GetCurrentSaveIndex();
    }
}
