using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour
{
    private Transform target;
    private Transform playerTarget;
    private Transform wolfEscapeTarget;
    private EnemyHealth enemyHealth;
    private float speed;
    public float enemySpeed = 1f;
    public float attackRange = 2f;
    public float aggroHealth = 7f;
    private Animator animator;
    private bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Puuro").transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
        wolfEscapeTarget = GameObject.FindGameObjectWithTag("WolfEscape").transform;
        enemyHealth = GetComponent<EnemyHealth>();
        animator = GetComponent<Animator>();
        speed = enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist < attackRange)
        {
            speed = 0f;
            isAttacking = true;

        }

        else
        {
            speed = enemySpeed;
            isAttacking = false;
            FindPray();
        }




        if (isAttacking)
        {
            Attack();
        }

        else
        {
            StopAttacking();
        }

        if (enemyHealth.currentHealth < aggroHealth)
        {
            AggroPlayer();
        }

    }

    void FaceTargetOnMelee() //Called in animation
    {
        transform.LookAt(target);

        transform.Rotate(90f, 0f, 0f, Space.Self);
        transform.Rotate(0f, 90f, 0f, Space.Self);
    }

    void FindPray()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.Rotate(90f, 0f, 0f, Space.Self);
        transform.Rotate(0f, 90f, 0f, Space.Self);
    }

    void AggroPlayer()
    {
        if (GameObject.Find("AlphaWolf") != null)
        {
            target = playerTarget;
        }

        else 
        {
            target = wolfEscapeTarget;
            Destroy(gameObject, 5f);
            print("AlphaWolf not present");
        }
        
    }



    void Attack()
    {


        animator.SetBool("isAttacking", true);
        animator.SetTrigger("attack");
    }

    void StopAttacking()
    {
        animator.SetBool("isAttacking", false);
    }
}
