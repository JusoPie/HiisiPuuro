using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 3f;
    public float sprintSpeed = 6f;
    private float currentSpeed = 3f;
    private Animator animator;


    public Rigidbody2D rb;
    public Camera cam;

    public Puurokattila puurokattila;

    Vector2 movement;
    Vector2 mousePos;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -9.0f, 9.1f),
            Mathf.Clamp(transform.position.y, -5.1f, 4.9f),
            transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Stir();
            SimmerPuurokattila();
        }

        if (Input.GetMouseButtonUp(1))
        {
            StopStirring();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = playerSpeed;
        }

        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }

    void Stir()
    {
        animator.SetBool("isStiring", true);
    }

    void StopStirring()
    {
        animator.SetBool("isStiring", false);
    }

    void SimmerPuurokattila()
    {
        if (puurokattila != null)
        {
            puurokattila.Simmer();
        }
        else
        {
            Debug.LogWarning("Puurokattila reference not set in the PlayerScript.");
        }
    }
}
