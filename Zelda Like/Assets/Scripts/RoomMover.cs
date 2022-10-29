using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomMover : MonoBehaviour
{
    [SerializeField] private Vector2 _cameraChange;
    [SerializeField] private Vector3 _playerChange;
    [SerializeField] private CameraMovement _camera;
    private bool _triggeredOnce;
    [SerializeField] private bool _needText;
    [SerializeField]private string _placeName;
    [SerializeField] private GameObject _text;
    [SerializeField] private TextMeshProUGUI _placeText;
    
    // private void OnTriggerEnter2D(Collider2D other)
            // {
            //     if (other.CompareTag("Player") && _triggeredOnce == false)
            //     {
            //         _camera.MaxPosition += _cameraChange;
            //         _camera.MinPosition += _cameraChange;
            //         other.transform.position += _playerChange;
            //         _triggeredOnce = true;
            //         if (_needText)
            //         {
            //             StartCoroutine(PlaceNameCoroutine());
            //         }
            //     }
            //     else if (other.CompareTag("Player") && _triggeredOnce)
            //     {
            //         _camera.MaxPosition -= _cameraChange;
            //         _camera.MinPosition -= _cameraChange;
            //         other.transform.position -= _playerChange;
            //         _triggeredOnce = false;
            //     }
            // }

            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.CompareTag("Player"))
                {
                    _camera.MaxPosition += _cameraChange;
                    _camera.MinPosition += _cameraChange;
                    other.transform.position += _playerChange;
                    // _triggeredOnce = true;
                    if (_needText)
                    {
                        StartCoroutine(PlaceNameCoroutine());
                    }
                }
            }

            private IEnumerator PlaceNameCoroutine()
    {
        _text.SetActive(true);
        _placeText.text = _placeName;
        yield return new WaitForSeconds(4f);
        _text.SetActive(false);
    }
}
