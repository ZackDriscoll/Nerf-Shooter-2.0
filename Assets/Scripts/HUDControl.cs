using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    //UI Text to manipulate
    public Text collectableText;
    public Text livesText;

    //Variables used from Game Manager
    public int Score;
    public int Lives;

    void Awake()
    {
        //Don't destroy UI when loading next scene
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        //everytime I call update, update the scores from the game manager
        Score = GameManager.instance.playerScore;
        Lives = GameManager.instance.lives;

        //Change text based on player score and lives values
        collectableText.text = "X " + Score.ToString();
        livesText.text = "X " + Lives.ToString();
    }
}
