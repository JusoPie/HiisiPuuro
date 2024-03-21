using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Destroy(gameObject);
        gameOver.SetActive(true);
    }

}   
