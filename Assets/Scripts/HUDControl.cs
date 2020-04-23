using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    //UI Text to manipulate
    public Text collectableText;
    public Text livesText;

    void Awake()
    {
        //Don't destroy UI when loading next scene
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        //Get UI Text components
        collectableText = GetComponent<Text>();
        livesText = GetComponent<Text>();
    }

    void Update()
    {
        //Change text based on player score and lives values
        collectableText.text = "X " + GameManager.instance.playerScore;
        collectableText.text = "X " + GameManager.instance.lives;
    }
}
