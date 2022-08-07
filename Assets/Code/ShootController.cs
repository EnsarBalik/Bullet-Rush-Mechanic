using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] private PlayerController playercontroller;

    public float Delay => delay;
    [SerializeField] float delay;

    public void shoot(Vector3 direction,Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }
}
