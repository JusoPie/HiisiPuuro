using UnityEngine;
using UnityEngine.UI;

public class Puurokattila : MonoBehaviour
{
    public float burningThreshold = 3f;
    public float simmerCooldown = 1f;
    public float burnDuration = 5f;
    public float simmerRate = 1f;
    private float simmerTime = 0f;
    private float burnTime = 0f;
    private bool isBurning = false;
    private bool isSimmering = false;

    public Slider burningSlider; // Reference to the UI slider

    void Start()
    {
        // Set the max value of the slider to the burn duration
        if (burningSlider != null)
        {
            burningSlider.maxValue = burnDuration;
        }

        StartBurning();
    }

    void Update()
    {
        if (isSimmering)
        {
            if (burnTime > 0f)
            {
                burnTime -= simmerRate * Time.deltaTime;
                if (burnTime < 0f)
                {
                    burnTime = 0f;
                }
                UpdateBurningSlider();
            }
        }

        else if (isBurning)
        {
            burnTime += Time.deltaTime;
            if (burnTime >= burnDuration)
            {
                Debug.Log("Puurokattila has burned!");
                ResetPuurokattila();
            }
            UpdateBurningSlider();
        }
    }

    public void Simmer()
    {
        simmerTime = Time.time;
        isSimmering = true;
        if (isBurning)
        {
            burnTime = 0f;

            Debug.Log("Puurokattila is simmered and cooling down.");
            UpdateBurningSlider();
        }
    }

    public void StopSimmering()
    {
        isSimmering = false;
        if (isBurning)
        {
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
    }

    void UpdateBurningSlider()
    {
        if (burningSlider != null)
        {
            burningSlider.value = burnTime;
        }
    }
}
