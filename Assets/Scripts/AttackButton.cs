using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _enemyAnimator;
    [SerializeField] private Animator _heroAnimator;

    public void CauseDamage()
    {
        _health.TakeGamage(_enemy.Damage);
        _enemyAnimator.SetTrigger(AnimatorData.Params.AttackParamHash);
        _heroAnimator.SetTrigger(AnimatorData.Params.TakeDamageParamHash);
    }
}
