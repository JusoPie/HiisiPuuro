using UnityEngine;
using UnityEngine.UI;

public class Puurokattila : MonoBehaviour
{
    public float burningThreshold = 3f;
    public float simmerCooldown = 1f;
    public float burnDuration = 15f;
    private float simmerTime = 0f;
    private float burnTime = 0f;
    private bool isBurning = false;
    public GameObject gameOver;

    public Slider burningSlider; // Reference to the UI slider

    void Start()
    {
        // Set the max value of the slider to the burn duration
        if (burningSlider != null)
        {
            burningSlider.maxValue = burnDuration;

            StartBurning();
        }
    }

    void Update()
    {
        if (isBurning)
        {
            burnTime += Time.deltaTime;
            if (burnTime >= burnDuration)
            {
                // Puurokattila has burned completely
                Debug.Log("Puurokattila has burned!");
                ResetPuurokattila();
            }

            // Update the UI slider value
            UpdateBurningSlider();
        }


    }

    public void Simmer()
    {
        simmerTime = Time.time;
        if (isBurning)
        {
            burnTime = 0f;
            
            Debug.Log("Puurokattila is simmered and cooling down.");
            UpdateBurningSlider();
        }
    }

    public void StartBurning()
    {
        isBurning = true;
        burnTime = 0f;
        Debug.Log("Puurokattila is burning!");
    }

    void ResetPuurokattila()
    {
        isBurning = false;
        simmerTime = 0f;
        burnTime = 0f;
        Debug.Log("Puurokattila is reset.");
        UpdateBurningSlider();
        

        if (burnTime <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {

        gameOver.SetActive(true);
        
    }

    void UpdateBurningSlider()
    {
        if (burningSlider != null)
        {
            burningSlider.value = burnTime;
        }
    }
}
