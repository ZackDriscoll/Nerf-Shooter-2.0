﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Components to manipulate
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    //Variables to control the player
    public float movementSpeed = 5.0f;
    public float jumpForce = 500.0f;
    public Transform groundPoint;
    public bool isGrounded = false;

    //Reference to bullet and fire point game objects
    public GameObject bulletPrefab;
    public Transform firePoint;

    //Audio clip to play when bullet is fired
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Controlls Horizontal movement
        float xMovement = Input.GetAxis("Horizontal") * movementSpeed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        
        //when moving right
        if (xMovement > 0)
        {
            //face right
            tf.rotation = Quaternion.Euler(0, 0, 0);
            animator.Play("Player_Run");
        }
        //when moving left
        else if (xMovement < 0)
        {
            //face left
            tf.rotation = Quaternion.Euler(0, 180, 0);
            animator.Play("Player_Run");
        }
        else
        {
            //Not Moving
            animator.Play("Player_Idle");
        }

        //Detect if the player is on the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //Jump with up arrow key
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Debug.Log("Jump");
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        //Jump with W key
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Debug.Log("Jump");
            rb2d.AddForce(Vector2.up * jumpForce);
        }

        //Press the spacebar to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    //Spawn a bullet from the fire point
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        //Play the Pew Pew sound effect
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
    }

    //Destroy player if they are hit by an enemy bullet
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy Bullet")
        {
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        //If the player dies, they lose a life.
        GameManager.instance.lives -= 1;
        if (GameManager.instance.lives > 0)
        {
            GameManager.instance.Respawn();
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
