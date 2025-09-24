using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // 애니메이터 컴포넌트에 대한 참조
    private Animator _animator;

    // 애니메이터 파라미터를 정수(ID)로 미리 변환하여 성능을 높이고 오타를 방지합니다.
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    
    // 콤보 공격용 트리거 파라미터 ID들
    private static readonly int LightAttack1 = Animator.StringToHash("LightAttack_1");
    private static readonly int LightAttack2 = Animator.StringToHash("LightAttack_2");
    private static readonly int LightAttack3 = Animator.StringToHash("LightAttack_3");
    private static readonly int HeavyAttack1 = Animator.StringToHash("HeavyAttack_1");
    private static readonly int HeavyAttack2 = Animator.StringToHash("HeavyAttack_2");
    private static readonly int HeavyAttack3 = Animator.StringToHash("HeavyAttack_3");
    
    
    // 기존의 일반 Attack 트리거는 이제 사용하지 않으므로 제거하거나 용도 변경이 필요합니다.
    // private static readonly int Attack = Animator.StringToHash("Attack"); 


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null)
        {
            Debug.LogError("Animator component not found on the character!");
        }
    }

    public void SetMoving(bool isMoving)
    {
        if (_animator == null) return;
        
        _animator.SetBool(IsMoving, isMoving);
        // Debug.Log("SetMoving: " + isMoving); // 디버그 로그는 필요한 경우에만 남겨두세요.
    }

    // --- 콤보 공격 애니메이션 함수들 ---

    public void LightAttack_1()
    {
        if (_animator == null) return;
        _animator.SetTrigger(LightAttack1);
        Debug.Log("Playing LightAttack_1");
    }

    public void LightAttack_2()
    {
        if (_animator == null) return;
        _animator.SetTrigger(LightAttack2);
        Debug.Log("Playing LightAttack_2");
    }

    public void LightAttack_3()
    {
        if (_animator == null) return;
        _animator.SetTrigger(LightAttack3);
        Debug.Log("Playing LightAttack_3");
    }

    public void HeavyAttack_1()
    {
        if (_animator == null) return;
        _animator.SetTrigger(HeavyAttack1);
        Debug.Log("Playing HeavyAttack_1");
    }

    public void HeavyAttack_2()
    {
        if (_animator == null) return;
        _animator.SetTrigger(HeavyAttack2);
        Debug.Log("Playing HeavyAttack_2");
    }
    
    public void HeavyAttack_3()
    {
        if (_animator == null) return;
        _animator.SetTrigger(HeavyAttack3);
        Debug.Log("Playing HeavyAttack_3");
    }
    
    public void LongSword_Light_1()
    {
        // 애니메이터에 LongSword_Light_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Light_1"); 
    }
    public void LongSword_Light_2()
    {
        // 애니메이터에 LongSword_Light_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Light_2"); 
    }
    
    public void LongSword_Light_3()
    {
        // 애니메이터에 LongSword_Light_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Light_3"); 
    }
    public void LongSword_Heavy_1()
    {
        // 애니메이터에 LongSword_Heavy_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Heavy_1");
    }
    public void LongSword_Heavy_2()
    {
        // 애니메이터에 LongSword_Heavy_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Heavy_2");
    }
    
    public void LongSword_Heavy_3()
    {
        // 애니메이터에 LongSword_Heavy_1 트리거를 추가하고 발동
        _animator.SetTrigger("LongSword_Heavy_3");
    }
}