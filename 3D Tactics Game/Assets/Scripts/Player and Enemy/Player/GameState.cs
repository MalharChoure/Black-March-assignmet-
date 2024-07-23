using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private state _currentState;
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    [SerializeField] PlayerMotion _player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentState == state.playermove)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (_playerInputHandler.OnHoverGameobject() != null)
                {
                    _player.moveTo(_playerInputHandler.OnHoverGameobject().transform.position);

                }
            }
        }
        if (_currentState == state.playerInitialize)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_playerInputHandler.OnHoverGameobject() != null)
                {
                    _player.OnInitialized(_playerInputHandler.OnHoverGameobject().transform.position);
                    _currentState = state.playermove;
                }
            }
        }
        
    }
}

public enum state
{
    playerInitialize,
    playermove
}