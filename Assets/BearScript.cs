using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    private Transform target;
    public float enemySpeed = 1f;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    private float lastAttackTime;
    private Animator animator;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Puuro").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the enemy is within attack range
        if (distanceToTarget <= attackRange)
        {
            // Check if enough time has passed since the last attack
            if (Time.time - lastAttackTime >= attackCooldown && !isAttacking)
            {
                Attack();
                lastAttackTime = Time.time;
            }
            // Stop movement while attacking
            return;
        }

        if (!isAttacking)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }

        transform.Rotate(90f, 0f, 0f, Space.Self);
        transform.Rotate(0f, 90f, 0f, Space.Self);


    }

    void Attack()
    {
        // Insert attack behavior here
        isAttacking = true;

        animator.SetBool("isAttacking", true);
        animator.SetTrigger("attack");


       

        StartCoroutine(ResetIsAttacking());

    }

    IEnumerator ResetIsAttacking()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isAttacking = false;
        animator.SetBool("isAttacking", false);

    }
}
