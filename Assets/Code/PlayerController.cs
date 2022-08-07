using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MyCharacterController
{
    [SerializeField] ScreenTouchController input;
    [SerializeField] ShootController shootcontroller;
    [SerializeField] Animator PlayerAnimController;

    private readonly List<Transform> enemies = new List<Transform>();
    private bool _isShooting;
    private int totalEnemy;

    private void Start()
    {
        totalEnemy = FindObjectsOfType<EnemyController>().Length;
        PlayerAnimController.SetFloat("Blend", 0);
    }

    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }

    private void Update()
    {
        if (enemies.Count > 0)
            transform.LookAt(enemies[0]);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Win();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            if(!enemies.Contains(other.transform))
                enemies.Add(other.transform);

            AutoShoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            enemies.Remove(other.transform);
        }
    }

    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (enemies.Count > 0)
            {
                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                shootcontroller.shoot(direction, transform.position);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootcontroller.Delay);
            }
            _isShooting = false;
        }
        if (!_isShooting)
        {
            _isShooting = true;
            StartCoroutine(Do());
        }
    }

    private void Dead()
    {
        Debug.Log("YOU DEAD");
        Time.timeScale = 0f;
    }

    private void Win()
    {
        Debug.Log("Win");
        Time.timeScale = 0f;
        var current = FindObjectsOfType<EnemyController>().Length;
        var result = current / (float)totalEnemy;
        var succes = Mathf.Lerp(100, 0, result);
        Debug.Log($"Complaeted => %{succes}");
    }
}