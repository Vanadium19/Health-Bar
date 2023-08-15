using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Animator _animator;

    public void Heal()
    {
        _health.Heal();
        _animator.SetTrigger(AnimatorData.Params.HealParamHash);
    }    
}
