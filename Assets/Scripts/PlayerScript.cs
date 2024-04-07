using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Movement")]
    public float playerSpeed = 3f;
    private Animator animator;

    [Header("Dash Settings")]
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float dashDuration = 1f;
    [SerializeField] float dashCooldown = 1f;
    bool isDashing;
    bool canDash;

    [Header("Shooting")]
    public Transform gun;
    public GameObject arrow;
    public int ammoCount = 20;
    private float timeSincefired;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] AudioClip outOfAmmoSound;

    [Header("Other")]
    public Rigidbody2D rb;
    public Camera cam;
    private UIManager uiManager;
    [SerializeField] AudioClip stabSound;



    //Vector2 movement;
    Vector2 moveDirection;
    Vector2 mousePos;

    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        animator = GetComponent<Animator>();
        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) 
        {
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        

        if (Input.GetKeyDown("space"))
        {
            Attack();
            
        }

        if (Input.GetMouseButton(1))
        {
            Stir();
            
        }

        else
        {
            StopStirring();
        }



        if (Input.GetButtonDown("Fire1"))
        {
            Load();
        }

        if (Input.GetButtonUp("Fire1") && Time.time > timeSincefired)
        {
            if (ammoCount == 0) 
            {
                AudioSource.PlayClipAtPoint(outOfAmmoSound, transform.position);
                return;
            }
            Shoot();
            timeSincefired = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -9.0f, 9.1f),
            Mathf.Clamp(transform.position.y, -5.1f, 4.9f),
            transform.position.z);

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed);
        //rb.MovePosition(rb.position + movement.normalized * currentSpeed * Time.fixedDeltaTime);
        

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        
    }

    private IEnumerator Dash() 
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

    void Attack()
    {
        animator.SetBool("bowEquipped", false);
        animator.SetTrigger("attack");
        AudioSource.PlayClipAtPoint(stabSound, transform.position);

    }

    

    void Stir()
    {
        animator.SetBool("bowEquipped", false);
        animator.SetBool("isStiring", true);
    }

    void StopStirring()
    {
        animator.SetBool("isStiring", false);
    }

    

    public void Load()
    {
        animator.SetBool("hasShot", false);
        animator.SetBool("bowEquipped", true);

    }

    public void Shoot() 
    {
        AmmoCount(-1);
        animator.SetBool("bowEquipped", false);
        animator.SetBool("hasShot", true);
        Instantiate(arrow, gun.transform.position, gun.transform.rotation);
    }

    public void AmmoCount(int arrows) 
    {
        ammoCount += arrows;
        uiManager.UpdateAmmoCount(ammoCount);
    }
}
