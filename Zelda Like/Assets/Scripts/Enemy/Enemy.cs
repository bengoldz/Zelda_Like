using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int _health;

    [SerializeField] protected string _enemyName;

    [SerializeField] protected int _baseAttack;
    
    [SerializeField] protected float _moveSpeed;

}
