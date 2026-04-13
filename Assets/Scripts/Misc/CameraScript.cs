using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float damping;

    public Transform target;

    private Vector3 vel = Vector3.zero;

    

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, damping);

        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, -3.3f, 3.4f),
            Mathf.Clamp(target.position.y, -2.0f, 1.8f),
            transform.position.z);
    }
}
