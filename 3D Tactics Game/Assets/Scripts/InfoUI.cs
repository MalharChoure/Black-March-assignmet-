using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUI : MonoBehaviour
{
    [SerializeField] PlayerInputHandler _inputhandler;
    [SerializeField] TMP_Text _info;
    [SerializeField] TMP_Text _position;
    // Start is called before the first frame update
    void Start()
    {
        _info.text = "Info";
        _position.text = "Position:";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject temp = _inputhandler.OnHoverGameobject();
        if (temp != null)
        {
            _info.text = "Info: " + temp.GetComponent<Information>().GetInfo();
            _position.text = "Position: "+"X: "+temp.transform.position.x + " Z: " + temp.transform.position.z;
        }
    }
}
