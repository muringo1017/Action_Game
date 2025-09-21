using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Player _player;
    //컴포넌트
    private PlayerStateMachine _stateMachine;
    private PlayerController _controller;
    private PlayerCombat _combat;
    private CharacterAnimation _characterAnimation;
    
    //속성
    public Player Player => _player;
    public PlayerStateMachine StateMachine => _stateMachine;
    public PlayerController Controller => _controller;
    public PlayerCombat Combat => _combat;
    public CharacterAnimation Animation => _characterAnimation;


    private void Awake()
    {
        InitalizeComponents();
    }
    
    
    private void InitalizeComponents()
    {
        if (_player == null) return;
        
        _stateMachine = _player.GetComponent<PlayerStateMachine>();
        _controller = _player.GetComponent<PlayerController>();
        _combat = _player.GetComponent<PlayerCombat>();
        _characterAnimation = _player.GetComponentInChildren<CharacterAnimation>();
    }
}