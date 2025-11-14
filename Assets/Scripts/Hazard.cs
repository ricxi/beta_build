using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private int healthPoints = 7;
    [SerializeField] private Animator _animator;
    private int damageThreshold = 5;
    private bool isDestroyed = false;


    public void TakeDamage(int damage)
    {
        if (!isDestroyed)
        {
            healthPoints -= damage;
            if (healthPoints <= 0)
            {
                isDestroyed = true;
                _animator.SetTrigger("isDestroyed");
                Destroy(gameObject, 0.36f);
            }

            if (healthPoints <= damageThreshold)
            {
                _animator.SetTrigger("isDamaged");
            }
        }
    }
}
