using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Log : Enemy
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRadius;
    [SerializeField] private float _attackRadius;
    [SerializeField] private Transform _homePosition;

    private void FixedUpdate()
    {
        CheckDistance();
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(_target.position, transform.position);
        if (distance <= _chaseRadius && distance > _attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
        }
    }
}
