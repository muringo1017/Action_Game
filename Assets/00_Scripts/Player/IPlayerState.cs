using UnityEngine;

public interface IPlayerState
{
    void OnEnter(PlayerStateMachine stateMachine);
    void OnUpdate();
    void OnExit();
    bool CanTransitionTo(PlayerState newState);
}
