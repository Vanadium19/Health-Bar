using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    public static class Params
    {
        public static readonly int HealParamHash = Animator.StringToHash("Heal");
        public static readonly int AttackParamHash = Animator.StringToHash("Attack");
        public static readonly int TakeDamageParamHash = Animator.StringToHash("TakeDamage");
    }
}
