using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Alternative used to state machine. There were only two sides so i felt it easier to just implement this. It holds 4 states and 2 for player and enemy initialization and 2 for player and enemy movement.
/// </summary>
public class GameState : MonoBehaviour
{
    /// <summary>
    /// Enum holds the current state so that we never run into missing state problem.
    /// </summary>
    [SerializeField] private state _currentState;
    /// <summary>
    /// Handle to player inputs.
    /// </summary>
    [SerializeField] private PlayerInputHandler _playerInputHandler;
    /// <summary>
    /// Handle to actual player. I originally thought of making this a singleton but deffered as the enemy uses a similar logic and can have multiple enemies as well as players and each with their own pathfinder 
    /// </summary>
    [SerializeField] private PlayerMotion _player;
    /// <summary>
    /// Checks and holds bool if any of the pieces are in motion.
    /// </summary>
    private bool _inMotion=false;
    /// <summary>
    /// Array that holds the motion handler for multiple enemies.
    /// </summary>
    [SerializeField] private EnemyMotion[] _enemy;
    /// <summary>
    /// Index that allows us to operate one enemy at a time.
    /// </summary>
    private int _currentEnemy=0;

    void Update()
    {
        _inMotion = IsMovingChecker.Instance.GetIsMoving();
        if (!_inMotion)
        {
            switch(_currentState)//Switch used to not run into missing state problem.
            {
                case state.playerInitialize:// Here player position is initialized.
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (_playerInputHandler.OnHoverGameobject() != null)
                        {
                            _player.OnInitialized(_playerInputHandler.OnHoverGameobject().transform.position);
                            _currentState = state.enemyInitialize;
                        }
                    }
                    break;
                case state.enemyInitialize:// Here enemy positions are set.
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (_playerInputHandler.OnHoverGameobject() != null)
                        {
                            _enemy[_currentEnemy].OnInitialized(_playerInputHandler.OnHoverGameobject().transform.position);
                            _enemy[_currentEnemy].alterTileOnInitialize();
                            
                            if(_currentEnemy==_enemy.Length-1)
                            _currentState = state.playermove;
                            _currentEnemy = (_currentEnemy + 1) % _enemy.Length;

                        }
                    }
                    break;

                case state.playermove:// here the game actually begins by moving the player to the respective point.
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (_playerInputHandler.OnHoverGameobject() != null)
                        {
                            _player.RunDijkstra(_playerInputHandler.OnHoverGameobject().transform.position);
                            _currentState = state.enemymove;
                            IsMovingChecker.Instance.SetIsMoving();
                        }
                    }
                    break;

                case state.enemymove://Here the enemies are moved one at a time.
                    IsMovingChecker.Instance.SetIsMoving();
                    _enemy[_currentEnemy].RunDijkstra(_player.transform.position);
                    _currentEnemy = (_currentEnemy + 1) % _enemy.Length;
                    _currentState = state.playermove;
                    break;

            }

        }
        
    }
}

/// <summary>
/// Enum to hold states akin to a state machine.
/// </summary>
public enum state
{
    playerInitialize,
    playermove,
    enemyInitialize,
    enemymove
}