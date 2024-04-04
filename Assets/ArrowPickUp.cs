using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPickUp : MonoBehaviour
{
    public int plusAmount = 10;
    //private PlayerScript playerscript;
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


        if (other.gameObject.TryGetComponent<PlayerScript>(out PlayerScript playerScriptComponent))
        {

            playerScriptComponent.AmmoCount(plusAmount);

            Destroy(gameObject);
        }

    }
}
