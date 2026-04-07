using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickUp : MonoBehaviour
{
    public int plusAmountMin = 5;
    public int plusAmountMax = 11; //11 = Max is 10

    // Start is called before the first frame update
    void Start()
    {
        //playerscript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        int amount = Random.Range(plusAmountMin, plusAmountMax);

        if (other.gameObject.TryGetComponent<PlayerScript>(out PlayerScript playerScriptComponent))
        {

            playerScriptComponent.AmmoCount(amount);

            Destroy(gameObject);
        }

    }
}
