using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 30;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.TryGetComponent<Health>(out Health healthComponent))
        {

            healthComponent.Heal(healAmount);

            Destroy(gameObject);
        }

    }
}
