using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject gameOver;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    public void ResetHealth() 
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthBar.SetHealth(currentHealth);


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
