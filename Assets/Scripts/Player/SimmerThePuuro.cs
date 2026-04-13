using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimmerThePuuro : MonoBehaviour
{
    private bool canSimmer;

    private void OnEnable()
    {
        canSimmer = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canSimmer)
        {
            if (other.gameObject.TryGetComponent<Puurokattila>(out Puurokattila puuroKattilaComponent))
            {

                puuroKattilaComponent.Simmer();
                canSimmer = false;
            }
        }
    }
}
