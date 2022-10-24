using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody2D _myRigidbody;
    [SerializeField] private Animator _animator;
    private Vector3 _change;
    private static readonly int MoveX = Animator.StringToHash("moveX");
    private static readonly int MoveY = Animator.StringToHash("moveY");
    private static readonly int Moving = Animator.StringToHash("moving");

    private void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
    }

    private void UpdateAnimationAndMove()
    {
        if (_change != Vector3.zero)
        {
            MoveCharacter();
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
