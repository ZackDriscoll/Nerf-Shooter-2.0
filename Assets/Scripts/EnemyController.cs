using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Objects to manipulate
    public GameObject enemyPrefab;
    public GameObject enemyBulletPrefab;
    public Transform firePoint;

    //Timer values
    public float waitTime = 1.0f;
    public float timer = 0.0f;

    void Update()
    {
        //Timer to shoot bullets periodically
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Shoot();
            timer = timer - waitTime;
        }
    }

    void Shoot()
    {
        //Shoot a bullet from enemy fire point
        Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter2D(Collision2D otherObject)
    {
        //Destroy player if they collide
        if (otherObject.gameObject.name == "Player" || otherObject.gameObject.name == "Player(Clone)")
        {
            Destroy(otherObject.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy enemy on collision with player's bullet
        if (collision.tag == "Player Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
