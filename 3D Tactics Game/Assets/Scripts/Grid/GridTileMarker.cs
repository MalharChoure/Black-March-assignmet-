using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileMarker : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler _input;
    [SerializeField] private GameObject _spotter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTileClicked();
/*        if (Input.GetMouseButtonDown(0))
        {
            OnTileClicked();
        }*/
    }
    private void OnTileClicked()
    {
        Vector3 temp = _input.OnHover();

        temp.x = Mathf.RoundToInt(temp.x);
        temp.z = Mathf.RoundToInt(temp.z);
        temp.y = temp.y + 0.01f;
        //Debug.Log(temp);
        _spotter.transform.position = temp;
    }
}
