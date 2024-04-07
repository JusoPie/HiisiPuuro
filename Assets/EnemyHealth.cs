using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject droppedLoot;
    public float dropChance = 0.5f;

    public float damageFlashDuration = 0.1f;
    public Color damageFlashColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        
    }

    public void TakeDamage(int amount)
    {
        print("damage");
        currentHealth -= amount;

        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        

        if (currentHealth <= 0)
        {
            if (Random.value <= dropChance) 
            {
                DropLoot();
            }
            Destroy(gameObject);
            
        }

    }



    IEnumerator FlashRed()
    {
        spriteRenderer.color = damageFlashColor;
        yield return new WaitForSeconds(damageFlashDuration);
        spriteRenderer.color = originalColor;
    }

    void DropLoot() 
    {
        Instantiate(droppedLoot, transform.position, Quaternion.identity);
    }
}
