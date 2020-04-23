using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform tf;
    public float bulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Always move forward
        tf.position -= tf.right * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //Destroy player if they hit the enemy bullet
        if (otherObject.gameObject == GameManager.instance.playerPrefab)
        {
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }
}
