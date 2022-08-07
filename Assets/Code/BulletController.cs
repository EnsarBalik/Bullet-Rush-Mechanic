using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float _speed;

    private Vector3 _movement;

    public void Fire(Vector3 direction)
    {
        _movement = direction * _speed;
    }

    private void FixedUpdate()
    {
        transform.position += _movement * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
