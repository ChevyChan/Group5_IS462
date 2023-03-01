using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public RuntimeAnimatorController animatorController;

    private void OnCollisionEnter(Collision collision)
    {
        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorController;
    }
}
