using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HiisiScript : MonoBehaviour
{
    private Transform target;
    public float enemySpeed = 1f;
    public float attackRange = 2f;
    private Animator animator;
    private bool isAttacking;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist > attackRange)
        {
            enemySpeed = 1f;
            isAttacking = false;
        }

        else 
        {
            enemySpeed = 0;
            isAttacking = true;
        }


        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

        transform.Rotate(90f, 0f, 0f, Space.Self);
        transform.Rotate(0f, 90f, 0f, Space.Self);

        if (isAttacking)
        {
            Attack();
        }

        else 
        {
            StopAttacking();
        }
    }

    



    void Attack()
    {
        // Insert attack behavior here
        

        animator.SetBool("isAttacking", true);
        animator.SetTrigger("attack");
    }

    void StopAttacking() 
    {
        animator.SetBool("isAttacking", false);
    }
}
