using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject gameOver;
    public HealthBar healthBar;
    public UITimer timerScript;

    public float damageFlashDuration = 0.1f;
    public Color damageFlashColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
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

        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRed());
        }


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator FlashRed()
    {
        spriteRenderer.color = damageFlashColor;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = originalColor;
    }

    private void Die()
    {
        if (timerScript != null) 
        {
            timerScript.StopTimer();
        }

        Destroy(gameObject);
        gameOver.SetActive(true);
    }

}   
