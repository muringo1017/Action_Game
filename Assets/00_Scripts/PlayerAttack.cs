using System;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3,
    KICK_1,
    KICK_2
}
public class PlayerAttack : MonoBehaviour
{
    
    private PlayerAnimation _playerAnimation;

    private bool _activateTimerToReset;
    
    private float _defaultComboTimer = 0.4f;
    private float _currentComboTimer;

    private ComboState _currentComboState;

    private void Awake()
    {
        _playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }

    public void Start()
    {
        _currentComboTimer = _defaultComboTimer;
        _currentComboState = ComboState.NONE;
    }

    private void Update()
    {
        ComboAttacks();
        ResetComboState();
    }

    void ComboAttacks()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (_currentComboState == ComboState.PUNCH_3 ||
                _currentComboState == ComboState.KICK_1 || 
                _currentComboState == ComboState.KICK_2) 
                return;
                
            _currentComboState++;
            _activateTimerToReset = true;
            _currentComboTimer = _defaultComboTimer;

            if (_currentComboState == ComboState.PUNCH_1)
            {
                _playerAnimation.Punch_1();
            }
            if (_currentComboState == ComboState.PUNCH_2)
            {
                _playerAnimation.Punch_2();
            }
            if (_currentComboState == ComboState.PUNCH_3)
            {
                _playerAnimation.Punch_3();
            }
            
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (_currentComboState == ComboState.KICK_2 ||
                _currentComboState == ComboState.PUNCH_3)
                return;

            if (_currentComboState == ComboState.NONE ||
                _currentComboState == ComboState.PUNCH_1 ||
                _currentComboState == ComboState.PUNCH_2)
            {
                _currentComboState = ComboState.KICK_1;
            }
            else if (_currentComboState == ComboState.KICK_1)
            {
                _currentComboState++;
            }

            _activateTimerToReset = true;
            _currentComboTimer = _defaultComboTimer;

            if (_currentComboState == ComboState.KICK_1)
            {
                _playerAnimation.Kick_1();
            }

            if (_currentComboState == ComboState.KICK_2)
            {
                _playerAnimation.Kick_2();
            }
        }
        
        
    }

    void ResetComboState()
    {
        if (_activateTimerToReset)
        {
            _currentComboTimer -= Time.deltaTime;

            if (_currentComboTimer <= 0f)
            {
                _currentComboState = ComboState.NONE;

                _activateTimerToReset = false;
                _currentComboTimer = _defaultComboTimer;
            }
        }
    }
}
