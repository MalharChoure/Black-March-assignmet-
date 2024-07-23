using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICurrentSaveUpdate : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] GridMaker _gridMaker;


    public void Awake()
    {
        _text.text = "Current Save: " + _gridMaker.GetCurrentSaveIndex();
    }

    public void TextUpdate()
    {
        _text.text="Current Save: "+ _gridMaker.GetCurrentSaveIndex();
    }
}
