using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.TryGetComponent<Health>(out Health healthComponent))
        {

            healthComponent.Heal(healAmount);

            Destroy(gameObject);
        }

    }
}
