using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    
    private void Update()
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");

        if (_change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    private void MoveCharacter()
    {
        _myRigidbody.MovePosition(transform.position + _change.normalized * _speed * Time.fixedDeltaTime);
    }
}
