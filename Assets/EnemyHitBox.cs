using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    [SerializeField] private int attackPower = 1;

    private bool canAttack;

    private void OnEnable()
    {
        canAttack = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canAttack)
        {
            if (other.gameObject.TryGetComponent<Health>(out Health healthComponent))
            {

                healthComponent.TakeDamage(attackPower);
                canAttack = false;
            }
        }
    }
}
