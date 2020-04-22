using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform firePoint;

    public float waitTime = 1.0f;
    public float timer = 0.0f;

    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Shoot();
            timer = timer - waitTime;
        }
    }

    void Shoot()
    {
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.player)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player Bullet")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }
}
