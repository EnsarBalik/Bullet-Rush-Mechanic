using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed;

    protected void Move(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
