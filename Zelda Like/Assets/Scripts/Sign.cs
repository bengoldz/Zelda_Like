using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;

public class Sign : MonoBehaviour
{

    [SerializeField] private GameObject _dialogBox;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private string _dialog;
    [SerializeField] private bool _playerInRange;

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !_playerInRange) return;
        if (_dialogBox.activeInHierarchy)
        {
            _dialogBox.SetActive(false);
        }
        else
        {
            _dialogBox.SetActive(true);
            _dialogText.text = _dialog;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !_playerInRange)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
            _dialogBox.SetActive(false);
        }
    }
}
