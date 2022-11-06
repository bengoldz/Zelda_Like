using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerState _currentState;
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody2D _myRigidbody;
    [SerializeField] private Animator _animator;
    private Vector3 _change;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int Moving = Animator.StringToHash("moving");
    private static readonly int Attacking = Animator.StringToHash("attacking");

    private void Start()
    {
        _currentState = PlayerState.Walk;
        _animator.SetFloat(MoveX, 0);
        _animator.SetFloat(MoveY, -1);
    }

    private void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("attack") && _currentState != PlayerState.Attack)
        {
            StartCoroutine(AttackCoroutine());
        }

        else if (_currentState == PlayerState.Walk)
        {
            UpdateAnimationAndMove();
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _animator.SetBool(Attacking, true);
        _currentState = PlayerState.Attack;
        yield return null;
        _animator.SetBool(Attacking, false);
        yield return new WaitForSeconds(.33f);
        _currentState = PlayerState.Walk;
    }

    private void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            MoveCharacter();
            _change.x = Mathf.Round(_change.x);
            _change.y = Mathf.Round(_change.y);
            _animator.SetFloat(MoveX, _change.x);
            _animator.SetFloat(MoveY, _change.y);
            _animator.SetBool(Moving, true);
        }
        else
        {
            _animator.SetBool(Moving, false);
        }
    }

    private void MoveCharacter()
    {
        _myRigidbody.MovePosition(transform.position + _change.normalized * _speed * Time.fixedDeltaTime);
    }
}
