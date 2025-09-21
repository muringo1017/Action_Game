using System;
using UnityEngine;
using Random = UnityEngine.Random;

/*
public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation _enemyAnimation;

    private Rigidbody _rigidbody;
    private float _moveSpeed = 1.0f;
    
    private Transform _playerTarget;

    public float attackDistance = 1.0f;
    public float chasePlayerAfterAttack = 1.0f;

    private float _currentAttackTime;
    private float _defaultAttackTime = 2.0f;

    private bool _followPlyaer, _attackPlayer;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _enemyAnimation = GetComponentInChildren<CharacterAnimation>();

        _playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        _followPlyaer = true;
        _currentAttackTime = _defaultAttackTime;
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    void FollowTarget()
    {
        if (_followPlyaer == false)
            return;
        
        if (Vector3.Distance(transform.position, _playerTarget.position) > attackDistance)
        {
            transform.LookAt(_playerTarget);
            _rigidbody.linearVelocity = transform.forward * _moveSpeed;

            if (_rigidbody.linearVelocity.sqrMagnitude != 0)
            {
                _enemyAnimation.Walk(true);
            }
        }
        
        else if (Vector3.Distance(transform.position, _playerTarget.position) <= attackDistance)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            _enemyAnimation.Walk(false);

            _followPlyaer = false;
            _attackPlayer = true;
        }

    
    } // follow target
    void Attack()
    {
        if (_attackPlayer == false)
            return;

        _currentAttackTime += Time.deltaTime;

        if (_currentAttackTime > _defaultAttackTime)
        {
            _enemyAnimation.EnemyAttack(Random.Range(0,3));


            _currentAttackTime = 0f;
        }

        if (Vector3.Distance(transform.position, _playerTarget.position) > 
            attackDistance + chasePlayerAfterAttack)
        {
            _attackPlayer = false;
            _followPlyaer = true;

        }

    }
}

*/