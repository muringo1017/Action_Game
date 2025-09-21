using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // 기본 파라미터
    private const string MOVEMENT_PARAM = "Movement";
    private const string ATTACK_TRIGGER = "Attack";
    private const string WEAPON_TYPE_PARAM = "WeaponType";

    // 이동 애니메이션
    public void SetMoving(bool moving) => SetBool("IsMoving", moving);
    public void SetMovementSpeed(float speed) => SetFloat(MOVEMENT_PARAM, speed);
    public void TriggerJump() => SetTrigger("Jump");

    // 공격 애니메이션
    public void TriggerAttack() => SetTrigger(ATTACK_TRIGGER);
    public void Punch1() => SetTrigger("Punch1");
    public void Punch2() => SetTrigger("Punch2");
    public void Punch3() => SetTrigger("Punch3");
    public void Kick1() => SetTrigger("Kick1");
    public void Kick2() => SetTrigger("Kick2");

    // 무기 관련
    public void SetWeaponType(int weaponType) => SetInt(WEAPON_TYPE_PARAM, weaponType);
    public void DrawWeapon() => SetTrigger("DrawWeapon");
    public void HolsterWeapon() => SetTrigger("HolsterWeapon");
    public void Reload() => SetTrigger("Reload");

    // 무기별 공격 애니메이션
    public void ShortSwordLightAttack() => SetTrigger("ShortSwordLight");
    public void ShortSwordHeavyAttack() => SetTrigger("ShortSwordHeavy");
    public void LongSwordLightAttack() => SetTrigger("LongSwordLight");
    public void LongSwordHeavyAttack() => SetTrigger("LongSwordHeavy");
    public void PistolShot() => SetTrigger("PistolShot");
    public void RifleShot() => SetTrigger("RifleShot");
    public void ShotgunShot() => SetTrigger("ShotgunShot");

    // 애니메이션 상태 체크
    public bool IsPlaying(string stateName)
    {
        if (_animator == null) return false;
        
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName);
    }

    public float GetCurrentAnimationLength()
    {
        if (_animator == null) return 0f;
        
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }

    public float GetCurrentAnimationTime()
    {
        if (_animator == null) return 0f;
        
        var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.normalizedTime;
    }

    // 안전한 Animator 메서드 래퍼
    private void SetTrigger(string triggerName)
    {
        if (_animator != null)
        {
            _animator.SetTrigger(triggerName);
        }
    }

    private void SetBool(string paramName, bool value)
    {
        if (_animator != null)
        {
            _animator.SetBool(paramName, value);
        }
    }

    private void SetFloat(string paramName, float value)
    {
        if (_animator != null)
        {
            _animator.SetFloat(paramName, value);
        }
    }

    private void SetInt(string paramName, int value)
    {
        if (_animator != null)
        {
            _animator.SetInteger(paramName, value);
        }
    }

    // 트리거 리셋 (중복 트리거 방지)
    public void ResetTrigger(string triggerName)
    {
        if (_animator != null)
        {
            _animator.ResetTrigger(triggerName);
        }
    }

    // 모든 트리거 리셋
    public void ResetAllTriggers()
    {
        if (_animator != null)
        {
            _animator.ResetTrigger("Jump");
            _animator.ResetTrigger("Attack");
            _animator.ResetTrigger("DrawWeapon");
            _animator.ResetTrigger("HolsterWeapon");
            _animator.ResetTrigger("Reload");
            _animator.ResetTrigger("Punch1");
            _animator.ResetTrigger("Punch2");
            _animator.ResetTrigger("Punch3");
            _animator.ResetTrigger("Kick1");
            _animator.ResetTrigger("Kick2");
        }
    }
}