using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControl : MonoBehaviour
{
    public Text collectableText;
    public Text livesText;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        collectableText = GetComponent<Text>();
        livesText = GetComponent<Text>();
    }

    void Update()
    {
        collectableText.text = "X " + GameManager.instance.playerScore;
        collectableText.text = "X " + GameManager.instance.lives;
    }
}
