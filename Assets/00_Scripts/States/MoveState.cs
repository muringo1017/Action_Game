using UnityEngine;

using UnityEngine;

public class MoveState : BasePlayerState
{
    private bool _facingRight = true;

    public override void OnEnter(PlayerStateMachine stateMachine)
    {
        base.OnEnter(stateMachine);
        Debug.Log("Entered Move State");
        
        // 애니메이션 설정
        _characterAnimation?.SetMoving(true);
    }

    public override void OnUpdate()
    {
        if (_player == null || _controller == null) return;

        HandleMovement();
        HandleStateTransitions();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        // 이동 처리
        Vector3 velocity = new Vector3(horizontal * _controller.moveSpeed, _rigidbody.linearVelocity.y, 0);
        _controller.ApplyMovement(velocity);

        // 방향 전환
        if (horizontal > 0 && !_facingRight) 
        {
            _facingRight = true;
            _controller.Flip(_facingRight);
        }
        if (horizontal < 0 && _facingRight)
        {
            _facingRight = false;
            _controller.Flip(_facingRight);
        }

        // 애니메이션 업데이트
        _characterAnimation?.SetMoving(horizontal != 0);
    }

    private void HandleStateTransitions()
    {
        // 이동 입력이 없으면 Idle로
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            _stateMachine.TransitionTo(PlayerState.Idle);
            return;
        }

        // 점프 입력 (Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _controller.Jump();
        }

        // 공격 입력 (Z or X)
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X))
        {
            _stateMachine.TransitionTo(PlayerState.Attack);
            return;
        }

        // 무기 교체 (V)
        if (Input.GetKeyDown(KeyCode.V))
        {
            // SwitchWeapon 상태로 전환 가능
            // stateMachine.TransitionTo(PlayerState.SwitchWeapon);
        }
        
    }
    public override void OnExit()
    {
        Debug.Log("Exited Move State");
        _characterAnimation?.SetMoving(false);
        
    }
    
}