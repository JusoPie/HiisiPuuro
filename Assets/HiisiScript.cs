using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiisiScript : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 1f;
    public float attackRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, target.position);

        if (dist > attackRange)
        {
            enemySpeed = 1f;
        }

        else 
        {
            enemySpeed = 0;
        }


        transform.LookAt(target);
        transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);

        transform.Rotate(90f, 0f, 0f, Space.Self);
        transform.Rotate(0f, 90f, 0f, Space.Self);
    }
}
