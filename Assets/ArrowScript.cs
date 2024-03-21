using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float power = 1500f;
    private Rigidbody2D rb;
    Vector2 fwd;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        fwd = transform.TransformDirection(Vector2.up); // Assuming you want to move along the x-axis in 2D
        rb.AddForce(fwd * power * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
           
     Destroy(gameObject);
        
    }
}
