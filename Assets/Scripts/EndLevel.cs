using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    //Scene number to change
    public int currentScene = 0;

    //Loads the next scene
    public void OnTriggerEnter2D(Collider2D other)
    {
        //If the game object that entered the trigger is our player, then load the next level.
        if (other.gameObject.name == "Player")
        {
            LoadNextScene();
        }
    }

    //Load the next scene
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
