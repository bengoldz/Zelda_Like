using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    private static readonly int Smash = Animator.StringToHash("smash");

    public void SmashPot()
    {
        _animator.SetBool(Smash, true);
        StartCoroutine(BreakCoroutine());
    }

   private IEnumerator BreakCoroutine()
   {
       yield return new WaitForSeconds(.3f);
       this.gameObject.SetActive(false);
   }
}
