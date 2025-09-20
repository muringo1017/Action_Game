using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Walk(bool move)
    {
        _animator.SetBool(AnimationTags.MOVEMENT, move);
        
    }

    public void Punch_1()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_1_TRIGGER);
    }
    
    public void Punch_2()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_2_TRIGGER);
    }
    
    public void Punch_3()
    {
        _animator.SetTrigger(AnimationTags.PUNCH_3_TRIGGER);
    }
    public void Kick_1()
    {
        _animator.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }

    public void Kick_2()
    {
        _animator.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }
    
    
}
