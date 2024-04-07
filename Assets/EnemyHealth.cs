using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject droppedLoot;
    public float dropChance = 0.5f;
  
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        print("damage");
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (Random.value <= dropChance) 
            {
                DropLoot();
            }
            Destroy(gameObject);
            
        }

    }

    void DropLoot() 
    {
        Instantiate(droppedLoot, transform.position, Quaternion.identity);
    }
}
