using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxAttack : MonoBehaviour
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
            if (other.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealthComponent))
            {

                enemyHealthComponent.TakeDamage(attackPower);
                canAttack = false;
            }
        }
    }
}
