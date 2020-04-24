using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);

        if (otherObject.gameObject.name == "Bullet")
        {
            Destroy(otherObject);
        }
        else if (otherObject.gameObject.name == "Enemy Bullet")
        {
            Destroy(otherObject);
        }
    }
}
