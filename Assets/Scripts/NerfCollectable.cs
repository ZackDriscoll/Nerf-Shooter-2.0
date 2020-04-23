using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfCollectable : MonoBehaviour
{
    //Audio clip to play when pickup is collected
    //public AudioClip audioClip;

    //Coin actions
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Reward the player with points
            GameManager.instance.playerScore += 1;

            //Play the Nerf Token sound effect
            //AudioSource.PlayClipAtPoint(audioClip, transform.position);

            //Destroy token when collected
            Destroy(this.gameObject);

            Debug.Log("I got a Nerf Token!");
        }
    }
}
