using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector2 _maxPosition;
    [SerializeField] private Vector2 _minPosition;

    public Vector2 MaxPosition
    {
        get => _maxPosition;
        set => _maxPosition = value;
    } 
    public Vector2 MinPosition
    {
        get => _minPosition;
        set => _minPosition = value;
    }

    private void FixedUpdate()
    {
        if (transform.position != _target.position)
        {
            var position = _target.position;
            Vector3 targetPosition = new Vector3(position.x, position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, _minPosition.x, _maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, _minPosition.y, _maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothing);
        }
    }

    public void SetMinPosition(Vector2 value)
    {
        _minPosition = value;
    }

    public void SetMaxValue(Vector2 value)
    {
        _maxPosition = value;
    }
    
}
