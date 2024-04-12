using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    private Transform target;
    private Transform playerTarget;
    private EnemyHealth enemyHealth; 
    private float speed;
    public float enemySpeed = 1f;
    public float attackRange = 2f;
    private Animator animator;
    private bool isAttacking;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Puuro").transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
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

        if (enemyHealth.currentHealth < 15)
        {
            target = playerTarget; // Change target to the player
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
        target = playerTarget;
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

